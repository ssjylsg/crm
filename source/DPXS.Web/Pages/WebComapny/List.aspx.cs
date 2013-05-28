using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCX.Web.Pages.WebComapny
{
    public partial class List : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTreeData();
            }
        }

        public ICompanyService Service
        {
            get { return DependencyResolver.Resolver<ICompanyService>(); }
        }


        private List<TreeNode> GetFirstTree(int? parentId = 0, string comanyName = null)
        {
            if (!parentId.HasValue)
            {
                parentId = 0;
            }
            IList<Company> list = this.Service.GetComapnyList(comanyName, parentId);
            return list.Select(m => new TreeNode() { Text = m.Name, Value = m.Id.ToString() }).ToList();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindTreeData(txtQueryText.Text.Trim());
        }

        public void BindTreeData(string keyWord = "")
        {
            TreeView1.Nodes.Clear();

            TreeNode root = new TreeNode();
            root.Text = "公司菜单树";
            root.Value = "0";
            foreach (TreeNode treeNode in this.GetFirstTree(null, keyWord))
            {
                root.ChildNodes.Add(treeNode);
            }
            TreeView1.Nodes.Add(root);
            TreeView1.ExpandAll();

            ReInitBtnState();
        }

        /// <summary>
        /// 重新初始化按钮状态
        /// </summary>
        public void ReInitBtnState()
        {
            btnNew.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        /// <summary>
        /// 新增类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            string url = "NewOrEdit.aspx";
            if (TreeView1.SelectedNode != null)
            {
                url = string.Format("NewOrEdit.aspx?NE=new&ParentId={0}&ParentName={1}", TreeView1.SelectedNode.Value, TreeView1.SelectedNode.Text);
            }
            Response.Redirect(url);
        }

        /// <summary>
        /// 编辑类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string url = string.Format("NewOrEdit.aspx?NE=edit&ParentId={0}&ParentName={1}&Id={2}&Name={3}",
                TreeView1.SelectedNode.Parent.Value, TreeView1.SelectedNode.Parent.Text, TreeView1.SelectedNode.Value, TreeView1.SelectedNode.Text);
            Response.Redirect(url);
        }

        /// <summary>
        /// 删除类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var node = TreeView1.SelectedNode;
            var model = this.Service.FindById(int.Parse(node.Value));
            if (model.ChildCompany.Count > 0)
            {
                this.ShowMsg("存在子节点时，不允许直接进行删除操作！");
            }
            else
            {

                model.Deleted = true;
                this.Service.Update(model);

                BindTreeData();
            }
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            var node = TreeView1.SelectedNode;
            var child = this.GetFirstTree(int.Parse(node.Value));
            node.ChildNodes.Clear();
            child.ForEach(m => node.ChildNodes.Add(m));
            this.btnNew.Enabled = true;
            this.btnEdit.Enabled = true;
            this.btnDelete.Enabled = child.Count <= 0;
        }
    }
}