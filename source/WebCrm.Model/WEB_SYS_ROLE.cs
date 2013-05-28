using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCX.Model
{
    public class WEB_SYS_ROLE
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
        /// ROLE_NAME
        /// </summary>
        public virtual string ROLE_NAME
        {
            get;
            set;
        }
        /// <summary>
        /// USE_FLAG
        /// </summary>
        public virtual int? USE_FLAG
        {
            get;
            set;
        }
        /// <summary>
        /// REMARK
        /// </summary>
        public virtual string REMARK
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
    }
}
