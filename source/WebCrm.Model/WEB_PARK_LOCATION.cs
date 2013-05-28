using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCX.Model
{
    public class WEB_PARK_LOCATION
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
        /// COORDINATEDATA
        /// </summary>
        public virtual string COORDINATEDATA
        {
            get;
            set;
        }  
    }
}
