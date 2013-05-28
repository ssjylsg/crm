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
    public class CrmDictionaryRepository : BaseNhibreateRepository<CrmDictionary>, ICrmDictionaryRepository
    {

        public void Query(PageQuery<IDictionary<string, object>, CrmDictionary> pageQuery)
        {
            StringBuilder stringBuilder = new StringBuilder("From CrmDictionary Where    Deleted != 1 ");
            var key = string.Empty;
            var depict = string.Empty;
            foreach (var condition in pageQuery.Condition)
            {
                if (condition.Key == "Key")
                {
                    key = (condition.Value ?? string.Empty).ToString();
                    stringBuilder.AppendFormat(" And  {0} LIKE :Key ", condition.Key, condition.Key).AppendLine();
                }
                else if (condition.Key == "Depict")
                {
                    depict = (condition.Value ?? string.Empty).ToString();
                    stringBuilder.AppendFormat(" Or  {0} LIKE :Depict ", condition.Key, condition.Key).AppendLine();
                }
                else
                {
                    stringBuilder.AppendFormat(" And  {0} = '{1}'", condition.Key, condition.Value).AppendLine();
                }
            }
            pageQuery.Result = this.GetSession().CreateQuery(stringBuilder.ToString() + pageQuery.Order)
                .StringLike("Key", key)
                .StringLike("Depict", depict)
                .SetPagerInfo(pageQuery.Pager)
                .List<CrmDictionary>();

            pageQuery.RecordCount =
                this.GetSession().CreateQuery("Select Count(*) " + stringBuilder.ToString())
                    .StringLike("Key", key)
                    .StringLike("Depict", depict)
                    .UniqueResult()
                    .ObjectToInt();

        }
        public int GetScalar(string keys)
        {
            StringBuilder stringBuilder = new StringBuilder(" From CrmDictionary ");
            stringBuilder.AppendFormat(" where key='{0}'", keys).AppendLine();
            object dates = this.GetSession().CreateQuery("Select count(*) " + stringBuilder.ToString()).UniqueResult();
            return int.Parse(dates.ToString());
        }
    }
}
