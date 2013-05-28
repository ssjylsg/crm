using System.Collections.Generic;
using System.Linq;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class FunctionService : BaseRequestService<Function>, IFunctionService
    {
        private IFunctionRepository _functionRepository;
        public FunctionService(IFunctionRepository functionRepository)
        {
            _functionRepository = functionRepository;
        }
        
        public List<Function> FindFirstStage()
        {
            return this._functionRepository.FindFirstStage().ToList();
        }

        public void Query(PageQuery<IDictionary<string, object>, Function> pageQuery)
        {
            this._functionRepository.Query(pageQuery);
        }
    }
}
