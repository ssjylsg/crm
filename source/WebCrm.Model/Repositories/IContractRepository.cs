using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;

namespace WebCrm.Model.Repositories
{
    public interface IContractRepository : IBaseNhibreateRepository<Contract>
    {
        void Query(PageQuery<IDictionary<string, object>, Contract> pageQuery);
    }
}
