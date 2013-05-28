using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class CustomerCorpInfoRepository : BaseNhibreateRepository<CustomerCorpInfo>, ICustomerCorpInfoRepository
    {
    }
}
