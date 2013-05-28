using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    public interface IRolePlugService : IBaseRequestService<RoleOperator>
    {
        /// <summary>
        /// 排除删除的数据
        /// </summary>
        /// <param name="plug"></param>
        /// <returns></returns>
        IList<Role> GetRoles(Plug plug);
        /// <summary>
        /// 排除删除的数据
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        IList<Plug> GetPlugs(Role role);
        /// <summary>
        /// 排除删除的数据
        /// </summary>
        /// <param name="operatorUser"></param>
        /// <returns></returns>
        IList<Role> GetRoles(OperatorUser operatorUser);
        /// <summary>
        /// 排除删除的数据
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        IList<OperatorUser> GetUsers(Role role);

        void Save(RolePlug rolePlug);
        void Update(RolePlug rolePlug);


        RolePlug FindRolePlugById(int roleId, int plugId);

        RoleOperator FindRoleOperatorById(int roleId, int userId);
        /// <summary>
        /// 根据用户选择插件，如果用户有多个角色，会合并插件
        /// </summary>
        /// <param name="operatorUser"></param>
        /// <returns></returns>
        IList<Plug> GetPlugs(OperatorUser operatorUser);

        /// <summary>
        /// 给管理员分配角色
        /// </summary>
        void GrantFunToRole();
    }
}
