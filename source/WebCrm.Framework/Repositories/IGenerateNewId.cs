using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WebCrm.Framework.Repositories
{
    public interface IGenerateNewId
    {
        int GenerateNewId(string keyName, string sqlConnection, int defaultValue = 1);
    }
    public class OracleGenerateNewId : IGenerateNewId
    {
        public int GenerateNewId(string keyName, string connection, int defaultValue = 1)
        {
            int value = 0;
            Guid guid = Guid.NewGuid();
            System.Diagnostics.Trace.WriteLine(connection);
            //TODO 不知道为什么 数据库连接不对
            connection = "User ID=oahr;Password=oahr;Data Source=oahr";
            using (var sqlConnection = new System.Data.OracleClient.OracleConnection(connection))
            {
                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;

                    for (int i = 0; i < 3; i++)
                    {
                        command.CommandText =
                            (string.Format("select MaxRecID from Sys_MaxRecId where TableName ='{0}'", keyName));
                        value = int.Parse((command.ExecuteScalar() ?? "0").ToString());
                        if (value <= 0)
                        {
                            value = defaultValue;
                            command.CommandText =
                                string.Format(
                                    "insert into Sys_MaxRecId(TableName,MaxRecID,Remark) values('{0}', {1}, '{2}')",
                                    keyName, defaultValue, guid);
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            value += 1;
                            command.CommandText =
                                (string.Format(
                                    "update Sys_MaxRecId set MaxRecID = MaxRecID  + 1, Remark = '{0}' where  TableName  =  '{1}'",
                                    guid, keyName));
                            command.ExecuteNonQuery();
                        }
                        command.CommandText =
                            (string.Format("select Remark from Sys_MaxRecId where TableName ='{0}'",
                                           keyName));
                        if ((command.ExecuteScalar() ?? Guid.Empty).ToString() == guid.ToString())
                        {
                            break;
                        }
                    }


                    return value;
                }
            }
        }
    }
    public class SqlServerGenerateNewId : IGenerateNewId
    {
        public int GenerateNewId(string keyName, string connection, int defaultValue = 1)
        {
            int value = 0;
            Guid guid = Guid.NewGuid();
            System.Diagnostics.Trace.WriteLine(connection);
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection(connection))
            {
                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;

                    for (int i = 0; i < 3; i++)
                    {
                        command.CommandText =
                            (string.Format("select MaxRecID from Sys_MaxRecId where TableName ='{0}'", keyName));
                        value = int.Parse((command.ExecuteScalar() ?? "0").ToString());
                        if (value <= 0)
                        {
                            value = defaultValue;
                            command.CommandText =
                                string.Format(
                                    "insert into Sys_MaxRecId(TableName,MaxRecID,Remark) values('{0}', {1}, '{2}')",
                                    keyName, defaultValue, guid);
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            value += 1;
                            command.CommandText =
                                (string.Format(
                                    "update Sys_MaxRecId set MaxRecID = MaxRecID  + 1, Remark = '{0}' where  TableName  =  '{1}'",
                                    guid, keyName));
                            command.ExecuteNonQuery();
                        }
                        command.CommandText =
                            (string.Format("select Remark from Sys_MaxRecId where TableName ='{0}'",
                                           keyName));
                        if ((command.ExecuteScalar() ?? Guid.Empty).ToString() == guid.ToString())
                        {
                            break;
                        }
                    }
                    return value;
                }
            }
        }
    }
}
