using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCrm.Api.DefaultCrm
{
    /// <summary>
    /// CustomerApi 的摘要说明
    /// </summary>
    public class CustomerApi : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
//            < consumerRecord >
//        <consumerid> xy2013</ consumerid >
//        < loginId > caedmon2013</ loginId >
//        < businessType >0</ businessType >
//        < recordNo >20130402028</ recordNo >
//        < amount >0.10</ amount >
//< ConsumptionTime >2012-07-04 17:22:31</ ConsumptionTime >
//    </ consumerRecord >

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}