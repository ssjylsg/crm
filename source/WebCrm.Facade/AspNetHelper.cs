using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using WebCrm.Framework;
using WebCrm.Model;
using WebCrm.Model.Services;
using WebCrm.Service;

namespace WebCrm.Web.Facade
{
    /// <summary>
    /// Asp   Web From Helper 
    /// </summary>
    public static class AspNetHelper
    {
        public static ICategoryItemService CategoryItemService
        {
            get { return DependencyResolver.Resolver<ICategoryItemService>(); }
        }
        /// <summary>
        /// 二级联动下拉框 子下拉框绑定
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="subDropdown"></param>
        public static void BindSubDropDown(DropDownList parent, DropDownList subDropdown)
        {
            int parnetId;
            if (int.TryParse(parent.SelectedValue, out parnetId))
            {
                subDropdown.Items.Clear();

                subDropdown.Items.AddRange(
                    CategoryItemService.FindByParentId(parnetId).Select(
                        m => new ListItem { Text = m.Name, Value = m.Id.ToString() }).ToArray());

                subDropdown.Items.Insert(0, new ListItem("请选择", ""));
            }
        }

        private static Dictionary<Type, ListItem[]> _sFieldDict;
        public static ListItem[] GetFieldDescription(Type type)
        {
            if (_sFieldDict == null)
            {
                _sFieldDict = new Dictionary<Type, ListItem[]>();
            }
            if (_sFieldDict.ContainsKey(type))
            {
                return _sFieldDict[type];
            }
            List<ListItem> list = new List<ListItem>();
            foreach (var f in type.GetFields())
            {
                object[] objects = f.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute),
                                                                    false);

