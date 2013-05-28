using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.DAL;
using WebCX.Model;
using System.Data;

namespace WebCX.BLL
{
    public class WebSysRoleBLL
    {
        private WebSysRoleDAL dal;
        public static readonly WebSysRoleBLL Instance = new WebSysRoleBLL();

        public WebSysRoleBLL()
        {
            dal = new WebSysRoleDAL();
        }

        public void SaveOrUpdate(WEB_SYS_ROLE model)
        {
            dal.SaveOrUpdate(model);
        }

        public void Delete(int id)
        {
            dal.Delete(id);
        }

        public WEB_SYS_ROLE GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public IList<WEB_SYS_ROLE> GetAllList(string condition = "", string orderBy = "")
        {
            return dal.GetAllList(condition, orderBy);
        }

        public IList<WEB_SYS_ROLE> GetPageList(int pageIndex, int pageSize, string condition = "", string orderBy = "")
        {
            return dal.GetPageList(pageIndex, pageSize, condition, orderBy);
        }

        public DataTable GetAll()
        {
            return dal.GetAll();
        }
    }
}
