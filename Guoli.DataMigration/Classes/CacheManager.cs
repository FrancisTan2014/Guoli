using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guoli.Bll;
using Guoli.Model;

namespace Guoli.DataMigration
{
    public class CacheManager
    {
        /// <summary>
        /// Oracle数据库表的最大Id缓存
        /// </summary>
        public static List<OracleTableMaxId> MaxIdCache { get; set; }

        /// <summary>
        /// Oracle数据库表Sql Server数据库表的主键对应关系缓存
        /// </summary>
        public static List<PrimaryIdRelation> PrimaryIdCache { get; set; }

        private static readonly CacheManager _instance;

        private CacheManager() { }

        static CacheManager()
        {
            _instance = new CacheManager();

            var maxIdBll = new OracleTableMaxIdBll();
            var primaryIdBll = new PrimaryIdRelationBll();

            var condition = "IsDelete=0";
            MaxIdCache = maxIdBll.QueryList(condition).ToList();
            PrimaryIdCache = primaryIdBll.QueryList(condition).ToList();
        }

        public static CacheManager GetInstance()
        {
            return _instance;
        }
    }
}
