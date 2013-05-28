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
    public class WebReportInfoDAL : DALBase<WEB_REPORT_INFO>
    {
        public WebReportInfoDAL()
        {
            TableName = "WEB_REPORT_INFO";
        }

        public void Delete(int id)
        {
            //control.Delete(new WEB_REPORT_INFO() { ID = id });
            ISession session = NHelper.GetCurrentSession();
            IQuery query = session.CreateQuery(string.Format("update WEB_REPORT_INFO set DELETED = 1 where ID={0}", id));
            query.ExecuteUpdate();
        }
        public DataTable GetAll()
        {
            string strSql = "select * from WEB_REPORT_INFO";
            return NHelper.ExecuteDataSet(strSql).Tables[0];
        }
        /// <summary>
        /// 根据ID修改模版文件字段
        /// </summary>
        /// <param name="newFileName"></param>
        public void UpdateFilePath(string id,string newFileName)
        {
            ISession session = NHelper.GetCurrentSession();
            IQuery query = session.CreateQuery(string.Format("update WEB_REPORT_INFO set FILEPATH='{0}' where ID={1}", newFileName,id));
            query.ExecuteUpdate();
        }
    }
}
