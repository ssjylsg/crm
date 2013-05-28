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
    public class CustomerRepository : BaseNhibreateRepository<Customer>, ICustomerRepository
    {
        public void Query(PageQuery<IDictionary<string, object>, Customer> pageQuery)
        {
            StringBuilder stringBuilder = new StringBuilder("From Customer Where    Deleted != 1 ");
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

            pageQuery.Result = this.GetSession()
                 .CreateQuery(stringBuilder.ToString() + pageQuery.Order)
                .SetValue(pageQuery.Condition, "Name")
                .SetPagerInfo(pageQuery.Pager)
                .List<Customer>();

            pageQuery.RecordCount =
                this.GetSession().CreateQuery("Select Count(*) " + stringBuilder.ToString())
                .SetValue(pageQuery.Condition, "Name")
                .UniqueResult()
                .ObjectToInt();

        }

        /// <summary>
        /// 条件查询不分页
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="selectFields"></param>
        /// <returns></returns>
        public DataTable GetByCondition(Dictionary<string, object> dict, string selectFields = "*")
        {
            StringBuilder stringBuilder = new StringBuilder("select " + selectFields + " From Crm_Customer Where    Deleted != 1 ");
            if (dict != null)
            {
                foreach (var condition in dict)
                {
                    if (condition.Key == "Name")
                    {
                        stringBuilder.AppendFormat(" And  {0} LIKE '%{1}%'", condition.Key, condition.Value).AppendLine();
                    }
                    else
                    {
                        stringBuilder.AppendFormat(" And  {0} = '{1}'", condition.Key, condition.Value).AppendLine();
                    }
                }
            }
            return NHelper.ExecuteDataSet(stringBuilder.ToString()).Tables[0];
        }

        public DataTable GetStatisticsData(Dictionary<string, object> dict)
        {
            string strSql = "";
            //加载省份数据
            if (string.IsNullOrEmpty("" + dict["ProvinceID"]))
            {
                strSql = string.Format(@"select name,count(name) as totalCount from(
select D.Name,D.OrderIndex from
(select B.Parentitemid from( select area from Crm_Customer where deleted=0
and createtime  between to_date('{0}','yyyy-mm-dd') and  to_date('{1}','yyyy-mm-dd') and company = {2})A
left join crm_categoryitem B on A.Area=B.ID)C
left join crm_categoryitem D on C.Parentitemid = D.ID)
group by Name,OrderIndex 
order by OrderIndex", dict["startDate"], dict["endDate"], dict["CompanyId"]);
            }
            else //加载市级数据
            {
                strSql = string.Format(@"select name,count(name) as totalCount from(
select B.ID,B.Name,B.Parentitemid,B.Orderindex from( select area from Crm_Customer where deleted=0 
and createtime  between to_date('{0}','yyyy-mm-dd') and  to_date('{1}','yyyy-mm-dd') and company = {3} )A
left join crm_categoryitem B on A.Area=B.ID
where parentitemid = '{2}')
group by Name,OrderIndex 
order by OrderIndex", dict["startDate"], dict["endDate"], dict["ProvinceID"], dict["CompanyId"]);
            }
            return NHelper.ExecuteDataSet(strSql).Tables[0];
        }
    }
}
