using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.Model;
using System.Data;
using WebCX.DAL.Common;
using NHibernate;

namespace WebCX.DAL
{
    public class WebSysRoleDAL : DALBase<WEB_SYS_ROLE>
    {
        public WebSysRoleDAL()
        {
            TableName = "WEB_SYS_ROLE";
        }

        public void Delete(int id)
        {
            //control.Delete(new WEB_SYS_ROLE() { ID = id });
            ISession session = NHelper.GetCurrentSession();
            IQuery query = session.CreateQuery(string.Format("update WEB_SYS_ROLE set DELETED = 1 where ID={0}", id));
            query.ExecuteUpdate();
        }
        public DataTable GetAll()
        {
            string strSql = "select * from WEB_SYS_ROLE";
            return NHelper.ExecuteDataSet(strSql).Tables[0];
        }
    }
}
