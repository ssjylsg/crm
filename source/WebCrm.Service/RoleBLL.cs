using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.DAL;
using WebCX.Model;
using System.Data;

namespace WebCX.BLL
{
    public class RoleBLL
    {
        private RoleDAL dal;
        public static readonly RoleBLL Instance = new RoleBLL();

        public RoleBLL()
        {
            dal = new RoleDAL();
        }

        public void SaveOrUpdate(SYS_ROLE model)
        {
            dal.SaveOrUpdate(model);
        }

        public void Delete(int id)
        {
            dal.Delete(id);
        }

        public SYS_ROLE GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public IList<SYS_ROLE> GetAllList(string condition = "", string orderBy = "")
        {
            return dal.GetAllList(condition, orderBy);
        }

        public IList<SYS_ROLE> GetPageList(int pageIndex, int pageSize, string condition = "", string orderBy = "")
        {
            return dal.GetPageList(pageIndex, pageSize, condition, orderBy);
        }

        public DataTable GetAll()
        {
            return dal.GetAll();
        }
    }
}
