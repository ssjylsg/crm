using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;

namespace WebCrm.Model.Repositories
{
    public interface IHolidayRepository : IBaseNhibreateRepository<Holiday>
    {
        void Query(PageQuery<IDictionary<string, object>, Holiday> pageQuery);

        IList<Holiday> GetSendInfoHodiay();
    }
}
