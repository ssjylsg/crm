using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;

namespace WebCX.Web.Pages.WebComapny
{
    public class WebSysFunctionsTree
    {
        public static List<TreeNode> GetTree(DataTable dt)
        {
            //TreeNodeCollection nodes = null;
            List<TreeNode> listNodes = new List<TreeNode>();
            foreach (var type in dt.Select("PARENT_ID is null", "FUN_SORT ASC"))
            {
                var node = CreatNode(type);
                listNodes.Add(node);
                FillChildren(type, node.ChildNodes, dt);
            }

            return listNodes;
        }


        public static List<TreeNode> GetTree(DataTable dt, string keyWord)
        {

            if (keyWord == "" || keyWord == null)
            {
                return GetTree(dt);
            }
            else
            {
                DataTable dtSlt = dt.Clone();
                DataColumn[] primaryKeyColumn = new DataColumn[]
                {
                    dtSlt.Columns["ID"]
                };

                dtSlt.PrimaryKey = primaryKeyColumn;
                DataRow[] rows = dt.Select(string.Format("FUN_NAME like '%{0}%'", keyWord));
                foreach (var row in rows)
                {
                    ImportParentRow(dt, dtSlt, row);
                }
                return GetTree(dtSlt);
            }
        }


        /// <summary>
        /// 创建节点信息
        /// </summary>
        private static TreeNode CreatNode(DataRow type)
        {
            return new TreeNode()
            {
                Text = "" + type["FUN_NAME"],
                Value = "" + type["ID"]
            };
        }


        /// <summary>
        /// 递归填充子节点
        /// </summary>
        private static void FillChildren(DataRow parentType, TreeNodeCollection parentNode, DataTable dt)
        {

            foreach (var type in dt.Select(string.Format("PARENT_ID='{0}'", parentType["ID"]), "FUN_SORT ASC"))
            {
                var node = CreatNode(type);
                parentNode.Add(node);
                FillChildren(type, node.ChildNodes, dt);
            }

        }


        /// <summary>
        /// 导入所有父行（包括自己）
        /// </summary>
        private static void ImportParentRow(DataTable dtSource, DataTable dtSlt, DataRow currentRow)
        {
            if (!dtSlt.Rows.Contains(currentRow["ID"])) //不存在则导入行
            {
                dtSlt.ImportRow(currentRow);
            }

            if (!string.IsNullOrEmpty(currentRow["PARENT_ID"] + "")) //如果还有父项
            {
                DataRow row = dtSource.Select(string.Format("ID='{0}'", currentRow["PARENT_ID"]))[0];
                ImportParentRow(dtSource, dtSlt, row);

            }
        }
    }
}