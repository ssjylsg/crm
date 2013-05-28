using System;
using System.Collections;

namespace WebCrm.Model
{
    /// <summary>
    /// ��ͻ�Э��
    /// </summary>
    public class CustomerAgreement : CrmEntity
    {
        /// <summary>
        /// �ͻ�
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Э������
        /// </summary>
        public virtual CategoryItem AgreementType { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public virtual string FileIds { get; set; }

        /// <summary>
        /// ��ע
        /// </summary>
        public virtual string Remark { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public virtual OperatorUser CreateUser { get; set; }
        /// <summary>
        /// ����  ���Ϊ����Э�� ��Ϊ��
        /// </summary>
        public virtual DateTime? Expire { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual string Content { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual string Subject { get; set; }
    }

}