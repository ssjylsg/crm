using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebCrm.Framework;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class ChartService : IChartService
    {
        private IChartRepository _chartRepository;
        public ChartService(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }
        public DataTable GetCustomerAgeStructure(Dictionary<string, object> dictionary)
        {
            DataTable dataTable = _chartRepository.GetCustomerAgeStructure(dictionary);
            string[] ages = new string[] { "20岁以下", "20-30岁", "30-40岁", "40-50岁", "50岁以上" };
            // 补全数据
            foreach (string age in ages)
            {
                if (dataTable.Select(string.Format("AGE='{0}'", age)).Count() <= 1)
                {
                    DataRow row = dataTable.NewRow();
                    row["AGE"] = age;
                    row["AgeSum"] = "0";

                    dataTable.Rows.Add(row);
                }
            }
            return dataTable;
        }

        public DataTable ExecuteDataTable(string strSql)
        {
            return _chartRepository.ExecuteDataTable(strSql);
        }

        public DataTable GetIncomeTrend(Dictionary<string, object> dict)
        {
            DataTable dataTable = _chartRepository.GetIncomeTrend(dict);
            // 对数据进行调整

            var list = DependencyResolver.Resolver<ICategoryItemService>().FindByCategoryType("ConsumerBusinessType").Where(
                m => m.Deleted == false);
            foreach (CategoryItem categoryItem in list)
            {
                if (dataTable.Select(string.Format("ID='{0}'", categoryItem.Id)).Length <= 0)
                {
                    DataRow row = dataTable.NewRow();
                    row["ID"] = categoryItem.Id;
                    row["Name"] = categoryItem.Name;
                    row["TOTAL"] = "0";
                    dataTable.Rows.Add(row);
                }
            }
            return dataTable;
        }

        public DataTable GetCustomerStructure(Dictionary<string, object> dictionary)
        {
            DataTable dataTable = _chartRepository.GetCustomerStructure(dictionary);
            // 对数据进行调整 
            var caType = dictionary["CaType"].ToString();
            var list = DependencyResolver.Resolver<ICategoryItemService>().FindByCategoryType(caType == "source" ? "CustomerSource" : "CustomerBusiness").Where(
                m => m.Deleted == false);
            foreach (CategoryItem categoryItem in list)
            {
                if (dataTable.Select(string.Format("ID='{0}'", categoryItem.Id)).Length <= 0)
                {
                    DataRow row = dataTable.NewRow();
                    row["ID"] = categoryItem.Id;
                    row["Name"] = categoryItem.Name;
                    row["TOTAL"] = "0";
                    dataTable.Rows.Add(row);
                }
            }
            return dataTable;
        }

        public DataTable SalesPerformance(Dictionary<string, object> dictionary)
        {
            return _chartRepository.SalesPerformance(dictionary);
        }

        public DataTable GetCustomerCategory(Dictionary<string, object> dict)
        {
            return this._chartRepository.GetCustomerCategory(dict);
        }

        public DataTable ComplaintsRate(Dictionary<string, object> dictionary)
        {
            DataTable consumTable = this._chartRepository.ConsumRecord(dictionary);
            DataTable complaint = this._chartRepository.Complaints(dictionary);

            DataTable result = new DataTable();
            result.Columns.AddRange(new DataColumn[] { new DataColumn("Name"), new DataColumn("Total"), });
            foreach (DataRow row in consumTable.Rows)
            {
                DataRow newRow = result.NewRow();
                string name = row["Name"].ToString();
                newRow["Name"] = name;
                DataRow[] comRows = complaint.Select(string.Format("Name='{0}'", name));
                if (comRows.Length > 0)
                {
                    newRow["Total"] = int.Parse(comRows[0]["COUNT"].ToString()) / double.Parse(row["COUNT"].ToString());
                }
                else
                {
                    newRow["Total"] = "0";
                }
                result.Rows.Add(newRow);
            }

            foreach (DataRow dataRow in complaint.Rows)
            {
                DataRow newRow = result.NewRow();
                string name = dataRow["Name"].ToString();
                newRow["Name"] = name;
                DataRow[] comRows = complaint.Select(string.Format("Name='{0}'", name));
                if (comRows.Length <= 0) // 有投诉 但是无消费
                {
                    newRow["Total"] = 1;
                    result.Rows.Add(newRow);
                }
            }

            return result;

        }
    }
}
