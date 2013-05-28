using System;
using System.Collections;

namespace WebCrm.Model
{
    /// <summary>
    /// 岗位
    /// </summary>
    public class Post : CrmEntity
    {

        public Post()
        {
            this.CreateTime = DateTime.Now;
        }
        #region Public Properties
        /// <summary>
        /// 部门
        /// </summary>
        public virtual Department Dept { get; set; }
        /// <summary>
        /// 上级岗位
        /// </summary>
        public virtual Post Parent { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public virtual string PostCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string PostName { get; set; }
        /// <summary>
        /// 真实名称
        /// </summary>
        public virtual string RealName { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public virtual int PostLevel { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public virtual OperatorUser Optor { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sort { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public virtual Company Company { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual int ChartViewType { get; set; }



        #endregion
    }
}
