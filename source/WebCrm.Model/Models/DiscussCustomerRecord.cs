using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace WebCrm.Model
{
    #region DiscussCustomerRecord

    /// <summary>
    /// Ǣ̸��¼
    /// </summary>
    public class DiscussCustomerRecord : CrmEntity
    {

        public DiscussCustomerRecord():base()
        {
            FileIds = string.Empty;
        }

        #region Public Properties

        /// <summary>
        /// �ͻ�
        /// </summary>
        public virtual Customer Customer { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public virtual string Content { get; set; }
        /// <summary>
        /// Ǣ̸ʱ��
        /// </summary>
        public virtual DateTime DiscussDate { get; set; }
        /// <summary>
        /// ҵ����Ա
        /// </summary>
        public virtual Staff BussinessPerson { get; set; }

        /// <summary>
        /// ���������Ա
        /// </summary>
        public virtual string OtherPersonName { get; set; }
        /// <summary>
        /// Ǣ̸״̬
        /// </summary>
        public virtual CategoryItem State { get; set; }

        /// <summary>
        /// �ϵ�Ǣ̸��Ա
        /// </summary>
        public virtual Staff OldBussinessPerson { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public virtual string FileIds { get; set; }
        /// <summary>
        /// ��˾
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        /// ��������
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