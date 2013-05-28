using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCX.Model
{
    public class WEB_PARK_MAP
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual int ID
        {
            get;
            set;
        }

        public virtual string NAME
        {
            get;
            set;
        }

        /// <summary>
        /// 背景图片路径
        /// </summary>
        public virtual string PATH
        {
            get;
            set;
        }

        /// <summary>
        /// 宽度px
        /// </summary>
        public virtual int? WIDTH
        {
            get;
            set;
        }
        /// <summary>
        /// 高度px
        /// </summary>
        public virtual int? HEIGHT
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
        /// 是否默认1：是√，0 否
        /// </summary>
        public virtual int? ISDEFAULT
        {
            get;
            set;
        }

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
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CREATE_TIME
        {
            get;
            set;
        }
        /// <summary>
        /// 更改时间
        /// </summary>
        public virtual DateTime MODIFIED_TIME
        {
            get;
            set;
        }
        /// <summary>
        /// 删除状态：1已删除，0：未删除
        /// </summary>
        public virtual int DELETED
        {
            get;
            set;
        } 
    }
}
