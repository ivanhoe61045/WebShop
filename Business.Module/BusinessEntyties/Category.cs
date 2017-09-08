using AutoMapper;
using Ninject;
using Persistence.Data.UnitofWork;
using System.Collections;
using System.Collections.Generic;

namespace Business.Module.BusinessEntyties
{
    public class Category
    {
        public int IdCategory { get; set; }

        public string CategoryName { get; set; }

        public bool CatergoryState { get; set; }

        private IUnitofWork unitofwork;

        public Category()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IUnitofWork>()
                      .To<UnitofWork>();
                unitofwork = kernel.Get<IUnitofWork>();
            }
        }

        public Category(Category category)
        {
            this.CategoryName = category.CategoryName;
            this.CatergoryState = category.CatergoryState;
            this.IdCategory = category.IdCategory;

            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IUnitofWork>()
                      .To<UnitofWork>();
                unitofwork = kernel.Get<IUnitofWork>();
            }
        }

        public void AddCategory()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, Persistence.Data.WebShopModel.Categories>();
            });

            var category = Mapper.Map<Category, Persistence.Data.WebShopModel.Categories>(this);
            unitofwork.CategoryRepository.Add(category);
            unitofwork.Complete();
        }

        public IEnumerable<Category> GetAll()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Persistence.Data.WebShopModel.Categories,Category>();
            });
            var listCategories =  unitofwork.CategoryRepository.GetAll();
            var listcategoriesBO = Mapper.Map<IEnumerable<Persistence.Data.WebShopModel.Categories>, List<Category>>(listCategories);
            return listcategoriesBO;
        } 
    }
}
