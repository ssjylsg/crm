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
    public class WebReportParameterDAL: DALBase<WEB_REPORT_PARAMETER>
    {
        public WebReportParameterDAL()
        {
            TableName = "WEB_REPORT_PARAMETER";
        }

        public void Delete(int id)
        {
            //control.Delete(new WEB_REPORT_PARAMETER() { ID = id });
            ISession session = NHelper.GetCurrentSession();
            IQuery query = session.CreateQuery(string.Format("update WEB_REPORT_PARAMETER set DELETED = 1 where ID={0}", id));
            query.ExecuteUpdate();
        }
        public DataTable GetAll()
        {
            string strSql = "select * from WEB_REPORT_PARAMETER";
            return NHelper.ExecuteDataSet(strSql).Tables[0];
        }
    }
}
