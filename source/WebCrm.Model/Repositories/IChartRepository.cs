using System;
using System.Collections.Generic;
using System.Data;

namespace WebCrm.Model.Repositories
{

    public interface IChartRepository
    {
        /// <summary>
        /// 填充DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        DataSet ExecuteDataSet(string sql);

        /// <summary>
        /// 获取第一行第一列数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        int GetScalar(string sql);

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        int GetTotalCount(string tableName, string where = null);

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
        DataTable GetStatisticsData(string tableName, string timeField, DateTime dateBegin, DateTime dateEnd, string type = "", string filterSql = "");

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
        DataTable GetStatisticsData(string tableName, string timeField, DateTime dateBegin, DateTime dateEnd, string sumField, string type = "", string filterSql = "");

        /// <summary>
        /// 客户年龄分析
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        DataTable GetCustomerAgeStructure(Dictionary<string, object> dictionary);

        DataTable ExecuteDataTable(string strSql);

        /// <summary>
        /// 消费组成
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        DataTable GetIncomeTrend(Dictionary<string, object> dict);

        DataTable GetCustomerStructure(Dictionary<string, object> dictionary);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        DataTable SalesPerformance(Dictionary<string, object> dictionary);

        DataTable GetCustomerCategory(Dictionary<string, object> dict);
        /// <summary>
        /// 消费记录
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        DataTable ConsumRecord(Dictionary<string, object> dictionary);
        /// <summary>
        /// 投诉数据
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        DataTable Complaints(Dictionary<string, object> dictionary);
    }
}

