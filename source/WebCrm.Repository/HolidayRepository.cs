using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class HolidayRepository : BaseNhibreateRepository<Holiday>, IHolidayRepository
    {
        public void Query(PageQuery<IDictionary<string, object>, Holiday> pageQuery)
        {
            StringBuilder stringBuilder = new StringBuilder("From Holiday Where    Deleted != 1 ");
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
                .List<Holiday>();
            pageQuery.RecordCount = this.GetSession().CreateQuery("Select Count(*) " + stringBuilder.ToString())
                 .SetValue(pageQuery.Condition, "Name")
                 .UniqueResult().ObjectToInt();

        }

        public IList<Holiday> GetSendInfoHodiay()
        {
            return
                this.GetSession().CreateQuery(" From Holiday Where IsSendMsg = 1 AND Deleted != 1").List<Holiday>().
                    Where(
                        m => DateEqual(DateTime.Now.AddDays(m.DateNum), m.HolidayDate)).ToList();
        }
        /// <summary>
        ///年 月 日 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="dateTime1"></param>
        /// <returns></returns>
        private bool DateEqual(DateTime dateTime, DateTime dateTime1)
        {
            return dateTime1.Month == dateTime.Month && dateTime1.Day == dateTime.Day && dateTime1.Year == dateTime.Year;
        }
    }
}
