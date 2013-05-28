using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class TemplateRepository : BaseNhibreateRepository<Template>, ITemplateRepository
    {
        public void Query(PageQuery<IDictionary<string, object>, Template> pageQuery)
        {
            StringBuilder stringBuilder = new StringBuilder("From Template Where    Deleted != 1 ");

            foreach (var condition in pageQuery.Condition)
            {
                if (condition.Value == null)
                {
                    continue;
                }
                if (condition.Key == "TemplateName")
                {
                    stringBuilder.StringLikeAppendHsql(condition.Key, condition.Value);
                }
                else
                {
                    stringBuilder.IntAppendHsql(condition.Key, condition.Value);
                }
            }
            pageQuery.Result = this.GetSession().CreateQuery(stringBuilder.ToString() + pageQuery.Order)
                .SetValue(pageQuery.Condition, "TemplateName")
                .SetPagerInfo(pageQuery.Pager)
                .List<Template>();

            pageQuery.RecordCount = this.GetSession().CreateQuery("Select Count(*) " + stringBuilder.ToString())
                .SetValue(pageQuery.Condition, "TemplateName")
                .UniqueResult().ObjectToInt();

        }
    }
}
