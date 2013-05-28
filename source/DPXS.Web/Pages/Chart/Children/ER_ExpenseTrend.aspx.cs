using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using WebCrm.Framework;
using WebCrm.Model.Services;
using System.Data;

namespace WebCrm.Web.Pages.Chart.Children
{
    public partial class ER_ExpenseTrend : ChartBasePage
    {
        public ICustomerService CustomerService
        {
            get { return DependencyResolver.Resolver<ICustomerService>(); }
        }
        public static ICustormerConsumRecordService CustormerConsumRecordService
        {
            get { return DependencyResolver.Resolver<ICustormerConsumRecordService>(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                startDate.Value = DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd");
                endDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                BindCustomerDDL();
                var customerId = Request.QueryString["CustomerId"];
                if(!string.IsNullOrEmpty(customerId))
                {
                    ddlCustomer.SelectedValue = customerId;
                }
            }
            DataTable dt = GetExpenseTrendData();
            int poinsCount = dt.Rows.Count;

            decimal[] percentValues = new decimal[poinsCount];
            string[] xValues = new string[poinsCount];
            int[] yValues = new int[poinsCount];
            int sumY = 0;
            for (int i = 0; i < poinsCount; i++)
            {
                yValues[i] = Convert.ToInt32(dt.Rows[i]["YVALUE"]);
                xValues[i] = "" + dt.Rows[i]["XVALUE"];
                sumY += yValues[i];

            }
            sumY = sumY == 0 ? 1 : sumY;
            for (int i = 0; i < poinsCount; i++)
            {
                percentValues[i] = 100 * yValues[i] / sumY;
            }

            Chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);

            for (int i = 0; i < poinsCount; i++)
            {
                Chart1.Series["Series1"].Points[i].ToolTip = string.Format("{0}消费金额{1}元,占{2}%", xValues[i], yValues[i],percentValues[i]);
            }

            // Set "bubble" series shape            
            Chart1.Series["Series1"].MarkerStyle = (MarkerStyle)MarkerStyle.Parse(typeof(MarkerStyle), Shape.SelectedItem.Value);
            

            // Set max bubble size
            Chart1.Series["Series1"]["BubbleMaxSize"] = MaxSize.SelectedItem.Text;

            // Show as 2D or 3D
            if (Show3D.Checked)
            {
                Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            }
            else
            {
                Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQuery_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 绑定客户下拉列表
        /// </summary>
        protected void BindCustomerDDL()
        {            
            var dt = CustomerService.GetByCondition(null, "ID,Name");
            ddlCustomer.Items.Clear();
            ddlCustomer.Items.Add(new ListItem("全部", ""));
            foreach (DataRow row in dt.Rows)
            {
                ddlCustomer.Items.Add(new ListItem("" + row[1], "" + row[0]));
            }
        }



        public DataTable GetExpenseTrendData()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("startDate", startDate.Value);
            dict.Add("endDate", endDate.Value);
            dict.Add("CustomerID", ddlCustomer.SelectedValue);
            dict["CompanyId"] = this.CompanyId;
            return CustormerConsumRecordService.GetExpenseTrendData(dict);
        }
    }
}