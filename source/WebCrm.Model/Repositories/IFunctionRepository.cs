using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Framework.Repositories;

namespace WebCrm.Model.Repositories
{
   public interface IFunctionRepository : IBaseNhibreateRepository<Function>
   {
       IList<Function> FindFirstStage();

       void Query(PageQuery<IDictionary<string, object>, Function> pageQuery);
   }
}
