using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace WebCrm.Model
{
    /// <summary>
    /// ��ͬ
    /// </summary>
    public class Contract : CrmEntity
    {
        #region Constructors

        public Contract()
            : base()
        {
            this.CreateDate = System.DateTime.Now;
            FiledIds = string.Empty;

        }

        #endregion

        #region Public Properties


        /// <summary>
        /// ��ͬ����
        /// </summary>
        public virtual string ContractName { get; set; }

        /// <summary>
        /// ��ͬ״̬
        /// </summary>
        public virtual CategoryItem State { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public virtual string FiledIds { get; set; }
        /// <summary>
        /// �ͻ�����
        /// </summary>
        public virtual string CustomerName { get; set; }

        public virtual Customer Customer { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public virtual string Code { get; set; }
        /// <summary>
        /// ��ʼ����
        /// </summary>
        public virtual DateTime StartDate { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public virtual DateTime EndDate { get; set; }
        /// <summary>
        /// ��˾ǩԼ��
        /// </summary>
        public virtual OperatorUser SignPerson { get; set; }
        /// <summary>
        /// �ͻ�ǩԼ��
        /// </summary>
        public virtual string CustomerSignPerson { get; set; }
        /// <summary>
        /// ǩԼ����
        /// </summary>
        public virtual DateTime SignDate { get; set; }
        /// <summary>
        /// ǩԼ�ص�
        /// </summary>
        public virtual string SignAddress { get; set; }
        /// <summary>
        /// ��ŵ�ַ
        /// </summary>
        public virtual string StorePlace { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public virtual decimal Sum { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public virtual SettleState SettleState { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public virtual OperatorUser CreatePerson { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public virtual DateTime CreateDate { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        public virtual string Remark { get; set; }
        /// <summary>
        /// ��ͬ����
        /// </summary>
        public virtual string Content { get; set; }

        /// <summary>
        /// ��˾
        /// </summary>
        public virtual Company Company { get; set; }

        #endregion
    }

}