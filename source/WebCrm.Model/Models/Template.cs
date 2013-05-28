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
        /// ģ������
        /// </summary>
        public virtual string MsgContent { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public virtual OperatorUser CreatePerson { get; set; }
        /// <summary>
        /// ��Ϣ����
        /// </summary>
        public virtual CategoryItem MsgType { get; set; }
        /// <summary>
        /// ģ������
        /// </summary>
        public virtual string TemplateName { get; set; }
        /// <summary>
        /// ģ����
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