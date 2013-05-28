using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Model;
using WebCrm.Model.Services;
using WebCrm.Framework;
using System.Data;
using WebCrm.Web.Facade;

namespace WebCrm.Web.Pages.Chart
{
    public partial class SalesPerformance : BasePage
    {
        public IUserInfoService UserInfoService
        {
            get { return DependencyResolver.Resolver<IUserInfoService>(); }
        }
        public IContractService ContractService
        {
            get { return DependencyResolver.Resolver<IContractService>(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                startDate.Value = DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd");
                endDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                BindSalesDDL();
                BindList();
            }
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindList()
        {
            PageQuery<IDictionary<string, object>, Contract> pageQuery = new PageQuery<IDictionary<string, object>, Contract>(null);
            pageQuery.Condition = new Dictionary<string, object>();
            pageQuery.Condition.Add("startDate", startDate.Value);
            pageQuery.Condition.Add("endDate", endDate.Value);
            string personID = ddlSales.SelectedValue;
            if (!string.IsNullOrEmpty(personID))
            {
                pageQuery.Condition.Add("SignPerson", personID);
            }
            if (ContactState.SelectedValue.IsInt())
            {
                pageQuery.Condition["State"] = ContactState.SelectedValue;
            }
            pageQuery.CurrentPageIndex = AspNetPager1.CurrentPageIndex;
            pageQuery.PageSize = AspNetPager1.PageSize;

            ContractService.Query(pageQuery);
            rptList.DataSource = pageQuery.Result;
            rptList.DataBind();
            AspNetPager1.RecordCount = pageQuery.RecordCount;
        }

        /// <summary>
        /// 绑定销售人员下拉列表
        /// </summary>
        protected void BindSalesDDL()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("ISCRM", 1);
            var dt = UserInfoService.GetByCondition(dict, "ID,OperatorName");
            ddlSales.Items.Clear();
            ddlSales.Items.Add(new ListItem("全部", ""));
            foreach (DataRow row in dt.Rows)
            {
                ddlSales.Items.Add(new ListItem("" + row[1], "" + row[0]));
            }

            Dictionary<DropDownList, string> dictionary = new Dictionary<DropDownList, string>();
            dictionary[ContactState] = "ContractState";
            AspNetHelper.BindDropDown(dictionary);
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

        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindList();
        }

        protected void ddlSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindList();
        }
    }
}