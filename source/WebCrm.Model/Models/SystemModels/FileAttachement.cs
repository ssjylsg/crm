using System;
using System.Collections;

namespace WebCrm.Model
{
    #region FileAttachement

    /// <summary>
    /// ����
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
        /// �ļ����ʵ������
        /// </summary>
        public virtual string ActualName { get { return string.Format("{0}_{1}", FileGuidId, FileName); } }
        /// <summary>
        /// �ļ��� + �ļ���ŵ�ַ
        /// </summary>
        public virtual string FullName { get { return string.Format("{0}{1}", FilePath, ActualName); } }
        /// <summary>
        /// �ļ�����
        /// </summary>
        public virtual string FileName { get; set; }
        /// <summary>
        /// �ļ���С
        /// </summary>
        public virtual int FileSize { get; set; }
        /// <summary>
        /// ��չ��
        /// </summary>
        public virtual string Extension { get; set; }
        /// <summary>
        /// �ļ���
        /// </summary>
        public virtual string FilePath { get; set; }
        #endregion
    }
    #endregion
}