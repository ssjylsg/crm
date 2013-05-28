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
    public class RolePlugService : BaseRequestService<RoleOperator>, IRolePlugService
    {
        private IRolePlugRepository _rolePlugRepository;
        public RolePlugService(IRolePlugRepository rolePlugRepository)
        {
            _rolePlugRepository = rolePlugRepository;
        }
        public IList<Role> GetRoles(Plug plug)
        {
            return _rolePlugRepository.GetRoles(plug);
        }

        public IList<Plug> GetPlugs(Role role)
        {
            return _rolePlugRepository.GetPlugs(role);
        }

        public IList<Role> GetRoles(OperatorUser operatorUser)
        {
            return _rolePlugRepository.GetRoles(operatorUser);
        }

        public IList<OperatorUser> GetUsers(Role role)
        {
            return _rolePlugRepository.GetUsers(role);
        }

        public void Save(RolePlug rolePlug)
        {
            _rolePlugRepository.Save(rolePlug);
        }

        public void Update(RolePlug rolePlug)
        {
            _rolePlugRepository.Update(rolePlug);
        }

        public RolePlug FindRolePlugById(int roleId, int plugId)
        {
            return _rolePlugRepository.FindRolePlugById(roleId, plugId);
        }

        public RoleOperator FindRoleOperatorById(int roleId, int userId)
        {
            return _rolePlugRepository.FindRoleOperatorById(roleId, userId);
        }

        public IList<Plug> GetPlugs(OperatorUser operatorUser)
        {
            IList<Role> roles = GetRoles(operatorUser);
            return roles.SelectMany(m => this.GetPlugs(m)).Distinct().ToList();
        }

        /// <summary>
        /// 给管理员分配角色
        /// </summary>
        public void GrantFunToRole()
        {
            RoleOperator roleOperator = new RoleOperator();
            roleOperator.Role = DependencyResolver.Resolver<IRoleService>().FindByRoleName("系统管理员");
            roleOperator.User = DependencyResolver.Resolver<IUserInfoService>().FindByUserName("ADMIN");

            DependencyResolver.Resolver<IRolePlugService>().Save(roleOperator);
        }
    }
}
