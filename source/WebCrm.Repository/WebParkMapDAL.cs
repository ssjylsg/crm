using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WebCX.Model;
using WebCX.DAL.Common;
using NHibernate;

namespace WebCX.DAL
{
    public class WebParkMapDAL:DALBase<WEB_PARK_MAP>
    {
        public WebParkMapDAL()
        {
            TableName = "WEB_PARK_MAP";
        }

        public void Delete(int id)
        {
            //control.Delete(new WEB_PARK_MAP() { ID = id });
            ISession session = NHelper.GetCurrentSession();
            IQuery query = session.CreateQuery(string.Format("update WEB_PARK_MAP set DELETED = 1 where ID={0}", id));
            query.ExecuteUpdate();
        }

        public DataTable GetAll()
        {
            string strSql = "select * from WEB_PARK_MAP where DELETED !=1";
            return NHelper.ExecuteDataSet(strSql).Tables[0];
        }

        

        /// <summary>
        /// 修改默认
        /// </summary>
        /// <param name="id"></param>
        public void SetDefaultMap(int id)
        {
            ISession session = NHelper.GetCurrentSession();
            ITransaction transaction = session.BeginTransaction();
            try
            {
                string strSql = "update WEB_PARK_MAP set ISDEFAULT = 0";
                string strSql2 = string.Format("update WEB_PARK_MAP set ISDEFAULT = 1 where ID={0}", id);
                session.CreateSQLQuery(strSql).ExecuteUpdate();
                session.CreateSQLQuery(strSql2).ExecuteUpdate();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                session.Close();
            }
        }
    }
}
