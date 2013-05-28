using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using NHibernate;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{


    public class ChartRepository : IChartRepository
    {
        private ISession GetCurrentSession()
        {
            ISession session = NHibernateDatabaseFactory.GetSession();
            return session;
        }
        private IDbCommand CreateDbCommand()
        {
            var session = GetCurrentSession();
            var command = session.Connection.CreateCommand();
            return command;
        }
        /// <summary>
        /// 填充DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string sql)
        {

            var ds = new DataSet();

            using (IDbCommand command = CreateDbCommand())
            {
                command.CommandText = sql;

                using (IDataReader reader = command.ExecuteReader())
                {
                    var result = new DataTable();
                    DataTable schemaTable = reader.GetSchemaTable();
                    for (int i = 0; i < schemaTable.Rows.Count; i++)
                    {
                        string columnName = schemaTable.Rows[i][0].ToString();
                        result.Columns.Add(columnName);
                    }

                    while (reader.Read())
                    {
                        int fieldCount = reader.FieldCount;
                        object[] values = new Object[fieldCount];
                        for (int i = 0; i < fieldCount; i++)
                        {
                            values[i] = reader.GetValue(i);
                        }
                        result.Rows.Add(values);
                    }
                    ds.Tables.Add(result);
                }
            }
            return ds;
        }

        /// <summary>
        /// 获取第一行第一列数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int GetScalar(string sql)
        {

            using (IDbCommand command = CreateDbCommand())
            {
                command.CommandText = sql;
                object obj = command.ExecuteScalar();
                if (obj == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(obj);
                }
            }
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int GetTotalCount(string tableName, string where = null)
        {
            string sql = string.Format("select count(1) from {0} ", tableName);
            if (!string.IsNullOrEmpty(where))
            {
                sql += " where " + where;
            }
            return GetScalar(sql);
        }

        /// <summary>
        /// 获取统计格式数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="timeField">日期时间字段</param>
        /// <param name="dateBegin">开始日期</param>
        /// <param name="dateEnd">结束日期（注意：是日期，时间部分都为零）</param>
        /// <param name="type">M:按月统计 Y：按年统计.缺省将按时间段自动选择，大于一年按年统计，否则按月统计</param>
        /// <param name="filterSql">其他筛选条件格式形如："and FName='123'"</param>
        /// <returns>
        /// 按年返回格式：
        /// ---------------------------------------
        /// XVALUE      INYEAR  INMONTH   YVALUE
        /// 2011年04月  2011    04        8
        /// 2011年05月  2011    05        10
        /// 2011年06月  2011    06        7
        /// ......
        /// ---------------------------------------
        /// 按月返回格式：
        /// ---------------------------------------
        /// XVALUE    YVALUE
        /// 2011年    50
        /// 2012年    89
        /// ......
        /// ---------------------------------------
        /// </returns>
        public DataTable GetStatisticsData(string tableName, string timeField, DateTime dateBegin, DateTime dateEnd, string type = "", string filterSql = "")
        {
            if ("" == type) //缺省判断
            {
                TimeSpan ts = dateEnd.Subtract(dateBegin);
                if (ts.TotalDays > 365) //大于一年按年统计，否则按月统计
                {
                    type = "Y";
                }
                else
                {
                    type = "M";
                }
            }
            //注：由于DateTime传人的都是日期部分Date，时间部分Time为零，所以下面转换能保证时间段正确
            //如果DataTime带了时间部分Time，则月尾最后一天查询不能保证正确
            string begin = dateBegin.ToString("yyyy-MM") + "-01";
            string end = dateEnd.AddDays(1).ToString("yyyy-MM-dd");

            DataTable dt; ;
            string strWhere = string.Format("  where {0}>to_date('{1}','yyyy-mm-dd') and {2}<to_date('{3}','yyyy-mm-dd') {4} ", timeField, begin, timeField, end, filterSql);
            if ("M" == type || "m" == type) //按月统计
            {
                string strSql = string.Format(@" select concat(concat(A.InYear,'年'),concat(A.InMonth,'月')) as XValue, A.InYear,A.InMonth,count(A.InMonth)as YValue from (
                select  SUBSTR(to_char({0},'yyyy-mm-dd'),1,4) as InYear,SUBSTR(to_char({1},'yyyy-mm-dd'),6,2) as InMonth  from {2} {3})A group by InYear,InMonth ", timeField, timeField, tableName, strWhere);
                dt = ExecuteDataSet(strSql).Tables[0];  //执行返回DataTable
                return dt;
            }
            else if ("Y" == type || "y" == type) //按年统计
            {
                string strSql = string.Format(@"select concat(A.InYear,'年') as XValue,count(A.InYear)as YValue from (
                select SUBSTR(to_char({0},'yyyy-mm-dd'),1,4) as InYear  from {1} {2})A group by InYear ", timeField, tableName, strWhere);
                dt = ExecuteDataSet(strSql).Tables[0];
                return dt;
            }
            return new DataTable();
        }

        /// <summary>
        /// 增加了一个求和的方式
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="timeField"></param>
        /// <param name="dateBegin"></param>
        /// <param name="dateEnd"></param>
        /// <param name="sumField"></param>
        /// <param name="type"></param>
        /// <param name="filterSql"></param>
        /// <returns></returns>
        public DataTable GetStatisticsData(string tableName, string timeField, DateTime dateBegin, DateTime dateEnd, string sumField, string type = "", string filterSql = "")
        {
            if ("" == type) //缺省判断
            {
                TimeSpan ts = dateEnd.Subtract(dateBegin);
                if (ts.TotalDays > 365) //大于一年按年统计，否则按月统计
                {
                    type = "Y";
                }
                else
                {
                    type = "M";
                }
            }
            //注：由于DateTime传人的都是日期部分Date，时间部分Time为零，所以下面转换能保证时间段正确
            //如果DataTime带了时间部分Time，则月尾最后一天查询不能保证正确
            string begin = dateBegin.ToString("yyyy-MM") + "-01";
            string end = dateEnd.AddDays(1).ToString("yyyy-MM-dd");

            DataTable dt; ;
            string strWhere = string.Format("  where {0}>to_date('{1}','yyyy-mm-dd') and {2}<to_date('{3}','yyyy-mm-dd') {4} ", timeField, begin, timeField, end, filterSql);
            if ("M" == type || "m" == type) //按月统计
            {
                string strSql = string.Format(@" select concat(concat(A.InYear,'年'),concat(A.InMonth,'月')) as XValue, A.InYear,A.InMonth,sum(A.{0})as YValue from (
                select  SUBSTR(to_char({1},'yyyy-mm-dd'),1,4) as InYear,SUBSTR(to_char({1},'yyyy-mm-dd'),6,2) as InMonth,{0}  from {2} {3})A group by InYear,InMonth ", sumField, timeField, tableName, strWhere);
                dt = ExecuteDataSet(strSql).Tables[0];  //执行返回DataTable
                return dt;
            }
            else if ("Y" == type || "y" == type) //按年统计
            {
                string strSql = string.Format(@"select concat(A.InYear,'年') as XValue,sum(A.{0})as YValue from (
                select SUBSTR(to_char({1},'yyyy-mm-dd'),1,4) as InYear,{0}  from {2} {3})A group by InYear ", sumField, timeField, tableName, strWhere);
                dt = ExecuteDataSet(strSql).Tables[0];
                return dt;
            }
            return new DataTable();
        }



        public DataTable GetCustomerAgeStructure(Dictionary<string, object> dictionary)
        {
            string sql =
                @"
SELECT SUM(T.IDCOUNT) as AgeSum,
       (CASE
       
         WHEN T.yearDiff < 20 THEN
          '20岁以下'
         WHEN T.yearDiff >= 20 AND T.yearDiff < 30 THEN
          '20-30岁'
         WHEN T.yearDiff >= 30 AND T.yearDiff < 40 THEN
          '30-40岁'
         WHEN T.yearDiff >= 40 AND T.yearDiff < 50 THEN
          '40-50岁'
         ELSE
          '50岁以上'
       END) AS AGE

  FROM (select count(id) AS IDCOUNT,
               EXTRACT(year FROM sysdate) - EXTRACT(year FROM birthday) as yearDiff
          from {0} WHERE birthday >= to_date('{1}', 'yyyy-mm-dd') AND birthday <=to_date('{2}', 'yyyy-mm-dd') And company = {3}
          AND DELETED <>1
         group by EXTRACT(year FROM sysdate) - EXTRACT(year FROM birthday)) T
 group by (CASE
          
            WHEN T.yearDiff < 20 THEN
             '20岁以下'
            WHEN T.yearDiff >= 20 AND T.yearDiff < 30 THEN
             '20-30岁'
            WHEN T.yearDiff >= 30 AND T.yearDiff < 40 THEN
             '30-40岁'
            WHEN T.yearDiff >= 40 AND T.yearDiff < 50 THEN
             '40-50岁'
            ELSE
             '50岁以上'
          END)
";
            var startDate = DateTime.Parse(dictionary["startDate"].ToString());
            var endDate = DateTime.Parse(dictionary["endDate"].ToString());
            var companyId = dictionary["CompanyId"].ToString();
            return
                this.ExecuteDataTable(string.Format(sql,
                                                    NHibernateDatabaseFactory.TableName(typeof(CustomerInfo)),
                                                    startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"),
                                                    companyId));
        }

        public DataTable ExecuteDataTable(string strSql)
        {
            DataSet ds = this.ExecuteDataSet(strSql);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public DataTable GetIncomeTrend(Dictionary<string, object> dict)
        {
            var startDate = dict.ContainsKey("startDate") ? (dict["startDate"]).ToString() : DateTime.Now.AddMonths(-1).ToShortDateString();
            var endDate = dict.ContainsKey("endDate") ? (dict["endDate"]).ToString() : DateTime.Now.ToShortDateString();
            string sql =
                string.Format(
                    @"
                SELECT R.TOTAL,I.NAME,I.ID FROM (
                SELECT T.CONSUMERBUSINESSTYPE,SUM(T.SPENDTOTAL) AS TOTAL FROM {0} T 
                WHERE T.DELETED <>1 AND TO_CHAR(T.CONSUMPTIONDATE,'yyyy-mm-dd') >= '{2}' 
                AND TO_CHAR(T.CONSUMPTIONDATE,'yyyy-mm-dd')  <='{3}'
                AND T.Company = {4}
                GROUP BY T.CONSUMERBUSINESSTYPE
                ) R INNER JOIN {1} I ON R.CONSUMERBUSINESSTYPE = I.ID
                ",
                    NHibernateDatabaseFactory.TableName(typeof(CustormerConsumRecord)),
                    NHibernateDatabaseFactory.TableName(typeof(CategoryItem)),
                    DateTime.Parse(startDate).ToString("yyyy-MM-dd"),
                    DateTime.Parse(endDate).ToString("yyyy-MM-dd"),
                    dict["CompanyId"]);
            return this.ExecuteDataTable(sql);
        }

        public DataTable GetCustomerStructure(Dictionary<string, object> dictionary)
        {

            var companyId = dictionary["Company"];
            var caType = dictionary["CaType"].ToString();
            var startDate = DateTime.Parse(dictionary["startDate"].ToString());
            var endDate = DateTime.Parse(dictionary["endDate"].ToString());

            string sql =
                @"SELECT COUNT(R.ID) AS TOTAL,C.ID  ,C.NAME FROM {2} R 
                    INNER JOIN {4} C ON C.ID = {3}
                    WHERE R.DELETED <> 1 
                    AND R.CUSTOMERSOURCE IS NOT NULL 
                    AND TO_CHAR( R.CREATETIME ,'yyyy-mm-dd') >='{0}'
                    AND TO_CHAR( R.CREATETIME ,'yyyy-mm-dd') <='{1}'
                    AND Company = {5}
                    GROUP BY C.ID ,C.NAME";
            string orderBy = caType == "source" ? "R.CUSTOMERSOURCE" : "R.CUSTOMERBUSINESS";
            return
                this.ExecuteDataTable(string.Format(sql,
                                                    startDate.ToString("yyyy-MM-dd"),
                                                    endDate.ToString("yyyy-MM-dd"),
                                                    NHibernateDatabaseFactory.TableName(typeof(Customer)),
                                                    orderBy,
                                                    NHibernateDatabaseFactory.TableName(typeof(CategoryItem)),
                                                    companyId
                                                    ));
        }

        public DataTable SalesPerformance(Dictionary<string, object> dictionary)
        {
            var startDate = DateTime.Parse(dictionary["startDate"].ToString());
            var endDate = DateTime.Parse(dictionary["endDate"].ToString());
            var deptId = (dictionary["DeptId"] ?? string.Empty).ToString();
            var companyId = dictionary["CompanyId"].ToString();
            string sql;
            if (!string.IsNullOrEmpty(deptId))
            {
                sql = string.Format(
                 @"SELECT R.BUSSINESSPERSON AS ID ,SUM(R.SPENDTOTAL) AS TOTAL,O.REALNAME AS Name  
                    FROM CRM_CUSTORMERCONSUMRECORD R 
                    INNER JOIN HR_RS_Staff O ON O.ID = R.BUSSINESSPERSON
                    WHERE O.DeptID = {0} AND TO_CHAR(R.CREATETIME,'yyyy-mm-dd') >= '{1}'  
                    AND TO_CHAR(R.CREATETIME,'yyyy-mm-dd') <='{2}' AND R.DELETED <> 1
                    GROUP BY R.BUSSINESSPERSON,O.REALNAME",
                 deptId, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
            }
            else
            {
                sql =
                    string.Format(
                        @"SELECT D.ID,D.DEPTNAME AS Name ,SUM(R.SPENDTOTAL) AS TOTAL  
                            FROM CRM_CUSTORMERCONSUMRECORD R 
                            INNER JOIN HR_RS_Staff O ON O.ID = R.BUSSINESSPERSON
                            INNER JOIN Sys_Dept D ON O.DEPTID = D.ID
                            WHERE O.COMPANYID = {0} AND TO_CHAR(R.CREATETIME,'yyyy-mm-dd') >= '{1}'  
                            AND TO_CHAR(R.CREATETIME,'yyyy-mm-dd') <='{2}' AND R.DELETED <> 1
                            GROUP BY D.ID,D.DEPTNAME",
                        string.IsNullOrEmpty(companyId) ? "0" : companyId, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
            }

            return this.ExecuteDataTable(sql);
        }

        public DataTable GetCustomerCategory(Dictionary<string, object> dict)
        {
            string strSql = "";
            // 
            if (string.IsNullOrEmpty("" + dict["CategoryID"]))
            {
                strSql = string.Format(@"select name,count(name) as totalCount from(
select D.Name,D.OrderIndex from
(select B.Parentitemid from( select CustomerType from Crm_Customer where deleted=0
and createtime  between to_date('{0}','yyyy-mm-dd') and  to_date('{1}','yyyy-mm-dd') and company = {2})A
left join crm_categoryitem B on A.CustomerType=B.ID)C
left join crm_categoryitem D on C.Parentitemid = D.ID)
group by Name,OrderIndex 
order by OrderIndex", dict["startDate"], dict["endDate"], dict["CompanyId"]);
            }
            else // 
            {
                strSql = string.Format(@"select name,count(name) as totalCount from(
select B.ID,B.Name,B.Parentitemid,B.Orderindex from( select CustomerType from Crm_Customer where deleted=0 
and createtime  between to_date('{0}','yyyy-mm-dd') and  to_date('{1}','yyyy-mm-dd') and company = {3} )A
left join crm_categoryitem B on A.CustomerType=B.ID
where parentitemid = '{2}')
group by Name,OrderIndex 
order by OrderIndex", dict["startDate"], dict["endDate"], dict["CategoryID"], dict["CompanyId"]);
            }
            return ExecuteDataTable(strSql);
        }

        public DataTable ConsumRecord(Dictionary<string, object> dictionary)
        {
            var startDate = DateTime.Parse(dictionary["startDate"].ToString());
            var endDate = DateTime.Parse(dictionary["endDate"].ToString());
            string groupBy = "TO_CHAR(C.CONSUMPTIONDATE,'yyyy-mm')";
            if (endDate.Subtract(startDate).TotalDays > 365) // 大于一年 安装年统计
            {
                groupBy = "TO_CHAR(C.CONSUMPTIONDATE,'yyyy')";
            }
            string sql =
                string.Format(
                    @"SELECT COUNT(C.ID) AS COUNT,{2} AS Name FROM CRM_CUSTORMERCONSUMRECORD C 
WHERE C.DELETED <> 1 AND (C.CONSUMPTIONDATE BETWEEN to_date('{0}','yyyy-mm-dd') AND to_date('{1}','yyyy-mm-dd')) And C.COMPANY = {3}
GROUP BY {2}", startDate.ToString("yyyy-MM-dd"), endDate.AddDays(1).ToString("yyyy-MM-dd"), groupBy, dictionary["CompanyId"]);
            return this.ExecuteDataTable(sql);
        }

        public DataTable Complaints(Dictionary<string, object> dictionary)
        {
            var startDate = DateTime.Parse(dictionary["startDate"].ToString());
            var endDate = DateTime.Parse(dictionary["endDate"].ToString());
            string groupBy = "TO_CHAR(C.SUGGESTDATE,'yyyy-mm')";
            if (endDate.Subtract(startDate).TotalDays > 365) // 大于一年 安装年统计
            {
                groupBy = "TO_CHAR(C.SUGGESTDATE,'yyyy')";
            }
            string sql =
                string.Format(
                    @"SELECT COUNT(C.ID) AS COUNT,{2} AS Name FROM CRM_SUGGEST C 
WHERE C.DELETED <> 1 AND (C.SUGGESTDATE BETWEEN to_date('{0}','yyyy-mm-dd') AND to_date('{1}','yyyy-mm-dd')) And C.COMPANY = {3}
And C.SuggestComplaints = 1
GROUP BY {2}", startDate.ToString("yyyy-MM-dd"), endDate.AddDays(1).ToString("yyyy-MM-dd"), groupBy, dictionary["CompanyId"]);
            return this.ExecuteDataTable(sql);
        }
    }
}
