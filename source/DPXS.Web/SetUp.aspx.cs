using System;
using WebCrm.Framework;
using WebCrm.Model.Services;

namespace WebCrm.Web
{
    public partial class SetUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DependencyResolver.Resolver<IPlugService>().FunctionInsert();
            this.PlugBtn.Enabled = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DependencyResolver.Resolver<IRoleService>().AddRoleAdmin();
            this.RoleBtn.Enabled = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            DependencyResolver.Resolver<IUserInfoService>().AddAdmin();
            this.UserBtn.Enabled = false;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DependencyResolver.Resolver<IRolePlugService>().GrantFunToRole();
            this.RoleUserBtn.Enabled = false;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            DependencyResolver.Resolver<ICrmDictionaryService>().CrmDictoryTest();
            this.CrmBtn.Enabled = false;
        }
    }
}