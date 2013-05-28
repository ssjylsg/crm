using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebCrm.Framework;

namespace WebCrm.Model
{
    #region Customer

    /// <summary>
    /// 客户
    /// </summary>
    public class Customer : CrmEntity
    {
        #region Public Properties
        /// <summary>
        /// 客户标识 企业/个人
        /// </summary>
        public virtual CustomerIdentification AccType { get; set; }
        /// <summary>
        /// 认可程度
        /// </summary>
        public virtual CategoryItem LevelSort { get; set; }

        /// <summary>
        /// 关系
        /// </summary>
        public virtual CategoryItem RelationLevel { get; set; }

        /// <summary>
        /// 重要级别
        /// </summary>
        public virtual ImportantLevel ImportantLevel { get; set; }

        /// <summary>
        /// 客户类别 潜在客户
        /// </summary>
        public virtual CategoryItem CustomerType { get; set; }

        /// <summary>
        /// 所属人
        /// </summary>
        public virtual OperatorUser BelongPerson { get; set; }

        /// <summary>
        /// 汽车牌照
        /// </summary>
        public virtual string Car { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public virtual string Code { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public virtual CategoryItem Area { get; set; }
        /// <summary>
        /// 客户类型 VIP/ 普通客户
        /// </summary>
        public virtual CategoryItem Cagegory { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 客户简称
        /// </summary>
        public virtual string ShortName { get; set; }
        /// <summary>
        /// 信用等级
        /// </summary>
        public virtual CategoryItem CreditRating { get; set; }

        /// <summary>
        /// 最后一次消费时间
        /// </summary>
        public virtual DateTime? LastSpendDate { get; set; }

        /// <summary>
        ///积分
        /// </summary>
        public virtual int TotalScore { get; set; }
        /// <summary>
        /// 客户详细信息
        /// </summary>
        // public virtual CustomerInfo CustomerInfo { get; set; }

        /// <summary>
        /// 联系人,多个ID集合,用逗号隔开
        /// </summary>
        public virtual string ContactUserInfoIds { get; protected set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public virtual IList<OperatorUser> ContactUserInfos
        {
            get
            {
                if (string.IsNullOrEmpty(this.ContactUserInfoIds))
                {
                    return new List<OperatorUser>();
                }
                return
                    DependencyResolver.Resolver<Services.IUserInfoService>().FindListByIds(
                        ContactUserInfoIds.Split(new char[] { ',' }).Where(m => m.IsInt()).Select(m => int.Parse(m)).
                            ToArray());
            }
            set { this.ContactUserInfoIds = string.Join(",", value.Select(u => u.Id.ToString()).ToArray()); }
        }
        /// <summary>
        /// 会员卡
        /// </summary>
        public virtual MembershipCard MemberCard { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public virtual Company Company { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public virtual OperatorUser CreatePerson { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }
        /// <summary>
        /// 客户来源
        /// </summary>
        public virtual CategoryItem CustomerSource { get; set; }
        /// <summary>
        /// 客户行业
        /// </summary>
        public virtual CategoryItem CustomerBusiness { get; set; }
        /// <summary>
        /// 显示客户名称和编号
        /// </summary>
        public virtual string ShowName
        {
            get
            {
                return string.Format("客户名称：{0}  客户编号:{1}", string.IsNullOrEmpty(this.Name) ? this.ShortName : this.Name,
                                     this.Code);
            }
        }
        #endregion
    }
    #endregion
}