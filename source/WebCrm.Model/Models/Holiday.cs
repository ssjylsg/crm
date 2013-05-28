using System;
using System.Collections;

namespace WebCrm.Model
{
    #region Holiday

    /// <summary>
    /// 节假日
    /// </summary>
    public class Holiday : CrmEntity
    {


        #region Constructors

        public Holiday() : base() { }
        #endregion

        #region Public Properties

        public virtual string Name { get; set; }

        /// <summary>
        /// 节假日
        /// </summary>
        public virtual DateTime HolidayDate { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Descript { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public virtual Company Company { get; set; }
        /// <summary>
        /// 是否发送消息
        /// </summary>
        public virtual bool IsSendMsg { get; set; }
        /// <summary>
        /// 提前几天发送消息
        /// </summary>
        public virtual int DateNum { get; set; }
        #endregion
    }
    #endregion
}