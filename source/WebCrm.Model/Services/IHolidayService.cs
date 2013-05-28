using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    public interface IHolidayService : IBaseRequestService<Holiday>
    {
        void Query(PageQuery<IDictionary<string, object>, Holiday> pageQuery);
        IList<Holiday> GetSendInfoHodiay();
    }
}
