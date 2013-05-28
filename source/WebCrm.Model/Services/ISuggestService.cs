using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    public interface ISuggestService : IBaseRequestService<Suggest>
    {

        void Query(PageQuery<IDictionary<string, object>, Suggest> pageQuery);
    }
}
