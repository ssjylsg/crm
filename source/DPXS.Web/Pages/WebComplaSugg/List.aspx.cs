using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCrm.Web.Pages.WebComplaSugg
{
    public partial class List : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList(" DELETED !=1 ");
            }
        }
        public bool IsPay
        {
            get { return SuggestComplaints.Equals("Complaints", StringComparison.CurrentCultureIgnoreCase); }
        }
        public string SuggestComplaints
        {
            get
            {
                var type = Request.GetRequestValue("SuggestComplaints");
                if (string.IsNullOrEmpty(type))
                {
                    type = "Complaints";
                }
                return type;
            }
        }

        public ISuggestService UserInfoService
        {
            get { return DependencyResolver.Resolver<ISuggestService>(); }
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindList(string condition = " DELETED !=1 ")
        {
            var pageQuery = new PageQuery<IDictionary<string, object>, Suggest>(CurrentOperatorUser);
            pageQuery.Condition = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(txtQueryText.Text))
            {
                pageQuery.Condition.Add("CustoMerName", txtQueryText.Text);
            }
            pageQuery.Condition["SuggestComplaints"] = this.IsPay
                                          ? (int)WebCrm.Model.SuggestComplaints.Complaints
                                          : (int)WebCrm.Model.SuggestComplaints.Suggest;

            pageQuery.CurrentPageIndex = AspNetPager1.CurrentPageIndex;
            pageQuery.PageSize = AspNetPager1.PageSize;

            UserInfoService.Query(pageQuery);
            rptList.DataSource = pageQuery.Result;
            rptList.DataBind();
            AspNetPager1.RecordCount = pageQuery.RecordCount;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindList(" DELETED !=1 ");
        }

        /// <summary>
        /// 单行数据操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpt_cmd(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                var user = this.UserInfoService.FindById(id);
                user.Deleted = true;
                this.UserInfoService.Update(user);

                BindList(" DELETED !=1 ");
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            string keyword = txtQueryText.Text.Trim();
            string conditon = "DELETED !=1";
            if (!string.IsNullOrEmpty(keyword))
            {
                conditon = string.Format(" DELETED !=1 and (LOGIN_NAME like '%{0}%' or LOGIN_REALNAME like '%{0}%')", keyword);
            }
            BindList(conditon);
        }
    }
}