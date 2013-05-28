using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
namespace WebCrm.Model
{
    #region Role

    /// <summary>
    /// ½ÇÉ«
    /// </summary>
    public class Role : CrmEntity
    {
        public Role()
        {
            this.Deleted = false;
            this.SystemName = SysConfig.SystemName;
        }
        #region Public Properties
        public virtual string RoleName { get; set; }
        public virtual string Remark { get; set; }
        public virtual OperatorUser Optor { get; set; }
        public virtual Company Company { get; set; }
        public virtual string SystemName { get; set; }
        //public virtual IList<OperatorUser> Users { get; set; }
        //public virtual IList<Plug> Plugs { get; set; }

        //public virtual bool IsUserInRole(OperatorUser user)
        //{
        //   if(Users == null || Users.Count == 0)
        //   {
        //       return false;
        //   }
        //    return Users.FirstOrDefault(m => m.Id == user.Id) != null;
        //}
        //public virtual bool IsPlugInRole(Plug plug)
        //{
        //    if (Plugs == null || Plugs.Count == 0)
        //    {
        //        return false;
        //    }
        //    return Plugs.FirstOrDefault(m => m.Id == plug.Id) != null;
        //}
        #endregion
    }
    #endregion
}