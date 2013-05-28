using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using WebCrm.Framework;
using WebCrm.Model.Services;
using System.Data;
using WebCrm.Web.Facade;

namespace WebCrm.Web.Pages.Chart.OperatingIncome
{
    /// <summary>
    /// 营业收入组成分析
    /// </summary>
    public partial class ER_IncomeTrend : ChartBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                startDate.Value = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                endDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                BindExplodedPointList();
            }

            DataTable dt = GetStatisticsData();
            int poinsCount = dt.Rows.Count;

            decimal[] percentValues = new decimal[poinsCount];
            string[] xValues = new string[poinsCount];
            int[] yValues = new int[poinsCount];

            Random random = new Random();
            int sumY = 0;
            for (int i = 0; i < poinsCount; i++)
            {
                yValues[i] = Convert.ToInt32(dt.Rows[i]["TOTAL"]);
                xValues[i] = "" + dt.Rows[i]["NAME"];
                sumY += yValues[i];
            }
            sumY = sumY == 0 ? 1 : sumY;
            for (int i = 0; i < poinsCount; i++)
            {
                percentValues[i] = 100 * yValues[i] / sumY;
            }

            Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);

            for (int i = 0; i < Chart1.Series["Default"].Points.Count; i++)
            {
                Chart1.Series["Default"].Points[i].ToolTip = string.Format("{0}:{1},占{2}%", xValues[i], yValues[i], percentValues[i]);
            }

            Chart1.Series["Default"].IsValueShownAsLabel = true;

            if (this.ChartTypeList.SelectedItem.ToString() == "Pie")
                Chart1.Series["Default"].ChartType = SeriesChartType.Pie;

            else
                Chart1.Series["Default"].ChartType = SeriesChartType.Doughnut;

            if (this.ShowLegend.Checked)
                Chart1.Series["Default"]["PieLabelStyle"] = "Disabled";

            else
                Chart1.Series["Default"]["PieLabelStyle"] = "Inside";

            // Set chart type and title
            Chart1.Series["Default"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), this.ChartTypeList.SelectedValue, true);
            Chart1.Titles[0].Text = "营业输入组成" + ChartTypeList.SelectedItem.ToString();

            // Set labels style
            Chart1.Series["Default"]["PieLabelStyle"] = this.LabelStyleList.SelectedValue;

            // Set Doughnut hole size
            Chart1.Series["Default"]["DoughnutRadius"] = this.HoleSizeList.SelectedValue;

            // Disable Doughnut hole size control for Pie chart
            this.HoleSizeList.Enabled = (this.ChartTypeList.SelectedValue != "Pie");

            // Explode selected country
            foreach (DataPoint point in Chart1.Series["Default"].Points)
            {
                point["Exploded"] = "false";
                if (point.AxisLabel == this.ExplodedPointList.SelectedItem.ToString())
                {
                    point["Exploded"] = "true";
                }
            }

            // Enable 3D
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = CheckboxShow3D.Checked;

            Chart1.Series[0]["PieDrawingStyle"] = this.Dropdownlist1.SelectedValue;

            // Pie drawing style
            if (this.CheckboxShow3D.Checked)
                this.Dropdownlist1.Enabled = false;

            else
                this.Dropdownlist1.Enabled = true;

            if (this.ShowLegend.Checked)
                this.Chart1.Legends[0].Enabled = true;
            else
                this.Chart1.Legends[0].Enabled = false;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQuery_Click(object sender, EventArgs e)
        {

        }

        private void BindExplodedPointList()
        {
            ExplodedPointList.Items.Clear();
            Dictionary<DropDownList, string> dictionary = new Dictionary<DropDownList, string>();
            dictionary[this.ExplodedPointList] = "ConsumerBusinessType";
            AspNetHelper.BindDropDown(dictionary);
        }

        public static ICategoryItemService CategoryItemService
        {
            get { return DependencyResolver.Resolver<ICategoryItemService>(); }
        }
        public static ICompanyActionService CompanyActionService
        {
            get { return DependencyResolver.Resolver<ICompanyActionService>(); }
        }
        public DataTable GetStatisticsData()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("startDate", startDate.Value);
            dict.Add("endDate", endDate.Value);
            dict["CompanyId"] = this.CompanyId;
            return DependencyResolver.Resolver<IChartService>().GetIncomeTrend(dict);
        }
    }
}