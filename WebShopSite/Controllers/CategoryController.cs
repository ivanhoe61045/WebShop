using Application.Categories.Commands;
using Application.Categories.Queries.GetCategoriesList;
using Ninject;
using System;
using System.Web.Mvc;
using WebShopSite.Models.WebShopViewModels;
using WebShopSite.Utilities;

namespace WebShopSite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IGetCategoriesListQuery _getCategoriesListQuery;
        private readonly ICreateCategoryCommand _createCategoryCommand;

        [Inject]
        public CategoryController(IGetCategoriesListQuery getCategoriesListQuery, ICreateCategoryCommand createCategoryCommand)
        {
            _getCategoriesListQuery = getCategoriesListQuery;
            _createCategoryCommand = createCategoryCommand;
        }
        // GET: Category
        public ActionResult Index()
        {
            var listCategories = _getCategoriesListQuery.GetAll();
            var listCategoriesViewModel = MappingUtility.MappFromCategoriesBOToCategoriesViewModel(listCategories);
            return View(listCategoriesViewModel);
        }
        
        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoriesViewModel categories)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var category = MappingUtility.MappFromCategoryViewModelToCategoryBO(categories);
                    _createCategoryCommand.AddCategory(category);
                }
                else
                {
                    return View();
                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
       
    }
}
