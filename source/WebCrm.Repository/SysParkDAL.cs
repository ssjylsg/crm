using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.Model;
using System.Data;
using WebCX.DAL.Common;

namespace WebCX.DAL
{
    public class SysParkDAL : DALBase<SYS_PARK>
    {
        public SysParkDAL()
        {
            TableName = "SYS_PARK";
        }

        public void Delete(int id)
        {
            control.Delete(new SYS_PARK() { ID = id });
        }
        public DataTable GetAll()
        {
            string strSql = "select * from SYS_PARK where DELETED !=1";
            return NHelper.ExecuteDataSet(strSql).Tables[0];
        }
    }
}
