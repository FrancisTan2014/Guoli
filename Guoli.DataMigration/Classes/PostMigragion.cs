using System.Collections.Generic;
using System.Linq;
using Guoli.Model;
using Guoli.Model.OracleModels;
using Guoli.Utilities.Extensions;

namespace Guoli.DataMigration
{
    public class PostMigragion: OracleMigration<J_JCYY_BASEPOST, Posts>
    {
        protected override string OracleTableName => nameof(J_JCYY_BASEPOST);
        protected override string OracleTablePrimaryKeyName => nameof(J_JCYY_BASEPOST.POSTID);
        protected override string SqlserverTableName => nameof(Posts);
        protected override string SqlserverTablePrimaryKeyName => nameof(Posts.Id);

        protected override bool HasEdited(J_JCYY_BASEPOST oracleModel, Posts sqlserverModel)
        {
            return oracleModel.POSTNAME != sqlserverModel.PostName;
        }

        protected override void UpdateSqlserverModel(J_JCYY_BASEPOST oracleEntity, Posts sqlserverEntity)
        {
            sqlserverEntity.PostName = oracleEntity.POSTNAME;
        }

        protected override dynamic MapEntity(J_JCYY_BASEPOST oracleEntity)
        {
            return new Posts
            {
                PostName = oracleEntity.POSTNAME
            };
        }

        protected override object GetMaxId(IEnumerable<J_JCYY_BASEPOST> source)
        {
            return source.Select(p => p.POSTID.ToInt32()).Max();
        }
    }
}
