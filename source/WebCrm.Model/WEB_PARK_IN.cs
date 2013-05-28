using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCX.Model
{
    public class WEB_PARK_IN
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
        /// PARKCODE
        /// </summary>
        public virtual string PARKCODE
        {
            get;
            set;
        }
        /// <summary>
        /// BEGINTIME
        /// </summary>
        public virtual string BEGINTIME
        {
            get;
            set;
        }
        /// <summary>
        /// ENDTIME
        /// </summary>
        public virtual string ENDTIME
        {
            get;
            set;
        }
        /// <summary>
        /// CHECKEDNUM
        /// </summary>
        public virtual int? CHECKEDNUM
        {
            get;
            set;
        }

        public virtual string FDATE
        {
            get;
            set;
        }
    }
}
