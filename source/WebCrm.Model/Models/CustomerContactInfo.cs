using System;
using System.Collections;

namespace WebCrm.Model
{
    #region CORPContactInfo

    /// <summary>
    /// ��ϵ��
    /// </summary>
    public class CustomerContactInfo : CrmEntity
    {

        #region Public Properties
        /// <summary>
        /// �ͻ�
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// ��ϵ������
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// �Ա�
        /// </summary>
        public virtual string Sex { get; set; }

        /// <summary>
        /// ��ϵ����
        /// </summary>
        public virtual string TelNumber { get; set; }

        /// <summary>
        /// �ֻ�����
        /// </summary>
        public virtual string PhoneNumber { get; set; }

        /// <summary>
        /// ְλ
        /// </summary>
        public virtual string DutyName { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public virtual DateTime? Birthday { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Email { get; set; }


        public virtual string QQ { get; set; }


        public virtual string MSN { get; set; }

        /// <summary>
        /// ���֤
        /// </summary>
        public virtual string IdCard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Address { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public virtual string NativePlace { get; set; }

        /// <summary>
        /// ����ϲ��
        /// </summary>
        public virtual string Favorites { get; set; }

        /// <summary>
        /// ��ע
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        /// �Ƿ�����ϵ��
        /// </summary>
        public virtual bool IsMain { get; set; }

        #endregion
    }
    #endregion
}