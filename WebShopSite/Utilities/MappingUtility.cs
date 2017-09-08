using AutoMapper;
using Business.Module.BusinessEntyties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShopSite.Models.WebShopViewModels;

namespace WebShopSite.Utilities
{
    public static class MappingUtility
    {
        public static List<ProdutCreationViewModel> MappFromProductViewModelToProduct(IEnumerable<Product> ListProducts)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProdutCreationViewModel>().
                ForMember(d => d.Gender, opt => opt.ResolveUsing(model => new Gender() { IdGender = model.Gender.IdGender, GenderName = model.Gender.GenderName }));
            });
            var ListProductEntityViewModel = Mapper.Map<IEnumerable<Product>, List<ProdutCreationViewModel>>(ListProducts);
            return ListProductEntityViewModel;
        }

        public static Product MappFromProductViewToProductBO(ProdutCreationViewModel productviewModel)
        {
            var productBusiness = new Product
            {
                Description = productviewModel.Description,
                Gender = new Gender
                {
                    GenderName = productviewModel.Gender.GenderName,
                    IdGender = productviewModel.Gender.IdGender
                },
                IdProduct = productviewModel.IdProduct,
                Image = productviewModel.Image,
                Price = productviewModel.Price,
                ProducName = productviewModel.ProducName,
                State = productviewModel.State,
                Title = productviewModel.Title,
                ListCategories = productviewModel.ListCategories.Select(e => new Category
                {
                    CategoryName = e.CategoryName,
                    CatergoryState = e.CatergoryState,
                    IdCategory = e.IdCategory
                }).ToList()
            };
            return productBusiness;
        }

        public static Gender MappFromGenderViewModelToGenderBO(GenderViewModel gender)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<GenderViewModel, Gender>();
            });

            var genderBussines = Mapper.Map<GenderViewModel, Gender>(gender);
            return genderBussines;
        }

        public static List<GenderViewModel> MappFromGenderBOToGenderViewModel(IEnumerable<Gender> ListGender)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Gender, GenderViewModel>();
            });
            var ListGenderEntityViewModel = Mapper.Map<IEnumerable<Gender>, List<GenderViewModel>>(ListGender);
            return ListGenderEntityViewModel;
        }

        public static List<CategoriesViewModel> MappFromCategoriesBOToCategoriesViewModel(IEnumerable<Category> ListCategories)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, CategoriesViewModel>();
            });
            var ListCategoriesEntityViewModel = Mapper.Map<IEnumerable<Category>, List<CategoriesViewModel>>(ListCategories);
            return ListCategoriesEntityViewModel;
        }

        public static Category MappFromCategoryViewModelToCategoryBO(CategoriesViewModel category)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CategoriesViewModel, Category>();
            });

            var categoryBussines = Mapper.Map<CategoriesViewModel, Category>(category);
            return categoryBussines;
        }
    }
}