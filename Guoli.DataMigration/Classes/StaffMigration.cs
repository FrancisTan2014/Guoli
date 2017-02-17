using System;
using System.Collections.Generic;
using System.Linq;
using Guoli.Model;
using Guoli.Model.OracleModels;
using Guoli.Utilities.Extensions;
using Guoli.Utilities.Helpers;

namespace Guoli.DataMigration
{
    public class StaffMigration : OracleMigration<Z_JCYY_BASEPERSONNEL, PersonInfo>
    {
        protected override string OracleTableName => nameof(Z_JCYY_BASEPERSONNEL);
        protected override string OracleTablePrimaryKeyName => nameof(Z_JCYY_BASEPERSONNEL.PERSONID);
        protected override string SqlserverTableName => nameof(PersonInfo);
        protected override string SqlserverTablePrimaryKeyName => nameof(PersonInfo.Id);

        protected override bool HasEdited(Z_JCYY_BASEPERSONNEL oracleModel, PersonInfo sqlserverModel)
        {
            // 若数据源中以下字段的值被改变，则可认为此条数据已被修改过
            // 工号：WORKNO 部门Id：DEPTID 职位Id：POSTID 姓名：HNAME 拼音：SPELL
            var workNoHasChanged = oracleModel.WORKNO != sqlserverModel.WorkNo;
            var nameHasChanged = oracleModel.HNAME != sqlserverModel.Name;
            var spellHasChanged = oracleModel.SPELL != sqlserverModel.Spell;

            var deptIdHasChanged = HasDeptIdChanged(oracleModel.DEPTID, sqlserverModel.DepartmentId.ToString());

            var postIdHasChanged = HasPostIdChanged(oracleModel.POSTID, sqlserverModel.PostId.ToString());

            return workNoHasChanged ||
                   nameHasChanged ||
                   spellHasChanged ||
                   deptIdHasChanged ||
                   postIdHasChanged;
        }

        private bool HasDeptIdChanged(string oracleDeptId, string sqlserverDeptId)
        {
            return FindPrimaryIdRelation(nameof(Y_JCYY_BASEDEPARTMENT), oracleDeptId)
                ?.SqlPrimaryId != sqlserverDeptId;
        }

        private bool HasPostIdChanged(string oraclePostId, string sqlserverPostId)
        {
            return FindPrimaryIdRelation(nameof(J_JCYY_BASEPOST), oraclePostId)
                ?.SqlPrimaryId != sqlserverPostId;
        }

        protected override void UpdateSqlserverModel(Z_JCYY_BASEPERSONNEL oracleEntity, PersonInfo sqlserverEntity)
        {
            var workNoHasChanged = oracleEntity.WORKNO != sqlserverEntity.WorkNo;
            if (workNoHasChanged)
            {
                sqlserverEntity.WorkNo = oracleEntity.WORKNO;
            }

            var nameHasChanged = oracleEntity.HNAME != sqlserverEntity.Name;
            if (nameHasChanged)
            {
                sqlserverEntity.Name = oracleEntity.HNAME;
            }

            var spellHasChanged = oracleEntity.SPELL != sqlserverEntity.Spell;
            if (spellHasChanged)
            {
                sqlserverEntity.Spell = oracleEntity.SPELL;
            }

            var deptIdHasChanged = HasDeptIdChanged(oracleEntity.DEPTID, sqlserverEntity.DepartmentId.ToString());
            if (deptIdHasChanged)
            {
                var newDepartInfoId =
                    FindPrimaryIdRelation(nameof(Y_JCYY_BASEDEPARTMENT), oracleEntity.DEPTID)?.SqlPrimaryId.ToInt32();

                // 若部门id在数据源中已被修改，但sqlserver还未同步
                // 则维持原值不变，等待系统下次更新此条数据时再行更新
                sqlserverEntity.DepartmentId = newDepartInfoId ?? sqlserverEntity.DepartmentId;
            }

            var postIdHasChanged = HasPostIdChanged(oracleEntity.POSTID, sqlserverEntity.PostId.ToString());
            if (postIdHasChanged)
            {
                var newPostsId =
                    FindPrimaryIdRelation(nameof(J_JCYY_BASEPOST), oracleEntity.POSTID)?.SqlPrimaryId.ToInt32();

                // 若职位id在数据源中已被修改，但sqlserver还未同步
                // 则维持原值不变，等待系统下次更新此条数据时再行更新
                sqlserverEntity.PostId = newPostsId ?? sqlserverEntity.PostId;
            }

        }

        protected override dynamic MapEntity(Z_JCYY_BASEPERSONNEL oracleEntity)
        {
            PersonInfo person = null;

            var departId =
                FindPrimaryIdRelation(nameof(Y_JCYY_BASEDEPARTMENT), oracleEntity.DEPTID)?.SqlPrimaryId.ToInt32();
            var postId = FindPrimaryIdRelation(nameof(J_JCYY_BASEPOST), oracleEntity.POSTID)?.SqlPrimaryId.ToInt32();

            if (departId != null && postId != null)
            {
                person = new PersonInfo
                {
                    DepartmentId = departId.Value,
                    PostId = postId.Value,
                    Name = oracleEntity.HNAME,
                    Spell = oracleEntity.SPELL?.ToLower() ?? string.Empty,
                    PersonId = oracleEntity.PERSONID,
                    // 在数据源中0表示男，1表示女，而在sqlserver中1表示男，2表示女，3表示未知
                    Sex = (oracleEntity.SEX?.ToInt32() ?? 2) + 1
                };

                // 为了保证插入数据时不出现SqlDataTime溢出异常所做的处理
                if (oracleEntity.DOB != null && oracleEntity.DOB.Value < DateTimeExtension.UnknownDateTime)
                {
                    person.BirthDate = DateTimeExtension.UnknownDateTime;
                }
                else
                {
                    person.BirthDate = oracleEntity.DOB ?? DateTimeExtension.UnknownDateTime;
                }

                var workNo = oracleEntity.WORKNO;
                person.WorkNo = workNo;

                var password = person.WorkNo;
                if (person.WorkNo.Length > 4)
                {
                    password = workNo.Substring(workNo.Length - 4 - 1);
                }

                person.Password = EncryptHelper.EncryptPassword(password);
            }

            return person;
        }

        protected override object GetMaxId(IEnumerable<Z_JCYY_BASEPERSONNEL> source)
        {
            return source.Select(p => p.PERSONID.ToInt32()).Max();
        }
    }
}
