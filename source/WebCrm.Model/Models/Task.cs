using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model
{
    public class Task : CrmEntity
    {
        /// <summary>
        /// 任务标题
        /// </summary>
        public virtual string Subject { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public virtual OperatorUser CreateUser { get; set; }
        /// <summary>
        /// 任务派遣人
        /// </summary>
        public virtual OperatorUser AssignUser { get; set; }
        /// <summary>
        /// 任务内容
        /// </summary>
        public virtual string TaskContent { get; set; }
        /// <summary>
        /// 任务进度
        /// </summary>
        public virtual CategoryItem TaskProcess { get; set; }
        /// <summary>
        /// 任务开始时间
        /// </summary>
        public virtual DateTime StartDate { get; set; }
        /// <summary>
        /// 期望完成时间
        /// </summary>
        public virtual DateTime? ExpectationDate { get; set; }
        /// <summary>
        /// 实际完成时间
        /// </summary>
        public virtual DateTime? ActualDate { get; set; }
        /// <summary>
        /// 任务备注信息
        /// </summary>
        public virtual string Remark { get; set; }
        /// <summary>
        /// 执行中的内容
        /// </summary>
        public virtual string ExecutionContent { get; set; }

    }
}
