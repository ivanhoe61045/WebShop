using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Module.BusinessEntyties;
using Ninject;
using Persistence.Data.UnitofWork;

namespace Application.ProductCategoryA.Queries
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private IUnitofWork _unitofwork;

        public ProductCategoryQuery()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IUnitofWork>().To<UnitofWork>();

                _unitofwork = kernel.Get<IUnitofWork>();
            }
        }
              

        private void Dependencies()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IUnitofWork>().To<UnitofWork>();

                _unitofwork = kernel.Get<IUnitofWork>();
            }
        }
    }

    
}
