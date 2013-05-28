using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.DAL;
using WebCX.Model;
using System.Data;
using System.Collections;

namespace WebCX.BLL
{
    public class WebLoginInfoBLL
    {
        private WebLoginInfoDAL dal;
        public static readonly WebLoginInfoBLL Instance = new WebLoginInfoBLL();

        public WebLoginInfoBLL()
        {
            dal = new WebLoginInfoDAL();
        }

        public void SaveOrUpdate(WEB_LOGIN_INFO model)
        {
            dal.SaveOrUpdate(model);
        }

        public void Delete(int id)
        {
            dal.Delete(id);
        }

        public WEB_LOGIN_INFO GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public WEB_LOGIN_INFO GetEntityByWhere(string where)
        {
            return dal.GetEntityByWhere(where);
        }

        public IList<WEB_LOGIN_INFO> GetAllList(string condition = "", string orderBy = "")
        {
            return dal.GetAllList(condition, orderBy);
        }

        public IList<WEB_LOGIN_INFO> GetPageList(int pageIndex, int pageSize, string condition = "", string orderBy = "")
        {
            return dal.GetPageList(pageIndex, pageSize, condition, orderBy);
        }

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        /// <summary>
        /// 根据用户ID，获取所有常规功能模块权限ID
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public IList GetFuncsByID(string id)
        {
            return dal.GetFuncsByID(id);
        }

        /// <summary>
        /// 根据用户ID，获取所有常规功能模块权限列表
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public IList GetFunsListByID(string id)
        {
            return dal.GetFunsListByID(id);
        }

        /// <summary>
        /// 根据用户ID，获取所有报表功能模块权限ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public IList GetReportFuncsByUserID(string userID)
        {
            return dal.GetReportFuncsByUserID(userID);
        }


        /// <summary>
        /// 根据用户ID,获取用户对应的手机报表权限列表
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataTable GetPhoneReportListByUserID(string userID)
        {
            return dal.GetPhoneReportListByUserID(userID);
        }

        /// <summary>
        /// 根据用户ID,获取用户对应的Web报表权限列表
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public IList GetWebReportListByUserID(string userID)
        {
            return dal.GetWebReportListByUserID(userID);
        }

        /// <summary>
        /// 用户名重复判断
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns></returns>
        public bool ExistName(string name, string id = "0")
        {
            return dal.ExistName(name, id);
        }
    }
}
