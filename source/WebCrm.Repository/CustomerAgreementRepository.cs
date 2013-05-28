using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
   public class CustomerAgreementRepository : BaseNhibreateRepository<CustomerAgreement>, ICustomerAgreementRepository
    {
       public void Query(PageQuery<IDictionary<string, object>, CustomerAgreement> pageQuery)
       {
           StringBuilder stringBuilder = new StringBuilder("From CustomerAgreement Where    Deleted != 1 ");
           foreach (var condition in pageQuery.Condition)
           {

               if (condition.Value == null)
               {
                   continue;
               }
               if (condition.Key == "Subject")
               {
                   stringBuilder.StringLikeAppendHsql(condition.Key, condition.Value);
               }
               else
               {
                   stringBuilder.IntAppendHsql(condition.Key, condition.Value);
               }
           }

           stringBuilder.AppendFormat("   Order  By CreateTime Desc ");
           pageQuery.Result = this.GetSession().CreateQuery(stringBuilder.ToString())
               .SetValue(pageQuery.Condition, "Subject")
               .SetPagerInfo(pageQuery.Pager)
               .List<CustomerAgreement>();

           pageQuery.RecordCount =
               this.GetSession().CreateQuery("Select Count(*) " + stringBuilder.ToString()).SetValue(
                   pageQuery.Condition, "Subject").UniqueResult().ObjectToInt();
       }
    }
}
