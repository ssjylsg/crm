using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    public interface IFunctionService : IBaseRequestService<Function>
    {
        List<Function> FindFirstStage();

        void Query(PageQuery<IDictionary<string, object>, Function> pageQuery);
    }
}
