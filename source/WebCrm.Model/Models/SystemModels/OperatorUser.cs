using System;
using System.Collections;
using System.Collections.Generic;
using WebCrm.Model.Services;
using System.Linq;
namespace WebCrm.Model
{
    #region OperatorUser

    /// <summary>
    /// 操作人员
    /// </summary>
    public class OperatorUser : CrmEntity
    {
        public OperatorUser()
        {
            IsCrm = true;
        }
        /// <summary>
        /// 编号
        /// </summary>
        public virtual string OperatorCode { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public virtual string OperatorPass { get; set; }
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public virtual string OperatorName { get; set; }
        /// <summary>
        /// 是否管理员
        /// </summary>
        public virtual bool IsAdmin { get; set; }

        public virtual DateTime? LastLoginTime { get; set; }

        public virtual OperatorUser Optor { get; set; }
        /// <summary>
        /// 1 启用 0 禁用
        /// </summary>
        public virtual int UseFlag { get; set; }

        public virtual string Remark { get; set; }

        public virtual Company Company { get; set; }

        public virtual bool IsCrm { get; set; }
        //public virtual IList<Role> RoleCollection { get; set; }
        ///// <summary>
        ///// 当前用户是否在给定的角色中
        ///// </summary>
        ///// <param name="roleName"></param>
        ///// <returns></returns>
        //public virtual bool IsInRole(string roleName)
        //{
        //    if (RoleCollection == null || RoleCollection.Count == 0)
        //    {
        //        return false;
        //    }
        //    return this.RoleCollection.FirstOrDefault(m => m.RoleName == roleName && m.Deleted == false) != null;
        //}
    }
    #endregion
}