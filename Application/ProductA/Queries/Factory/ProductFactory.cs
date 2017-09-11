using AutoMapper;
using Business.Module.BusinessEntyties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Data.WebShopModel;

namespace Application.ProductA.Queries.Factory
{
    public class ProductFactory: IProductFactory
    {
        public IEnumerable<Business.Module.BusinessEntyties.Product> CreateListProductDataToBO(IEnumerable<Persistence.Data.WebShopModel.Product> ListProducts)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Persistence.Data.WebShopModel.Product, Business.Module.BusinessEntyties.Product>().
                ForMember(d => d.Gender, opt => opt.ResolveUsing(model => new Business.Module.BusinessEntyties.Gender() { IdGender = model.IdGender, GenderName = model.Gender.GenderName }));
            });

            if (((List<Persistence.Data.WebShopModel.Product>)ListProducts).Count == 0)
                return new List<Business.Module.BusinessEntyties.Product>();

            var ListProductEntity = Mapper.Map<IEnumerable<Persistence.Data.WebShopModel.Product>, List<Business.Module.BusinessEntyties.Product>>(ListProducts);
            return ListProductEntity;
        }

        public Persistence.Data.WebShopModel.Product CreateProductData(Business.Module.BusinessEntyties.Product product)
        {
            return new Persistence.Data.WebShopModel.Product
            {
                Description = product.Description,
                IdGender = product.Gender.IdGender,
                IdProduct = product.IdProduct,
                Image = product.Image,
                Price = product.Price,
                ProducName = product.ProducName,
                State = product.State,
                Title = product.Title
            };
        }

        public List<Category> CreateListCategoryBOFromData(IEnumerable<Persistence.Data.WebShopModel.Categories> listCategoriesByProduct)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Persistence.Data.WebShopModel.Categories, Category>();
            });
            var ListCategoryEntity = Mapper.Map<IEnumerable<Persistence.Data.WebShopModel.Categories>, List<Category>>(listCategoriesByProduct);
            return ListCategoryEntity;
        }

        public Business.Module.BusinessEntyties.Product CreatePRoductBOFromData(Persistence.Data.WebShopModel.Product product, List<Category> listCategories)
        {
            var productCategory = new Business.Module.BusinessEntyties.Product
            {
                ListCategories = listCategories,
                Description = product.Description,
                IdProduct = product.IdProduct,
                Image = product.Image,
                Price = product.Price,
                ProducName = product.ProducName,
                State = product.State,
                Title = product.Title,
                Gender = new Business.Module.BusinessEntyties.Gender
                {
                    GenderName = product.Gender.GenderName,
                    IdGender = product.IdGender
                }
            };
            return productCategory;
        }
    }
}
