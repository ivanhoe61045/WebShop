using Persistence.Data.GenericRepository;
using Persistence.Data.WebShopModel;
using Persistence.Data.WebShopRepository.Interfaces;
using System.Data.Entity;

namespace Persistence.Data.WebShopRepository.WebShopImplementation
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}
