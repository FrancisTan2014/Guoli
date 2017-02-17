using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guoli.Admin.Utilities;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Helpers;

namespace Guoli.DataMigration.Classes
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
    public abstract class OracleMigration<TOracle, TSqlserver>: IMigration
        where TOracle: class,new()
        where TSqlserver: class,new()
    {
        /// <summary>
        /// Oracle数据库表的最大Id缓存
        /// </summary>
        public static List<OracleTableMaxId> MaxIdCache { get; set; }

        /// <summary>
        /// Oracle数据库表Sql Server数据库表的主键对应关系缓存
        /// </summary>
        public static List<PrimaryIdRelation> PrimaryIdCache { get; set; } 

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
        /// 构造函数，执行基类当中的初始化
        /// </summary>
        protected OracleMigration()
        {
            BuildInstance();
        }

        /// <summary>
        /// 在基类第一次被使用到的时候从数据库中加载缓存信息
        /// </summary>
        static OracleMigration()
        {
            var maxIdBll = new OracleTableMaxIdBll();
            var primaryIdBll = new PrimaryIdRelationBll();

            var condition = "IsDelete=0";
            MaxIdCache = maxIdBll.QueryList(condition).ToList();
            PrimaryIdCache = primaryIdBll.QueryList(condition).ToList();
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
            // 构造查询条件
            var condition = string.Empty;
            var maxId = MaxIdCache.SingleOrDefault(item => item.TableName == OracleTableName);
            if (maxId != null)
            {
                condition = $"to_number({OracleTablePrimaryKeyName})>'{maxId.MaxId}'";
            }

            var newData = OracleBaseBll.QueryList(condition);
            ExecuteImport(newData);
        }

        /// <summary>
        /// 实现更新数据源中被修改过的数据
        /// </summary>
        public void UpdateEditedData()
        {
            // 获取关系缓存中与待更新表有关的数据
            var relations = PrimaryIdCache.Where(item => item.OracleTableName == OracleTableName);
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
                                DataUpdateLog.SingleUpdate(SqlserverTableName, sqlserverModel.Id, DataUpdateType.Update);
                                return true;
                            }

                            return false;
                        };

                        // 执行数据同步
                        SqlserverBaseBll.ExecuteTransation(updateTransaction);

                    } // end if

                } // end else

            } // end foreach
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
                PrimaryIdCache.Add(relation);
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

                // 数据插入事务
                Func<bool> importTransaction = () =>
                {
                    var success = SqlserverBaseBll.Insert(sqlModel).Id > 0;
                    if (success)
                    {
                        // 将数据库更新同步到app
                        DataUpdateLog.SingleUpdate(SqlserverTableName, sqlModel.Id, DataUpdateType.Insert);

                        // 更新主键关系
                        return UpdatePrimaryRelation(model, sqlModel);
                    }

                    return false;
                };

                // 执行事务
                SqlserverBaseBll.ExecuteTransation(importTransaction);
            }

            // 将数据源的最大主键存入缓存中
            var maxId = GetMaxId(oracleData)?.ToString();
            UpdateMaxId(maxId);
        }

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
                MaxIdCache.Add(maxModel);
            }
        }

        /// <summary>
        /// 根据指定oracle表的主键查找对应的sqlserver表的主键
        /// </summary>
        /// <param name="oracleId">指定oracle表的主键</param>
        /// <returns>对应的sqlserver表的主键</returns>
        protected string SearchId(string oracleId)
        {
            var cache = PrimaryIdCache.Find(
                item => item.OracleTableName == OracleTableName && item.OraclePrimaryId == oracleId);

            return cache?.SqlPrimaryId;
        }
    }
}
