using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using System.Data;
namespace WebCrm.Dao
{
    public class CooperationRepository : BaseNhibreateRepository<Cooperation>, ICooperationRepository
    {
        public void Query(PageQuery<IDictionary<string, object>, Cooperation> pageQuery)
        {
            StringBuilder stringBuilder = new StringBuilder("From Cooperation Where    Deleted != 1 ");
            foreach (var condition in pageQuery.Condition)
            {
                if (condition.Value == null)
                {
                    continue;
                }
                if (condition.Key == "Name")
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
                stringBuilder.AppendFormat(" AND Company.Id = {0}", pageQuery.OperatorUser.Company.Id);
            }
            pageQuery.Result = this.GetSession().CreateQuery(stringBuilder.ToString() + pageQuery.Order)
                 .SetValue(pageQuery.Condition, "Name")
                .SetPagerInfo(pageQuery.Pager)
                .List<Cooperation>();

            pageQuery.RecordCount = this.GetSession().CreateQuery("Select Count(*) " + stringBuilder.ToString())
                .SetValue(pageQuery.Condition, "Name")
                .UniqueResult()
                .ObjectToInt();

        }

        /// <summary>
        /// 条件查询不分页
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public DataTable GetByCondition(Dictionary<string, object> dict, string selectFields = "*")
        {
            StringBuilder stringBuilder = new StringBuilder("select " + selectFields + " From crm_Cooperation Where    Deleted != 1 ");
            foreach (var condition in dict)
            {
                if (condition.Key == "Name")
                {
                    stringBuilder.AppendFormat(" And  {0} = '{1}'", condition.Key, condition.Value).AppendLine();
                }
                else
                {
                    stringBuilder.AppendFormat(" And  {0} = '{1}'", condition.Key, condition.Value).AppendLine();
                }
            }
            return NHelper.ExecuteDataSet(stringBuilder.ToString()).Tables[0];
        }
    }
}
