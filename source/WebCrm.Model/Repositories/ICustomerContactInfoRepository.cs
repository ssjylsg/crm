using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;

namespace WebCrm.Model.Repositories
{
    public interface ICustomerContactInfoRepository : IBaseNhibreateRepository<CustomerContactInfo>
    {
        void Query(PageQuery<IDictionary<string, object>, CustomerContactInfo> pageQuery);

        void Query(PageQuery<QueryModel.CustomerContactQuery, CustomerContactInfo> pageQuery);
    }
}
