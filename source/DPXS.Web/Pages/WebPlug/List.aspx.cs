using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;
namespace WebCX.Web.Pages.WebPlug
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
        public IPlugService Service
        {
            get { return DependencyResolver.Resolver<IPlugService>(); }
        }
        /// <summary>
        /// 根据条件查询，返回查询后的DepartmentTree
        /// </summary>
        /// <param name="keyWord">关键词，为空表示查询整棵树</param>
        /// <returns></returns>
        public List<TreeNode> GetTree(string keyWord)
        {
            var pageQuery = new PageQuery<IDictionary<string, object>, Plug>(this.CurrentOperatorUser);
            pageQuery.Condition = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(txtQueryText.Text.Trim()))
            {
                pageQuery.Condition["PlugName"] = txtQueryText.Text.Trim();
            }
            pageQuery.CurrentPageIndex = 1;
            pageQuery.PageSize = int.MaxValue;
            Service.Query(pageQuery);
            return AspNetHelper.GetPlugChildNote(pageQuery.Result.ToList());
        }


        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindTreeData(txtQueryText.Text.Trim());
        }

        public void BindTreeData(string keyWord = "")
        {
            TreeView1.Nodes.Clear();
            List<TreeNode> nodes = GetTree(keyWord);
            TreeNode root = new TreeNode();
            root.Text = "功能菜单树";
            root.Value = "0";

            foreach (TreeNode node in nodes)
            {
                root.ChildNodes.Add(node);
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
            if (node.ChildNodes.Count > 0)
            {
                this.ShowMsg("存在子节点时，不允许直接进行删除操作！");
            }
            else
            {
                var model = this.Service.FindById(int.Parse(node.Value));
                model.Deleted = true;

                this.Service.Update(model);
                BindTreeData();
            }
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            var node = TreeView1.SelectedNode;
            btnEdit.Enabled = node.Value == "0" ? false : true;
            btnDelete.Enabled = node.Value == "0" ? false : true;

            if (node.Depth == 2)
            {
                btnNew.Enabled = false;
            }
            else
            {
                btnNew.Enabled = true;
            }
        }


    }
}