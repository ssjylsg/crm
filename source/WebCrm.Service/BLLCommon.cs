using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WebCX.DAL.Common;

namespace WebCX.BLL
{
    public class BLLCommon
    {
        /// <summary>
        /// 执行SQL返回DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string sql)
        {
            return NHelper.ExecuteDataSet(sql);
        }

        /// <summary>
        /// 获取第一行第一列数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int GetScalar(string sql)
        {
            return NHelper.GetScalar(sql);
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public static int GetTotalCount(string tableName, string where = null)
        {
            return NHelper.GetTotalCount(tableName, where);
        }
    }
}
