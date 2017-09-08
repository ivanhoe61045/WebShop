using Persistence.Data.GenericRepository;
using Persistence.Data.WebShopModel;
using Persistence.Data.WebShopRepository.Interfaces;
using System.Data.Entity;

namespace Persistence.Data.WebShopRepository.WebShopImplementation
{
    public class CategoryRepository : GenericRepository<Categories>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
