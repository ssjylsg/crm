using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;
using System.Data;
namespace WebCrm.Model.Repositories
{
    public interface ICooperationRepository : IBaseNhibreateRepository<Cooperation>
    {
        void Query(PageQuery<IDictionary<string, object>, Cooperation> pageQuery);

        DataTable GetByCondition(Dictionary<string, object> dict, string selectFields = "*");
    }
}
