using System;
using System.Collections;

namespace WebCrm.Model
{
    #region Financial

    /// <summary>
    /// �������
    /// </summary>
    public class Financial : CrmEntity
    {
        /// <summary>
        /// Ӧ��������
        /// </summary>
        public virtual CategoryItem FinancialPayType { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public virtual string FiledIds { get; set; }

        public Financial()
            : base()
        {

        }
        #region Public Properties
        /// <summary>
        /// ����
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public virtual FinancialType FinancialType { get; set; }
        /// <summary>
        /// �տλ
        /// </summary>
        public virtual Customer Customer { get; set; }
        /// <summary>
        /// �ͻ�����
        /// </summary>
        public virtual string CustomerName { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual decimal SumPrice { get; set; }
        /// <summary>
        /// �Ƿ�����/�Ѹ�
        /// </summary>
        public virtual bool State { get; set; }
        /// <summary>
        /// ��ʼ����
        /// </summary>
        public virtual DateTime FinancialDate { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public virtual OperatorUser ChargePerson { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public virtual string TreatResult { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        /// ���λ
        /// </summary>
        public virtual Cooperation Cooperation { get; set; }
        /// <summary>
        /// ��˾
        /// </summary>
        public virtual Company Company { get; set; }
        #endregion
    }
    #endregion
}