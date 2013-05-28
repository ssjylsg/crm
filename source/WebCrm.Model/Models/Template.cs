using System;
using System.Collections;

namespace WebCrm.Model
{
    #region Template

    /// <summary>
    /// Template object for NHibernate mapped table 'Crm_Template'.
    /// </summary>
    public class Template : CrmEntity
    {

        #region Public Properties
        /// <summary>
        /// 模板内容
        /// </summary>
        public virtual string MsgContent { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public virtual OperatorUser CreatePerson { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public virtual CategoryItem MsgType { get; set; }
        /// <summary>
        /// 模板名称
        /// </summary>
        public virtual string TemplateName { get; set; }
        /// <summary>
        /// 模板编号
        /// </summary>
        public virtual string TemplateCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Company Company { get; set; }
        #endregion
    }

    #endregion
}