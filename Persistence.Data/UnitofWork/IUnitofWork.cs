using Persistence.Data.WebShopRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.UnitofWork
{
    public interface IUnitofWork : IDisposable
    {
        IProductCategoryRepository ProductCategoryRepository
        {
            get;
        }
        IProductRepository ProductRepository
        {
            get;
        }
        IGenderRepository GenderRepository
        {
            get;
        }
        ICategoryRepository CategoryRepository
        {
            get;
        }
        
        int Complete();
    }
}
