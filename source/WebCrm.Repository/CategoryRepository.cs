using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;

namespace WebCrm.Dao
{
    public class CategoryRepository : BaseNhibreateRepository<Category>, WebCrm.Model.Repositories.ICategoryRepository
    {
        public IList<Category> GetCategoryList(string comanyName)
        {
            throw new NotImplementedException();
        }

        public void Query(PageQuery<IDictionary<string, object>, Category> pageQuery)
        {
            StringBuilder stringBuilder = new StringBuilder("From Category Where    Deleted != 1 ");
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
            pageQuery.Result = this.GetSession().CreateQuery(stringBuilder.ToString() + pageQuery.Order)
                .SetValue(pageQuery.Condition, "Name")
                .SetPagerInfo(pageQuery.Pager)
                .List<Category>();

            pageQuery.RecordCount = this.GetSession().CreateQuery("Select Count(*) " + stringBuilder.ToString())
                .SetValue(pageQuery.Condition, "Name")
                .UniqueResult()
                .ObjectToInt();

        }
    }
}
