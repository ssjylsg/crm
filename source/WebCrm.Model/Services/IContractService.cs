using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    public interface IContractService : IBaseRequestService<Contract> 
    {

        void Query(PageQuery<IDictionary<string, object>, Contract> pageQuery);
    }
}
