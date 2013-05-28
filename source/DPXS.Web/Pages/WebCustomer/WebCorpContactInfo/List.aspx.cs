using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;
namespace WebCrm.Web.Pages.WebCorpContactInfo
{
    public partial class List : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var customerId = this.Request.GetRequestValue("CustomerId");
                if (customerId.IsInt())
                {
                    var customer = DependencyResolver.Resolver<ICustomerService>().FindById(int.Parse(customerId));
                    if (customer != null)
                    {
                        this.CustmerNameID.Text = customer.ShowName;
                    }
                }
                BindList(" DELETED !=1 ");
            }
        }
        public ICustomerContactInfoService Service
        {
            get { return DependencyResolver.Resolver<ICustomerContactInfoService>(); }
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindList(string condition = " DELETED !=1 ")
        {
            var pageQuery = new PageQuery<IDictionary<string, object>, CustomerContactInfo>(this.CurrentOperatorUser);
            pageQuery.Condition = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(txtQueryText.Text))
            {
                pageQuery.Condition.Add("Customer.Name", txtQueryText.Text);
            }

            pageQuery.Condition["Customer.Id"] = Request.QueryString["CustomerId"];
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