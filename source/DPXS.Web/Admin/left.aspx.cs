using System;
using System.Collections.Generic;
using System.Linq;
using WebCrm.Framework;
using WebCrm.Model;
using WebCrm.Model.Services;
using WebCrm.Service;
using WebCrm.Web.Facade;


namespace DPXS.Web.Admin
{
    public partial class left : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["sign"] == "firstMenu")
            {
                GetFirstMenu();
            }
            else if (Request["sign"] == "subMenu")
            {
                GetMyMenu();
            }
            else if (Request["sign"] == "firstWebReportMenu")
            {
                GetFirstWebReportMenu();
            }
            else if (Request["sign"] == "subWebReportMenu")
            {
                GetMyWebReportMenu();
            }
        }
        /// <summary>
        /// 一级菜单
        /// </summary>
        protected void GetFirstMenu()
        {
            IList<Plug> list = DependencyResolver.Resolver<IPlugService>().GetAllParent().OrderBy(m => m.Sort).ToList();

            string str =
                 (
                   list.Select(m => new { ID = m.Id, FUN_NAME = m.PlugName }).ToArray()).ToJson();
            Response.Write(str);
            Response.End();
        }
        /// <summary>
        /// 二级 子菜单
        /// </summary>
        protected void GetMyMenu()
        {

            var plugService = DependencyResolver.Resolver<IRolePlugService>();
            IList<Plug> plugs = plugService.GetPlugs(this.CurrentOperatorUser).OrderBy(m => m.Sort).ToList();
            string[][] result = plugs.Select(
                m =>
                new string[]
                    {
                        m.Id.ToString(), m.Parent != null ? m.Parent.Id.ToString() : string.Empty, m.PlugName, m.Sort.ToString()
                        , m.PlugWebFile
                    }).ToArray();

            string str = result.ToJson();
            Response.Write(str);
            Response.End();
        }

        protected void GetFirstWebReportMenu()
        {
            //var list = WebReportCategoryBLL.Instance.GetAllList("PARENTID is not null", "SORT");
            string str = string.Empty; //JSSerialize.Serialize(list);
            Response.Write(str);
            Response.End();
        }

        protected void GetMyWebReportMenu()
        {
            // var list = WebLoginInfoBLL.Instance.GetWebReportListByUserID("" + LoginUser.UserID);
            string str = string.Empty;// JSSerialize.Serialize(list);
            Response.Write(str);
            Response.End();
        }
    }
}