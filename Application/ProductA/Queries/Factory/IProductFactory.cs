using AutoMapper;
using Business.Module.BusinessEntyties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductA.Queries.Factory
{
    public interface IProductFactory
    {
        IEnumerable<Product> CreateListProductDataToBO(IEnumerable<Persistence.Data.WebShopModel.Product> ListProducts);
        Persistence.Data.WebShopModel.Product CreateProductData(Product product);
        List<Category> CreateListCategoryBOFromData(IEnumerable<Persistence.Data.WebShopModel.Categories> listCategoriesByProduct);
        Business.Module.BusinessEntyties.Product CreatePRoductBOFromData(Persistence.Data.WebShopModel.Product product, List<Category> listCategories);
    }
}
