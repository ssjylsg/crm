using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.Model;
using System.Data;
using WebCX.DAL.Common;
using System.Collections;
using NHibernate;

namespace WebCX.DAL
{
    public class WebReportCategoryDAL:DALBase<WEB_REPORT_CATEGORY>
    {
        public WebReportCategoryDAL()
        {
            TableName = "WEB_REPORT_CATEGORY";
        }

        public void Delete(int id)
        {
            //control.Delete(new WEB_REPORT_CATEGORY() { ID = id });
            ISession session = NHelper.GetCurrentSession();
            IQuery query = session.CreateQuery(string.Format("update WEB_REPORT_CATEGORY set DELETED = 1 where ID={0}", id));
            query.ExecuteUpdate();
        }

        public DataTable GetAll()
        {
            string strSql = "select * from WEB_REPORT_CATEGORY where DELETED !=1";
            return NHelper.ExecuteDataSet(strSql).Tables[0];
        }

        /// <summary>
        /// 获取所有叶子节点ID,和名称路径
        /// </summary>
        /// <returns></returns>
        public IList GetLeafNamePath()
        {
            string strSql = @" select ID,NAME_PATH from(
 select T.ID,T.DELETED,CONNECT_BY_ISLEAF as ISLEAF,
 SUBSTR(SYS_CONNECT_BY_PATH(NAME,'->'),3) as NAME_PATH
 from WEB_REPORT_CATEGORY  T where DELETED=0
 start with PARENTID is null
 connect by prior ID=PARENTID)R 
 where ISLEAF=1  order by NAME_PATH";
            return NHelper.GetCurrentSession().CreateSQLQuery(strSql).List();
        }
    }
}
