using System;
using System.Collections;
using System.Collections.Generic;

namespace WebCrm.Model
{
    #region Function

    /// <summary>
    /// ����
    /// </summary>
    public class Function : CrmEntity
    {

        #region Public Properties
        /// <summary>
        /// ��������
        /// </summary>
        public virtual string FunctionName { get; set; }
        /// <summary>
        /// ���ܱ��
        /// </summary>
        public virtual string FunctionFlag { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        public virtual Function Parent { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public virtual int PlugID { get; set; }
        /// <summary>
        /// ���ܰ�ťͼ��
        /// </summary>
        public virtual string IcoTemplate { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public virtual OperatorUser Optor { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        public virtual string Remark { get; set; }
        /// <summary>
        /// �ӿ�����
        /// </summary>
        public virtual string ActionName { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual int OrderNum { get; set; }

        public virtual IList<Function> ChildFunctions { get; set; }
        #endregion
    }
    #endregion
}