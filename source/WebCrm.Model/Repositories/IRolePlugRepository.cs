using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;

namespace WebCrm.Model.Repositories
{
    public interface IRolePlugRepository : IBaseNhibreateRepository<RoleOperator>
    {
        IList<Role> GetRoles(Plug plug);
        IList<Plug> GetPlugs(Role role);
        IList<Role> GetRoles(OperatorUser operatorUser);
        IList<OperatorUser> GetUsers(Role role);

        void Save(RolePlug rolePlug);
        void Update(RolePlug rolePlug);

        RolePlug FindRolePlugById(int roleId, int plugId);
        RoleOperator FindRoleOperatorById(int roleId, int userId);
    }
}
