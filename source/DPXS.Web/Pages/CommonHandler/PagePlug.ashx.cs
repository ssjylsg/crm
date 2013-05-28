using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCrm.Framework;
using WebCrm.Model;
using WebCrm.Model.Services;

namespace WebCrm.Web.Pages.CommonHandler
{
    /// <summary>
    /// PagePlug 的摘要说明
    /// </summary>
    public class PagePlug : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var Request = context.Request;
            string result = string.Empty;
            if (Request["sign"] == "firstMenu")
            {
                result = GetFirstMenu();
            }
            else if (Request["sign"] == "subMenu")
            {
                result = GetMyMenu();
            }
            context.Response.Write(result);
        }
        /// <summary>
        /// 一级菜单
        /// </summary>
        protected string GetFirstMenu()
        {
            IList<Plug> list = DependencyResolver.Resolver<IPlugService>().GetAllParent().OrderBy(m => m.Sort).ToList();

            string str = (list.Select(m => new { ID = m.Id, FUN_NAME = m.PlugName }).ToArray()).ToJson();
            return str;
        }
        /// <summary>
        /// 二级 子菜单
        /// </summary>
        protected string GetMyMenu()
        {

            var plugService = DependencyResolver.Resolver<IRolePlugService>();
            IList<Plug> plugs = plugService.GetPlugs(Facade.HttpCurrentUserService.Current).OrderBy(m => m.Sort).ToList();
            string[][] result = plugs.Select(
                m =>
                new string[]
                    {
                        m.Id.ToString(), m.Parent != null ? m.Parent.Id.ToString() : string.Empty, m.PlugName, m.Sort.ToString()
                        , m.PlugWebFile
                    }).ToArray();

            return result.ToJson();

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