using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    public interface ITemplateService : IBaseRequestService<Template>
    {
        void Query(PageQuery<IDictionary<string, object>, Template> pageQuery);
        List<Template> GetTemplateByCategory(CategoryItem categoryItem);
    }
}
