using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.DAL;
using WebCX.Model;
using System.Data;

namespace WebCX.BLL
{
    public class WebLoginRoleBLL
    {
        private WebLoginRoleDAL dal;
        public static readonly WebLoginRoleBLL Instance = new WebLoginRoleBLL();

        public WebLoginRoleBLL()
        {
            dal = new WebLoginRoleDAL();
        }

        public void SaveOrUpdate(WEB_LOGIN_ROLE model)
        {
            dal.SaveOrUpdate(model);
        }

        public void Delete(int id)
        {
            dal.Delete(id);
        }

        public WEB_LOGIN_ROLE GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public IList<WEB_LOGIN_ROLE> GetAllList(string condition = "", string orderBy = "")
        {
            return dal.GetAllList(condition, orderBy);
        }

        public IList<WEB_LOGIN_ROLE> GetPageList(int pageIndex, int pageSize, string condition = "", string orderBy = "")
        {
            return dal.GetPageList(pageIndex, pageSize, condition, orderBy);
        }

        public DataTable GetAll()
        {
            return dal.GetAll();
        }
        public void DeleteByRoleIDAndUserID(string roleID, string userID)
        {
             dal.DeleteByRoleIDAndUserID(roleID, userID);
        }
    }
}
