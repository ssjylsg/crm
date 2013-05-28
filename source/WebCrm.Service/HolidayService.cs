using System.Collections.Generic;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class HolidayService : BaseRequestService<Holiday>, IHolidayService
    {
        private IHolidayRepository _repository;
         
        public HolidayService(IHolidayRepository repository)
        {
            _repository = repository;
        }

        public void SaveOrUpdate(Holiday day)
        {
            _repository.SaveOrUpdate(day);
        }

        public void Query(PageQuery<IDictionary<string, object>, Holiday> pageQuery)
        {
            this._repository.Query(pageQuery);
        }

        public IList<Holiday> GetSendInfoHodiay()
        {
            return _repository.GetSendInfoHodiay();
        }
    }
}
