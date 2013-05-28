using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.DAL;
using WebCX.Model;
using System.Data;

namespace WebCX.BLL
{
    public class UserBLL
    {
        private UserDAL dal;
        public static readonly UserBLL Instance = new UserBLL();

        public UserBLL()
        {
            dal = new UserDAL();
        }

        public void SaveOrUpdate(SYS_USER model)
        {
            dal.SaveOrUpdate(model);
        }

        public void Delete(int id)
        {
            dal.Delete(id);
        }

        public SYS_USER GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public IList<SYS_USER> GetAllList(string condition = "", string orderBy = "")
        {
            return dal.GetAllList(condition, orderBy);
        }

        public IList<SYS_USER> GetPageList(int pageIndex, int pageSize, string condition = "", string orderBy = "")
        {
            return dal.GetPageList(pageIndex, pageSize, condition, orderBy);
        }

        public DataTable GetAll()
        {
            return dal.GetAll();
        }
    }
}
