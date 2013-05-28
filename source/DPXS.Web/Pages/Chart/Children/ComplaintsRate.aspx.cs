using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using WebCrm.Web.Facade;

namespace WebCrm.Web.Pages.Chart.Children
{
    public partial class ComplaintsRate : ChartBasePage
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                startDate.Value = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                endDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
            }
            DataTable dt = GetData();

            int poinsCount = dt.Rows.Count;
            string[] xValues = new string[poinsCount];
            double[] yValues = new double[poinsCount];
            string[] yDisplay = new string[poinsCount];
            double sumY = 0;
            double[] percentValues = new double[poinsCount];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                yValues[i] = Convert.ToDouble(row["TOTAL"]);
                xValues[i] = "" + row["Name"];
                sumY += yValues[i] >= 1 ? 0 : yValues[i];
                yDisplay[i] = yValues[i] >= 1 ? "100%" : (yValues[i] * 100).ToString("#0.#0") + "%";
            }
            sumY = sumY == 0 ? 1 : sumY;
            for (int i = 0; i < poinsCount; i++)
            {
                percentValues[i] = 100 * yValues[i] / sumY;
            }
            Chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);

            for (int i = 0; i < Chart1.Series["Series1"].Points.Count; i++)
            {
                Chart1.Series["Series1"].Points[i].ToolTip = string.Format("{0} : 投诉率 {1}, 占{2}%", xValues[i], yDisplay[i], percentValues[i]);
            }
            Chart1.Series["Series1"].IsValueShownAsLabel = true;
            // Set series chart type
            if (ChartType.SelectedValue == "Bar")
            {
                Chart1.Series["Series1"].ChartType = SeriesChartType.Bar;
                Chart1.Titles[0].Text = "投诉率层次条形图";
            }
            else
            {
                Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart1.Titles[0].Text = "投诉率层次柱形图";
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

        public DataTable GetData()
        {

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary["startDate"] = DateTime.Parse(startDate.Value).ToString("yyyy-MM-dd");
            dictionary["endDate"] = DateTime.Parse(this.endDate.Value).ToString("yyyy-MM-dd");

            dictionary["CompanyId"] = this.CompanyId;
            return WebCrm.Framework.DependencyResolver.Resolver<WebCrm.Model.Services.IChartService>().ComplaintsRate(dictionary);
        }
    }
}