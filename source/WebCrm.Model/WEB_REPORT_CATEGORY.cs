using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCX.Model
{
    public class WEB_REPORT_CATEGORY
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual int ID
        {
            get;
            set;
        }
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string NAME
        {
            get;
            set;
        }
        /// <summary>
        /// 父节点ID
        /// </summary>
        public virtual int? PARENTID
        {
            get;
            set;
        }
        /// <summary>
        /// 排序
        /// </summary>
        public virtual int? SORT
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? CREATETIME
        {
            get;
            set;
        }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public virtual DateTime? MODIFYTIME
        {
            get;
            set;
        }
        /// <summary>
        /// 删除状态：1已删除，0：未删除
        /// </summary>
        public virtual int? DELETED
        {
            get;
            set;
        }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string REMARK
        {
            get;
            set;
        }
        /// <summary>
        /// 创建人ID
        /// </summary>
        public virtual int? CREATE_LOGIN_ID
        {
            get;
            set;
        } 
    }
}
