using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebCrm.Framework;

namespace WebCrm.Model
{
    #region Customer

    /// <summary>
    /// �ͻ�
    /// </summary>
    public class Customer : CrmEntity
    {
        #region Public Properties
        /// <summary>
        /// �ͻ���ʶ ��ҵ/����
        /// </summary>
        public virtual CustomerIdentification AccType { get; set; }
        /// <summary>
        /// �Ͽɳ̶�
        /// </summary>
        public virtual CategoryItem LevelSort { get; set; }

        /// <summary>
        /// ��ϵ
        /// </summary>
        public virtual CategoryItem RelationLevel { get; set; }

        /// <summary>
        /// ��Ҫ����
        /// </summary>
        public virtual ImportantLevel ImportantLevel { get; set; }

        /// <summary>
        /// �ͻ���� Ǳ�ڿͻ�
        /// </summary>
        public virtual CategoryItem CustomerType { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public virtual OperatorUser BelongPerson { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public virtual string Car { get; set; }
        /// <summary>
        /// �ͻ����
        /// </summary>
        public virtual string Code { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual CategoryItem Area { get; set; }
        /// <summary>
        /// �ͻ����� VIP/ ��ͨ�ͻ�
        /// </summary>
        public virtual CategoryItem Cagegory { get; set; }
        /// <summary>
        /// �ͻ�����
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// �ͻ����
        /// </summary>
        public virtual string ShortName { get; set; }
        /// <summary>
        /// ���õȼ�
        /// </summary>
        public virtual CategoryItem CreditRating { get; set; }

        /// <summary>
        /// ���һ������ʱ��
        /// </summary>
        public virtual DateTime? LastSpendDate { get; set; }

        /// <summary>
        ///����
        /// </summary>
        public virtual int TotalScore { get; set; }
        /// <summary>
        /// �ͻ���ϸ��Ϣ
        /// </summary>
        // public virtual CustomerInfo CustomerInfo { get; set; }

        /// <summary>
        /// ��ϵ��,���ID����,�ö��Ÿ���
        /// </summary>
        public virtual string ContactUserInfoIds { get; protected set; }

        /// <summary>
        /// ��ϵ��
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
        /// ��Ա��
        /// </summary>
        public virtual MembershipCard MemberCard { get; set; }
        /// <summary>
        /// ��˾
        /// </summary>
        public virtual Company Company { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public virtual OperatorUser CreatePerson { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        public virtual string Remark { get; set; }
        /// <summary>
        /// �ͻ���Դ
        /// </summary>
        public virtual CategoryItem CustomerSource { get; set; }
        /// <summary>
        /// �ͻ���ҵ
        /// </summary>
        public virtual CategoryItem CustomerBusiness { get; set; }
        /// <summary>
        /// ��ʾ�ͻ����ƺͱ��
        /// </summary>
        public virtual string ShowName
        {
            get
            {
                return string.Format("�ͻ����ƣ�{0}  �ͻ����:{1}", string.IsNullOrEmpty(this.Name) ? this.ShortName : this.Name,
                                     this.Code);
            }
        }
        #endregion
    }
    #endregion
}