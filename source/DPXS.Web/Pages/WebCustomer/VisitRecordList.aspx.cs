using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;
namespace WebCrm.Web.Pages.WebCustomer
{
    /// <summary>
    /// 访谈记录
    /// </summary>
    public partial class VisitRecordList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList(" DELETED !=1 ");
            }
        }
        public ICustomerVisitRecordService Service
        {
            get { return DependencyResolver.Resolver<ICustomerVisitRecordService>(); }
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
            PageQuery<IDictionary<string, object>, CustomerVisitRecord> pageQuery = new PageQuery<IDictionary<string, object>, CustomerVisitRecord>(CurrentOperatorUser);
            pageQuery.Condition = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(txtQueryText.Text))
            {
                pageQuery.Condition.Add("Customer.Name", txtQueryText.Text);
            }
            if (!string.IsNullOrEmpty(CustomerId))
            {
                pageQuery.Condition.Add("Customer.Id", CustomerId);
            }
            pageQuery.CurrentPageIndex = AspNetPager1.CurrentPageIndex;
            pageQuery.PageSize = AspNetPager1.PageSize;

            Service.Query(pageQuery);
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
                var user = this.Service.FindById(id);
                user.Deleted = true;
                this.Service.Update(user);

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