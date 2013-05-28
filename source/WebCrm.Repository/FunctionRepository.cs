using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class FunctionRepository : BaseNhibreateRepository<Function>, IFunctionRepository
    {
        public IList<Function> FindFirstStage()
        {
            return this.GetSession().CreateQuery("From Function Where Parent IS NULL").List<Function>();
        }

        public void Query(PageQuery<IDictionary<string, object>, Function> pageQuery)
        {

            StringBuilder stringBuilder = new StringBuilder("From Function Where    Deleted != 1 ");
            foreach (var condition in pageQuery.Condition)
            {
                if (condition.Value == null)
                {
                    continue;
                }
                if (condition.Key == "FunctionName")
                {
                    stringBuilder.StringLikeAppendHsql(condition.Key, condition.Value);
                }
                else
                {
                    stringBuilder.IntAppendHsql(condition.Key, condition.Value);
                }
            }
            pageQuery.Result = this.GetSession().CreateQuery(stringBuilder.ToString())
                .SetValue(pageQuery.Condition, "FunctionName")
                .SetPagerInfo(pageQuery.Pager)
                .List<Function>();

            pageQuery.RecordCount =
                this.GetSession().CreateQuery("Select Count(*) " + stringBuilder.ToString())
                .SetValue(pageQuery.Condition, "FunctionName")
                .UniqueResult()
                .ObjectToInt();

        }
    }
}
