using System;
using System.Collections;
using System.Collections.Generic;

namespace WebCrm.Model
{


    /// <summary>
    /// 部门信息表
    /// </summary>
    public class Department : CrmEntity
    {
        public virtual IList<Department> ChildDept { get; set; }
        public virtual string DeptName { get; set; }
        public virtual string ShortName { get; set; }
        public virtual Department Parent { get; set; }
        public virtual string DeptCode { get; set; }
        public virtual string DeptShortCode { get; set; }


        public virtual string RealName { get; set; }
        public virtual string PYCode { get; set; }

        public virtual string DeptLeader { get; set; }

        public virtual string TelNo { get; set; }

        public virtual string FaxNo { get; set; }

        public virtual string Email { get; set; }

        public virtual int Sort { get; set; }

        public virtual string Remark { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public virtual string OptorCode { get; set; }

        public virtual int ChartViewType { get; set; }

        public virtual Company Company { get; set; }
    }

}