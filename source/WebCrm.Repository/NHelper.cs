using System;
using System.Data;
using NHibernate;
using WebCrm.Framework.Repositories;

namespace WebCrm.Dao
{
    internal class NHelper
    {
        private static ISession GetCurrentSession()
        {
            ISession session = NHibernateDatabaseFactory.GetSession();
            return session;
        }
        private static IDbCommand CreateDbCommand()
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
        public static DataSet ExecuteDataSet(string sql)
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
        public static int GetScalar(string sql)
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
        public static int GetTotalCount(string tableName, string where = null)
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
        public static DataTable GetStatisticsData(string tableName, string timeField, DateTime dateBegin, DateTime dateEnd, string type = "", string filterSql = "")
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
        public static DataTable GetStatisticsData(string tableName, string timeField, DateTime dateBegin, DateTime dateEnd, string sumField, string type = "", string filterSql = "")
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


    }
}
