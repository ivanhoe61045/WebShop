using Persistence.Data.GenericRepository;
using Persistence.Data.WebShopModel;
using Persistence.Data.WebShopRepository.Interfaces;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.Data.WebShopRepository.WebShopImplementation
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(DbContext context) : base(context)
        {
        }

        public List<Categories> GetCategoriesByProduct(int ID)
        {
            var categoriesList = Context.Set<ProductCategory>().Include("Categories").Where(e => e.IdProduct == ID).ToList();
            return categoriesList.Where(e => e.IdProduct == ID).Select(e=> new Categories
            {
                CategoryName=e.Categories.CategoryName,
                CatergoryState=e.Categories.CatergoryState,
                IdCategory=e.IdCategory
            }).ToList();
        }
        
    }
}
