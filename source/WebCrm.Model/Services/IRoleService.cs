using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    public interface IRoleService : IBaseRequestService<Role>
    {
        void Query(PageQuery<IDictionary<string, object>, Role> pageQuery);
        Role FindByRoleName(string roleName);

        /// <summary>
        /// 增加系统管理员角色
        /// </summary>
        void AddRoleAdmin();
    }
}
