﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;

namespace WebCrm.Model.Repositories
{
    public interface ICustomerAgreementRepository : IBaseNhibreateRepository<CustomerAgreement>
    {
        void Query(PageQuery<IDictionary<string, object>, CustomerAgreement> pageQuery);
    }
}
