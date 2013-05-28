using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;
namespace WebCX.Web.Pages.WebCustomerAgreement
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
        public ICustomerAgreementService UserInfoService
        {
            get { return DependencyResolver.Resolver<ICustomerAgreementService>(); }
        }
        public string QueryType
        {
            get { return this.Request.QueryString["QueryType"]; }
        }
        public string CustomerId
        {
            get
            {
                var customerId = Request.QueryString["CustomerId"];
                if (customerId != null)
                {
                    if (customerId.IsInt())
                    {
                        return customerId;
                    }
                }
                return string.Empty;
            }
        }
        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindList(string condition = " DELETED !=1 ")
        {
            var pageQuery = new PageQuery<IDictionary<string, object>, CustomerAgreement>(CurrentOperatorUser);
            pageQuery.Condition = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(txtQueryText.Text))
            {
                pageQuery.Condition.Add("Subject", txtQueryText.Text);
            }
            if (!string.IsNullOrEmpty(CustomerId))
            {
                pageQuery.Condition.Add("Customer.Id", CustomerId);
            }
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