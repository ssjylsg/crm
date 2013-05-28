using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

using SendInfo.Common;

namespace DPXS.DAL
{
    public class DALBase
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName = string.Empty;

        /// <summary>
        /// 添加SQL
        /// </summary>
        protected string InsertSql = string.Empty;

        /// <summary>
        /// 更新SQL
        /// </summary>
        protected string UpdateSql = string.Empty;

        /// <summary>
        /// 删除SQL
        /// </summary>
        protected string DeleteSql = string.Empty;

        /// <summary>
        /// 获取实体SQL
        /// </summary>
        protected string GetModelSql = string.Empty;

        /// <summary>
        /// 数据库对象
        /// </summary>
        public Database DB
        {
            get { return DatabaseFactory.CreateDatabase(); }
        }

        /// <summary>
        /// 获取新ID
        /// </summary>
        /// <returns></returns>
        public int GetNewID()
        {
            int result = 0;
            string strSql = string.Empty;

            var db = this.DB;
            strSql = string.Format("select ID from Tbl_MaxID where Name = '{0}'", TableName);
            result = Convert.ToInt32(db.ExecuteScalar(CommandType.Text, strSql));

            if (result < 1)
                strSql = string.Format("insert into Tbl_MaxID(Name, ID)values('{0}', {1})", TableName, 1);
            else
                strSql = string.Format("update Tbl_MaxID set ID = ID + 1 where Name = '{0}'", TableName);
            db.ExecuteNonQuery(CommandType.Text, strSql);

            return result + 1;
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public int Count(string condition)
        {
            string strSql = string.Format("select count(*) from {0} {1}",
                TableName,
                condition.Length > 0 ? " where " + condition : "");

            var db = this.DB;
            return Convert.ToInt32(db.ExecuteScalar(CommandType.Text, strSql));
        }

        /// <summary>
        /// 获取记录列表
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<T> GetList<T>(string condition, string orderBy, int pageIndex, int pageSize, out int recordCount, Func<IDataReader, T> BindEntity)
        {
            var list = new List<T>();
            string sql;

            // 排序
            if (!orderBy.IsNullOrEmpty())
                orderBy = " order by " + orderBy;
            else
                orderBy = " order by ID desc";

            // sql语句
            var sb = new StringBuilder();
            sb.Append(" select top #pageSize# * from #tableName# ");

            if (pageIndex <= 1)
                sb.Append(" #condition# #orderBy#");
            else
                sb.Append(" where ID not in(select top #pageSize_temp# ID from #tableName# #condition# #orderBy#) #condition_temp# #orderBy#");            

            // 替换sql语句
            sb.Replace("#pageSize#", pageSize.ToString());
            sb.Replace("#tableName#", TableName);
            sb.Replace("#pageSize_temp#", ((pageIndex - 1) * pageSize).ToString());
            sb.Replace("#condition#", condition.IsNullOrEmpty() ? "" : " where " + condition);
            sb.Replace("#condition_temp#", condition.IsNullOrEmpty() ? "" : " and " + condition);
            sb.Replace("#orderBy#", orderBy);
            sql = sb.ToString();

            // 提交数据库查询
            var db = this.DB;
            using (var reader = db.ExecuteReader(CommandType.Text, sql))
            {
                while (reader.Read())
                    list.Add(BindEntity(reader));
            }

            sql = string.Format("select count(*) from {0} {1}", TableName, condition.IsNullOrEmpty() ? "" : " where " + condition);
            recordCount = (int)db.ExecuteScalar(CommandType.Text, sql);

            return list;
        }

        /// <summary>
        /// 获取记录列表
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="orderBy"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<T> GetList<T>(string condition, string orderBy, int recordCount, Func<IDataReader, T> BindEntity)
        {
            var list = new List<T>();
            string strSql;

            strSql = string.Format("select top {0} * from [{1}]", recordCount, TableName);

            if (!condition.IsNullOrEmpty())
                strSql += " where " + condition;

            if (!orderBy.IsNullOrEmpty())
                strSql += " order by " + orderBy;

            var db = this.DB;
            using (var reader = db.ExecuteReader(CommandType.Text, strSql))
            {
                while (reader.Read())
                    list.Add(BindEntity(reader));
            }

            return list;
        }
    }
}
