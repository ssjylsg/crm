using System.Collections.Generic;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class SuggestRepository : BaseNhibreateRepository<Suggest>, ISuggestRepository
    {
        public void Query(PageQuery<IDictionary<string, object>, Suggest> pageQuery)
        {
            StringBuilder stringBuilder = new StringBuilder("From Suggest Where   Deleted != 1 ");

            foreach (var condition in pageQuery.Condition)
            {
                if (condition.Value == null)
                {
                    continue;
                }
                if (condition.Key == "CustoMerName")
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
              .SetValue(pageQuery.Condition, "CustoMerName")
                .SetPagerInfo(pageQuery.Pager)
                .List<Suggest>();
            pageQuery.RecordCount = this.GetSession().CreateQuery("Select Count(*) " + stringBuilder.ToString())
                .SetValue(pageQuery.Condition, "CustoMerName")
                .UniqueResult().ObjectToInt();
        }
    }
}
