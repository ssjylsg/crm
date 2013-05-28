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
    public class CustormerConsumRecordRepository : BaseNhibreateRepository<CustormerConsumRecord>, ICustormerConsumRecordRepository
    {
        public void Query(PageQuery<IDictionary<string, object>, CustormerConsumRecord> pageQuery)
        {
            StringBuilder stringBuilder = new StringBuilder("From CustormerConsumRecord Where    Deleted != 1 ");
            foreach (var condition in pageQuery.Condition)
            {
                if (condition.Value == null)
                {
                    continue;
                }
                if (condition.Key == "Customer.Name")
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
                .SetValue(pageQuery.Condition, "Customer.Name")
                .SetPagerInfo(pageQuery.Pager)
                .List<CustormerConsumRecord>();

            pageQuery.RecordCount = this.GetSession().CreateQuery("Select Count(*) " + stringBuilder.ToString())
                .SetValue(pageQuery.Condition, "Customer.Name").UniqueResult().ObjectToInt();

        }

        /// <summary>
        /// 统计客户应收
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public DataTable GetStatisticsData(Dictionary<string, object> dict)
        {
            string strSql = string.Format(@"select name,sum(fee) as totalCount from (
            select B.NAME,A.fee from 
            (select customerid,AFTERDISCOUNTFREE,RECEIVEMONEY,(AFTERDISCOUNTFREE-RECEIVEMONEY) as fee from {2} 
            where Deleted=0 And COMPANY = {3} and AFTERDISCOUNTFREE-RECEIVEMONEY >0 
            and ConsumptionDate between to_date('{0}','yyyy-mm-dd') and  to_date('{1}','yyyy-mm-dd')
            ) A left join Crm_Customer B on A.customerid = B.ID)
            where fee > 0
            group by name", dict["startDate"], dict["endDate"], NHibernateDatabaseFactory.TableName(typeof(CustormerConsumRecord)), dict["CompanyId"]);
            return WebCrm.Framework.DependencyResolver.Resolver<IChartRepository>().ExecuteDataTable(strSql);
        }

        /// <summary>
        /// 获取客户消费行为走势数据
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public DataTable GetExpenseTrendData(Dictionary<string, object> dict)
        {
            DateTime dateBegin = Convert.ToDateTime(dict["startDate"]);
            DateTime dateEnd = Convert.ToDateTime(dict["endDate"]);
            string filterSql = " and Deleted=0 ";
            if (dict.ContainsKey("CustomerID") && !string.IsNullOrEmpty("" + dict["CustomerID"]))
            {
                filterSql += string.Format(" and CustomerID='{0}'", dict["CustomerID"]);
            }
            filterSql += " And COMPANY = " + dict["CompanyId"];
            return NHelper.GetStatisticsData(NHibernateDatabaseFactory.TableName(typeof(CustormerConsumRecord)), "ConsumptionDate", dateBegin, dateEnd, "AFTERDISCOUNTFREE", "", filterSql);
        }
    }
}
