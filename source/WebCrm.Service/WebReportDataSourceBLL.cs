using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.DAL;
using WebCX.Model;
using System.Data;

namespace WebCX.BLL
{
    public class WebReportDataSourceBLL
    {
        private WebReportDataSourceDAL dal;
        public static readonly WebReportDataSourceBLL Instance = new WebReportDataSourceBLL();

        public WebReportDataSourceBLL()
        {
            dal = new WebReportDataSourceDAL();
        }

        public void SaveOrUpdate(WEB_REPORT_DATASOURCE model)
        {
            dal.SaveOrUpdate(model);
        }

        public void Delete(int id)
        {
            dal.Delete(id);
        }

        public WEB_REPORT_DATASOURCE GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public WEB_REPORT_DATASOURCE GetEntityByWhere(string where)
        {
            return dal.GetEntityByWhere(where);
        }

        public IList<WEB_REPORT_DATASOURCE> GetAllList(string condition = "", string orderBy = "")
        {
            return dal.GetAllList(condition, orderBy);
        }

        public IList<WEB_REPORT_DATASOURCE> GetPageList(int pageIndex, int pageSize, string condition = "", string orderBy = "")
        {
            return dal.GetPageList(pageIndex, pageSize, condition, orderBy);
        }

        public DataTable GetAll()
        {
            return dal.GetAll();
        }
    }
}
