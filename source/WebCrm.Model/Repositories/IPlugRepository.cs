using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;

namespace WebCrm.Model.Repositories
{
    public interface IPlugRepository : IBaseNhibreateRepository<Plug>
    {
        void Query(PageQuery<IDictionary<string, object>, Plug> pageQuery);

        IList<Plug> GetAllParent();
    }
}
