using System;
using System.Collections.Generic;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class TaskRepository : BaseNhibreateRepository<Task>, ITaskRepository
    {
        public void Query(PageQuery<IDictionary<string, object>, Task> pageQuery)
        {
            StringBuilder stringBuilder = new StringBuilder("From Task Where    Deleted != 1 ");
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
                .List<Task>();

            pageQuery.RecordCount =
                this.GetSession().CreateQuery("Select Count(*) " + stringBuilder.ToString()).SetValue(
                    pageQuery.Condition, "Subject").UniqueResult().ObjectToInt();
        }
    }
}
