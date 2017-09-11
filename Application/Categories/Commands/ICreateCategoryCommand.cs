using Business.Module.BusinessEntyties;

namespace Application.Categories.Commands
{
    public interface ICreateCategoryCommand
    {
        void AddCategory(Category category);
    }
}
