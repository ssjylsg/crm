using System.Collections.Generic;
using System.Linq;
using WebCrm.Model;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class CategoryService : BaseRequestService<Category>, ICategoryService
    {
        private WebCrm.Model.Repositories.ICategoryRepository _categoryRepository;
      
        public CategoryService(WebCrm.Model.Repositories.ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Category FindByCode(string code)
        {
            return
                this._categoryRepository.Query(string.Format("FROM Category Where Code ='{0}'", code)).ToList().
                    FirstOrDefault();
        }

        public IList<Category> GetCategoryList(string comanyName)
        {
            var pageQuery = new PageQuery<IDictionary<string, object>, Category>(null)
                                {
                                    Condition = new Dictionary<string, object> { { "Name", comanyName } }
                                };
            WebCrm.Framework.DependencyResolver.Resolver<ICategoryService>().Query(pageQuery);
            return pageQuery.Result;
        }

        public void Query(PageQuery<IDictionary<string, object>, Category> pageQuery)
        {
            _categoryRepository.Query(pageQuery);
        }

        public bool ExisCode(string code, int id)
        {
            return
                this._categoryRepository.Query(string.Format("From Category Where Code='{0}' And Id != {1}", code, id)).
                    Count() > 0;
        }
    }
}
