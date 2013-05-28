using System;
using System.Collections.Generic;
using System.Web.UI.DataVisualization.Charting;
using System.Data;
using WebCrm.Web.Facade;

namespace WebCrm.Web.Pages.Chart.CA
{
    public partial class CA_Rate : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                startDate.Value = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                endDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
            }
            DataTable dt = GetData();
            //Random random = new Random();
            int poinsCount = dt.Rows.Count;
            //int yValue1 = random.Next(100, 200);
            //int yValue2 = random.Next(10, 100);
            int yValue1 = int.Parse(dt.Rows[0][0].ToString());
            int yValue2 = int.Parse(dt.Rows[1][0].ToString());

            if (yValue1 != 0 || yValue2 != 0)
            {
                decimal percentValue1 = 100 * yValue1 / (yValue1 + yValue2);
                decimal percentValue2 = 100 - percentValue1;
                decimal[] percentValues = { percentValue1, percentValue2 };


                // Populate series data
                double[] yValues = { yValue1, yValue2 };
                string[] xValues = { "单位", "散客" };
                Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);

                Chart1.Series["Default"].IsValueShownAsLabel = true;

                for (int i = 0; i < Chart1.Series["Default"].Points.Count; i++)
                {
                    Chart1.Series["Default"].Points[i].ToolTip = string.Format("{0}:{1},占{2}%", xValues[i], yValues[i], percentValues[i]);
                }

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
                Chart1.Titles[0].Text = "单位和散客比例" + ChartTypeList.SelectedItem.ToString();

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
                    if (point.AxisLabel == this.ExplodedPointList.SelectedValue)
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
            else
            {
                double[] yValues = { yValue1, yValue2 };
                string[] xValues = { "单位", "散客" };
                Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);

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
                Chart1.Titles[0].Text = "单位和散客比例" + ChartTypeList.SelectedItem.ToString();

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
                    if (point.AxisLabel == this.ExplodedPointList.SelectedValue)
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
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQuery_Click(object sender, EventArgs e)
        {

        }

        public DataTable GetStatisticsData(Dictionary<string, object> dict)
        {
            string strSql = "";
            //加载数据

            strSql =
                string.Format(
                    @"SELECT  nvl(count(1),0) as tcount FROM CRM_CUSTOMER R 
WHERE R.ACCTYPE = 1 AND deleted <>1
AND  R.COMPANY = {2} AND   createtime between to_date('{0}','yyyy-mm-dd') and  to_date('{1}','yyyy-mm-dd') 
UNION ALL
SELECT  nvl(count(1),0) as tcount FROM CRM_CUSTOMER R 
WHERE R.ACCTYPE = 0 AND deleted <>1
AND  R.COMPANY = {2} AND   createtime between to_date('{0}','yyyy-mm-dd') and  to_date('{1}','yyyy-mm-dd') 
           "
                    , dict["startDate"], dict["endDate"], dict["CompanyId"]);

            return WebCrm.Framework.DependencyResolver.Resolver<WebCrm.Model.Services.IChartService>().ExecuteDataTable(strSql);
        }

        public DataTable GetData()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("startDate", startDate.Value);
            dict.Add("endDate", DateTime.Parse(endDate.Value).AddDays(1).ToShortDateString());
            dict.Add("CompanyId", this.CurrentCompany != null ? this.CurrentCompany.Id : 0);
            return GetStatisticsData(dict);
        }
    }
}