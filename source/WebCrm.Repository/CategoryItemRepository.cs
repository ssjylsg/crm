using WebCrm.Framework.Repositories;
using WebCrm.Model;
using WebCrm.Model.Repositories;

namespace WebCrm.Dao
{
    public class CategoryItemRepository : BaseNhibreateRepository<CategoryItem>, ICategoryItemRepository
    {
        public CategoryItem FindByCategoryTypeAndItemName(string categoryType, string itemName)
        {
            return
                this.GetSession().CreateQuery(
                    "FROM CategoryItem WHERE Category.Code =:categoryType AND Name =: itemName")
                    .SetString("categoryType", categoryType)
                    .SetString("itemName", itemName)
                    .UniqueResult<CategoryItem>();
        }
    }
}
