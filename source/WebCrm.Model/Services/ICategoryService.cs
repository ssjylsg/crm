using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    public interface ICategoryService : IBaseRequestService<Category>
    {

        Category FindByCode(string code);
        IList<Category> GetCategoryList(string comanyName);
        void Query(PageQuery<IDictionary<string, object>, Category> pageQuery);
        bool ExisCode(string code, int id);
    }
}
