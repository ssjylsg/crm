using System;
using System.Data;
using System.Data.SqlClient;
using NHibernate;

namespace WebCX.DAL
{
    /// <summary>
    /// 直接运行 SQL 语句或存储过程
    /// </summary>
    public static class DirectRun
    {
        /// <summary>
        /// 返回相应表中的记录数
        /// </summary>
        /// <param name="session">ISession，包含连接IDbConnection</param>
        /// <param name="tableName">数据库表名称</param>
        /// <param name="where">查询条件</param>
        /// <returns>符合条件的记录总数</returns>
        public static int GetRecordCount(ISession session, string tableName, string where)
        {
            int recordCount = 0;
            string query = "Select Count(*) From [" + tableName + "]";
            if (!String.IsNullOrEmpty(where) && where != "")
            {
                query += " Where " + where;
            }

            using (session)
            {
                IDbConnection conn = session.Connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = (SqlConnection)conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    recordCount = Convert.ToInt32(dr[0]);
                }
            }

            return recordCount;
        }

        /// <summary>
        /// 执行一个不需要返回值的 SqlCommand 命令
        /// </summary>
        /// <param name="session">ISession，包含连接IDbConnection</param>
        /// <param name="tableName">数据库表名称</param>
        /// <returns>此命令影响的记录条数</returns>
        public static int ExecuteNonQuery(ISession session, string cmdText)
        {
            using (session)
            {
                IDbConnection conn = session.Connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = (SqlConnection)conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = cmdText;

                int val = cmd.ExecuteNonQuery();
                return val;
            }
        }
    }
}
