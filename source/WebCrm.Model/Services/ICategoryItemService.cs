using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model.Services
{
    public interface ICategoryItemService : IBaseRequestService<CategoryItem>
    {
        CategoryItem FindByCategoryTypeAndItemName(string categoryType, string itemName);
        IList<CategoryItem> FindCagegoryItem(int categoryId, bool? isCategoryItemParentIsNull);

        IList<CategoryItem> FindByParentId(int parnetId);
        IList<CategoryItem> FindByCategoryType(string categoryCode);
    }
}
