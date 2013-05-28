using System;
using System.Collections.Generic;
using System.Web.UI.DataVisualization.Charting;
using System.Data;
using WebCrm.Web.Facade;

namespace WebCrm.Web.Pages.Chart.Children
{
    public partial class CA_AgeStructure : ChartBasePage
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                startDate.Value = DateTime.Now.AddYears(-70).ToString("yyyy-MM-dd");
                endDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
            }
            DataTable dt = GetData();

            int poinsCount = dt.Rows.Count;
            string[] xValues = new string[poinsCount];
            int[] yValues = new int[poinsCount];
            int sumY = 0;
            decimal[] percentValues = new decimal[poinsCount];
            // name 和数据库的查询结果是一样的，此处也含有排序的意图，将年龄 按照从小到大排列
            string[] names = { "20岁以下", "20-30岁", "30-40岁", "40-50岁", "50岁以上" };
            for (int i = 0; i < names.Length; i++)
            {
                DataRow row = dt.Select(string.Format("AGE='{0}'", names[i]))[0];
                yValues[i] = Convert.ToInt32(row["AGESUM"]);
                xValues[i] = "" + row["AGE"];
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
                Chart1.Titles[0].Text = "年龄层次条形图";
            }
            else
            {
                Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart1.Titles[0].Text = "年龄层次柱形图";
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
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("startDate", startDate.Value);
            dict.Add("endDate", endDate.Value);
            dict.Add("CompanyId", this.CompanyId);
            return WebCrm.Framework.DependencyResolver.Resolver<WebCrm.Model.Services.IChartService>().GetCustomerAgeStructure(dict);
        }
    }
}