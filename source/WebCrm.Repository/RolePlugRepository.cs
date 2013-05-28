using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class RolePlugRepository : BaseNhibreateRepository<RoleOperator>, IRolePlugRepository
    {
        public IList<Role> GetRoles(Plug plug)
        {
            string sql =
                string.Format(
                    @"SELECT R1.* FROM Sys_RolePlug R 
INNER JOIN SYS_ROLE R1 ON R.ROLEID = R1.ID
INNER JOIN SYS_PLUG P ON P.ID = R.PLUGID
WHERE P.PLUGTYPE = {0} AND P.ID = {1} AND R.DELETED <>1",
                    SysConfig.PlugType, plug.Id);
            return this.GetSession().CreateSQLQuery(sql).AddEntity("R1", typeof(Role)).List<Role>();
        }

        public IList<Plug> GetPlugs(Role role)
        {
            string sql =
              string.Format(
                  @"SELECT P.* FROM Sys_RolePlug R 
INNER JOIN SYS_ROLE R1 ON R.ROLEID = R1.ID
INNER JOIN SYS_PLUG P ON P.ID = R.PLUGID
WHERE P.PLUGTYPE = {0} AND R1.ID = {1} AND R.DELETED <>1 ",
                  SysConfig.PlugType, role.Id);
            return this.GetSession().CreateSQLQuery(sql).AddEntity("P", typeof(Plug)).List<Plug>();
        }

        public IList<Role> GetRoles(OperatorUser operatorUser)
        {
            string sql =
               string.Format(
                   @" 
SELECT R.* FROM  Sys_RoleOperator ro
INNER JOIN  Sys_Operator O ON RO.OPERATORID = O.ID
INNER JOIN SYS_ROLE R ON R.ID = RO.ROLEID
WHERE r.SYSTEMNAME = '{0}' AND O.ID = {1} AND ro.DELETED <>1",
                   SysConfig.SystemName, operatorUser.Id);
            return this.GetSession().CreateSQLQuery(sql).AddEntity("R", typeof(Role)).List<Role>();
        }

        public IList<OperatorUser> GetUsers(Role role)
        {
            string sql =
             string.Format(
                 @" 
SELECT O.* FROM  Sys_RoleOperator ro
INNER JOIN  Sys_Operator O ON RO.OPERATORID = O.ID
INNER JOIN SYS_ROLE R ON R.ID = RO.ROLEID
WHERE r.SYSTEMNAME = '{0}' AND R.ID = {1}  AND ro.DELETED <>1",
                 SysConfig.SystemName, role.Id);
            return this.GetSession().CreateSQLQuery(sql).AddEntity("O", typeof(OperatorUser)).List<OperatorUser>();
        }

        public void Save(RolePlug rolePlug)
        {
            this.SaveObject(rolePlug);
        }

        public void Update(RolePlug rolePlug)
        {
            this.GetSession().Update(rolePlug);
        }

        public RolePlug FindRolePlugById(int roleId, int plugId)
        {
            return this.GetSession().CreateQuery(string.Format("FROM RolePlug WHERE Plug.Id = {0} AND  Role.Id ={1}", plugId, roleId)).
                SetMaxResults(1).UniqueResult<RolePlug>();
        }

        public RoleOperator FindRoleOperatorById(int roleId, int userId)
        {
            return this.GetSession().CreateQuery(string.Format("FROM RoleOperator WHERE User.Id = {0} AND  Role.Id ={1}", userId, roleId)).
                SetMaxResults(1).UniqueResult<RoleOperator>();
        }
    }
}
