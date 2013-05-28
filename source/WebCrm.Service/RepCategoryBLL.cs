using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.DAL;
using WebCX.Model;
using System.Data;


namespace WebCX.BLL
{
    public class RepCategoryBLL
    {
        private RepCategoryDAL dal;
        public static readonly RepCategoryBLL Instance = new RepCategoryBLL();

        public RepCategoryBLL()
        {
            dal = new RepCategoryDAL();
        }

        public void SaveOrUpdate(SYS_REPCATEGORY model)
        {
            dal.SaveOrUpdate(model);
        }

        public void Delete(int id)
        {
            dal.Delete(id);
        }

        public SYS_REPCATEGORY GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public IList<SYS_REPCATEGORY> GetAllList(string condition = "", string orderBy = "")
        {
            return dal.GetAllList(condition, orderBy);
        }

        public IList<SYS_REPCATEGORY> GetPageList(int pageIndex, int pageSize, string condition = "", string orderBy = "")
        {
            return dal.GetPageList(pageIndex, pageSize, condition, orderBy);
        }

        public DataTable GetAll()
        {
            return dal.GetAll();
        }
    }
}
