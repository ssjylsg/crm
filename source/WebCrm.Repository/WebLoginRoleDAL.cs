using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.Model;
using System.Data;
using WebCX.DAL.Common;

namespace WebCX.DAL
{
    public class WebLoginRoleDAL: DALBase<WEB_LOGIN_ROLE>
    {
        public WebLoginRoleDAL()
        {
            TableName = "WEB_LOGIN_ROLE";
        }

        public void Delete(int id)
        {
            control.Delete(new WEB_LOGIN_ROLE() { ID = id });
        }
        public DataTable GetAll()
        {
            string strSql = "select * from WEB_LOGIN_ROLE where DELETED !=1";
            return NHelper.ExecuteDataSet(strSql).Tables[0];
        }

        public void DeleteByRoleIDAndUserID(string roleID, string userID)
        {
            //string strSql = string.Format("from WEB_LOGIN_ROLE where ROLE_ID={0} and LOGIN_ID={1}", roleID, userID);
            //var session = NHelper.GetCurrentSession();
            //session.Delete(strSql);
            //session.Close();

            string strSql = string.Format("delete WEB_LOGIN_ROLE where ROLE_ID={0} and LOGIN_ID={1}", roleID, userID);
            var session = NHelper.GetCurrentSession();
            session.CreateQuery(strSql).ExecuteUpdate();
            session.Close();
        }
    }
}
