using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.DAL;
using WebCX.Model;
using System.Data;
using WebCX.DAL.Common;

namespace WebCX.DAL
{
    public class RepCategoryDAL : DALBase<SYS_REPCATEGORY>
    {
        public RepCategoryDAL()
        {
            TableName = "SYS_REPCATEGORY";
        }

        public void Delete(int id)
        {
            control.Delete(new SYS_REPCATEGORY() { ID = id });
        }

        public DataTable GetAll()
        {
            string strSql = "select * from SYS_REPCATEGORY";
            return NHelper.ExecuteDataSet(strSql).Tables[0];
        }
    }
}
