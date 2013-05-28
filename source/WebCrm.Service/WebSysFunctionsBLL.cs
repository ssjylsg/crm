using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.DAL;
using WebCX.Model;
using System.Data;

namespace WebCX.BLL
{
    public class WebSysFunctionsBLL
    {
        private WebSysFunctionsDAL dal;
        public static readonly WebSysFunctionsBLL Instance = new WebSysFunctionsBLL();

        public WebSysFunctionsBLL()
        {
            dal = new WebSysFunctionsDAL();
        }

        public void SaveOrUpdate(WEB_SYS_FUNCTIONS model)
        {
            dal.SaveOrUpdate(model);
        }

        public void Delete(int id)
        {
            dal.Delete(id);
        }

        public WEB_SYS_FUNCTIONS GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public IList<WEB_SYS_FUNCTIONS> GetAllList(string condition = "", string orderBy = "")
        {
            return dal.GetAllList(condition, orderBy);
        }

        public IList<WEB_SYS_FUNCTIONS> GetPageList(int pageIndex, int pageSize, string condition = "", string orderBy = "")
        {
            return dal.GetPageList(pageIndex, pageSize, condition, orderBy);
        }

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

    }
}
