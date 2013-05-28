using System;
using System.Data;
using System.Linq;
using NUnit.Framework;
using WebCrm.Model.Utils;

namespace WebCrm.Test
{
     
    public class CommonTest
    {
        
        [Test]
        public void TestMethod1()
        {
            DataTable dataTable = new DataTable();
            string[] columns = new string[] {"时间", "姓名", "ID"};
            dataTable.Columns.AddRange(columns.Select(m => new DataColumn(m)).ToArray());
            for (int i = 0; i < 10; i++)
            {
                DataRow row = dataTable.NewRow();
                row["时间"] = DateTime.Now;
                row["姓名"] = string.Format("第{0}个", i);
                row["ID"] = i;
                dataTable.Rows.Add(row);
            }
            string fileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Guid.NewGuid() + "测试.xls");
            AsposeCellsHelper.ExportToExcel(dataTable,fileName);
            Assert.IsTrue(System.IO.File.Exists(fileName));
        }
    }
}
