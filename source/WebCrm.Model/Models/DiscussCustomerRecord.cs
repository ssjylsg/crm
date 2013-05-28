using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace WebCrm.Model
{
    #region DiscussCustomerRecord

    /// <summary>
    /// 洽谈记录
    /// </summary>
    public class DiscussCustomerRecord : CrmEntity
    {

        public DiscussCustomerRecord():base()
        {
            FileIds = string.Empty;
        }

        #region Public Properties

        /// <summary>
        /// 客户
        /// </summary>
        public virtual Customer Customer { get; set; }
        /// <summary>
        /// 其他内容
        /// </summary>
        public virtual string Content { get; set; }
        /// <summary>
        /// 洽谈时间
        /// </summary>
        public virtual DateTime DiscussDate { get; set; }
        /// <summary>
        /// 业务人员
        /// </summary>
        public virtual Staff BussinessPerson { get; set; }

        /// <summary>
        /// 其他与会人员
        /// </summary>
        public virtual string OtherPersonName { get; set; }
        /// <summary>
        /// 洽谈状态
        /// </summary>
        public virtual CategoryItem State { get; set; }

        /// <summary>
        /// 老的洽谈人员
        /// </summary>
        public virtual Staff OldBussinessPerson { get; set; }

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