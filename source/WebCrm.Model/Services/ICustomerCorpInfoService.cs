using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    public interface ICustomerCorpInfoService : IBaseRequestService<CustomerCorpInfo>
    {

        CustomerCorpInfo FindByCustomerId(int p);
    }
}
