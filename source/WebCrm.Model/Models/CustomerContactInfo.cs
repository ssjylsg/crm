using System;
using System.Collections;

namespace WebCrm.Model
{
    #region CORPContactInfo

    /// <summary>
    /// 联系人
    /// </summary>
    public class CustomerContactInfo : CrmEntity
    {

        #region Public Properties
        /// <summary>
        /// 客户
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public virtual string Sex { get; set; }

        /// <summary>
        /// 联系号码
        /// </summary>
        public virtual string TelNumber { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public virtual string PhoneNumber { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public virtual string DutyName { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public virtual DateTime? Birthday { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Email { get; set; }


        public virtual string QQ { get; set; }


        public virtual string MSN { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public virtual string IdCard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Address { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        public virtual string NativePlace { get; set; }

        /// <summary>
        /// 个人喜好
        /// </summary>
        public virtual string Favorites { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        /// 是否主联系人
        /// </summary>
        public virtual bool IsMain { get; set; }

        #endregion
    }
    #endregion
}