                if (objects != null && objects.Length > 0)
                {
                    var description = objects[0] as DescriptionAttribute;
                    if (description != null)
                    {
                        var value1 = Convert.ToInt32(f.GetValue(f));
                        list.Add(new ListItem
                        {
                            Text = description.Description,
                            Value = value1.ToString(),
                        });
                    }
                }
            }
            _sFieldDict[type] = list.ToArray();
            return _sFieldDict[type];
        }

        public static string GetRequestValue(this HttpRequest request, string name)
        {
            string value = request.QueryString[name];
            if (string.IsNullOrEmpty(value))
            {
                value = request.Form[name] ?? string.Empty;
            }
            return HttpUtility.UrlDecode(value);
        }
        public static string GetEnumDesc(this Enum value)
        {
            Type enumType = value.GetType();
            // 获取枚举常数名称。
            string name = Enum.GetName(enumType, value);

            // 获取枚举字段
            FieldInfo fieldInfo = enumType.GetField(name);
            if (fieldInfo != null)
            {
                // 获取描述的属性
                DescriptionAttribute attr = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), false) as DescriptionAttribute;
                if (attr != null)
                {
                    return attr.Description;
                }
            }

            return null;
        }
        /// <summary>
        /// 是否时间格式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDateTime(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            DateTime outDate;
            return DateTime.TryParse(value, out outDate);
        }
        /// <summary>
        /// 是否decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDecimal(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            decimal result;
            return decimal.TryParse(value, out result);
        }
        /// <summary>
        /// 绑定分类表中的下拉框
        /// </summary>
        /// <param name="requestList"></param>
        public static void BindDropDown(Dictionary<DropDownList, string> requestList)
        {
            var categoryService = DependencyResolver.Resolver<ICategoryService>();
            var categoryItemService = CategoryItemService;
            foreach (KeyValuePair<DropDownList, string> keyValuePair in requestList)
            {
                var category = categoryService.FindByCode(keyValuePair.Value);
                if (category == null)
                {
                    continue;
                }
                categoryItemService.FindCagegoryItem(category.Id, true).Where(m => m.Deleted == false).OrderBy(
                    m => m.OrderIndex).ToList().ForEach(
                        item =>
                        {
                            keyValuePair.Key.Items.Add(new ListItem(item.Name, item.Id.ToString()));
                        });
                keyValuePair.Key.Items.Insert(0, new ListItem("请选择", ""));
            }
        }

        private static ListItem _defaultSelect = new ListItem("请选择", "");
        /// <summary>
        /// 绑定客户
        /// </summary>
        /// <param name="downList"></param>
        public static void BindCustomer(DropDownList downList)
        {
            downList.Items.Clear();

            PageQuery<IDictionary<string, object>, Customer> pageQuery = new PageQuery<IDictionary<string, object>, Customer>(HttpCurrentUserService.Current);
            pageQuery.Condition = new Dictionary<string, object>();
            pageQuery.PageSize = int.MaxValue;
            pageQuery.CurrentPageIndex = 1;

            DependencyResolver.Resolver<ICustomerService>().Query(pageQuery);

            ListItem[] list = pageQuery.Result.Where(m => m.Deleted == false).Select(
                m => new ListItem() { Text = m.ShortName, Value = m.Id.ToString() }).ToArray();
            downList.Items.AddRange(list);
            downList.Items.Insert(0, _defaultSelect);
        }
        /// <summary>
        /// 绑定销售人员
        /// </summary>
        /// <param name="downList"></param>
        public static void BindBussinessPerson(DropDownList downList)
        {
            downList.Items.Clear();

            PageQuery<IDictionary<string, object>, OperatorUser> pageQuery = new PageQuery<IDictionary<string, object>, OperatorUser>(HttpCurrentUserService.Current);
            pageQuery.Condition = new Dictionary<string, object>();
            pageQuery.PageSize = int.MaxValue;
            pageQuery.CurrentPageIndex = 1;
            pageQuery.Condition["IsCrm"] = "1";
            DependencyResolver.Resolver<IUserInfoService>().Query(pageQuery);

            ListItem[] list = pageQuery.Result.Where(m => m.Deleted == false).Select(
                m => new ListItem() { Text = m.OperatorName, Value = m.Id.ToString(), Selected = false }).ToArray();
            downList.Items.AddRange(list);
            downList.Items.Insert(0, _defaultSelect);
        }
        /// <summary>
        /// 对字符串进行截取 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ToShortString(this string value, int length = 10)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            if (value.Length > length)
            {
                return value.Substring(0, length) + "...";
            }
            return value;
        }
        /// <summary>
        /// 根据下拉框的SelectedValue 获取字典表
        /// </summary>
        /// <param name="downList"></param>
        /// <returns></returns>
        public static CategoryItem GetItemByDropDownValue(DropDownList downList)
        {
            if (downList.SelectedValue.IsInt())
            {
                return CategoryItemService.FindById(int.Parse(downList.SelectedValue));
            }
            return null;
        }
        /// <summary>
        /// 设置下拉框选中
        /// </summary>
        /// <param name="downList"></param>
        /// <param name="categoryItem"></param>
        public static void SetDropDownSelectedvalue(DropDownList downList, CategoryItem categoryItem)
        {
            if (categoryItem != null)
            {
                downList.SelectedValue = categoryItem.Id.ToString();
            }
        }
        /// <summary>
        /// 获取网站的地址
        /// </summary>
        /// <returns></returns>
        public static string WebUrl()
        {
            return
                string.Format("{0}://{1}:{2}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host, HttpContext.Current.Request.Url.Port);
        }

        public static void AddReage(this TreeNodeCollection collection, IList<TreeNode> notes)
        {
            foreach (TreeNode treeNode in notes)
            {
                collection.Add(treeNode);
            }
        }

        #region 获取Plug 树形结构
        public static List<TreeNode> GetPlugChildNote(List<Plug> source, int parentId = 0)
        {
            return GetPlugChildNote(source, null, parentId);
        }
        /// <summary>
        /// 获取Plug 树形结构
        /// </summary> 
        public static List<TreeNode> GetPlugChildNote(List<Plug> source, List<Plug> plugs, int parentId = 0)
        {
            var list = new List<TreeNode>();
            list.AddRange(ForamtFunction(source.Where(m =>
                                                          {
                                                              if (parentId == 0)
                                                              {
                                                                  return m.Parent == null;
                                                              }
                                                              else
                                                              {
                                                                  return m.Parent != null &&
                                                                         m.Parent.Id == parentId;
                                                              }
                                                          }).ToList(), plugs));
            foreach (TreeNode treeNode in list)
            {
                var child = GetPlugChildNote(source, plugs, int.Parse(treeNode.Value));
                treeNode.ChildNodes.AddReage(child);
            }
            return list;
        }

        private static List<TreeNode> ForamtFunction(List<Plug> source, List<Plug> plugs)
        {

            return source
                .OrderBy(o => o.Sort)
                .Select(
                    m =>
                    new TreeNode()
                        {
                            Text = m.PlugName,
                            Value = m.Id.ToString(),
                            Checked = plugs != null ? plugs.IsIdInList(m) : false
                        })
                .ToList();

        }
        #endregion

        #region 操作员树形结构
        public static List<TreeNode> GetOperateTree(OperatorUser currentUser, IList<OperatorUser> users)
        {
            var pageQuery =
                new PageQuery<IDictionary<string, object>, OperatorUser>(currentUser.IsAdmin ? null : currentUser);
            pageQuery.Condition = new Dictionary<string, object>();
            pageQuery.SetQueryAll();
            DependencyResolver.Resolver<IUserInfoService>().Query(pageQuery);
            if (users == null)
            {
                return pageQuery.Result.Select(m => new TreeNode() { Text = m.OperatorName, Value = m.Id.ToString() }).ToList();
            }
            else
            {
                return
                    pageQuery.Result.Select(
                        m =>
                        new TreeNode() { Text = m.OperatorName, Value = m.Id.ToString(), Checked = users.IsIdInList(m) })
                        .ToList();
            }
        }
        public static bool IsIdInList<T>(this IList<T> value, T entity) where T : CrmEntity
        {
            return value.FirstOrDefault(m => m.Id == entity.Id) != null;
        }
        #endregion

        #region 角色树形结构
        /// <summary>
        /// 获取角色树形结构
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public static IList<TreeNode> GetRoleTreeNote(OperatorUser currentUser, IList<Role> roles)
        {
            var pageQuery = new PageQuery<IDictionary<string, object>, Role>(currentUser);
            pageQuery.Condition = new Dictionary<string, object>();

            pageQuery.SetQueryAll();
            DependencyResolver.Resolver<IRoleService>().Query(pageQuery);

            if (roles == null)
            {
                return pageQuery.Result.Select(m => new TreeNode() { Text = m.RoleName, Value = m.Id.ToString() }).ToList();
            }
            else
            {
                return
                    pageQuery.Result.Select(
                        m =>
                        new TreeNode() { Text = m.RoleName, Value = m.Id.ToString(), Checked = roles.IsIdInList(m) })
                        .ToList();
            }
        }
        #endregion

        public static string ToShortDate(this object value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            if (value.ToString().IsDateTime())
            {
                return DateTime.Parse(value.ToString()).ToString("yyyy-MM-dd");
            }
            return string.Empty;
        }
        /// <summary>
        /// 绑定合作单位
        /// </summary>
        /// <param name="downList"></param>
        public static void BindCooperation(DropDownList downList)
        {
            var query = new PageQuery<IDictionary<string, object>, Cooperation>(HttpCurrentUserService.Current);
            query.Condition = new Dictionary<string, object>();
            query.SetQueryAll();

            DependencyResolver.Resolver<ICooperationService>().Query(query);

            downList.Items.Clear();
            downList.Items.AddRange(
                query.Result.Select(m => new ListItem() { Text = m.Name, Value = m.Id.ToString() }).ToArray());
            downList.Items.Insert(0, _defaultSelect);
        }
        public static string AppendUiString(string tag, string value)
        {
            return string.Format("<td><span>{0}</span>{1}</td>", tag, value);
        }
        public static string AppendUiString(string tag, object value)
        {
            if (value.GetType() == typeof(DateTime))
            {
                return AppendUiString(tag, value.ToShortDate());
            }
            if (value.GetType() == typeof(decimal))
            {
                return AppendUiString(tag, decimal.Parse(value.ToString()).ToString("C"));
            }
            return AppendUiString(tag, (value ?? string.Empty).ToString());
        }
        public static string ItemName(this CategoryItem categoryItem)
        {
            if (categoryItem == null)
            {
                return string.Empty;
            }
            return categoryItem.Name;
        }
        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="fileAttachements"></param>
        /// <returns></returns>
        public static string DownLoadFile(IList<FileAttachement> fileAttachements)
        {
            return string.Join("</br>",
                               fileAttachements.Select(
                                   m =>
                                   string.Format("<a href ='{0}/DownLoadFile.aspx?fileId={1}' target='_blank'>{2}</a>", WebUrl(),
                                                 m.FileGuidId, m.FileName)).
                                   ToArray());
        }
        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="filedIds"></param>
        /// <returns></returns>
        public static string DownLoadFile(string filedIds)
        {
            return DownLoadFile(GetFiles(filedIds));
        }
        /// <summary>
        /// 附件集合
        /// </summary>
        public static IList<FileAttachement> GetFiles(string filedIds)
        {
            if (string.IsNullOrEmpty(filedIds))
            {
                return new List<FileAttachement>();
            }
            return DependencyResolver.Resolver<IFileService>().FindByIds(filedIds.Trim(',').Split(',').Where(m => m.IsInt()).Select(m => int.Parse(m)).ToArray());

        }


        /// <summary>
        /// 字符串长度判断
        /// </summary>
        /// <param name="input"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static bool ValidStringLength(this string input, int maxLength = 1000)
        {
            if (string.IsNullOrEmpty(input))
                return true;
            if (input.Length > maxLength)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 公司绑定
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="parent"></param>
        public static void BindCompany(DropDownList companyId, Company parent)
        {
            var service = DependencyResolver.Resolver<ICompanyService>();

            IList<ListItem> list = service.GetComapnyList(string.Empty, parent == null ? 0 : parent.Id).Select(
                m => new ListItem() { Text = m.Name, Value = m.Id.ToString() }).ToList();
            if (parent != null)
            {
                list.Add(new ListItem() { Text = parent.Name, Value = parent.Id.ToString() });
                list.Distinct();
            }
            companyId.Items.Clear();
            companyId.Items.AddRange(list.ToArray());
            companyId.Items.Insert(0, new ListItem() { Text = "请选择", Value = "" });
        }
        /// <summary>
        /// 部门绑定，如果company 为空，则绑定全部部门，负责只绑定给定公司的部门
        /// </summary>
        /// <param name="deptId"></param>
        /// <param name="company"></param>
        public static void BindDept(DropDownList deptId, Company company)
        {
            IList<Department> departments = DependencyResolver.Resolver<IDeptService>().GetDeptByCompany(company);

            deptId.Items.Clear();
            deptId.Items.AddRange(departments.Select(m => new ListItem() { Text = m.DeptName, Value = m.Id.ToString() }).ToArray());
            deptId.Items.Insert(0, _defaultSelect);
        }
    }
}
