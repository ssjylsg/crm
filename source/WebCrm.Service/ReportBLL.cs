using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.DAL;
using WebCX.Model;
using System.Data;

namespace WebCX.BLL
{
     public class ReportBLL
    {
        private ReportDAL dal;
        public static readonly ReportBLL Instance = new ReportBLL();   

        public ReportBLL()
        {
            dal = new ReportDAL();
        }

        public void SaveOrUpdate(SYS_REPORT model)
        {
            dal.SaveOrUpdate(model);
        }

        public void Delete(int id)
        {
            dal.Delete(id);
        }

        public SYS_REPORT GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public IList<SYS_REPORT> GetAllList(string condition = "", string orderBy = "")
        {
            return dal.GetAllList(condition, orderBy);
        }

        public IList<SYS_REPORT> GetPageList(int pageIndex, int pageSize, string condition = "", string orderBy = "")
        {
            return dal.GetPageList(pageIndex, pageSize, condition, orderBy);
        }

        public DataTable GetAll()
        {
            return dal.GetAll();
        }
    }
}
