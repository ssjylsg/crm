using System;

namespace WebCrm.Model
{
    #region CustomerInfo

    /// <summary>
    ///  ɢ����չ��Ϣ
    /// </summary>
    public class CustomerInfo : CrmEntity
    {
        #region Constructors

        public CustomerInfo()
            : base()
        {
            this.Deleted = false;

        }



        #endregion

        #region Public Properties

        ///// <summary>
        ///// ���֤
        ///// </summary>
        //public virtual string Identity { get; set; }
        ///// <summary>
        ///// �Ƿ��ѻ�
        ///// </summary>
        //public virtual bool IsMarry { get; set; }
        ///// <summary>
        ///// �Ƿ���С��
        ///// </summary>
        //public virtual bool IsHasChild { get; set; }
        ///// <summary>
        ///// �����̶�
        ///// </summary>
        //public virtual Educational Educational { get; set; }
        ///// <summary>
        ///// ���彡���̶�
        ///// </summary>
        //public virtual HealthState HealthState { get; set; }

        ///// <summary>
        ///// ����
        ///// </summary>
        //public virtual BodyType BodyType { get; set; }

        ///// <summary>
        ///// �ȾƳ̶�
        ///// </summary>
        //public virtual DrinkingLevel DrinkingLevel { get; set; }
        ///// <summary>
        ///// ����
        ///// </summary>
        //public virtual double BodyWeight { get; set; }
        ///// <summary>
        ///// ����
        ///// </summary>
        //public virtual string Other { get; set; }

        ///// <summary>
        ///// ����ʱ��
        ///// </summary>
        //public virtual DateTime CreateDate { get; set; }
        ///// <summary>
        ///// ��ע
        ///// </summary>
        //public virtual string Remark { get; set; }
        ///// <summary>
        ///// ���˾���
        ///// </summary>
        //public virtual string PersonalExperience { get; set; }

        ///// <summary>
        ///// ��Ҫ����
        ///// </summary>
        //public virtual ImportantLevel ImportantLevel { get; set; }
        ///// <summary>
        ///// ������
        ///// </summary>
        //public virtual string Birthplace { get; set; }

        ///// <summary>
        ///// ����
        ///// </summary>
        //public virtual DateTime? BirthDate { get; set; }


        ///// <summary>
        ///// ����
        ///// </summary>
        //public virtual Constellation Constellation { get; set; }
        ///// <summary>
        ///// ����
        ///// </summary>
        //public virtual AnimalSign AnimalSign { get; set; }
        ///// <summary>
        ///// ����
        ///// </summary>
        //public virtual CategoryItem NationalitySate { get; set; }
        ///// <summary>
        ///// רҵ
        ///// </summary>
        //public virtual Field Field { get; set; }

        ///// <summary>
        ///// ����
        ///// </summary>
        //public virtual CategoryItem Belief { get; set; }

        ///// <summary>
        ///// ���̶̳�
        ///// </summary>
        //public virtual bool? SmokeLevel { get; set; }

        ///// <summary>
        ///// ���
        ///// </summary>
        //public virtual double Height { get; set; }

        ///// <summary>
        ///// ����
        ///// </summary>
        //public virtual string Vision { get; set; }
        ///// <summary>
        ///// ������
        ///// </summary>
        //public virtual OperatorUser CreatePerson { get; set; }

        ///// <summary>
        ///// ����
        ///// </summary>
        //public virtual int Age { get; set; }
        ///// <summary>
        ///// ��ϵ������
        ///// </summary>
        //public virtual string ContactName { get; set; }
        ///// <summary>
        ///// �칫�ҵ绰
        ///// </summary>
        //public virtual string OfficalTelNum { get; set; }
        ///// <summary>
        ///// �ֻ�
        ///// </summary>
        //public virtual string Mobile { get; set; }
        ///// <summary>
        ///// �����ʼ�
        ///// </summary>
        //public virtual string Email { get; set; }
        ///// <summary>
        ///// ��ַ
        ///// </summary>
        //public virtual string Adress { get; set; }
        ///// <summary>
        ///// ����
        ///// </summary>
        //public virtual string Zip { get; set; }
        /// <summary>
        /// �ͻ�
        /// </summary>
        public virtual Customer Customer { get; set; }

        #region Public Properties
        /// <summary>
        /// ����
        /// </summary>
        public virtual string RealName { get; set; }

        /// <summary>
        /// ���֤
        /// </summary>
        public virtual string IdCard { get; set; }

        /// <summary>
        /// ���֤ͼƬ
        /// </summary>
        public virtual string IdCardImg { get; set; }

        /// <summary>
        /// ʵ����֤
        /// </summary>
        public virtual bool Realauth { get; set; }

        /// <summary>
        /// ��ϸ��ַ
        /// </summary>
        public virtual string Addr { get; set; }

        /// <summary>
        /// �̶��绰
        /// </summary>
        public virtual string Tel { get; set; }

        /// <summary>
        /// �ʱ�
        /// </summary>
        public virtual string Post { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// �ʼ���֤
        /// </summary>
        public virtual bool EmailAuth { get; set; }

        /// <summary>
        /// �ֻ�
        /// </summary>
        public virtual string Mobile { get; set; }

        /// <summary>
        /// �ֻ���֤
        /// </summary>
        public virtual bool MobileAuth { get; set; }

        /// <summary>
        /// �Ա�
        /// </summary>
        public virtual string Sex { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public virtual DateTime? BirthDate { get; set; }

        public virtual Company Company { get; set; }
        #endregion
        #endregion
    }
    #endregion
}