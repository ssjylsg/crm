using System;
using System.Collections.Generic;
using System.Data;

namespace WebCrm.Model.Services
{
    /// <summary>
    /// 报表服务
    /// </summary>
    public interface IChartService
    {
        /// <summary>
        /// 客户年龄分析
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        DataTable GetCustomerAgeStructure(Dictionary<string, object> dictionary);
        /// <summary>
        /// 执行SQL 返回DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        DataTable ExecuteDataTable(string strSql);
        /// <summary>
        /// 营业收入组成分析
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        DataTable GetIncomeTrend(Dictionary<string, object> dict);
        /// <summary>
        /// 客户分析
        /// </summary>
        DataTable GetCustomerStructure(Dictionary<string, object> dictionary);

        /// <summary>
        /// 销售人员业绩分析
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        DataTable SalesPerformance(Dictionary<string, object> dictionary);

        DataTable GetCustomerCategory(Dictionary<string, object> dict);
        /// <summary>
        /// 回访投诉率
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        DataTable ComplaintsRate(Dictionary<string, object> dictionary);
    }
}
