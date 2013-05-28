using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCX.Model
{
    public class WEB_SYS_ROLEFUNCS
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
        /// ROLE_ID
        /// </summary>
        public virtual int ROLE_ID
        {
            get;
            set;
        }
        /// <summary>
        /// FUNC_ID
        /// </summary>
        public virtual int FUNC_ID
        {
            get;
            set;
        }
        /// <summary>
        /// CREATE_LOGIN_ID
        /// </summary>
        public virtual int? CREATE_LOGIN_ID
        {
            get;
            set;
        }
        /// <summary>
        /// CREATE_TIME
        /// </summary>
        public virtual DateTime CREATE_TIME
        {
            get;
            set;
        }
        /// <summary>
        /// MODIFIED_TIME
        /// </summary>
        public virtual DateTime MODIFIED_TIME
        {
            get;
            set;
        }
        /// <summary>
        /// DELETED
        /// </summary>
        public virtual int DELETED
        {
            get;
            set;
        }

        /// <summary>
        /// 1：常规功能菜单授权  5:Web报表授权  6：手机报表授权
        /// </summary>
        public virtual int? FTYPE
        {
            get;
            set;
        }
    }
}
