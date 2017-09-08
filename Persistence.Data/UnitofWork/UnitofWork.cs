using System;
using Persistence.Data.WebShopRepository.Interfaces;
using Persistence.Data.WebShopRepository.WebShopImplementation;

namespace Persistence.Data.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {
        protected readonly WebShopModel.ModelShop _context;

        public UnitofWork()
        {
            _context = new WebShopModel.ModelShop();
            ProductRepository = new ProductRepository(_context);
            ProductCategoryRepository = new ProductCategoryRepository(_context);
            GenderRepository = new GenderRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
        }
        
        public IProductCategoryRepository ProductCategoryRepository { get; private set; }

        public IProductRepository ProductRepository { get; private set; }

        public IGenderRepository GenderRepository { get; private set; }

        public ICategoryRepository CategoryRepository { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
