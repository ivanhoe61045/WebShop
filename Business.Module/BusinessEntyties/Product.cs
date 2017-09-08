using AutoMapper;
using Ninject;
using Persistence.Data.UnitofWork;
using System.Collections.Generic;

namespace Business.Module.BusinessEntyties
{
    public class Product
    {
        #region properties
        public long IdProduct { get; set; }

        public string ProducName { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public bool State { get; set; }

        public Gender Gender { get; set; }

        public List<Category> ListCategories { get; set; }

        private IUnitofWork unitofwork;
        #endregion

        #region constructor
        public Product(Product product)
        {
            this.IdProduct = product.IdProduct;
            this.Image = product.Image;
            this.Description = product.Description;
            this.Gender = new Gender(product.Gender);
            this.Price = product.Price;
            this.ProducName = product.ProducName;
            this.State = product.State;
            this.Title = product.Title;
            this.ListCategories = product.ListCategories;

            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IUnitofWork>()
                      .To<UnitofWork>();

                unitofwork = kernel.Get<IUnitofWork>();
            }
        }
        public Product()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IUnitofWork>()
                      .To<UnitofWork>();

                unitofwork = kernel.Get<IUnitofWork>();
            }
        }
        #endregion

        #region methods
        public void AddProduct()
        {
            var productCategoryBO = new ProductCategory();
            Persistence.Data.WebShopModel.Product productData = MappingProduct();
            var productCategory = new List<Persistence.Data.WebShopModel.ProductCategory>();
            if (ListCategories.Count > 0)
            {
                foreach (var item in this.ListCategories)
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
                productCategoryBO.AddProductCategory(productCategory);
            }
            else
            {
                unitofwork.ProductRepository.Add(productData);
                unitofwork.Complete();
            }

        }

        private Persistence.Data.WebShopModel.Product MappingProduct()
        {
            return new Persistence.Data.WebShopModel.Product
            {
                Description = this.Description,
                IdGender = this.Gender.IdGender,
                IdProduct = this.IdProduct,
                Image = this.Image,
                Price = this.Price,
                ProducName = this.ProducName,
                State = this.State,
                Title = this.Title
            };
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var ListProducts = unitofwork.ProductRepository.Include(new List<string>() {"Gender"});
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Persistence.Data.WebShopModel.Product, Product>().
                ForMember(d => d.Gender, opt => opt.ResolveUsing(model => new Gender() { IdGender = model.IdGender, GenderName = model.Gender.GenderName }));
            });

            if (((List<Persistence.Data.WebShopModel.Product>)ListProducts).Count == 0)
                return new List<Product>();

            var ListProductEntity = Mapper.Map<IEnumerable<Persistence.Data.WebShopModel.Product>, List<Product>>(ListProducts);

            return ListProductEntity;
        }


        #endregion
    }
}
