using Business.Module.BusinessEntyties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductA.Queries
{
    public interface IProductsQuery
    {
        IEnumerable<Product> GetAllProducts();
        Product GetCategoriesByProduct(int ID);
    }
}
