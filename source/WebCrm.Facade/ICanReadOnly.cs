using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Web.Facade
{
    public interface ICanReadOnly
    {
        bool ReadOnly { set; }
    }
}
