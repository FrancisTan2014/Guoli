﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Guoli.Admin.Utilities;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Helpers;
using log4net;
using log4net.Config;

[assembly: log4net.Config.XmlConfigurator(Watch = true, ConfigFile = "log4net.config")]
namespace Guoli.DataMigration
{
    /// <summary>
    /// 实现了数据迁移操作规范的抽象类
    /// 将从oracle数据库更新数据的流程进行了封装
    /// 未解决的问题：
    ///     若中间有某条数据插入或者更新失败，系统将出现逻辑错误
    /// </summary>
    /// <typeparam name="TOracle">将要从Oracle数据库中导入的数据表对应的实体类型</typeparam>
    /// <typeparam name="TSqlserver">Sqlserver中目标数据表对应的实体类型</typeparam>
    /// <author>FrancisTan</author>
    /// <since>2017-02-10</since>
    public abstract class OracleMigration<TOracle, TSqlserver> : IMigration
        where TOracle : class, new()
        where TSqlserver : class, new()
    {
        protected ILog Logger { get; set; }

        protected CacheManager CacheManager { get; set; }

        /// <summary>
        /// 将要做为数据源的Oracle数据库表名称
        /// </summary>
        protected abstract string OracleTableName { get; }

        /// <summary>
        /// 将要做为数据源的Oracle数据库表的主键名称
        /// </summary>
        protected abstract string OracleTablePrimaryKeyName { get; }

        /// <summary>
        /// 将要做为目标数据库表的表名称
        /// </summary>
        protected abstract string SqlserverTableName { get; }

        /// <summary>
        /// 将要做为目标数据库表的主键名称
        /// </summary>
        protected abstract string SqlserverTablePrimaryKeyName { get; }

        /// <summary>
        /// Oracle数据源的Bll层实例
        /// </summary>
        protected BaseBll<TOracle> OracleBaseBll { get; set; }

        /// <summary>
        /// Sqlserver目标数据表对应的Bll层实例
        /// </summary>
        protected BaseBll<TSqlserver> SqlserverBaseBll { get; set; }

        /// <summary>
        /// 指示数据迁移程序是否需要从数据源中同步所有更改
        /// 设置此标识的目的是针对那些数据量大，但时效性差的表
        /// 以减少不必要的数据更新
        /// </summary>
        protected virtual bool NeedToUpdateAll => true;

        /// <summary>
        /// 指示数据迁移程序是否需要缓存数据源与目标数据表之间的主键关系
        /// 设置此标识的目的是针对那些数据量大、时效性较差的表，减少缓存的数据量
        /// 以便每次都能将缓存全部加载到内存中，避免出现内存溢出
        /// </summary>
        protected virtual bool NeedToCachePrimaryRelation => true;

        /// <summary>
        /// 构造函数，执行基类当中的初始化
        /// </summary>
        protected OracleMigration()
        {
            //var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "\\log4net.config");
            //XmlConfigurator.ConfigureAndWatch(logCfg);
            Logger = LogManager.GetLogger(GetType());

            BuildInstance();
        }

        /// <summary>
        /// 实现导入新增数据，流程如下
        ///     1.从OracleTableMaxId表中获取上一次更新的最大Id
        ///     2.以最大Id为条件，去数据源中查询之后的新数据
        ///     3.将新数据逐条插入Sqlserver数据库
        ///     4.插入成功之后，更新DbUpdateLog表、PrimaryIdRelation表
        ///     5.循环结束之后，将本次更新的最大Id存入数据库中，流程结束
        /// </summary>
        public void ImportNewData()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();

                Logger.Info($"正在执行从表 {OracleTableName} 中导入最新数据");

                var maxId = CacheManager.MaxIdCache.SingleOrDefault(item => item.TableName == OracleTableName);
                Logger.Info($"从缓存中获取到的表 {OracleTableName} 的最大Id为 {maxId?.MaxId}");

                var newData = GetDataFromSourdeDb(maxId).ToList();

                Logger.Info($"从表 {OracleTableName} 获取到 {newData.Count} 条最新数据");

                Logger.Info($"正在执行将 {newData.Count} 条新数据写入目标数据库");
                ExecuteImport(newData);

                // 将数据源的最大主键存入缓存中，做为下次查询数据的条件
                var newMaxId = GetMaxId(newData)?.ToString();
                Logger.Info($"正在执行将本次导入数据的最大Id {newMaxId} 写入缓存");
                UpdateMaxId(newMaxId);

                watch.Stop();
                Logger.Info($"从表 {OracleTableName} 中导入新数据结束，用时 {watch.Elapsed}");
            }
            catch (Exception ex)
            {
                Logger.Error($"在执行从表 {OracleTableName} 中导入最新数据时发生异常", ex);
            }
        }

        /// <summary>
        /// 执行数据导入到具体表
        /// </summary>
        /// <param name="data">从Oracle数据库中获取到的新增数据集合</param>
        protected virtual void ExecuteImport(IEnumerable<TOracle> data)
        {
            IList<TOracle> oracleData = data.ToList();
            if (DataProcessEvent != null)
            {
                oracleData = DataProcessEvent(data);
            }

            foreach (var model in oracleData)
            {
                dynamic sqlModel = MapEntity(model);

                if (sqlModel != null)
                {
                    // 数据插入事务
                    Func<bool> importTransaction = () =>
                    {
                        var success = SqlserverBaseBll.Insert(sqlModel).Id > 0;
                        if (success)
                        {
                                // 将数据库更新同步到app
                                DataUpdateLog.SingleUpdate(SqlserverTableName, Convert.ToInt32(sqlModel.Id), DataUpdateType.Insert);

                                // 更新主键关系
                                return UpdatePrimaryRelation(model, sqlModel);
                        }

                        return false;
                    };

                    // 执行事务
                    SqlserverBaseBll.ExecuteTransation(importTransaction);
                }
                else
                {
                    // 数据模型映射失败
                    // 可能原因，与之相关的其他表数据不存在
                }
            }
        }

        /// <summary>
        /// 从数据源中获取新增的数据，默认以主键Id大于缓存的最大Id为查询条件
        /// 若子类需要以其它条件查询数据则可重写此方法
        /// </summary>
        /// <param name="maxId">包含上次查询的最大Id的<see cref="Guoli.Model.OracleTableMaxId"></see>实体对象/></param>
        /// <returns>查询到的新增数据集合</returns>
        protected virtual IEnumerable<TOracle> GetDataFromSourdeDb(OracleTableMaxId maxId)
        {
            var condition = string.Empty;
            if (maxId != null)
            {
                condition = $"to_number({OracleTablePrimaryKeyName})>'{maxId.MaxId}'";
            }

            return OracleBaseBll.QueryList(condition);
        }

        /// <summary>
        /// 实现更新数据源中被修改过的数据
        /// </summary>
        public void UpdateEditedData()
        {
            try
            {
                var watch = new Stopwatch();
                watch.Start();

                var counter = 0;

                #region 执行数据同步
                Logger.Info($"正在执行同步表 {OracleTableName} 中被更新过的数据");
                if (!NeedToUpdateAll)
                {
                    Logger.Info($"由于表 {OracleTableName} 配置了 {nameof(NeedToUpdateAll)} 的值为false，因此跳过同步数据操作");
                    return;
                }

                // 获取关系缓存中与待更新表有关的数据
                Logger.Info($"正在执行从缓存中获取与表 {OracleTableName} 所对应的主键关系");
                var relations = CacheManager.PrimaryIdCache.Where(item => item.OracleTableName == OracleTableName);

                Logger.Info("正在执行逐条对比源数据与目标数据的差异性");

                foreach (var relation in relations)
                {
                    // 逐条对比oracle与sqlserver中的数据有无变化
                    dynamic oracleModel = OracleBaseBll.QuerySingle((object)relation.OraclePrimaryId);
                    dynamic sqlserverModel = SqlserverBaseBll.QuerySingle((object)relation.SqlPrimaryId);

                    if (oracleModel == null)
                    {
                        // 数据源中该数据被删除，目前暂时忽略
                    }
                    else
                    {
                        if (HasEdited(oracleModel, sqlserverModel))
                        {
                            // 数据源中的数据被修改过
                            UpdateSqlserverModel(oracleModel, sqlserverModel);

                            Func<bool> updateTransaction = () =>
                            {
                                var success = SqlserverBaseBll.Update(sqlserverModel);
                                if (success)
                                {
                                    // 将数据更新同步到数据更新日志表中
                                    DataUpdateLog.SingleUpdate(SqlserverTableName, Convert.ToInt32(sqlserverModel.Id), DataUpdateType.Update);
                                    return true;
                                }

                                return false;
                            };

                            // 执行数据同步
                            var syncSuccess = SqlserverBaseBll.ExecuteTransation(updateTransaction);
                            if (syncSuccess)
                            {
                                counter++;
                            }

                        } // end if

                    } // end else

                } // end foreach
                #endregion

                watch.Stop();
                Logger.Info($"本次同步数据结束，共检查 {relations.Count()} 条数据，其中有 {counter} 条数据被更新，共耗时 {watch.Elapsed}");
            }
            catch (Exception ex)
            {
                Logger.Error($"在执行同步表 {OracleTableName} 的数据更新时发生异常", ex);
            }
        }

        /// <summary>
        /// 对比oracle数据源中的数据是否已被修改过，此方法由子类具体实现
        /// </summary>
        /// <param name="oracleModel">oracle数据源对应的实体对象</param>
        /// <param name="sqlserverModel">与数据源对应的sqserver数据实体对象</param>
        /// <returns>若数据源中的数据已被修改返回<c>true</c>，否则返回<c>false</c></returns>
        protected abstract bool HasEdited(TOracle oracleModel, TSqlserver sqlserverModel);

        /// <summary>
        /// 将sqlserver中的数据与数据源中的数据同步，由子类具体实现
        /// </summary>
        /// <param name="oracleEntity">数据源数据实体对象</param>
        /// <param name="sqlserverEntity">sqlserver数据实体对象</param>
        protected abstract void UpdateSqlserverModel(TOracle oracleEntity, TSqlserver sqlserverEntity);

        /// <summary>
        /// 创建导入过程中所需要的实例
        /// </summary>
        private void BuildInstance()
        {
            CacheManager = CacheManager.GetInstance();

            OracleBaseBll =
                ReflectorHelper.GetInstance("Guoli.Bll", $"Guoli.Bll.{OracleTableName}Bll") as BaseBll<TOracle>;

            SqlserverBaseBll =
                ReflectorHelper.GetInstance("Guoli.Bll", $"Guoli.Bll.{SqlserverTableName}Bll") as BaseBll<TSqlserver>;
        }

        /// <summary>
        /// 用于子类处理从数据源获取到的数据的委托
        /// </summary>
        /// <param name="data">从oracle数据源获取到的数据集合</param>
        /// <returns>由子类处理过后的新数据</returns>
        public delegate IList<TOracle> DataProcessHandler(IEnumerable<TOracle> data);

        /// <summary>
        /// 由子类绑定的数据处理事件
        /// </summary>
        public event DataProcessHandler DataProcessEvent;

        /// <summary>
        /// 由子类自己实现的将oracle数据实体映射成sqlserver数据实体的方法
        /// </summary>
        /// <param name="oracleEntity">oracle数据实体对象</param>
        /// <returns>返回对应的sqlserver数据实体对象</returns>
        protected abstract dynamic MapEntity(TOracle oracleEntity);

        /// <summary>
        /// 更新数据源对应的表之间的关系（将同时更新数据库及缓存）
        /// </summary>
        /// <param name="oracleModel">oracle数据实体对象</param>
        /// <param name="sqlserverModel">sqlserver数据实体对象</param>
        protected bool UpdatePrimaryRelation(TOracle oracleModel, TSqlserver sqlserverModel)
        {
            if (!NeedToCachePrimaryRelation)
            {
                return true;
            }

            // 更新oracle与sqlserver对应表的主键关系，用作缓存
            var relationBll = new PrimaryIdRelationBll();
            var relation = new PrimaryIdRelation
            {
                OracleTableName = OracleTableName,
                OraclePrimaryId = ReflectorHelper.GetPropertyValue(oracleModel, OracleTablePrimaryKeyName)?.ToString(),
                SqlTableName = SqlserverTableName,
                SqlPrimaryId = ReflectorHelper.GetPropertyValue(sqlserverModel, SqlserverTablePrimaryKeyName)?.ToString()
            };

            var success = relationBll.Insert(relation).Id > 0;
            if (success)
            {
                // 将新的主键关系加入缓存中
                CacheManager.PrimaryIdCache.Add(relation);
            }

            return success;
        }

        /// <summary>
        /// 由子类实现的从数据源获取到的集合中取出最大主键键的方法
        /// </summary>
        /// <param name="source">从数据源中获取到的数据集合</param>
        /// <returns>返回获取到的最大主键值或者null</returns>
        protected abstract object GetMaxId(IEnumerable<TOracle> source);

        /// <summary>
        /// 更新最大Id记录
        /// </summary>
        /// <param name="maxId">数据源中当前最大主键值</param>
        private void UpdateMaxId(string maxId)
        {
            var maxBll = new OracleTableMaxIdBll();
            var maxModel = new OracleTableMaxId
            {
                MaxId = maxId,
                TableName = OracleTableName
            };

            bool success;
            if (maxBll.Exists($"TableName='{OracleTableName}'"))
            {
                success = maxBll.Update(maxModel);
            }
            else
            {
                success = maxBll.Insert(maxModel).Id > 0;
            }

            if (success)
            {
                // 更新缓存
                CacheManager.MaxIdCache.Add(maxModel);
            }
        }

        /// <summary>
        /// 根据指定oracle表的主键查找对应的sqlserver表的主键
        /// </summary>
        /// <param name="oracleId">指定oracle表的主键</param>
        /// <returns>对应的sqlserver表的主键</returns>
        protected string SearchId(string oracleId)
        {
            var cache = CacheManager.PrimaryIdCache.Find(
                item => item.OracleTableName == OracleTableName && item.OraclePrimaryId == oracleId);

            return cache?.SqlPrimaryId;
        }

        /// <summary>
        /// 从主键对应关系的缓存中根据指定oracle表名及主键，查找与它对应的sqlserver表的关系信息
        /// </summary>
        /// <param name="oracleTableName">表示指定的oracle表名的字符串</param>
        /// <param name="id">表示指定的oracle表的主键的字符串</param>
        /// <returns>与指定表及主键对应的sqlserver表的关系信息或者Null</returns>
        protected PrimaryIdRelation FindPrimaryIdRelation(string oracleTableName, string id)
        {
            return CacheManager.PrimaryIdCache.Find(item => item.OracleTableName == oracleTableName && item.OraclePrimaryId == id);
        }
    }
}
