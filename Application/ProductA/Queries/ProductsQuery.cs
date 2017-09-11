using Application.ProductA.Queries.Factory;
using Business.Module.BusinessEntyties;
using Ninject;
using Persistence.Data.UnitofWork;
using System.Collections.Generic;

namespace Application.ProductA.Queries
{
    public class ProductsQuery : IProductsQuery
    {
        private IUnitofWork _unitofwork;
        private IProductFactory _productfactory;

        public ProductsQuery()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IUnitofWork>().To<UnitofWork>();
                kernel.Bind<IProductFactory>().To<ProductFactory>();

                _unitofwork = kernel.Get<IUnitofWork>();
                _productfactory = kernel.Get<IProductFactory>();
            }
        }
        public IEnumerable<Product> GetAllProducts()
        {
            var ListProducts = _unitofwork.ProductRepository.Include(new List<string>() { "Gender" });
            var ListProductEntity = _productfactory.CreateListProductDataToBO(ListProducts);
            return ListProductEntity;
        }

        public Product GetCategoriesByProduct(int ID)
        {            
            var listCategoriesByProduct = _unitofwork.ProductCategoryRepository.GetCategoriesByProduct(ID);
            var ListCategoryEntity = _productfactory.CreateListCategoryBOFromData(listCategoriesByProduct);
            var productBO = _unitofwork.ProductRepository.IncludeEntityById(new List<string>() { "Gender" }, e => e.IdProduct == ID);
            var productCategory = _productfactory.CreatePRoductBOFromData(productBO,ListCategoryEntity);
            return productCategory;
        }

        private void Dependencies()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IUnitofWork>().To<UnitofWork>();
                kernel.Bind<IProductFactory>().To<ProductFactory>();

                _unitofwork = kernel.Get<IUnitofWork>();
                _productfactory = kernel.Get<IProductFactory>();
            }
        }
    }
}
