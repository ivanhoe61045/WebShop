using Business.Module.BusinessEntyties;
using System.Collections.Generic;

namespace Application.Categories.Queries.GetCategoriesList
{
    public interface IGetCategoriesListQuery
    {        
        IEnumerable<Category> GetAll();
    }
}
