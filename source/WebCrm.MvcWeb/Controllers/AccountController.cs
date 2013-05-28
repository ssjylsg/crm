using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web.Security;
using WebCrm.Model;
using WebCrm.Model.Services;
using WebCrm.MvcWeb.Models;
using WebCrm.Web.Facade;

namespace WebCrm.MvcWeb.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult LogOn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            string result = "";


            if (string.IsNullOrEmpty(model.UserName))
            {
                result = ("请输入用户名！");
                ViewData["Result"] = result;
                return View();
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                result = ("请输入密码！");
                ViewData["Result"] = result;
                return View();
            }

            if (model.ValidCode != (Session["ValidCode"] ?? string.Empty).ToString())
            {
                result = ("验证码错误！");
                ViewData["Result"] = result;
                return View();
            }

            var userInfoService =
                WebCrm.Framework.DependencyResolver.Resolver<IUserInfoService>();
            var userInfo = userInfoService.FindByUserName(model.UserName.ToUpper());

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

                    if (userInfo.OperatorPass != model.Password.Md5())
                    {
                        result = "密码错误！";
                    }
                    else
                    {
                        userInfo.LastLoginTime = DateTime.Now;

                        userInfoService.Update(userInfo);
                        Session.Clear();
                        FormsAuthentication.SetAuthCookie(
                            string.Format("{0},{1}", userInfo.OperatorCode, userInfo.Id), false);

                        return RedirectToAction("EvernoteList");
                    }
                }
            }

            ViewData["Result"] = result;
            return View();
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            ChangePasswordModel model = new ChangePasswordModel();
            model.OldPassword = HttpCurrentUserService.Current.OperatorPass;
            return View(model);
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            //DependencyResolver.SetResolver();
            return View(model);
        }

        public ActionResult ChangePasswordSuccess()
        {

            return View();
        }
        [HttpGet]
        public ActionResult EvernoteList()
        {
            var model = ModelReposity.FindAll().Select(m => new EvernoteModel(m)).ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddEvernote(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View();
            }

            return View(new EvernoteModel(ModelReposity.FindById(int.Parse(id))));
        }
        [HttpPost]
        public ActionResult AddEvernote(EvernoteModel evernoteModel)
        {
            EvernoteEntity entity = evernoteModel.ConvertToEntity();
            ModelReposity.Save(entity);
            return RedirectToAction("EvernoteList");
        }
        [HttpPost]
        public ActionResult DeleteEvernote(int id)
        {
            ModelReposity.Delete(id);
            return new JsonResult() { Data = new { Success = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpPost]
        public ActionResult AutoGenerate()
        {
            for (int i = 0; i < 20; i++)
            {
                var model = new EvernoteEntity() { Content = i.ToString(), Group = i.ToString(), Title = string.Format("第{0}个", i) };
                model.CreateUser = WebCrm.Framework.DependencyResolver.Resolver<IUserInfoService>().FindByUserName("LISG");
                model.SetId(ModelReposity.GenerateId());
                ModelReposity.Save(model);
            }

            return new JsonResult() { Data = new { Success = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult DeleteAll()
        {
            ModelReposity.RemoveAll();
            return new JsonResult() { Data = new { Success = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetAll()
        {
            return new JsonResult() { Data = new { Success = true, Data = ModelReposity.FindAll().Select(m => new EvernoteModel(m)).ToArray() }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }

    public static class HelperMvc
    {
        public static SelectListItem[] BindBussinessPerson(string selectText)
        {
            PageQuery<IDictionary<string, object>, OperatorUser> pageQuery = new PageQuery<IDictionary<string, object>, OperatorUser>(HttpCurrentUserService.Current);
            pageQuery.Condition = new Dictionary<string, object>();
            pageQuery.PageSize = int.MaxValue;
            pageQuery.CurrentPageIndex = 1;
            pageQuery.Condition["IsCrm"] = "1";
            WebCrm.Framework.DependencyResolver.Resolver<IUserInfoService>().Query(pageQuery);

            return pageQuery.Result.Where(m => m.Deleted == false)
                .Select(m => new SelectListItem()
                                 {
                                     Text = m.OperatorName,
                                     Value = m.Id.ToString(),
                                     Selected = m.Id.ToString() == selectText
                                 }).ToArray();
        }
    }
}
