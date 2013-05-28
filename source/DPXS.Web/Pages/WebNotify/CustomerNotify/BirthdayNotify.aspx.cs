using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.QueryModel;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;
namespace WebCX.Web.Pages.CustomerNotify
{
    public partial class List : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BeginDate.Text = DateTime.Now.AddDays(-7).ToShortDate();
                this.DateRadio.SelectedValue = "week";
                BindList(" DELETED !=1 ");
            }
            Week = DateTime.Now.AddDays(-7).ToShortDate();
            Month = DateTime.Now.AddMonths(-1).ToShortDate();
        }

        protected string Week;
        protected string Month;
        public ICustomerContactInfoService UserInfoService
        {
            get { return DependencyResolver.Resolver<ICustomerContactInfoService>(); }
        }
        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindList(string condition = " DELETED !=1 ")
        {
            var pageQuery = new PageQuery<CustomerContactQuery, CustomerContactInfo>(CurrentOperatorUser);
            pageQuery.Condition = new CustomerContactQuery();

            if (BeginDate.Text.IsDateTime())
            {
                pageQuery.Condition.EndBirthday = DateTime.Parse(BeginDate.Text);
            }
            if (MySelfData.Checked)
            {
                pageQuery.Condition.BussinessPerson = this.CurrentOperatorUser;
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
            BindList();
        }
    }
}