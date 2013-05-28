using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCX.Model;
using System.Data;
using WebCX.DAL.Common;

namespace WebCX.DAL
{
    public class WebParkLocationDAL: DALBase<WEB_PARK_LOCATION>
    {
        public WebParkLocationDAL()
        {
            TableName = "WEB_PARK_LOCATION";
        }

        public void Delete(int id)
        {
            control.Delete(new WEB_PARK_LOCATION() { ID = id });
        }
        public DataTable GetAll()
        {
            string strSql = "select * from WEB_PARK_LOCATION ";
            return NHelper.ExecuteDataSet(strSql).Tables[0];
        }

        /// <summary>
        /// 获取所有标注点详细信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDetailInfo()
        {
            //暂时取固定的数据，一般取实时的日期时间
            //string fdate = "2013-03-18";// DateTime.Now.ToString("yyyy-MM-dd");
            //string ftime = "09:10:00";// DateTime.Now.ToString("HH:mm:ss");
            string fdate = DateTime.Now.ToString("yyyy-MM-dd");
            string ftime = DateTime.Now.ToString("HH:mm:ss");
            string strSql = string.Format(@"select A.*, CHECKEDINNUM,CHECKEDOUTNUM,D.PARKFULLNAME from Web_Park_Location A
 left join 
 (select PARKCODE,CHECKEDNUM as CHECKEDINNUM from WEB_PARK_IN where FDATE='{0}' and BEGINTIME<='{1}' and ENDTIME> '{1}')B
 on A.PARKCODE = B.PARKCODE
 left join 
 (select  PARKCODE,CHECKEDNUM as CHECKEDOUTNUM from WEB_PARK_OUT where FDATE='{0}' and BEGINTIME<='{1}' and ENDTIME> '{1}')C
 on A.PARKCODE = C.PARKCODE 
 left join SYS_PARK D on A.PARKCODE = D.PARKCODE", fdate, ftime);
            return NHelper.ExecuteDataSet(strSql).Tables[0];
        }

        /// <summary>
        /// 更改坐标
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newCoor"></param>
        public void EditCoordinateData(string id, string newCoor)
        {
            string strSql = string.Format("update WEB_PARK_LOCATION set COORDINATEDATA='{0}' where ID={1}",newCoor,id);
            var session = NHelper.GetCurrentSession();
            session.CreateQuery(strSql).ExecuteUpdate();
            session.Close();
        }
    }
}
