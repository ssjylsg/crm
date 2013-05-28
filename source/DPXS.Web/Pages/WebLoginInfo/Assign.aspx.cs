using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebCX.BLL;
using System.Data;
using WebCX.Web.Pages.WebSysFunctions;
using WebCX.Model;
using WebCX.Web.Helper;

namespace WebCX.Web.Pages.WebLoginInfo
{
    public partial class Assign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTitle.Text = RealName;
                BindRoleTreeData();
                BindMenuTreeData();
                BindCheckedRole();
                BindCheckedMenu();
                BindReportTreeData();
                BindCheckedReport();
             }
        }
        /// <summary>
        /// UserID
        /// </summary>
        public int UserId
        {
            get
            {
                string strId = Request.QueryString["Id"];
                return Convert.ToInt32(strId);
            }
        }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string RealName
        {
            get { return Request.QueryString["RealName"]; }
        }

        /// <summary>
        /// 根据条件查询，返回查询后的Tree
        /// </summary>
        /// <param name="keyWord">关键词，为空表示查询整棵树</param>
        /// <returns></returns>
        public List<TreeNode> GetMenuTree(string keyWord)
        {
            DataTable dt = WebSysFunctionsBLL.Instance.GetAll();
            return WebSysFunctionsTree.GetTree(dt, keyWord);
        }

        public void BindMenuTreeData(string keyWord = "")
        {
            tvMenu.Nodes.Clear();
            List<TreeNode> nodes = GetMenuTree(keyWord);
            TreeNode root = new TreeNode();
            root.Text = "常规功能菜单树";
            root.Value = "0";

            foreach (TreeNode node in nodes)
            {
                root.ChildNodes.Add(node);
            }
            tvMenu.Nodes.Add(root);
            tvMenu.ExpandAll();
        }

        /// <summary>
        /// 绑定报表功能菜单树
        /// </summary>
        public void BindReportTreeData()
        {
            tvReport.Nodes.Clear();
            DataTable dtReportCategory = WebReportCategoryBLL.Instance.GetAll();
            List<TreeNode> nodes = WebReportCategory.WebReportCategoryTree.GetTree(dtReportCategory);
            TreeNode root = new TreeNode();
            root.Text = "报表功能菜单树";
            root.Value = "0";

            var listReportInfo = WebReportInfoBLL.Instance.GetAllList("DELETED = 0 and STATUS=1", "CATEGORYID");
            int? categoryID = -1;
            TreeNode findNode = null;
            foreach (var item in listReportInfo)
            {
                if (categoryID != item.CATEGORYID)
                {
                    findNode = TreeNodeHelper.GetNodeByID(nodes, "" + item.CATEGORYID);
                }
                if (findNode != null)
                {
                    TreeNode childeNode = new TreeNode();
                    childeNode.Value = "Info_" + item.ID; //加Info_前缀的目的是防止ID和类别的ID相同 
                    childeNode.Text = "" + item.NAME;
                    findNode.ChildNodes.Add(childeNode);

                    categoryID = item.CATEGORYID;
                }
            }

            foreach (TreeNode node in nodes)
            {
                root.ChildNodes.Add(node);
            }
            tvReport.Nodes.Add(root);
        }

        /// <summary>
        /// 角色列表
        /// </summary>
        public void BindRoleTreeData()
        {
            TreeNode root = new TreeNode();
            root.Text = "角色列表";
            root.Value = "0";
            var list = WebSysRoleBLL.Instance.GetAllList(" DELETED !=1 ");

            foreach (var itm in list)
            {
                TreeNode node = new TreeNode();
                node.Text = itm.ROLE_NAME;
                node.Value = "" + itm.ID;
                root.ChildNodes.Add(node);
            }
            tvRole.Nodes.Add(root);
        }

        /// <summary>
        /// 根据数据库记录选择当前人员拥有的角色
        /// </summary>
        protected void BindCheckedRole()
        {
            string condition = string.Format("LOGIN_ID='{0}' and DELETED !=1", UserId);
            var list = WebLoginRoleBLL.Instance.GetAllList(condition);           
            foreach (var item in list)
            {
                foreach (TreeNode node in tvRole.Nodes[0].ChildNodes)
                {
                    if (node.Value == "" + item.ROLE_ID)
                    {
                        node.Checked = true;
                        break;
                    }
                }
            }
        }


        /// <summary>
        /// 根据数据库记录选择当前人员拥有的常规功能菜单权限
        /// </summary>
        protected void BindCheckedMenu()
        {
            var list = WebLoginInfoBLL.Instance.GetFuncsByID(""+UserId);
            for (int i = 0; i < list.Count;i++ )
            {
                TreeNode node = TreeNodeHelper.GetChildNodeByID(tvMenu.Nodes[0],  "" + list[i]);
                if (node != null)
                {
                    node.Checked = true;
                }
                //暂时没找的好的方法，只能用最笨的遍历了
                //foreach (TreeNode menuNode in tvMenu.Nodes[0].ChildNodes)
                //{
                //    foreach (TreeNode node in menuNode.ChildNodes)
                //    {
                //        if (node.Value == ""+list[i])
                //        {
                //            node.Checked = true;
                //            break;
                //        }
                //    }
                //}
            }
            
        }

        /// <summary>
        /// 根据数据库记录选择当前人员拥有的报表功能菜单权限
        /// </summary>
        protected void BindCheckedReport()
        {
            var list = WebLoginInfoBLL.Instance.GetReportFuncsByUserID("" + UserId);
            for (int i = 0; i < list.Count; i++)
            {
                TreeNode node = TreeNodeHelper.GetChildNodeByID(tvReport.Nodes[0], "Info_" + list[i]);
                if (node != null)
                {
                    node.Checked = true;
                }
            }
        }

        /// <summary>
        /// 重新加载常规权限
        /// </summary>
        protected void ReBindCheckedMenu()
        {
            //暂时没找的好的方法，只能用最笨的遍历了
            //foreach (TreeNode menuNode in tvMenu.Nodes[0].ChildNodes)
            //{
            //    foreach (TreeNode node in menuNode.ChildNodes)
            //    {
            //        node.Checked = false;
            //    }                
            //}
            TreeNodeHelper.CheckedOrUnCheckedAllNode(tvMenu.Nodes, false);
            BindCheckedMenu();
        }

        /// <summary>
        /// 重新报表权限
        /// </summary>
        protected void ReBindCheckedReport()
        {            
            TreeNodeHelper.CheckedOrUnCheckedAllNode(tvReport.Nodes, false);
            BindCheckedReport();
        }

        protected void tvRole_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            if (e.Node.Checked)
            {
                WEB_LOGIN_ROLE model = new WEB_LOGIN_ROLE();
                model.ROLE_ID = Convert.ToInt32(e.Node.Value);
                model.LOGIN_ID = UserId;
                model.CREATE_TIME = DateTime.Now;
                model.MODIFIED_TIME = DateTime.Now;
                model.DELETED = 0;
                WebLoginRoleBLL.Instance.SaveOrUpdate(model);
            }
            else
            {
                WebLoginRoleBLL.Instance.DeleteByRoleIDAndUserID(e.Node.Value, ""+UserId);
            }
            ReBindCheckedMenu();
            ReBindCheckedReport();
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}