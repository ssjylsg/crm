using System.Collections.Generic;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class SuggestService : BaseRequestService<Suggest>, ISuggestService
    {

        private ISuggestRepository _suggestRepository;
        public SuggestService(ISuggestRepository suggestRepository)
        {
            _suggestRepository = suggestRepository;
        }


        public void Query(PageQuery<IDictionary<string, object>, Suggest> pageQuery)
        {
            _suggestRepository.Query(pageQuery);
        }

    }
}
