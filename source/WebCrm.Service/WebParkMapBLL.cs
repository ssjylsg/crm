using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WebCX.DAL;
using WebCX.Model;

namespace WebCX.BLL
{
    public class WebParkMapBLL
    {
        private WebParkMapDAL dal;
        public static readonly WebParkMapBLL Instance = new WebParkMapBLL();

        public WebParkMapBLL()
        {
            dal = new WebParkMapDAL();
        }

        public void SaveOrUpdate(WEB_PARK_MAP model)
        {
            dal.SaveOrUpdate(model);
        }

        public void Delete(int id)
        {
            dal.Delete(id);
        }

        public WEB_PARK_MAP GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public IList<WEB_PARK_MAP> GetAllList(string condition = "", string orderBy = "")
        {
            return dal.GetAllList(condition, orderBy);
        }

        public WEB_PARK_MAP GetEntityByWhere(string where)
        {
            return dal.GetEntityByWhere(where);
        }

        public IList<WEB_PARK_MAP> GetPageList(int pageIndex, int pageSize, string condition = "", string orderBy = "")
        {
            return dal.GetPageList(pageIndex, pageSize, condition, orderBy);
        }

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        /// <summary>
        /// 修改默认
        /// </summary>
        /// <param name="id"></param>
        public void SetDefaultMap(int id)
        {
            dal.SetDefaultMap(id);
        }
    }
}
