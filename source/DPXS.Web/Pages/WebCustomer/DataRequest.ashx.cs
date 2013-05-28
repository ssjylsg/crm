using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCrm.Framework;
using WebCrm.Model;
using WebCrm.Model.Services;
using WebCrm.Web.Facade;
namespace WebCrm.Web.Pages.WebCustomer
{
    /// <summary>
    /// DataRequest 的摘要说明
    /// </summary>
    public class DataRequest : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var type = request.GetRequestValue("type");

            context.Response.ContentType = "text/plain";
            string result = string.Empty;
            if (!string.IsNullOrEmpty(type))
            {
                switch (type)
                {
                    case "getcustomerno":
                        result = GetCustomerNo();
                        break;
                    case "checkcustomername":
                        result =
                        CheckCustomerName(request.GetRequestValue("name"), request.GetRequestValue("id"));
                        break;
                    case "findsubcategoryitem":
                        result = FindCategoryItem(request.GetRequestValue("category"),
                                                  request.GetRequestValue("id"));
                        break;
                    case "querycustomername":
                        result = QueryCustomerByName(request.GetRequestValue("key"));
                        break;
                    default:
                        break;
                }
            }
            context.Response.Write((new { Result = result }).ToJson());
        }

        private string QueryCustomerByName(string key)
        {
            string result = string.Empty;
            var pageQuery = new PageQuery<IDictionary<string, object>, Customer>(HttpCurrentUserService.Current);
            pageQuery.Condition = new Dictionary<string, object>();
            pageQuery.Condition.Add("Name", key);
            DependencyResolver.Resolver<ICustomerService>().Query(pageQuery);
            pageQuery.Result.Where(m => m.Deleted == false).ToList().ForEach(m =>
                                                                                 {
                                                                                     result +=
                                                                                         "<p onMouseOver=\"this.style.backgroundColor='#B4D7E9';\" onMouseOut=\"this.style.backgroundColor=''\" onClick=\"clickkey('" +
                                                                                         m.Id.ToString() + "','" +
                                                                                         m.Name +
                                                                                         "')\" style=\"cursor:pointer\">" +
                                                                                         m.Name.ToString().Trim() +
                                                                                         "</p>";
                                                                                 });
            return result;
        }
        /// <summary>
        /// 获取联动下拉框
        /// </summary>
        /// <param name="categoryType"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private string FindCategoryItem(string categoryType, string id)
        {
            int outId;
            List<string> selected = new List<string>();
            if (int.TryParse(id, out outId) && !string.IsNullOrEmpty(categoryType))
            {
                selected =
                    DependencyResolver.Resolver<ICategoryItemService>().FindById(outId).ChildItems.Where(m => !m.Deleted)
                        .Select(m => string.Format("<option value='{0}'>{1}</option>", m.Id, m.Name)).ToList();

            }
            return string.Format("<select>{0}</selected>", string.Join("", selected.ToArray()));
        }
        /// <summary>
        /// 检查客户名称
        /// </summary> 
        /// <returns></returns>
        private string CheckCustomerName(string s, string id)
        {
            int outId;
            if (int.TryParse(id, out outId))
            {
                return
                DependencyResolver.Resolver<ICustomerService>().ExistName(s, outId).ToString();
            }
            return "True";
        }
        /// <summary>
        /// 获取客户编号
        /// </summary>
        /// <returns></returns>
        private string GetCustomerNo()
        {
            return DependencyResolver.Resolver<ICustomerService>().GetCustomerNo();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}