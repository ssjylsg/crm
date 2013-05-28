﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;
namespace WebCX.Web.Pages.CustomerNotify
{
    /// <summary>
    /// 我自己的客户
    /// </summary>
    public partial class MySelftCustomer : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();

                BindList(" DELETED !=1 ");
            }
        }

        private void BindDropDown()
        {
            var requestList = new Dictionary<DropDownList, string>();
            requestList[this.CustomerSourceID] = "CustomerSource";// 客户来源
            requestList[this.CustomerBusinessID] = "CustomerBusiness";// 客户行业
            AspNetHelper.BindDropDown(requestList);
        }
        public ICustomerService UserInfoService
        {
            get { return DependencyResolver.Resolver<ICustomerService>(); }
        }
        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindList(string condition = " DELETED !=1 ")
        {
            var pageQuery = new PageQuery<IDictionary<string, object>, Customer>(CurrentOperatorUser);
            pageQuery.Condition = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(QueryName.Text))
            {
                pageQuery.Condition.Add("ShortName", QueryName.Text);
            }
            if (!string.IsNullOrEmpty(CustomerSourceID.SelectedValue) && CustomerSourceID.SelectedValue.IsInt())
            {
                pageQuery.Condition.Add("CustomerSource.Id", CustomerSourceID.SelectedValue);
            }
            if (!string.IsNullOrEmpty(CustomerBusinessID.SelectedValue) && CustomerBusinessID.SelectedValue.IsInt())
            {
                pageQuery.Condition.Add("CustomerBusiness.Id", CustomerBusinessID.SelectedValue);
            }
            if (!string.IsNullOrEmpty(AccTypeId.SelectedValue) && AccTypeId.SelectedValue.IsInt())
            {
                pageQuery.Condition.Add("AccType", AccTypeId.SelectedValue);
            }
            pageQuery.Condition["BelongPerson.Id"] = this.CurrentOperatorUser.Id;
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