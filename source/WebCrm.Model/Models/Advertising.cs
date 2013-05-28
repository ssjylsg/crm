using System;
using System.Collections;

namespace WebCrm.Model
{
    #region Advertising

    /// <summary>
    /// ���
    /// </summary>
    public class Advertising : CrmEntity
    {
        #region Public Properties
        /// <summary>
        /// ����
        /// </summary>
        public virtual string Content { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// Ͷ������
        /// </summary>
        public virtual DateTime DeliveryDate { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual CategoryItem Channel { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual decimal Free { get; set; }
        /// <summary>
        /// ״̬
        /// </summary>
        public virtual CategoryItem State { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual CategoryItem Evaluate { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        public virtual string Remark { get; set; }
        /// <summary>
        /// ��˾
        /// </summary>
        public virtual Company Company { get; set; }
        /// <summary>
        /// ��˾����
        /// </summary>
        public virtual string WorkName { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public virtual string FiledIds { get; set; }
        #endregion
    }
    #endregion
}