using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;

namespace WebCrm.Service
{
    public class CategoryItemService : BaseRequestService<CategoryItem>, ICategoryItemService
    {
        private ICategoryItemRepository _categoryItemRepository;
        public CategoryItemService(ICategoryItemRepository categoryItemRepository)
        {
            _categoryItemRepository = categoryItemRepository;
        }

        public CategoryItem FindByCategoryTypeAndItemName(string categoryType, string itemName)
        {
            return _categoryItemRepository.FindByCategoryTypeAndItemName(categoryType, itemName);
        }

        public IList<CategoryItem> FindCagegoryItem(int categoryId, bool? isCategoryItemParentIsNull)
        {
            string sql = string.Format("From CategoryItem Where Category.Id =  {0}  ", categoryId);

            if (isCategoryItemParentIsNull.HasValue)
            {
                sql += " And ParentItem ";
                sql += isCategoryItemParentIsNull.Value ? "   IS  NULL" : "IS NOT NULL";
            }
            return this._categoryItemRepository.Query(sql).ToList();
        }

        public IList<CategoryItem> FindByParentId(int parnetId)
        {
            return
                this._categoryItemRepository.Query(string.Format("From CategoryItem Where ParentItem.Id = {0}", parnetId))
                    .Where(m => m.Deleted == false).ToList();
        }

        public IList<CategoryItem> FindByCategoryType(string messagecagetory)
        {

            return
                this._categoryItemRepository.Query(
                    string.Format("From CategoryItem Where Category.Code = '{0}' And Deleted <> 1", messagecagetory))
                    .ToList();
        }
    }
}
