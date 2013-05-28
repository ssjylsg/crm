using System;
using System.Collections;

namespace WebCrm.Model
{
    #region RoleOperator

    /// <summary>
    /// RoleOperator object for NHibernate mapped table 'Sys_RoleOperator'.
    /// </summary>
    public class RoleOperator : CrmEntity
    {
        #region Public Properties

        public virtual OperatorUser User { get; set; }

        public virtual Role Role { get; set; }

        /// <summary>
        /// 当前操作人
        /// </summary>
        public virtual OperatorUser Optor { get; set; }
        #endregion
    }
    #endregion
}