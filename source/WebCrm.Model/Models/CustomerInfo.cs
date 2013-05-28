using System;

namespace WebCrm.Model
{
    #region CustomerInfo

    /// <summary>
    ///  散客扩展信息
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
        ///// 身份证
        ///// </summary>
        //public virtual string Identity { get; set; }
        ///// <summary>
        ///// 是否已婚
        ///// </summary>
        //public virtual bool IsMarry { get; set; }
        ///// <summary>
        ///// 是否有小孩
        ///// </summary>
        //public virtual bool IsHasChild { get; set; }
        ///// <summary>
        ///// 教育程度
        ///// </summary>
        //public virtual Educational Educational { get; set; }
        ///// <summary>
        ///// 身体健康程度
        ///// </summary>
        //public virtual HealthState HealthState { get; set; }

        ///// <summary>
        ///// 体型
        ///// </summary>
        //public virtual BodyType BodyType { get; set; }

        ///// <summary>
        ///// 喝酒程度
        ///// </summary>
        //public virtual DrinkingLevel DrinkingLevel { get; set; }
        ///// <summary>
        ///// 体重
        ///// </summary>
        //public virtual double BodyWeight { get; set; }
        ///// <summary>
        ///// 其他
        ///// </summary>
        //public virtual string Other { get; set; }

        ///// <summary>
        ///// 创建时间
        ///// </summary>
        //public virtual DateTime CreateDate { get; set; }
        ///// <summary>
        ///// 备注
        ///// </summary>
        //public virtual string Remark { get; set; }
        ///// <summary>
        ///// 个人经历
        ///// </summary>
        //public virtual string PersonalExperience { get; set; }

        ///// <summary>
        ///// 重要级别
        ///// </summary>
        //public virtual ImportantLevel ImportantLevel { get; set; }
        ///// <summary>
        ///// 出生地
        ///// </summary>
        //public virtual string Birthplace { get; set; }

        ///// <summary>
        ///// 生日
        ///// </summary>
        //public virtual DateTime? BirthDate { get; set; }


        ///// <summary>
        ///// 星座
        ///// </summary>
        //public virtual Constellation Constellation { get; set; }
        ///// <summary>
        ///// 属相
        ///// </summary>
        //public virtual AnimalSign AnimalSign { get; set; }
        ///// <summary>
        ///// 民族
        ///// </summary>
        //public virtual CategoryItem NationalitySate { get; set; }
        ///// <summary>
        ///// 专业
        ///// </summary>
        //public virtual Field Field { get; set; }

        ///// <summary>
        ///// 信仰
        ///// </summary>
        //public virtual CategoryItem Belief { get; set; }

        ///// <summary>
        ///// 吸烟程度
        ///// </summary>
        //public virtual bool? SmokeLevel { get; set; }

        ///// <summary>
        ///// 身高
        ///// </summary>
        //public virtual double Height { get; set; }

        ///// <summary>
        ///// 视力
        ///// </summary>
        //public virtual string Vision { get; set; }
        ///// <summary>
        ///// 创建人
        ///// </summary>
        //public virtual OperatorUser CreatePerson { get; set; }

        ///// <summary>
        ///// 年龄
        ///// </summary>
        //public virtual int Age { get; set; }
        ///// <summary>
        ///// 联系人姓名
        ///// </summary>
        //public virtual string ContactName { get; set; }
        ///// <summary>
        ///// 办公室电话
        ///// </summary>
        //public virtual string OfficalTelNum { get; set; }
        ///// <summary>
        ///// 手机
        ///// </summary>
        //public virtual string Mobile { get; set; }
        ///// <summary>
        ///// 电子邮件
        ///// </summary>
        //public virtual string Email { get; set; }
        ///// <summary>
        ///// 地址
        ///// </summary>
        //public virtual string Adress { get; set; }
        ///// <summary>
        ///// 区号
        ///// </summary>
        //public virtual string Zip { get; set; }
        /// <summary>
        /// 客户
        /// </summary>
        public virtual Customer Customer { get; set; }

        #region Public Properties
        /// <summary>
        /// 姓名
        /// </summary>
        public virtual string RealName { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public virtual string IdCard { get; set; }

        /// <summary>
        /// 身份证图片
        /// </summary>
        public virtual string IdCardImg { get; set; }

        /// <summary>
        /// 实名认证
        /// </summary>
        public virtual bool Realauth { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public virtual string Addr { get; set; }

        /// <summary>
        /// 固定电话
        /// </summary>
        public virtual string Tel { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public virtual string Post { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// 邮件认证
        /// </summary>
        public virtual bool EmailAuth { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public virtual string Mobile { get; set; }

        /// <summary>
        /// 手机认证
        /// </summary>
        public virtual bool MobileAuth { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public virtual string Sex { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public virtual DateTime? BirthDate { get; set; }

        public virtual Company Company { get; set; }
        #endregion
        #endregion
    }
    #endregion
}