using Persistence.Data.GenericRepository;
using Persistence.Data.WebShopModel;
using System.Collections.Generic;

namespace Persistence.Data.WebShopRepository.Interfaces
{
    public interface IProductCategoryRepository : IGenericRepository<ProductCategory>
    {
         List<Categories> GetCategoriesByProduct(int ID);

    }
}
