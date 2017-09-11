using Ninject;
using Persistence.Data.UnitofWork;
using Persistence.Data.WebShopModel;
using System.Collections.Generic;

namespace Application.ProductCategoryA.Commands
{
    public class CommandsProductCategory : ICommandsProductCategory
    {
        private IUnitofWork _unitofwork;

        public CommandsProductCategory()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IUnitofWork>().To<UnitofWork>();

                _unitofwork = kernel.Get<IUnitofWork>();
            }
        }

        public void AddProductCategory(IEnumerable<ProductCategory> listProductCategory)
        {
            _unitofwork.ProductCategoryRepository.AddRange(listProductCategory);
            _unitofwork.Complete();
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
