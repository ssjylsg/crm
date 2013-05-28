using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.DAL;
using WebCX.Model;
using System.Data;
using System.Collections;

namespace WebCX.BLL
{
    public class WebReportCategoryBLL
    {
        private WebReportCategoryDAL dal;
        public static readonly WebReportCategoryBLL Instance = new WebReportCategoryBLL();

        public WebReportCategoryBLL()
        {
            dal = new WebReportCategoryDAL();
        }

        public void SaveOrUpdate(WEB_REPORT_CATEGORY model)
        {
            dal.SaveOrUpdate(model);
        }

        public void Delete(int id)
        {
            dal.Delete(id);
        }

        public WEB_REPORT_CATEGORY GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public IList<WEB_REPORT_CATEGORY> GetAllList(string condition = "", string orderBy = "")
        {
            return dal.GetAllList(condition, orderBy);
        }

        public IList<WEB_REPORT_CATEGORY> GetPageList(int pageIndex, int pageSize, string condition = "", string orderBy = "")
        {
            return dal.GetPageList(pageIndex, pageSize, condition, orderBy);
        }

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        /// <summary>
        /// 获取所有叶子节点ID,和名称路径
        /// </summary>
        /// <returns></returns>
        public IList GetLeafNamePath()
        {
            return dal.GetLeafNamePath();
        }
    }
}
