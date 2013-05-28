using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using WebCrm.Web.Facade;
using WebCrm.Model.Services;
using System.Data;
using WebCrm.Framework;

namespace WebCrm.Web.Pages.Chart.Children
{
    public partial class CA_CustomerArea : BasePage
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                startDate.Value = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                endDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                BindDDLProvince();
            }
            DataTable dt = GetStatisticsData();
            int poinsCount = dt.Rows.Count;

            decimal[] percentValues = new decimal[poinsCount];
            string[] xValues = new string[poinsCount];
            int[] yValues = new int[poinsCount];
            int sumY = 0;
            for (int i = 0; i < poinsCount; i++)
            {
                yValues[i] = Convert.ToInt32(dt.Rows[i]["TOTALCOUNT"]);
                xValues[i] = "" + dt.Rows[i]["NAME"];
                sumY += yValues[i];
            }
            sumY = sumY == 0 ? 1 : sumY;
            for (int i = 0; i < poinsCount; i++)
            {
                percentValues[i] = 100 * yValues[i] / sumY;
            }


            Chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);

            for (int i = 0; i < Chart1.Series["Series1"].Points.Count; i++)
            {
                Chart1.Series["Series1"].Points[i].ToolTip = string.Format("{0}:{1},占{2}%", xValues[i], yValues[i], percentValues[i]);
            }


            Chart1.Series["Series1"].IsValueShownAsLabel = true;
            // Set series chart type
            if (ChartType.SelectedValue == "Bar")
            {
                Chart1.Series["Series1"].ChartType = SeriesChartType.Bar;
                Chart1.Titles[0].Text = "客户区域分布条形图";
            }
            else
            {
                Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart1.Titles[0].Text = "客户区域分布柱形图";
            }

            // Set point width of the series
            Chart1.Series["Series1"]["PointWidth"] = BarWidthList.SelectedItem.Text;

            // Set drawing style
            Chart1.Series["Series1"]["DrawingStyle"] = this.DrawingStyle.SelectedValue;

            // Show as 2D or 3D
            if (Show3D.Checked)
                Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

            else
                Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
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
        /// 绑定省份下拉列表
        /// </summary>
        protected void BindDDLProvince()
        {
            Dictionary<DropDownList, string> requestList = new Dictionary<DropDownList, string>();
            requestList[ddlProvince] = "CustomerArea"; // 区域
            AspNetHelper.BindDropDown(requestList);
            ddlProvince.Items[0].Text = "全部";
        }

        public static ICustomerService CustomerService
        {
            get { return DependencyResolver.Resolver<ICustomerService>(); }
        }

        public DataTable GetStatisticsData()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("startDate", startDate.Value);
            dict.Add("endDate", endDate.Value);
            dict.Add("ProvinceID", ddlProvince.SelectedValue);
            dict.Add("CompanyId", this.CurrentCompany != null ? this.CurrentCompany.Id : 0);
            return CustomerService.GetStatisticsData(dict);
        }
    }
}