using Business.Module.BusinessEntyties;
using System.Collections.Generic;
using Persistence.Data.WebShopModel;

namespace Application.Categories.Queries.Factory
{
    public interface ICategoriesFactory
    {
        Persistence.Data.WebShopModel.Categories CreateCategoryPersistence(Category category);
        IEnumerable<Category> CreateCategoriesBOFromList(IEnumerable<Persistence.Data.WebShopModel.Categories> category);
    }
}
