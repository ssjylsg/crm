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
    public class WebSysFunctionsDAL : DALBase<WEB_SYS_FUNCTIONS>
    {
        public WebSysFunctionsDAL()
        {
            TableName = "WEB_SYS_FUNCTIONS";
        }

        public void Delete(int id)
        {
            control.Delete(new WEB_SYS_FUNCTIONS() { ID = id });
        }
        public DataTable GetAll()
        {
            string strSql = "select * from WEB_SYS_FUNCTIONS where DELETED !=1";
            return NHelper.ExecuteDataSet(strSql).Tables[0];
        }


    }
}
