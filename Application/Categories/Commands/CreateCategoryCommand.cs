using Application.Categories.Queries.Factory;
using Business.Module.BusinessEntyties;
using Ninject;
using Persistence.Data.UnitofWork;

namespace Application.Categories.Commands
{
    public class CreateCategoryCommand : ICreateCategoryCommand
    {
        private IUnitofWork _unitofwork;
        private ICategoriesFactory _categoriesFactory;

        public CreateCategoryCommand()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IUnitofWork>().To<UnitofWork>();
                kernel.Bind<ICategoriesFactory>().To<CategoriesFactory>();

                _unitofwork = kernel.Get<IUnitofWork>();
                _categoriesFactory = kernel.Get<ICategoriesFactory>();
            }
        }

        public void AddCategory(Category category)
        {
            _unitofwork.CategoryRepository.Add(_categoriesFactory.CreateCategoryPersistence(category));
            _unitofwork.Complete();
        }

        private void Dependencies()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IUnitofWork>().To<UnitofWork>();
                kernel.Bind<ICategoriesFactory>().To<CategoriesFactory>();

                _unitofwork = kernel.Get<IUnitofWork>();
                _categoriesFactory = kernel.Get<ICategoriesFactory>();
            }
        }
    }
}
