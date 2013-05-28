using System;
using System.Collections.Generic;
using WebCrm.Framework.Repositories;

namespace WebCrm.Model.Repositories
{
    public interface ICategoryRepository : IBaseNhibreateRepository<Category>
    {
        IList<Category> GetCategoryList(string comanyName);
        void Query(PageQuery<IDictionary<string, object>, Category> pageQuery);
    }
}
