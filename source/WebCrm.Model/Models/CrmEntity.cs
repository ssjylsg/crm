using System;
using WebCrm.Framework.Model;

namespace WebCrm.Model
{

    public abstract class CrmEntity : BaseEntity
    {
        protected CrmEntity()
        {
            Deleted = false;
            CreateTime = DateTime.Now;
            this.ModifyTime = DateTime.Now;
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public virtual bool Deleted { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public virtual DateTime? ModifyTime { get; set; }
    }
}
