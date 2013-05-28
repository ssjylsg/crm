using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

namespace WebCrm.Web.Pages.Chart.ChartUC
{
    public partial class CA_RateUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                startDate.Value = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                endDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                hiddenStartDate.Text= DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");                 
                hiddenEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            Random random = new Random();
            int yValue1 = random.Next(100, 200);
            int yValue2 = random.Next(10, 100);
            decimal percentValue1 =  100 * yValue1 / (yValue1 + yValue2);
            decimal percentValue2 = 100 - percentValue1;
            decimal[] percentValues = { percentValue1, percentValue2 };

            // Populate series data
            double[] yValues = {yValue1 ,yValue2};
            string[] xValues = { "单位", "散客"};
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
            Chart1.Titles[0].Text = "单位和散客比例"+ChartTypeList.SelectedItem.ToString();

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
}