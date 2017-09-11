using Business.Module.BusinessEntyties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductA.Commands
{
    public interface ICommandProduct
    {
        void AddProduct(Product product);
    }
}
