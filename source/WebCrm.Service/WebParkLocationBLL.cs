using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.DAL;
using WebCX.Model;
using System.Data;

namespace WebCX.BLL
{
    public class WebParkLocationBLL
    {
        private WebParkLocationDAL dal;
        public static readonly WebParkLocationBLL Instance = new WebParkLocationBLL();

        public WebParkLocationBLL()
        {
            dal = new WebParkLocationDAL();
        }

        public void SaveOrUpdate(WEB_PARK_LOCATION model)
        {
            dal.SaveOrUpdate(model);
        }

        public void Delete(int id)
        {
            dal.Delete(id);
        }

        public WEB_PARK_LOCATION GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public IList<WEB_PARK_LOCATION> GetAllList(string condition = "", string orderBy = "")
        {
            return dal.GetAllList(condition, orderBy);
        }

        public IList<WEB_PARK_LOCATION> GetPageList(int pageIndex, int pageSize, string condition = "", string orderBy = "")
        {
            return dal.GetPageList(pageIndex, pageSize, condition, orderBy);
        }

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        /// <summary>
        /// 获取所有标注点详细信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDetailInfo()
        {
            return dal.GetDetailInfo();
        }

        /// <summary>
        /// 更改坐标
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newCoor"></param>
        public void EditCoordinateData(string id, string newCoor)
        {
            dal.EditCoordinateData(id, newCoor);
        }
    }
}
