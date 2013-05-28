using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;
using System.Data;
namespace WebCrm.Service
{
    public class CooperationService : BaseRequestService<Cooperation>, ICooperationService
    {
        private ICooperationRepository _cooperationRepository;
        public CooperationService(ICooperationRepository cooperationRepository)
        {
            _cooperationRepository = cooperationRepository;
        }

        public void Query(PageQuery<IDictionary<string, object>, Cooperation> pageQuery)
        {
            this._cooperationRepository.Query(pageQuery);
        }

        public DataTable GetByCondition(Dictionary<string, object> dict, string selectFields = "*")
        {
            return _cooperationRepository.GetByCondition(dict, selectFields);
        }
    }
}
