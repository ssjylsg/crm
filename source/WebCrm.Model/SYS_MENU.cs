using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCX.Model
{
    public class SYS_MENU
    {
        public virtual int ID { get; set; }
        public virtual string NAME { get; set; }
        public virtual string CODE { get; set; }
        public virtual int? SORT { get; set; }
        public virtual string HREF { get; set; }
        public virtual string REMARK { get; set; }
        public virtual int FLEVEL { get; set; }
    }
}
