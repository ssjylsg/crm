
/*--------------------------------------------------------------------
 // 版权所有 Copyright (C) 2012 MicroSoft
 // 项目名称：Project
 // 文件名：Admin.cs
 // 创建者： 
 // 创建时间：2012-6-5
 // 文件功能描述：Tbl_Admin逻辑处理层
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

using SendInfo.Common;
using DPXS.Model;
using DPXS.DAL;

namespace DPXS.BLL
{
    /// <summary>
    /// 逻辑处理服务类 Admin
    /// </summary>
    public partial class AdminBLL 
    {
        private readonly AdminDAL dal = new AdminDAL();
        public static readonly AdminBLL Instance = new AdminBLL();

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool Insert(AdminModel model)
        {
            return dal.Insert(model);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool Update(AdminModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }
        
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public bool Delete(string condition)
        {
            return dal.Delete(condition);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public AdminModel GetModel(int id)
        {
            return dal.GetModel(id);
        }
        
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public AdminModel GetModel(string condition)
        {
            return dal.GetModel(condition);
        }

        /// <summary>
        /// 获取主键ID
        /// </summary>
        public int GetNewID()
        {
            return dal.GetNewID();
        }
        
        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="condition">条件</param>
        public int Count(string condition)
        {
            return dal.Count(condition);
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        public List<AdminModel> GetList()
        {
            return GetList(string.Empty);
        }

        /// <summary>
        /// 根据条件，获取所有数据
        /// </summary>
        public List<AdminModel> GetList(string condition)
        {
            return dal.GetList(condition, "ID desc", 99999);
        }
        
        /// <summary>
        /// 根据条件，获取所有数据
        /// </summary>
        public List<AdminModel> GetList(string condition, int recordCount)
        {
            return dal.GetList(condition, "ID desc", recordCount);
        }
    
        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="orderBy">排序</param>
        /// <param name="recordCount">记录数</param>
        /// <returns>集合</returns>
        public List<AdminModel> GetList(string condition, string orderBy, int recordCount)
        {
            return dal.GetList(condition, orderBy, recordCount);
        }


        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="orderBy">排序</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页显示数量</param>
        /// <param name="recordCount">总数</param>
        /// <returns>集合</returns>
        public List<AdminModel> GetList(string condition, string orderBy, int pageIndex, int pageSize, out int recordCount)
        {
            return dal.GetList(condition, orderBy, pageIndex, pageSize, out recordCount);
        }
    }
    
}
