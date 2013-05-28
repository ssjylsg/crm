using System.Collections.Generic;
using System.Data;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class AdvertisingRepository : BaseNhibreateRepository<Advertising>, IAdvertisingRepository
    {
        public void Query(PageQuery<IDictionary<string, object>, Advertising> pageQuery)
        {
            StringBuilder stringBuilder = new StringBuilder("From Advertising Where    Deleted != 1 ");
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
            if (pageQuery.OperatorUser != null && pageQuery.OperatorUser.Company != null)
            {
                stringBuilder.AppendFormat(" AND Company.Id = {0}", pageQuery.OperatorUser.Company.Id);
            }
            pageQuery.Result = this.GetSession().CreateQuery(stringBuilder.ToString() + pageQuery.Order)
                  .SetValue(pageQuery.Condition, "Name")
                  .SetPagerInfo(pageQuery.Pager)
                  .List<Advertising>();

            pageQuery.RecordCount = this.GetSession().CreateQuery("Select Count(*) " + stringBuilder.ToString())
                .SetValue(pageQuery.Condition, "Name")
                .UniqueResult()
                .ObjectToInt();

        }

        public DataTable GetStatisticsData(Dictionary<string, object> dict)
        {

            string strSql = string.Format(@"select ID, Name, count(ID) as totalCount
  from (select B.ID, B.Name
          from (select Evaluate
                  from crm_advertising
                 where deleted = 0 and company = {2}
                   and DeliveryDate between to_date('{0}', 'yyyy-mm-dd') and
                       to_date('{1}', 'yyyy-mm-dd')) A
          join crm_categoryitem B
            on A.Evaluate = B.ID)
 group by ID, NAME

", dict["startDate"], dict["endDate"], dict["CompanyId"]);
            return NHelper.ExecuteDataSet(strSql).Tables[0];
        }
    }
}
