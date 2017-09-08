using Business.Module.BusinessEntyties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopSite.Models.WebShopViewModels;
using WebShopSite.Utilities;

namespace WebShopSite.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var categoryBO = new Category();
            var listCategories = categoryBO.GetAll();
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
                    var categoryBO = new Category(category);
                    categoryBO.AddCategory();
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
