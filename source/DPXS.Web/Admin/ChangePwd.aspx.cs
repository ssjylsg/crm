using System;
using WebCrm.Model;
using WebCrm.Web.Facade;

namespace WebCX.Web.Admin
{
    public partial class ChangePwd : WebCrm.Web.Facade.BasePage
    {
        protected override void OnLoad(EventArgs e)
        {
            txtName.Text = this.CurrentOperatorUser.OperatorName;
            base.OnLoad(e);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                string oldPwd = txtOriPwd.Text; //原始密码
                oldPwd = (oldPwd).Md5();
                string newPwd = txtPwd.Text;//新密码
                newPwd = (newPwd).Md5();

                if (oldPwd != CurrentOperatorUser.OperatorPass)
                {
                    throw new Exception("原始密码错误");
                }
                else
                {

                    var service = WebCrm.Framework.DependencyResolver.Resolver<WebCrm.Model.Services.IUserInfoService>();
                    var user = service.FindById(this.CurrentOperatorUser.Id);
                    user.OperatorPass = newPwd;
                    service.Update(user);
                    this.ShowMsg("密码修改成功", "Welcome.htm");
                }
            }
            catch (System.Exception ex)
            {
                this.ShowMsg(ex.Message);
            }
        }
    }
}