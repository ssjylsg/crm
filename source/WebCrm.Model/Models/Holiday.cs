using System;
using System.Collections;

namespace WebCrm.Model
{
    #region Holiday

    /// <summary>
    /// �ڼ���
    /// </summary>
    public class Holiday : CrmEntity
    {


        #region Constructors

        public Holiday() : base() { }
        #endregion

        #region Public Properties

        public virtual string Name { get; set; }

        /// <summary>
        /// �ڼ���
        /// </summary>
        public virtual DateTime HolidayDate { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public virtual string Descript { get; set; }
        /// <summary>
        /// ��˾
        /// </summary>
        public virtual Company Company { get; set; }
        /// <summary>
        /// �Ƿ�����Ϣ
        /// </summary>
        public virtual bool IsSendMsg { get; set; }
        /// <summary>
        /// ��ǰ���췢����Ϣ
        /// </summary>
        public virtual int DateNum { get; set; }
        #endregion
    }
    #endregion
}