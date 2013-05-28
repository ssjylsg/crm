
/*--------------------------------------------------------------------
 // 版权所有 Copyright (C) 2011 MicroSoft
 // 项目名称：Project
 // 文件名：Admin.cs
 // 创建者： 
 // 创建时间：2011-7-9
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
        /// <summary>
        /// 根据用户名，获取实体
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public AdminModel GetModelByUserName(string userName)
        {
            return dal.GetModel(string.Format(" UserName='{0}'", userName));
        }

        /// <summary>
        /// 用户名是否存在
        /// </summary>
        /// <returns></returns>
        public bool ExistUserName(string userName)
        {
            var model = GetModelByUserName(userName);
            return model != null;
        }
    }
    
}
