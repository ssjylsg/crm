using System;
using System.Web.UI.WebControls;



namespace DPXS.Web.Admin.Admin
{
    public partial class List : WebCrm.Web.Facade.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindList()
        {
            int count = 0;
            rptList.DataSource = null;// AdminBLL.Instance.GetList(getcondition.ToString(), "id desc", AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out count);
            rptList.DataBind();
            AspNetPager1.RecordCount = count;
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpt_cmd(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                // AdminBLL.Instance.Delete(id);
                BindList();
            }
        }
    }
}
