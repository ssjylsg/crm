﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;

namespace WebCrm.Model.Repositories
{
    public interface ICustomerInfoRepository : IBaseNhibreateRepository<CustomerInfo>
    {
        IList<CustomerInfo> FindSendInfoCustomers();
    }
}
