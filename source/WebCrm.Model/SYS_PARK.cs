using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCX.Model
{
    public class SYS_PARK
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
        /// PARKPID
        /// </summary>
        public virtual int? PARKPID
        {
            get;
            set;
        }
        /// <summary>
        /// PARKCODE
        /// </summary>
        public virtual string PARKCODE
        {
            get;
            set;
        }
        /// <summary>
        /// PARKFULLNAME
        /// </summary>
        public virtual string PARKFULLNAME
        {
            get;
            set;
        }
        /// <summary>
        /// PARKSHORTNAME
        /// </summary>
        public virtual string PARKSHORTNAME
        {
            get;
            set;
        }
        /// <summary>
        /// PARKENGNAME
        /// </summary>
        public virtual string PARKENGNAME
        {
            get;
            set;
        }
        /// <summary>
        /// PARKKIND
        /// </summary>
        public virtual int? PARKKIND
        {
            get;
            set;
        }
        /// <summary>
        /// PARKTYPE
        /// </summary>
        public virtual string PARKTYPE
        {
            get;
            set;
        }
        /// <summary>
        /// LEADER
        /// </summary>
        public virtual string LEADER
        {
            get;
            set;
        }
        /// <summary>
        /// TELNO
        /// </summary>
        public virtual string TELNO
        {
            get;
            set;
        }
        /// <summary>
        /// FAXNO
        /// </summary>
        public virtual string FAXNO
        {
            get;
            set;
        }
        /// <summary>
        /// ADDRESS
        /// </summary>
        public virtual string ADDRESS
        {
            get;
            set;
        }
        /// <summary>
        /// SORT
        /// </summary>
        public virtual int? SORT
        {
            get;
            set;
        }
        /// <summary>
        /// RECFLAG
        /// </summary>
        public virtual int? RECFLAG
        {
            get;
            set;
        }
        /// <summary>
        /// TRANSFLAG
        /// </summary>
        public virtual int? TRANSFLAG
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
        /// CREATE_TIME
        /// </summary>
        public virtual DateTime? CREATE_TIME
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
        public virtual int? DELETED
        {
            get;
            set;
        } 
    }
}
