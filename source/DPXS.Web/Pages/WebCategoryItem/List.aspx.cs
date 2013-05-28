using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCX.Web.Pages.WebCategoryItem
{
    public partial class List : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ResetAddDeleteCancle(false);
                BindTreeData();
            }
        }

        private const string _Category = "Category";
        public ICategoryService Service
        {
            get { return DependencyResolver.Resolver<ICategoryService>(); }
        }

        public ICategoryItemService CategoryItemService
        {
            get { return DependencyResolver.Resolver<ICategoryItemService>(); }
        }
        private List<TreeNode> GetFirstTree(int? parentId = 0, string comanyName = null)
        {
            var list = this.Service.GetCategoryList(this.txtQueryText.Text);

            return list.Select(m => new TreeNode() { Text = m.Name, Value = m.Id.ToString(), Target = _Category }).ToList();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindTreeData(txtQueryText.Text.Trim());
            this.ParentId = 0;
            this.CategoryId = 0;
            this.Id = 0;
            this.btnNew.Enabled = false;
            this.ResetAddDeleteCancle(false);
            this.CurrentModel = null;
        }

        public void BindTreeData(string keyWord = "")
        {
            TreeView1.Nodes.Clear();

            TreeNode root = new TreeNode();
            root.Text = "分类菜单树";
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
        }
        /// <summary>
        /// 父ID
        /// </summary>
        public int ParentId
        {
            get
            {
                if (string.IsNullOrEmpty(this.ParentIdLbl.Text))
                {
                    return 0;
                }
                return int.Parse(this.ParentIdLbl.Text);
            }
            set { this.ParentIdLbl.Text = value.ToString(); }
        }
        /// <summary>
        /// 分类ID
        /// </summary>
        public int CategoryId
        {
            get
            {
                if (string.IsNullOrEmpty(this.CategoryIdlbl.Text))
                {
                    return 0;
                }
                return int.Parse(this.CategoryIdlbl.Text);
            }
            set { this.CategoryIdlbl.Text = value.ToString(); }
        }
        /// <summary>
        /// 新增类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            if (this.Selected == null)
            {
                this.ShowMsg("请选中树形节点");
                return;
            }
            this.Id = 0;
            if (this.Selected.Target == _Category) // 新增CategoryItem 无父类
            {
                this.CategoryId = int.Parse(this.Selected.Value);
                ParentId = 0;
            }
            else // 新增CategoryItem
            {
                ParentId = int.Parse(this.Selected.Value);
                CategoryId = this.CategoryItemService.FindById(this.ParentId).Category.Id;
            }
            this.CurrentModel = null;
            this.ResetAddDeleteCancle(true);

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
            //var node = TreeView1.SelectedNode;

            //if (node.Target == _Category)
            //{
            //    this.ShowMsg("分类类别，不允许进行删除操作！");
            //}
            //else
            //{
            //    var model = this.Service.FindById(int.Parse(node.Value));

            //    model.Deleted = true;
            //    this.Service.Update(model);

            //    BindTreeData();
            //}
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            var node = Selected;

            if (node.Value == "0")
            {
                this.btnNew.Enabled = false;
                return;
            }
            int? categortyId = null;
            int parentId = 0;
            if (node.Target == _Category)
            {
                categortyId = int.Parse(node.Value);
                this.CategoryId = categortyId.Value;
                Id = 0;
            }
            else
            {
                parentId = int.Parse(node.Value);
                Id = parentId;
            }
            CurrentModel = this.CategoryItemService.FindById(Id);
            var child = this.GetCategortyItem(categortyId, parentId);
            node.ChildNodes.Clear();
            child.ForEach(m => node.ChildNodes.Add(m));
            this.btnNew.Enabled = true;

            ResetAddDeleteCancle(node.Target != _Category);
        }
        /// <summary>
        /// 选中树形结构
        /// </summary>
        public TreeNode Selected
        {
            get { return this.TreeView1.SelectedNode; }
        }
        private List<TreeNode> GetCategortyItem(int? categortyId, int parentId)
        {
            IList<CategoryItem> list;
            if (categortyId.HasValue)
            {
                list = this.CategoryItemService.FindCagegoryItem(categortyId.Value, true);
            }
            else
            {
                list = this.CategoryItemService.FindByParentId(parentId);
            }
            return
                list.Where(m => m.Deleted == false).Select(m => new TreeNode() { Text = m.Name, Value = m.Id.ToString(), Target = "CagegoryItem" })
                    .ToList();
        }

        public int Id
        {
            get
            {
                if (string.IsNullOrEmpty(this.RequestId.Text))
                {
                    return 0;
                }
                else
                {
                    return int.Parse(this.RequestId.Text);
                }
            }
            set { this.RequestId.Text = value.ToString(); }
        }
        public CategoryItem CurrentModel
        {
            get
            {
                CategoryItem customer = Id != 0 ? this.CategoryItemService.FindById(Id) : new CategoryItem();
                FaceToData(ref customer);
                return customer;
            }
            set
            {
                DataToFace(value);
            }
        }

        private void DataToFace(CategoryItem value)
        {
            if (value == null)
            {
                // 清空数据
                Category category = this.Service.FindById(this.CategoryId);

                this.CategoryID.Text = string.Empty;
                this.ParentItemID.Text = string.Empty;

                if (category != null)
                {
                    this.CategoryID.Text = category.Name;
                    this.ParentItemID.Text = string.Empty;
                }
                CategoryItem parent = this.CategoryItemService.FindById(this.ParentId);
                if (parent != null)
                {
                    this.CategoryID.Text = parent.Category.Name;
                    this.ParentItemID.Text = parent.Name;
                }
                this.NameID.Text = string.Empty;
                this.DescriptionID.Text = string.Empty;
                this.OrderIndexID.Text = "0";
                return;
            }

            this.NameID.Text = value.Name;
            this.DescriptionID.Text = value.Description;
            this.OrderIndexID.Text = value.OrderIndex.ToString();
            this.CategoryID.Text = value.Category == null ? string.Empty : value.Category.Name;
            this.ParentItemID.Text = value.ParentItem == null ? string.Empty : value.ParentItem.Name;
            OtherInfoID.Text = value.OtherInfo;
        }

        private void FaceToData(ref CategoryItem customer)
        {
            if (this.Id == 0) // 新增
            {
                if (this.Selected != null && this.Selected.Target != _Category)
                {
                    customer.ParentItem = this.CategoryItemService.FindById(this.ParentId);
                    if (customer.ParentItem != null)
                    {
                        customer.Category = customer.ParentItem.Category;
                    }
                }
                else
                {
                    customer.Category = this.Service.FindById(CategoryId);
                }
            }

            customer.Name = this.NameID.Text;
            customer.Description = this.DescriptionID.Text;
            customer.OrderIndex = short.Parse(this.OrderIndexID.Text);
            customer.OtherInfo = this.OtherInfoID.Text;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DeleteId_Click(object sender, EventArgs e)
        {
            if (this.Selected == null || this.Id == 0)
            {
                this.ShowMsg("请选择要删除的节点");
                return;
            }
            var model = this.CategoryItemService.FindById(this.Id);
            if (model.ChildItems.Where(m => m.Deleted == false).Count() > 0)
            {
                this.ShowMsg("存在叶子节点不容许删除");
                return;
            }
            model.Deleted = true;
            this.CategoryItemService.Update(model);
            this.ShowMsg("删除成功!");
            RebulidChidTree();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string errorMsg;
            if (!this.CheckData(out errorMsg))
            {
                this.ShowMsg(errorMsg);
                return;
            }
            if (this.Id == 0)
            {
                this.CategoryItemService.Save(this.CurrentModel);
                this.ShowMsg("新增成功!");
            }
            else
            {
                this.CategoryItemService.Update(this.CurrentModel);
                this.ShowMsg("更新成功!");
            }
            RebulidChidTree();
        }
        private bool CheckData(out string errorMsg)
        {
            errorMsg = string.Empty;
            if (!this.OrderIndexID.Text.IsInt())
            {
                this.OrderIndexID.Focus();
                errorMsg = "排序需为数字";
                return false;
            }
            return true;
        }
        /// <summary>
        /// 重新绘制子树
        /// </summary>
        private void RebulidChidTree()
        {
            var node = this.Selected;
            if (node == null)
            {
                return;
            }
            List<TreeNode> list = new List<TreeNode>();
            // 如果当前选中的是Category，则重新加载CategortyItem，否则，只加载孩子节点
            if (node.Target == _Category)
            {
                list.AddRange(this.GetCategortyItem(int.Parse(node.Value), 0));
            }
            else
            {
                node = node.Parent;
                // 如果选中的节点父节点还是Category，需要获取Category，并进行绑定
                if (node.Target == _Category)
                {
                    list.AddRange(this.GetCategortyItem(int.Parse(node.Value), 0));
                }
                else
                {
                    list.AddRange(this.GetCategortyItem(null, int.Parse(node.Value)));
                }
            }
            node.ChildNodes.Clear();
            list.ForEach(m => node.ChildNodes.Add(m));

            node.Expand();
            node.Select();
            ResetAddDeleteCancle(false);
        }
        /// <summary>
        /// 重置按钮状态
        /// </summary>
        /// <param name="enabled"></param>
        private void ResetAddDeleteCancle(bool enabled)
        {
            this.btnSubmit.Enabled = enabled;
            this.DeleteId.Enabled = enabled;
        }
    }
}