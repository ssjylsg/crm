using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class RoleRepository : BaseNhibreateRepository<Role>, IRoleRepository
    {
        public void Query(PageQuery<IDictionary<string, object>, Role> pageQuery)
        {

            StringBuilder stringBuilder = new StringBuilder("From Role Where    Deleted != 1  And SystemName = 'CRM'");
            foreach (var condition in pageQuery.Condition)
            {

                if (condition.Value == null)
                {
                    continue;
                }
                if (condition.Key == "RoleName")
                {
                    stringBuilder.StringLikeAppendHsql(condition.Key, condition.Value);
                }
                else
                {
                    stringBuilder.IntAppendHsql(condition.Key, condition.Value);
                }
            }
            if (pageQuery.OperatorUser != null && pageQuery.OperatorUser.Company != null)
            {
                stringBuilder.AppendFormat(" And  Company.Id = {0}", pageQuery.OperatorUser.Company.Id);
            }
            pageQuery.Result = this.GetSession().CreateQuery(stringBuilder.ToString())
                .SetPagerInfo(pageQuery.Pager)
                 .SetValue(pageQuery.Condition, "RoleName")
                .List<Role>();
            pageQuery.RecordCount = this.GetSession().CreateQuery("Select Count(*) " + stringBuilder.ToString())
                 .SetValue(pageQuery.Condition, "RoleName")
                .UniqueResult().ObjectToInt();
        }
    }
}
