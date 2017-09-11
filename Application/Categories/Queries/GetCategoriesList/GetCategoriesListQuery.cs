using Application.Categories.Queries.Factory;
using AutoMapper;
using Business.Module.BusinessEntyties;
using Ninject;
using Persistence.Data.UnitofWork;
using System.Collections.Generic;
using System;

namespace Application.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IGetCategoriesListQuery
    {

        private IUnitofWork _unitofwork;
        private ICategoriesFactory _categoriesFactory;

        public GetCategoriesListQuery()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IUnitofWork>().To<UnitofWork>();
                kernel.Bind<ICategoriesFactory>().To<CategoriesFactory>();

                _unitofwork = kernel.Get<IUnitofWork>();
                _categoriesFactory = kernel.Get<ICategoriesFactory>();
            }
            
        }
        
        public IEnumerable<Category> GetAll()
        {
            var listCategories = _unitofwork.CategoryRepository.GetAll();
            var listcategoriesBO = _categoriesFactory.CreateCategoriesBOFromList(listCategories);
            return listcategoriesBO;
        }

        private void Dependencies()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IUnitofWork>().To<UnitofWork>();
                kernel.Bind<ICategoriesFactory>().To<CategoriesFactory>();

                _unitofwork = kernel.Get<IUnitofWork>();
                _categoriesFactory = kernel.Get<ICategoriesFactory>();
            }
        }
    }
}
