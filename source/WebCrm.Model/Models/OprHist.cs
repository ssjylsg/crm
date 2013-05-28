using System;
using System.Collections;

namespace WebCrm.Model
{
    #region OprHist

    /// <summary>
    /// ������ʷ
    /// </summary>
    public class OprHist : CrmEntity
    {

        #region Public Properties
        /// <summary>
        /// ����������
        /// </summary>
        public virtual string OprUsername { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public virtual string OprAction { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual string StageDesc { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        public virtual string OprComment { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public virtual DateTime OprDateTime { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public virtual OperatorUser OprUser { get; set; }

        /// <summary>
        /// ����ID
        /// </summary>
        public virtual int RequestId { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual string RequestType { get; set; }

        #endregion
    }
    #endregion
}