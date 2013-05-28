using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.Model;
using System.Data;
using WebCX.DAL.Common;
using NHibernate;
using System.Collections;

namespace WebCX.DAL
{
    public class WebLoginInfoDAL: DALBase<WEB_LOGIN_INFO>
    {
        public WebLoginInfoDAL()
        {
            TableName = "WEB_LOGIN_INFO";
        }

        public void Delete(int id)
        {
            //control.Delete(new WEB_LOGIN_INFO() { ID = id });
            ISession session = NHelper.GetCurrentSession();
            IQuery query = session.CreateQuery(string.Format("update WEB_LOGIN_INFO set DELETED = 1 where ID={0}", id));
            query.ExecuteUpdate();
        }
        public DataTable GetAll()
        {
            string strSql = "select * from WEB_LOGIN_INFO where DELETED !=1";
            return NHelper.ExecuteDataSet(strSql).Tables[0];
        }

        /// <summary>
        /// 根据用户ID，获取所有常规功能模块权限ID
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public IList GetFuncsByID(string id)
        {
            string strSql = string.Format(@"select distinct FUNC_ID from (select * from Web_Login_Role  where LOGIN_ID={0}) LR join Web_Sys_Rolefuncs RF on LR.ROLE_ID=RF.ROLE_ID  where FTYPE=1", id);
            ISQLQuery query = NHelper.GetCurrentSession().CreateSQLQuery(strSql);
            return query.List();
        }

        /// <summary>
        /// 根据用户ID，获取所有报表功能模块权限ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public IList GetReportFuncsByUserID(string userID)
        {
            string strSql = string.Format(@"select distinct FUNC_ID from (select * from Web_Login_Role  where LOGIN_ID={0}) LR join Web_Sys_Rolefuncs RF on LR.ROLE_ID=RF.ROLE_ID  where FTYPE!=1", userID);
            ISQLQuery query = NHelper.GetCurrentSession().CreateSQLQuery(strSql);
            return query.List();
        }


        /// <summary>
        /// 根据用户ID，获取所有常规功能模块权限列表
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public IList GetFunsListByID(string id)
        {
            string strSql = string.Format(@"select F.* from WEB_SYS_FUNCTIONS F join(select distinct FUNC_ID from  
(select ROLE_ID from Web_Login_Role  where LOGIN_ID={0}) LR 
join Web_Sys_Rolefuncs RF on LR.ROLE_ID=RF.ROLE_ID)A on F.ID = A.FUNC_ID order by FUN_SORT", id);
            ISQLQuery query = NHelper.GetCurrentSession().CreateSQLQuery(strSql);
            return query.List();
        }

        /// <summary>
        /// 根据用户ID,获取用户对应的手机报表权限列表
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataTable GetPhoneReportListByUserID(string userID)
        {
            string strSql = string.Format(@"select F.* from WEB_REPORT_INFO F join (select distinct FUNC_ID from  
(select ROLE_ID from Web_Login_Role  where LOGIN_ID={0}) LR 
join Web_Sys_Rolefuncs RF on LR.ROLE_ID=RF.ROLE_ID where FTYPE=6
)A on F.ID = A.FUNC_ID where status=1  and DELETED=0 order by SORT", userID);
            return NHelper.ExecuteDataSet(strSql).Tables[0];
        }

        /// <summary>
        /// 根据用户ID,获取用户对应的Web报表权限列表
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public IList GetWebReportListByUserID(string userID)
        {
            string strSql = string.Format(@"select ID,CATEGORYID,NAME,ISONLINE,FILEPATH from WEB_REPORT_INFO where ID in(
 select distinct FUNC_ID from (select * from Web_Login_Role  where LOGIN_ID={0}) LR 
 join Web_Sys_Rolefuncs RF on LR.ROLE_ID=RF.ROLE_ID  where FTYPE = 5) and status=1  and DELETED=0 order by SORT", userID);
            return NHelper.GetCurrentSession().CreateSQLQuery(strSql).List();
        }


        /// <summary>
        /// 用户名重复判断
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns></returns>
        public bool ExistName(string name,string id="0")
        {
            string strSql = string.Format("select ID from WEB_LOGIN_INFO where LOGIN_NAME='{0}'", name);
            if (id == "0" || string.IsNullOrEmpty(id)) //新增
            {

            }
            else  //编辑
            {
                strSql += string.Format(" and ID !={0}", id);
            }
            int count = NHelper.GetCurrentSession().CreateQuery(strSql).List().Count;
            return count > 0 ? true : false;
        }
    }
}
