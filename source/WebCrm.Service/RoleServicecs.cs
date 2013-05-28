using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class RoleServicecs : BaseRequestService<Role>, IRoleService
    {
        private IRoleRepository _repository;
        public RoleServicecs(IRoleRepository repository)
        {
            _repository = repository;
        }
        public void Query(PageQuery<IDictionary<string, object>, Role> pageQuery)
        {
            _repository.Query(pageQuery);
        }

        public Role FindByRoleName(string roleName)
        {
            return
                this._repository.Query(
                    string.Format("From Role Where    Deleted != 1  And SystemName = 'CRM' AND RoleName = '{0}'",
                                  roleName)).FirstOrDefault();
        }

        /// <summary>
        /// 增加系统管理员角色
        /// </summary>
        public void AddRoleAdmin()
        {
            string roleName = "系统管理员";
            var role = FindByRoleName(roleName);

            if (role == null)
            {
                role = new Role() { RoleName = roleName, Remark = "CRM 系统管理员" };
                DependencyResolver.Resolver<IRoleService>().Save(role);
            }

            // 给角色分配操作功能
            var pageQuery = new PageQuery<IDictionary<string, object>, Plug>(null);
            pageQuery.Condition = new Dictionary<string, object>();
            DependencyResolver.Resolver<IPlugService>().Query(pageQuery);

            foreach (Plug plug in pageQuery.Result.Where(m => m.Parent != null))
            {
                RolePlug rolePlug = new RolePlug();
                rolePlug.Role = role;
                rolePlug.Plug = plug;
                DependencyResolver.Resolver<IRolePlugService>().Save(rolePlug);
            }

        }
    }
}
