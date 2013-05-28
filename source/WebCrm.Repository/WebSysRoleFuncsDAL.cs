using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.Model;
using System.Data;
using WebCX.DAL.Common;

namespace WebCX.DAL
{
    public class WebSysRoleFuncsDAL : DALBase<WEB_SYS_ROLEFUNCS>
    {
        public WebSysRoleFuncsDAL()
        {
            TableName = "WEB_SYS_ROLEFUNCS";
        }

        public void Delete(int id)
        {
            control.Delete(new WEB_SYS_ROLEFUNCS() { ID = id });
        }
        public DataTable GetAll()
        {
            string strSql = "select * from WEB_SYS_ROLEFUNCS where DELETED !=1";
            return NHelper.ExecuteDataSet(strSql).Tables[0];
        }

        public void DeleteByRoleIDAndFuncID(string roleID,string funcID,string ftype)
        {
            //string strSql = string.Format("from WEB_SYS_ROLEFUNCS where ROLE_ID='{0}' and FUNC_ID='{1}'", roleID, funcID);
            //var session = NHelper.GetCurrentSession();
            //session.Delete(strSql);
            //session.Close();

            string strSql = string.Format("delete WEB_SYS_ROLEFUNCS where ROLE_ID='{0}' and FUNC_ID='{1}' and FTYPE='{2}'", roleID, funcID,ftype);
            var session = NHelper.GetCurrentSession();
            session.CreateQuery(strSql).ExecuteUpdate();
            session.Close();
        }
        
    }
}
