using System;
using System.Web.Security;
using WebCrm.Framework;
using WebCrm.Model;
using WebCrm.Model.Services;
using WebCrm.Web.Facade;

namespace DPXS.Web.Admin
{
    public partial class Login : BasePage
    {
        private IUserInfoService _userInfoService;
        public Login()
        {
            _userInfoService = DependencyResolver.Resolver<IUserInfoService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Act == "login")
                    Log_in();
                else if (Act == "out")
                    Log_out();
            }
        }

        /// <summary>
        /// 操作
        /// </summary>
        public string Act
        {
            get
            {
                var ret = Request.GetRequestValue("hdAct");

                if (string.IsNullOrEmpty(ret))
                {
                    ret = Request.GetRequestValue("act");
                }
                return ret;
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        private void Log_in()
        {
            // 参数获取
            string userName = this.Request.GetRequestValue("txtUserName").ToUpper();
            string password = this.Request.GetRequestValue("txtPassword");
            string validCode = this.Request.GetRequestValue("txtValidCode");

            // 参数验证
            try
            {
                if (string.IsNullOrEmpty(userName))
                    throw new Exception("请输入用户名！");

                if (string.IsNullOrEmpty(password))
                    throw new Exception("请输入密码！");

                if (validCode != Session["ValidCode"].ToString())
                    throw new Exception("验证码错误！");
            }
            catch (Exception ex)
            {
                this.ShowMsg(ex.Message, "Login.aspx");
                return;
            }

            // 验证登录
            string result = "OK";
            var userInfo = _userInfoService.FindByUserName(userName);
            if (userInfo == null)
            {
                result = "用户不存在！";
            }
            else
            {

                if (userInfo.UseFlag == 0)
                {
                    result = "用户已被停用！";
                }
                else
                {
                    if (userInfo.OperatorPass != (password).Md5())
                    {
                        result = "密码错误！";
                    }
                    else
                    {
                        userInfo.LastLoginTime = DateTime.Now;

                        _userInfoService.Update(userInfo);
                        Session.Clear();
                        FormsAuthentication.SetAuthCookie(
                            string.Format("{0},{1}", userInfo.OperatorCode, userInfo.Id), false);
                        Response.Redirect("/Admin/default.aspx");
                    }
                }
            }
            this.ShowMsg(result);
        }

        /// <summary>
        /// 退出
        /// </summary>
        private void Log_out()
        {
            FormsAuthentication.SignOut();
            System.Web.HttpContext.Current.Items.Clear();
            System.Web.HttpContext.Current.Request.Cookies.Clear();

            FormsAuthentication.RedirectToLoginPage();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Log_in();
        }
    }
}