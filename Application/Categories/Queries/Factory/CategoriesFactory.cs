using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Module.BusinessEntyties;
using Persistence.Data.WebShopModel;
using AutoMapper;

namespace Application.Categories.Queries.Factory
{
    public class CategoriesFactory : ICategoriesFactory
    {       
        public IEnumerable<Category> CreateCategoriesBOFromList(IEnumerable<Persistence.Data.WebShopModel.Categories> listCategories)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Persistence.Data.WebShopModel.Categories, Category>();
            });
            var listcategoriesBO = Mapper.Map<IEnumerable<Persistence.Data.WebShopModel.Categories>, List<Category>>(listCategories);
            return listcategoriesBO;
        }

        public Persistence.Data.WebShopModel.Categories CreateCategoryPersistence(Category category)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, Persistence.Data.WebShopModel.Categories>();
            });

            var categories = Mapper.Map<Category, Persistence.Data.WebShopModel.Categories>(category);
            return categories;
        }
    }
}
