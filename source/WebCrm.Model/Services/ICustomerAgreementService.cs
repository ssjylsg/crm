using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
   public interface ICustomerAgreementService : IBaseRequestService<CustomerAgreement>
    {
       void Query(PageQuery<IDictionary<string, object>, CustomerAgreement> pageQuery);
    }
}
