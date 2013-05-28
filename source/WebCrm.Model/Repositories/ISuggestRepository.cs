using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;

namespace WebCrm.Model.Repositories
{
    public interface ISuggestRepository : IBaseNhibreateRepository<Suggest>
    {
        void Query(PageQuery<IDictionary<string, object>, Suggest> pageQuery);
    }
}
