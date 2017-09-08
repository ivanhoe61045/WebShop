using Persistence.Data.GenericRepository;
using Persistence.Data.WebShopModel;
using System.Data.Entity;

namespace Persistence.Data.WebShopRepository.Interfaces
{
    public class GenderRepository : GenericRepository<Gender>, IGenderRepository
    {
        public GenderRepository(DbContext context) : base(context)
        {
        }
    }
}
