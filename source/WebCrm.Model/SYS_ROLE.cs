using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCX.Model
{
    public class SYS_ROLE
    {
        public virtual int ID { get; set; }
        public virtual string NAME { get; set; }
        public virtual int? SORT { get; set; }
        public virtual string REMARK { get; set; }
        public virtual DateTime? CREATETIME { get; set; }
        public virtual DateTime? MODIFYTIME { get; set; }
        public virtual int? OPTORID { get; set; }
    }
}
