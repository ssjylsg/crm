using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCrm.Web.Facade;

namespace WebCrm.Web.Pages.CommonHandler
{
    /// <summary>
    /// Comment 的摘要说明
    /// </summary>
    public class Comment : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var type = context.Request.GetRequestValue("type");



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