using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class FinancialRepository : BaseNhibreateRepository<Financial>, IFinancialRepository
    {
        public void Query(PageQuery<IDictionary<string, object>, Financial> pageQuery)
        {
            StringBuilder stringBuilder = new StringBuilder("From Financial Where    Deleted != 1 ");
            foreach (var condition in pageQuery.Condition)
            {
                if (condition.Value == null)
                {
                    continue;
                }
                if (condition.Key == "CustomerName" || condition.Key == "Name")
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
                .SetValue(pageQuery.Condition, "Name", "CustomerName")
                .SetPagerInfo(pageQuery.Pager)
                .List<Financial>();

            pageQuery.RecordCount = this.GetSession().CreateQuery("Select Count(*) " + stringBuilder.ToString())
                .SetValue(pageQuery.Condition, "Name", "CustomerName")
                .UniqueResult()
                .ObjectToInt();

        }
    }
}
