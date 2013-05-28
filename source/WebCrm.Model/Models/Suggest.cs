using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace WebCrm.Model
{
    #region Suggest

    /// <summary>
    /// 投诉/建议
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
        /// 投诉/建议内容
        /// </summary>
        public virtual string Content { get; set; }
        /// <summary>
        /// 解决结果
        /// </summary>
        public virtual string SolveResults { get; set; }
        /// <summary>
        /// 解决方案
        /// </summary>
        public virtual CategoryItem SolveType { get; set; }

        /// <summary>
        /// 投诉分类
        /// </summary>
        public virtual CategoryItem SuggestType { get; set; }

        /// <summary>
        /// 投诉/建议日期
        /// </summary>
        public virtual DateTime SuggestDate { get; set; }
        /// <summary>
        /// 解决日期
        /// </summary>
        public virtual DateTime SolveDate { get; set; }
        /// <summary>
        /// 附件集合
        /// </summary>
        public virtual string FileIds { get; set; }
        /// <summary>
        /// 投诉/建议
        /// </summary>
        public virtual SuggestComplaints SuggestComplaints { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public virtual Company Company { get; set; }
        /// <summary>
        /// 投诉建议人姓名（客户姓名）
        /// </summary>
        public virtual string CustoMerName { get; set; }
        /// <summary>
        /// 客户
        /// </summary>
        public virtual Customer Customer { get; set; }
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
        /// <summary>
        /// 经手人
        /// </summary>
        public virtual OperatorUser HandlerPerson { get; set; }
        /// <summary>
        /// 处理人
        /// </summary>
        public virtual OperatorUser DealPerson { get; set; }
        #endregion
    }
    #endregion
}