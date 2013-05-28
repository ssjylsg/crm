using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class MembershipCardRepository : BaseNhibreateRepository<MembershipCard>, IMembershipCardRepository
    {
        public void Query(PageQuery<IDictionary<string, object>, MembershipCard> pageQuery)
        {
            StringBuilder stringBuilder = new StringBuilder("From MembershipCard Where    Deleted != 1 ");
            foreach (var condition in pageQuery.Condition)
            {
                if (condition.Value == null)
                {
                    continue;
                }
                if (condition.Key == "CardCode")
                {
                    stringBuilder.StringLikeAppendHsql(condition.Key, condition.Value);
                }
                else
                {
                    stringBuilder.IntAppendHsql(condition.Key, condition.Value);
                }
            }
            pageQuery.Result = this.GetSession().CreateQuery(stringBuilder.ToString() + pageQuery.Order)
                   .SetValue(pageQuery.Condition, "CardCode")
              .SetPagerInfo(pageQuery.Pager)
                .List<MembershipCard>();

            pageQuery.RecordCount = this.GetSession().CreateQuery("Select Count(*) " + stringBuilder.ToString())
                .SetValue(pageQuery.Condition, "CardCode")
                .UniqueResult().ObjectToInt();

        }
    }
}
