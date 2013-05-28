using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace WebCrm.Model
{
    #region CustomerVisitRecord

    /// <summary>
    /// �طü�¼
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
        /// �ͻ�
        /// </summary>
        public virtual Customer Customer { get; set; }
        /// <summary>
        /// ҵ��Ա
        /// </summary>
        public virtual Staff BusinessPeople { get; set; }
        /// <summary>
        /// �ط�����
        /// </summary>
        public virtual DateTime VisitDate { get; set; }
        /// <summary>
        /// ����ҵ����Ա
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
        /// �ط�����
        /// </summary>
        public virtual string Content { get; set; }
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