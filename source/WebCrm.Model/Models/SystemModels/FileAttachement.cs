using System;
using System.Collections;

namespace WebCrm.Model
{
    #region FileAttachement

    /// <summary>
    /// 附件
    /// </summary>
    public class FileAttachement : CrmEntity
    {
        public FileAttachement()
            : base()
        {
            FileGuidId = Guid.NewGuid().ToString();
        }

        #region Public Properties
        /// <summary>
        /// Guid ID
        /// </summary>
        public virtual string FileGuidId { get; set; }
        /// <summary>
        /// 文件存放实际名称
        /// </summary>
        public virtual string ActualName { get { return string.Format("{0}_{1}", FileGuidId, FileName); } }
        /// <summary>
        /// 文件夹 + 文件存放地址
        /// </summary>
        public virtual string FullName { get { return string.Format("{0}{1}", FilePath, ActualName); } }
        /// <summary>
        /// 文件名称
        /// </summary>
        public virtual string FileName { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public virtual int FileSize { get; set; }
        /// <summary>
        /// 扩展名
        /// </summary>
        public virtual string Extension { get; set; }
        /// <summary>
        /// 文件夹
        /// </summary>
        public virtual string FilePath { get; set; }
        #endregion
    }
    #endregion
}