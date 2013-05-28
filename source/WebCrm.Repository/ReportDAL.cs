using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.Model;
using System.Data;
using WebCX.DAL.Common;

namespace WebCX.DAL
{
    public class ReportDAL : DALBase<SYS_REPORT>
    {
        public ReportDAL()
        {
            TableName = "SYS_REPORT";
        }

        public void Delete(int id)
        {
            control.Delete(new SYS_REPORT() { ID = id });
        }
        public DataTable GetAll()
        {
            string strSql = "select * from SYS_REPORT";
            return NHelper.ExecuteDataSet(strSql).Tables[0];
        }
    }
}
