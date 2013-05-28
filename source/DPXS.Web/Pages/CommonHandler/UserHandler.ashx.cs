using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCrm.Framework;
using WebCrm.Model;
using WebCrm.Web.Facade;
namespace WebCrm.Web.Pages.CommonHandler
{
    /// <summary>
    /// UserHandler 的摘要说明
    /// </summary>
    public class UserHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var type = context.Request.GetRequestValue("type");
            DataResult result = new DataResult();
            var error = string.Empty;
            if (!string.IsNullOrEmpty(type))
            {
                type = type.ToLower();
                switch (type)
                {
                    case "existname":
                        var name = context.Request.GetRequestValue("name");
                        var id = context.Request.GetRequestValue("id");
                        if (!id.IsInt())
                        {
                            error = "数据错误";
                            break;
                        }
                        result.Data =
                            DependencyResolver.Resolver<WebCrm.Model.Services.IUserInfoService>().ExistName(name,
                                                                                                            int.Parse(id));
                        break;
                }
            }

            result.Error = error;
            result.Success = string.IsNullOrEmpty(error);
            context.Response.Write(result.ToJson());

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