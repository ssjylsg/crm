using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCX.Model
{
    public class WEB_SYS_FUNCTIONS
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
        /// PARENT_ID
        /// </summary>
        public virtual int? PARENT_ID
        {
            get;
            set;
        }
        /// <summary>
        /// FUN_NAME
        /// </summary>
        public virtual string FUN_NAME
        {
            get;
            set;
        }
        /// <summary>
        /// FUN_TYPE
        /// </summary>
        public virtual int? FUN_TYPE
        {
            get;
            set;
        }
        /// <summary>
        /// FUN_URL
        /// </summary>
        public virtual string FUN_URL
        {
            get;
            set;
        }
        /// <summary>
        /// FUN_SORT
        /// </summary>
        public virtual int? FUN_SORT
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
        public virtual DateTime? MODIFIED_TIME
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
