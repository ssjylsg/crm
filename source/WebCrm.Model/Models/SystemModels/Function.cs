using System;
using System.Collections;
using System.Collections.Generic;

namespace WebCrm.Model
{
    #region Function

    /// <summary>
    /// 功能
    /// </summary>
    public class Function : CrmEntity
    {

        #region Public Properties
        /// <summary>
        /// 功能名称
        /// </summary>
        public virtual string FunctionName { get; set; }
        /// <summary>
        /// 功能编号
        /// </summary>
        public virtual string FunctionFlag { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public virtual Function Parent { get; set; }
        /// <summary>
        /// 所属插件
        /// </summary>
        public virtual int PlugID { get; set; }
        /// <summary>
        /// 功能按钮图标
        /// </summary>
        public virtual string IcoTemplate { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public virtual OperatorUser Optor { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }
        /// <summary>
        /// 接口名称
        /// </summary>
        public virtual string ActionName { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public virtual int OrderNum { get; set; }

        public virtual IList<Function> ChildFunctions { get; set; }
        #endregion
    }
    #endregion
}