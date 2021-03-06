﻿using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCrm.Web.Pages.WebCrmDictionary
{
    public partial class List : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }
        public ICrmDictionaryService Service
        {
            get { return DependencyResolver.Resolver<ICrmDictionaryService>(); }
        }
        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindList()
        {
            var pageQuery = new PageQuery<IDictionary<string, object>, CrmDictionary>(this.CurrentOperatorUser);
            pageQuery.Condition = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(txtQueryText.Text))
            {
                pageQuery.Condition.Add("Key", txtQueryText.Text);
                pageQuery.Condition.Add("Depict", txtQueryText.Text);
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
           BindList();
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
                BindList();
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