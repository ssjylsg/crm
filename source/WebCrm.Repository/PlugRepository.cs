using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class PlugRepository : BaseNhibreateRepository<Plug>, IPlugRepository
    {
        public void Query(PageQuery<IDictionary<string, object>, Plug> pageQuery)
        {
            StringBuilder stringBuilder = new StringBuilder("From Plug Where    Deleted != 1  And  PlugType = 801 ");
            foreach (var condition in pageQuery.Condition)
            {

                if (condition.Value == null)
                {
                    continue;
                }
                if (condition.Key == "PlugName")
                {
                    stringBuilder.StringLikeAppendHsql(condition.Key, condition.Value);
                }
                else
                {
                    stringBuilder.IntAppendHsql(condition.Key, condition.Value);
                }
            }
            pageQuery.Result = this.GetSession().CreateQuery(stringBuilder.ToString())
                .SetValue(pageQuery.Condition, "PlugName")
                .SetPagerInfo(pageQuery.Pager)
                .List<Plug>();

            pageQuery.RecordCount =
                this.GetSession().CreateQuery("Select Count(*) " + stringBuilder.ToString())
                    .SetValue(pageQuery.Condition, "PlugName")
                    .UniqueResult().ObjectToInt();

        }

        public IList<Plug> GetAllParent()
        {
            return this.GetSession().CreateQuery("From Plug Where    Deleted != 1  And  PlugType = 801 AND Parent IS NULL").List<Plug>();
        }
    }
}
