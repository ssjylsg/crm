using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class TemplateService : BaseRequestService<Template>, ITemplateService
    {
        private ITemplateRepository _templateRepository;
        public TemplateService(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }

        public void Query(PageQuery<IDictionary<string, object>, Template> pageQuery)
        {
            this._templateRepository.Query(pageQuery);
        }
        public List<Template> GetTemplateByCategory(CategoryItem categoryItem)
        {
            PageQuery<IDictionary<string, object>, Template> pageQuery = new PageQuery<IDictionary<string, object>, Template>(null);
            pageQuery.Condition = new Dictionary<string, object>();
            pageQuery.Condition["MsgType.Id"] = categoryItem.Id;

            pageQuery.SetQueryAll();
            this.Query(pageQuery);
            return pageQuery.Result.ToList();
        }
    }
}
