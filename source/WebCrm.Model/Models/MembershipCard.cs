using System;
using System.Collections;

namespace WebCrm.Model
{
    #region MembershipCard

    /// <summary>
    /// 会员卡
    /// </summary>
    public class MembershipCard : CrmEntity
    {
        #region Member Variables


        private string _cardCode;
        private string _description;
        private DateTime _validDate;

        #endregion

        #region Constructors

        public MembershipCard() : base() { }

        public MembershipCard(string cardCode, string description, DateTime validDate, bool isDeleted)
            : base()
        {
            this._cardCode = cardCode;
            this._description = description;
            this._validDate = validDate;
            this.Deleted = isDeleted;
        }

        #endregion

        #region Public Properties
        /// <summary>
        /// 会员类型
        /// </summary>
        public virtual CategoryItem CardType { get; set; }

        public virtual string CardCode
        {
            get { return _cardCode; }
            set
            {
                if (value != null && value.Length > 20)
                    throw new ArgumentOutOfRangeException("Invalid value for CardCode", value, value.ToString());
                _cardCode = value;
            }
        }

        public virtual string Description
        {
            get { return _description; }
            set
            {
                if (value != null && value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
                _description = value;
            }
        }

        public virtual DateTime ValidDate
        {
            get { return _validDate; }
            set { _validDate = value; }
        }

        /// <summary>
        /// 公司
        /// </summary>
        public virtual Company Company { get; set; }



        #endregion
    }
    #endregion
}