using System;
using System.Collections;

namespace WebCrm.Model
{
    #region Operator

    /// <summary>
    /// Operator object for NHibernate mapped table 'Sys_Operator'.
    /// </summary>
    public class Operator : CrmEntity
    {
        #region Public Properties
        public virtual string OperatorCode { get; set; }

        public virtual string OperatorPass { get; set; }

        public virtual string OperatorName { get; set; }

        public virtual int IsAdmin { get; set; }
        public virtual DateTime LastLoginTime { get; set; }

        public virtual DateTime CreateTime { get; set; }

        public virtual DateTime ModifyTime { get; set; }

        public virtual int OptorID { get; set; }

        public virtual int UseFlag { get; set; }

        public virtual string Remark { get; set; }

        public virtual int Deleted { get; set; }

        public virtual int CompanyID { get; set; }
        #endregion
    }
    #endregion
}