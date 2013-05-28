using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.Model;
using WebCX.DAL.Common;
using System.Data;

namespace WebCX.DAL
{
    public class RoleDAL: DALBase<SYS_ROLE>
    {
        public RoleDAL()
        {
            TableName = "SYS_USER";
        }

        public void Delete(int id)
        {
            control.Delete(new SYS_ROLE() { ID = id });
        }
        public DataTable GetAll()
        {
            string strSql = "select * from SYS_ROLE";
            return NHelper.ExecuteDataSet(strSql).Tables[0];
        }
    }
}
