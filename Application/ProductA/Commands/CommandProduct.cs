using Application.ProductA.Queries.Factory;
using Business.Module.BusinessEntyties;
using Ninject;
using Persistence.Data.UnitofWork;
using System;
using System.Collections.Generic;

namespace Application.ProductA.Commands
{
    public class CommandProduct : ICommandProduct
    {
        private IUnitofWork _unitofwork;
        private IProductFactory _productfactory;
        

        public CommandProduct()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IUnitofWork>().To<UnitofWork>();
                kernel.Bind<IProductFactory>().To<ProductFactory>();

                _unitofwork = kernel.Get<IUnitofWork>();
                _productfactory = kernel.Get<IProductFactory>();
            }
            
        }

        public void AddProduct(Product product)
        {
            var productData = _productfactory.CreateProductData(product);
            var productCategory = new List<Persistence.Data.WebShopModel.ProductCategory>();
            if (product.ListCategories.Count > 0)
            {
                foreach (var item in product.ListCategories)
                {
                    if (item.IdCategory > 0)
                    {
                        productCategory.Add(new Persistence.Data.WebShopModel.ProductCategory
                        {
                            Product = productData,
                            IdCategory = item.IdCategory
                        });
                    }
                }
                _unitofwork.ProductCategoryRepository.AddRange(productCategory);
                _unitofwork.Complete();
            }
            else
            {
                _unitofwork.ProductRepository.Add(productData);
                _unitofwork.Complete();
            }
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
