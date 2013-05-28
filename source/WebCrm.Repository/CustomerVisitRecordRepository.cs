using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class CustomerVisitRecordRepository : BaseNhibreateRepository<CustomerVisitRecord>, ICustomerVisitRecordRepository
    {
        public void Query(PageQuery<IDictionary<string, object>, CustomerVisitRecord> pageQuery)
        {
            StringBuilder stringBuilder = new StringBuilder("From CustomerVisitRecord Where    Deleted != 1 ");

            if (pageQuery.Condition != null)
            {
                foreach (var condition in pageQuery.Condition)
                {
                    if (condition.Value == null)
                    {
                        continue;
                    }
                    if (condition.Key == "Customer.Name")
                    {
                        stringBuilder.StringLikeAppendHsql(condition.Key, condition.Value);
                    }
                    else
                    {
                        stringBuilder.IntAppendHsql(condition.Key, condition.Value);
                    }
                }
            }
            if (pageQuery.OperatorUser != null && pageQuery.OperatorUser.Company != null)
            {
                stringBuilder.AppendFormat(" AND Company.Id = {0}", pageQuery.OperatorUser.Company.Id);
            }
            pageQuery.Result =
                this.GetSession().CreateQuery(stringBuilder.ToString() + pageQuery.Order)
                    .SetValue(pageQuery.Condition, "Customer.Name")
                    .SetPagerInfo(pageQuery.Pager)
                    .List<CustomerVisitRecord>();

            pageQuery.RecordCount =
                this.GetSession().CreateQuery("Select Count(*) " + stringBuilder.ToString()).SetValue(
                    pageQuery.Condition,
                    "Customer.Name").UniqueResult().ObjectToInt();

        }
    }
}
