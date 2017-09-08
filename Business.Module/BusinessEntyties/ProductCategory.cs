using AutoMapper;
using Ninject;
using Persistence.Data.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Module.BusinessEntyties
{
    public class ProductCategory
    {
        public long IdProductCategory { get; set; }

        public virtual IEnumerable<Category> Category { get; set; }

        public virtual Product Product { get; set; }
        
        private IUnitofWork unitofwork;

        public ProductCategory()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IUnitofWork>()
                      .To<UnitofWork>();

                unitofwork = kernel.Get<IUnitofWork>();
            }
        }

        internal void AddProductCategory(List<Persistence.Data.WebShopModel.ProductCategory> listProductCategory)
        {
            unitofwork.ProductCategoryRepository.AddRange(listProductCategory);
            unitofwork.Complete();
        }

        public Product GetCategoriesByProduct(int ID)
        {
            var categoryBO = new Category();
            var listCategoriesByProduct = unitofwork.ProductCategoryRepository.GetCategoriesByProduct(ID);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Persistence.Data.WebShopModel.Categories, Category>();
            });            
            var ListCategoryEntity = Mapper.Map<IEnumerable<Persistence.Data.WebShopModel.Categories>, List<Category>>(listCategoriesByProduct);
            
            var productBO = unitofwork.ProductRepository.IncludeEntityById(new List<string>() { "Gender" }, e=>e.IdProduct==ID);
            var productCategory = new Product
            {
                ListCategories = ListCategoryEntity,
                Description = productBO.Description,
                IdProduct = productBO.IdProduct,
                Image = productBO.Image,
                Price = productBO.Price,
                ProducName = productBO.ProducName,
                State = productBO.State,
                Title = productBO.Title,
                Gender = new Gender
                {
                    GenderName=productBO.Gender.GenderName,
                    IdGender = productBO.IdGender
                }
            };
            return productCategory;
        }
    }
}
