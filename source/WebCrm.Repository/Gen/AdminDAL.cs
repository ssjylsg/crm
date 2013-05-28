
/*--------------------------------------------------------------------
 // 版权所有 Copyright (C) 2012 MicroSoft
 // 项目名称：Project
 // 文件名：Admin.cs
 // 创建者： 
 // 创建时间：2012-6-5
 // 文件功能描述：Tbl_Admin数据访问类
 //
 //-------------------------------------------------------------------
 // 修改者：
 // 修改时间：
 // 修改描述：
 //
//------------------------------------------------------------------*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

using SendInfo.Common;
using DPXS.Model;

namespace DPXS.DAL
{
    /// <summary>
    /// 数据层访问类 AdminDAL
    /// </summary>
    public partial class AdminDAL : DALBase
    {
        public AdminDAL()
        {
            TableName = "Tbl_Admin";

            InsertSql = "insert into Tbl_Admin([CreateTime],[Email],[LastLoginTime],[Password],[Phone],[QQ],[RealName],[Remark],[Status],[Tel],[UpdateTime],[UserName],ID)values(@CreateTime,@Email,@LastLoginTime,@Password,@Phone,@QQ,@RealName,@Remark,@Status,@Tel,@UpdateTime,@UserName,@ID)";
            UpdateSql = "update Tbl_Admin set [CreateTime] = @CreateTime,[Email] = @Email,[LastLoginTime] = @LastLoginTime,[Password] = @Password,[Phone] = @Phone,[QQ] = @QQ,[RealName] = @RealName,[Remark] = @Remark,[Status] = @Status,[Tel] = @Tel,[UpdateTime] = @UpdateTime,[UserName] = @UserName where ID = @ID";
            DeleteSql = "delete * from Tbl_Admin where ID = @ID";
            GetModelSql = "select * from Tbl_Admin where ID = @ID";
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public bool Insert(AdminModel model)
        {
            var db = base.DB;
            var cmd = db.GetSqlStringCommand(InsertSql);
            BindParameters(db, cmd, model);
            return db.ExecuteNonQuery(cmd) > 0 ? true : false;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public bool Update(AdminModel model)
        {
            var db = base.DB;
            var cmd = db.GetSqlStringCommand(UpdateSql);
            BindParameters(db, cmd, model);
            return db.ExecuteNonQuery(cmd) > 0 ? true : false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="ID">主键</param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            var db = base.DB;
            var cmd = db.GetSqlStringCommand(DeleteSql);
            db.AddInParameter(cmd, "@ID", DbType.Int32, id);
            return db.ExecuteNonQuery(cmd) > 0 ? true : false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public bool Delete(string condition)
        {
            var db = base.DB;
            var cmd = db.GetSqlStringCommand(string.Format("delete from {0} {1}",
                            "Tbl_Admin",
                            condition.Length > 0 ? " where " + condition : ""));

            return db.ExecuteNonQuery(cmd) > 0 ? true : false;
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="ID">主键</param>
        /// <returns></returns>
        public AdminModel GetModel(int id)
        {
            AdminModel model = null;

            var db = base.DB;
            var cmd = db.GetSqlStringCommand(GetModelSql);
            db.AddInParameter(cmd, "@ID", DbType.Int32, id);
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    model = BindModel(reader);
                }
            }

            return model;
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public AdminModel GetModel(string condition)
        {
            AdminModel model = null;

            List<AdminModel> list = GetList(condition, string.Empty, 1);

            if (list.Count > 0)
                model = list[0];

            return model;
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="orderBy">排序</param>
        /// <param name="count">记录数</param>
        /// <returns>集合</returns>
        public List<AdminModel> GetList(string condition, string orderBy, int count)
        {
            return GetList<AdminModel>(condition, orderBy, count, BindModel);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="orderBy">排序</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页显示大小</param>
        /// <param name="recordCount">总数</param>
        /// <returns>集合</returns>
        public List<AdminModel> GetList(string condition, string orderBy, int pageIndex, int pageSize, out int recordCount)
        {
            return GetList<AdminModel>(condition, orderBy, pageIndex, pageSize, out recordCount, BindModel);
        }

        /// <summary>
        /// 绑定实体
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private AdminModel BindModel(IDataReader reader)
        {
            var model = new AdminModel();

            model.CreateTime = reader["CreateTime"].ToString();
            model.Email = reader["Email"].ToString();
            model.ID = Convert.ToInt32(reader["ID"]);
            model.LastLoginTime = reader["LastLoginTime"].ToString();
            model.Password = reader["Password"].ToString();
            model.Phone = reader["Phone"].ToString();
            model.QQ = reader["QQ"].ToString();
            model.RealName = reader["RealName"].ToString();
            model.Remark = reader["Remark"].ToString();
            model.Status = Convert.ToInt32(reader["Status"]);
            model.Tel = reader["Tel"].ToString();
            model.UpdateTime = reader["UpdateTime"].ToString();
            model.UserName = reader["UserName"].ToString();

            return model;
        }

        /// <summary>
        /// 绑定cmd参数
        /// </summary>
        /// <param name="cmd"></param>
        private void BindParameters(Database db, DbCommand cmd, AdminModel model)
        {
            db.AddInParameter(cmd, "@CreateTime", DbType.String, model.CreateTime);
            db.AddInParameter(cmd, "@Email", DbType.String, model.Email);
            db.AddInParameter(cmd, "@LastLoginTime", DbType.String, model.LastLoginTime);
            db.AddInParameter(cmd, "@Password", DbType.String, model.Password);
            db.AddInParameter(cmd, "@Phone", DbType.String, model.Phone);
            db.AddInParameter(cmd, "@QQ", DbType.String, model.QQ);
            db.AddInParameter(cmd, "@RealName", DbType.String, model.RealName);
            db.AddInParameter(cmd, "@Remark", DbType.String, model.Remark);
            db.AddInParameter(cmd, "@Status", DbType.Int32, model.Status);
            db.AddInParameter(cmd, "@Tel", DbType.String, model.Tel);
            db.AddInParameter(cmd, "@UpdateTime", DbType.String, model.UpdateTime);
            db.AddInParameter(cmd, "@UserName", DbType.String, model.UserName);
            db.AddInParameter(cmd, "@ID", DbType.Int32, model.ID);
        }
    }
}
