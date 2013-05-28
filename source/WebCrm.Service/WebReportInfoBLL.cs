using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.DAL;
using WebCX.Model;
using System.Data;

namespace WebCX.BLL
{
    public class WebReportInfoBLL
    {
        private WebReportInfoDAL dal;
        public static readonly WebReportInfoBLL Instance = new WebReportInfoBLL();

        public WebReportInfoBLL()
        {
            dal = new WebReportInfoDAL();
        }

        public void SaveOrUpdate(WEB_REPORT_INFO model)
        {
            dal.SaveOrUpdate(model);
        }

        public void Delete(int id)
        {
            dal.Delete(id);
        }

        public WEB_REPORT_INFO GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public IList<WEB_REPORT_INFO> GetAllList(string condition = "", string orderBy = "")
        {
            return dal.GetAllList(condition, orderBy);
        }

        public IList<WEB_REPORT_INFO> GetPageList(int pageIndex, int pageSize, string condition = "", string orderBy = "")
        {
            return dal.GetPageList(pageIndex, pageSize, condition, orderBy);
        }

        public DataTable GetAll()
        {
            return dal.GetAll();
        }
        /// <summary>
        /// 根据ID修改模版文件字段
        /// </summary>
        /// <param name="newFileName"></param>
        public void UpdateFilePath(string id, string newFileName)
        {
            dal.UpdateFilePath(id,newFileName);
        }
    }
}
