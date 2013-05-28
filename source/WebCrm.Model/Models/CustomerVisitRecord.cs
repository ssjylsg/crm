using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace WebCrm.Model
{
    #region CustomerVisitRecord

    /// <summary>
    /// 回访记录
    /// </summary>
    public class CustomerVisitRecord : CrmEntity
    {
        #region Member Variables

        public CustomerVisitRecord()
            : base()
        {
            FileIds = string.Empty;

        }
        private string _otherPerson;
        

        #endregion

        #region Public Properties

        /// <summary>
        /// 客户
        /// </summary>
        public virtual Customer Customer { get; set; }
        /// <summary>
        /// 业务员
        /// </summary>
        public virtual Staff BusinessPeople { get; set; }
        /// <summary>
        /// 回访日期
        /// </summary>
        public virtual DateTime VisitDate { get; set; }
        /// <summary>
        /// 其他业务人员
        /// </summary>
        public virtual string OtherPerson
        {
            get { return _otherPerson; }
            set
            {
                if (value != null && value.Length > 100)
                    throw new ArgumentOutOfRangeException("Invalid value for OtherPerson", value, value.ToString());
                _otherPerson = value;
            }
        }
        /// <summary>
        /// 回访内容
        /// </summary>
        public virtual string Content { get; set; }
        /// <summary>
        /// 附件集合
        /// </summary>
        public virtual string FileIds { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        /// 附件集合
        /// </summary>
        public virtual IList<FileAttachement> Files
        {
            get
            {
                if (string.IsNullOrEmpty(this.FileIds))
                {
                    return new List<FileAttachement>();
                }
                return WebCrm.Framework.DependencyResolver.Resolver<WebCrm.Model.Services.IFileService>().FindByIds(this.FileIds.Trim(',').Split(',').Where(m => m.IsInt()).Select(m => int.Parse(m)).ToArray());
            }
        }
        #endregion
    }
    #endregion
}