using System;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using WebCrm.Model;
using WebCrm.Model.Services;
using WebCrm.Service;

namespace WebCrm.Web.Facade
{
    public class AuthenticationHttpModel : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += new EventHandler(context_PostRequestHandlerExecute);
        }

        private string[] _ingoreExistion = new string[] { ".css", ".js", ".jpg", ".gif", ".png" };
        public void Dispose()
        {

        }

        void context_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpContext context = (sender as HttpApplication).Context;
            HttpRequest request = context.Request;
            // js css 图片，不需要做限制
            if (request.CurrentExecutionFilePathExtension == null || this._ingoreExistion.Contains(request.CurrentExecutionFilePathExtension))
            {
                return;
            }
            if (request.CurrentExecutionFilePath.Contains("ValidCode.aspx")) // 验证码
            {
                return;
            }
            IPrincipal principal = context.User;
            var oper = context.Items[HttpCurrentUserService.CurrentUserKey] as OperatorUser;
            if(oper != null)
            {
                new HttpCurrentUserService().SetUser(oper);
                return;
            }
            AuthenticateWithForm(context, request, principal);

        }
        static void AuthenticateWithForm(HttpContext context, HttpRequest request, IPrincipal principal)
        {
            if (request.Url.ToString().ToLower().IndexOf(FormsAuthentication.LoginUrl.ToLower()) > 0)
                return;

            var cookie = request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                RedirectToLoginPage(context);
                return;
            }
            IUserInfoService userInfoService = WebCrm.Framework.DependencyResolver.Resolver<IUserInfoService>();
            var ticket = FormsAuthentication.Decrypt(request.Cookies[FormsAuthentication.FormsCookieName].Value);
            var username = ticket.Name.Split(',')[0];
            var userid = ticket.Name.Split(',')[1];

            var contextService = new HttpCurrentUserService();
            var user = userInfoService.FindById(int.Parse(userid));
            contextService.SetUser(user);

            if (user == null)
                RedirectToLoginPage(context);
        }
        static void RedirectToLoginPage(HttpContext context)
        {
            FormsAuthentication.RedirectToLoginPage();
            context.Response.End();
        }
    }
}

