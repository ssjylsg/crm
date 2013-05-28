using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.DAL;
using WebCX.Model;
using System.Data;

namespace WebCX.BLL
{
    public class WebSysRoleFuncsBLL
    {
        private WebSysRoleFuncsDAL dal;
        public static readonly WebSysRoleFuncsBLL Instance = new WebSysRoleFuncsBLL();

        public WebSysRoleFuncsBLL()
        {
            dal = new WebSysRoleFuncsDAL();
        }

        public void SaveOrUpdate(WEB_SYS_ROLEFUNCS model)
        {
            dal.SaveOrUpdate(model);
        }

        public void Delete(int id)
        {
            dal.Delete(id);
        }

        public WEB_SYS_ROLEFUNCS GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public IList<WEB_SYS_ROLEFUNCS> GetAllList(string condition = "", string orderBy = "")
        {
            return dal.GetAllList(condition, orderBy);
        }

        public IList<WEB_SYS_ROLEFUNCS> GetPageList(int pageIndex, int pageSize, string condition = "", string orderBy = "")
        {
            return dal.GetPageList(pageIndex, pageSize, condition, orderBy);
        }

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        public void DeleteByRoleIDAndFuncID(string roleID, string funcID, string ftype)
        {
            dal.DeleteByRoleIDAndFuncID(roleID, funcID,ftype);
            
        }
    }
}
