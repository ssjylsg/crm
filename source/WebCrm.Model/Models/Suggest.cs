using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace WebCrm.Model
{
    #region Suggest

    /// <summary>
    /// Ͷ��/����
    /// </summary>
    public class Suggest : CrmEntity
    {


        public Suggest()
            : base()
        {
            FileIds = string.Empty;
        }
        #region Public Properties


        /// <summary>
        /// Ͷ��/��������
        /// </summary>
        public virtual string Content { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public virtual string SolveResults { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public virtual CategoryItem SolveType { get; set; }

        /// <summary>
        /// Ͷ�߷���
        /// </summary>
        public virtual CategoryItem SuggestType { get; set; }

        /// <summary>
        /// Ͷ��/��������
        /// </summary>
        public virtual DateTime SuggestDate { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public virtual DateTime SolveDate { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public virtual string FileIds { get; set; }
        /// <summary>
        /// Ͷ��/����
        /// </summary>
        public virtual SuggestComplaints SuggestComplaints { get; set; }
        /// <summary>
        /// ��˾
        /// </summary>
        public virtual Company Company { get; set; }
        /// <summary>
        /// Ͷ�߽������������ͻ�������
        /// </summary>
        public virtual string CustoMerName { get; set; }
        /// <summary>
        /// �ͻ�
        /// </summary>
        public virtual Customer Customer { get; set; }
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
        /// <summary>
        /// ������
        /// </summary>
        public virtual OperatorUser HandlerPerson { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public virtual OperatorUser DealPerson { get; set; }
        #endregion
    }
    #endregion
}