using System;
using System.Collections;
using System.Collections.Generic;
using WebCrm.Model.Services;
using System.Linq;
namespace WebCrm.Model
{
    #region OperatorUser

    /// <summary>
    /// ������Ա
    /// </summary>
    public class OperatorUser : CrmEntity
    {
        public OperatorUser()
        {
            IsCrm = true;
        }
        /// <summary>
        /// ���
        /// </summary>
        public virtual string OperatorCode { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual string OperatorPass { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        public virtual string OperatorName { get; set; }
        /// <summary>
        /// �Ƿ����Ա
        /// </summary>
        public virtual bool IsAdmin { get; set; }

        public virtual DateTime? LastLoginTime { get; set; }

        public virtual OperatorUser Optor { get; set; }
        /// <summary>
        /// 1 ���� 0 ����
        /// </summary>
        public virtual int UseFlag { get; set; }

        public virtual string Remark { get; set; }

        public virtual Company Company { get; set; }

        public virtual bool IsCrm { get; set; }
        //public virtual IList<Role> RoleCollection { get; set; }
        ///// <summary>
        ///// ��ǰ�û��Ƿ��ڸ����Ľ�ɫ��
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