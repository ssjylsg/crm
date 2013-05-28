using System;
using System.Collections;

namespace WebCrm.Model
{
    #region CustormerConsumRecord

    /// <summary>
    /// ���Ѽ�¼
    /// </summary>
    public class CustormerConsumRecord : CrmEntity
    {
        public CustormerConsumRecord()
            : base()
        {
            this.WriteDate = DateTime.Now;
            FiledIds = "";
        }

        #region Public Properties

        /// <summary>
        /// ��������
        /// </summary>
        public virtual DateTime? ConsumptionDate { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public virtual Customer Customer { get; set; }
        /// <summary>
        /// �ܻ���
        /// </summary>
        public virtual decimal SpendTotal { get; set; }
        /// <summary>
        /// ���۷�ʽ
        /// </summary>
        public virtual CategoryItem DiscountType { get; set; }
        /// <summary>
        /// ���ۺ���������
        /// </summary>
        public virtual decimal AfterDiscountFree { get; set; }
        /// <summary>
        /// ���λ���
        /// </summary>
        public virtual int Score { get; set; }
        /// <summary>
        /// ���ֹ���
        /// </summary>
        public virtual CategoryItem ScoreRule { get; set; }
        /// <summary>
        /// ¼��ʱ��
        /// </summary>
        public virtual DateTime WriteDate { get; set; }
        /// <summary>
        /// ¼����
        /// </summary>
        public virtual OperatorUser WritePerson { get; set; }

        /// <summary>
        /// �յ�����
        /// </summary>
        public virtual decimal ReceiveMoney { get; set; }
        /// <summary>
        /// ��˾
        /// </summary>
        public virtual Company Company { get; set; }
        /// <summary>
        /// ������ϸ
        /// </summary>
        public virtual string ConsumerDetails { get; set; }
        /// <summary>
        /// ��ע��Ϣ
        /// </summary>
        public virtual string Remark { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public virtual CategoryItem ConsumerBusinessType { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public virtual string FiledIds { get; set; }
        /// <summary>
        /// ҵ����Ա
        /// </summary>
        public virtual OperatorUser BussinessPerson { get; set; }
        #endregion
    }
    #endregion
}