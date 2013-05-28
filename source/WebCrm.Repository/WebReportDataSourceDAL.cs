using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.Model;
using NHibernate;
using WebCX.DAL.Common;
using System.Data;

namespace WebCX.DAL
{
    public class WebReportDataSourceDAL: DALBase<WEB_REPORT_DATASOURCE>
    {
        public WebReportDataSourceDAL()
        {
            TableName = "WEB_REPORT_DATASOURCE";
        }

        public void Delete(int id)
        {
            //control.Delete(new WEB_REPORT_DATASOURCE() { ID = id });
            ISession session = NHelper.GetCurrentSession();
            IQuery query = session.CreateQuery(string.Format("update WEB_REPORT_DATASOURCE set DELETED = 1 where ID={0}", id));
            query.ExecuteUpdate();
        }
        public DataTable GetAll()
        {
            string strSql = "select * from WEB_REPORT_DATASOURCE";
            return NHelper.ExecuteDataSet(strSql).Tables[0];
        }
    }
}
