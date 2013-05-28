using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.DAL;
using WebCX.Model;
using System.Data;

namespace WebCX.BLL
{
    public class WebReportParameterBLL
    {
        private WebReportParameterDAL dal;
        public static readonly WebReportParameterBLL Instance = new WebReportParameterBLL();

        public WebReportParameterBLL()
        {
            dal = new WebReportParameterDAL();
        }

        public void SaveOrUpdate(WEB_REPORT_PARAMETER model)
        {
            dal.SaveOrUpdate(model);
        }

        public void Delete(int id)
        {
            dal.Delete(id);
        }

        public WEB_REPORT_PARAMETER GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public WEB_REPORT_PARAMETER GetEntityByWhere(string where)
        {
            return dal.GetEntityByWhere(where);
        }

        public IList<WEB_REPORT_PARAMETER> GetAllList(string condition = "", string orderBy = "")
        {
            return dal.GetAllList(condition, orderBy);
        }

        public IList<WEB_REPORT_PARAMETER> GetPageList(int pageIndex, int pageSize, string condition = "", string orderBy = "")
        {
            return dal.GetPageList(pageIndex, pageSize, condition, orderBy);
        }

        public DataTable GetAll()
        {
            return dal.GetAll();
        }
    }
}
