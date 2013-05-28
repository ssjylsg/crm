using System;
using System.Data;
using System.Data.SqlClient;
using NHibernate;

namespace WebCX.DAL
{
    /// <summary>
    /// ֱ������ SQL ����洢����
    /// </summary>
    public static class DirectRun
    {
        /// <summary>
        /// ������Ӧ���еļ�¼��
        /// </summary>
        /// <param name="session">ISession����������IDbConnection</param>
        /// <param name="tableName">���ݿ������</param>
        /// <param name="where">��ѯ����</param>
        /// <returns>���������ļ�¼����</returns>
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
        /// ִ��һ������Ҫ����ֵ�� SqlCommand ����
        /// </summary>
        /// <param name="session">ISession����������IDbConnection</param>
        /// <param name="tableName">���ݿ������</param>
        /// <returns>������Ӱ��ļ�¼����</returns>
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
