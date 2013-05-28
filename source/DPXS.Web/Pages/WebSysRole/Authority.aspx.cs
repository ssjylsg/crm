using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model.Services;
using WebCrm.Model;
using WebCrm.Web.Facade;


namespace WebCX.Web.Pages.WebSysRole
{
    public partial class Authority : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTitle.Text = RoleName;
                BindMenuTreeData();
                BindUserTreeData();
            }
        }

        /// <summary>
        /// RoleID
        /// </summary>
        public int Id
        {
            get
            {
                string strId = Request.QueryString["Id"];
                return Convert.ToInt32(strId);
            }
        }
        public Role CurrentRole
        {
            get { return this.RoleService.FindById(this.Id); }
        }
        public IRoleService RoleService
        {
            get { return DependencyResolver.Resolver<IRoleService>(); }
        }
        public IUserInfoService UserInfoService
        {
            get { return DependencyResolver.Resolver<IUserInfoService>(); }
        }
        public IPlugService PlugService
        {
            get { return DependencyResolver.Resolver<IPlugService>(); }
        }
        public IRolePlugService RolePlugService
        {
            get { return DependencyResolver.Resolver<IRolePlugService>(); }
        }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName
        {
            get { return Request.QueryString["RoleName"]; }
        }

        /// <summary>
        /// 根据条件查询，返回查询后的Tree
        /// </summary>
        /// <param name="keyWord">关键词，为空表示查询整棵树</param>
        /// <returns></returns>
        public List<TreeNode> GetMenuTree(string keyWord)
        {
            var pageQuery = new PageQuery<IDictionary<string, object>, Plug>(this.CurrentOperatorUser);
            pageQuery.Condition = new Dictionary<string, object>();

            pageQuery.SetQueryAll();
            PlugService.Query(pageQuery);
            return AspNetHelper.GetPlugChildNote(pageQuery.Result.ToList(),
                                                 this.RolePlugService.GetPlugs(this.CurrentRole).ToList());
        }

        /// <summary>
        /// 常规功能菜单树
        /// </summary>
        /// <param name="keyWord"></param>
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
        }


        /// <summary>
        /// 用户列表
        /// </summary>
        public void BindUserTreeData()
        {
            TreeNode root = new TreeNode();
            root.Text = "用户列表";
            root.Value = "0";
            root.ChildNodes.AddReage(AspNetHelper.GetOperateTree(this.CurrentOperatorUser, this.RolePlugService.GetUsers(this.CurrentRole)));
            tvUser.Nodes.Add(root);
        }

        protected void tvMenu_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            var plug = this.PlugService.FindById(int.Parse(e.Node.Value));
            var model = this.CurrentRole;
            RolePlug opr = this.RolePlugService.FindRolePlugById(model.Id, plug.Id);
            if (opr != null)
            {
                opr.Deleted = !e.Node.Checked;
                opr.ModifyTime = DateTime.Now;
                this.RolePlugService.Update(opr);
            }
            else if (e.Node.Checked)
            {
                opr = new RolePlug();
                opr.Optor = this.CurrentOperatorUser;
                opr.Role = model;
                opr.Plug = plug;

                this.RolePlugService.Save(opr);
            }
        }
 

        protected void tvUser_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            var user = this.UserInfoService.FindById(int.Parse(e.Node.Value));
            var model = this.CurrentRole;
            var opr = this.RolePlugService.FindRoleOperatorById(model.Id, user.Id);
            if (opr != null)
            {
                opr.Deleted = !e.Node.Checked;
                opr.ModifyTime = DateTime.Now;
                this.RolePlugService.Update(opr);
            }
            else if (e.Node.Checked)
            {
                opr = new RoleOperator();
                opr.Optor = this.CurrentOperatorUser;
                opr.Role = model;
                opr.User = user;

                this.RolePlugService.Save(opr);
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

    }
}