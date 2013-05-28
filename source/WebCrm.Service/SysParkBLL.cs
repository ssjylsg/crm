using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.DAL;
using WebCX.Model;
using System.Data;

namespace WebCX.BLL
{
    public class SysParkBLL
    {
        private SysParkDAL dal;
        public static readonly SysParkBLL Instance = new SysParkBLL();

        public SysParkBLL()
        {
            dal = new SysParkDAL();
        }

        public void SaveOrUpdate(SYS_PARK model)
        {
            dal.SaveOrUpdate(model);
        }

        public void Delete(int id)
        {
            dal.Delete(id);
        }

        public SYS_PARK GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public IList<SYS_PARK> GetAllList(string condition = "", string orderBy = "")
        {
            return dal.GetAllList(condition, orderBy);
        }

        public IList<SYS_PARK> GetPageList(int pageIndex, int pageSize, string condition = "", string orderBy = "")
        {
            return dal.GetPageList(pageIndex, pageSize, condition, orderBy);
        }

        public DataTable GetAll()
        {
            return dal.GetAll();
        }
    }
}
