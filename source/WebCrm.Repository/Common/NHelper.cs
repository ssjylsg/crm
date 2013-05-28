using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NHibernate;

namespace WebCX.DAL.Common
{
    public class NHelper
    {

        public static readonly string AssemblyName = "WebCX.Model";

        public static ISession GetCurrentSession()
        {
            return SessionFactory.OpenSession(NHelper.AssemblyName);
        }

        /// <summary>
        /// 填充DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string sql)
        {
            ISession session = NHelper.GetCurrentSession();
            DataSet ds = new DataSet();
            try
            {
                IDbCommand command = session.Connection.CreateCommand();
                command.CommandText = sql;

                IDataReader reader = command.ExecuteReader();
                DataTable result = new DataTable();

                //result.Load(reader);//此方法亦可
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

            catch (Exception ex)
            {
            }
            finally
            {
                if (session != null)
                {
                    session.Close();
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
            ISession session = NHelper.GetCurrentSession();
            IDbCommand command = session.Connection.CreateCommand();
            command.CommandText = sql;
            object obj = command.ExecuteScalar();
            if (obj == null)
            {
                return 0;
            }
            else {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public static int GetTotalCount(string tableName, string where=null)
        {
            string sql = string.Format("select count(1) from {0} ",tableName);
            if (!string.IsNullOrEmpty(where))
            {
                sql += " where " + where;
            }
            return GetScalar(sql);
        }

    }
}
