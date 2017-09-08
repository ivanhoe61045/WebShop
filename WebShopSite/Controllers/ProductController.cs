using Business.Module.BusinessEntyties;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Transversal.Module.CustomException;
using WebShopSite.Hubs;
using WebShopSite.Models.WebShopViewModels;
using WebShopSite.Utilities;

namespace WebShopSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly ISaveFilesFromRequest _saleFilesFromRequest;
        private readonly IGetFilesFromRequest _getFilesFromRequest;

        public ProductController()
        {

        }
        [Inject]
        public ProductController(ISaveFilesFromRequest saleFilesFromRequest, IGetFilesFromRequest getFilesFromRequest)
        {
            _saleFilesFromRequest = saleFilesFromRequest;
            _getFilesFromRequest = getFilesFromRequest;
        }

        // GET: Product
        public ActionResult Index()
        {
            var productBO = new Product();
            var ListProductViewModel = new List<ProdutCreationViewModel>();
            var ListProducts = productBO.GetAllProducts();
            if (((List<Product>)ListProducts).Count == 0)
                return View(ListProductViewModel);

            List<ProdutCreationViewModel> ListProductEntityViewModel = MappingUtility.MappFromProductViewModelToProduct(ListProducts);
            return View(ListProductEntityViewModel);
        }

        [HttpGet]
        public ActionResult IndexProduct()
        {
            var productBO = new Product();
            var ListProductViewModel = new List<ProdutCreationViewModel>();
            var ListProducts = productBO.GetAllProducts();
            if (((List<Product>)ListProducts).Count == 0)
                return View(ListProductViewModel);
            List<ProdutCreationViewModel> ListProductEntityViewModel = MappingUtility.MappFromProductViewModelToProduct(ListProducts);
            return View(ListProductEntityViewModel);
        }

        [HttpGet]
        public ActionResult GetDataProduct()
        {
            var productBO = new Product();
            var ListProductViewModel = new List<ProdutCreationViewModel>();
            var ListProducts = productBO.GetAllProducts();
            if (((List<Product>)ListProducts).Count == 0)
                return PartialView("ProductDataList", ListProductViewModel);
            var ListProductEntityViewModel = MappingUtility.MappFromProductViewModelToProduct(ListProducts);
            return PartialView("ProductDataList", ListProductEntityViewModel);
        }


        // GET: Product/Create
        public ActionResult Create()
        {
            LoadGender();
            ProdutCreationViewModel ProdutViewModel = LoadCategories();
            return View(ProdutViewModel);
        }

        private static ProdutCreationViewModel LoadCategories()
        {
            var ProdutViewModel = new ProdutCreationViewModel();
            var categoryBO = new Category();
            var listCategories = categoryBO.GetAll();
            var listCategoriesViewModel = MappingUtility.MappFromCategoriesBOToCategoriesViewModel(listCategories);
            ProdutViewModel.ListCategories = listCategoriesViewModel;
            return ProdutViewModel;
        }

        private void LoadGender()
        {
            var genderBO = new Gender();
            var genderList = genderBO.GetAllGender();
            ViewBag.IdGender = new SelectList(genderList, "IdGender", "GenderName");
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutCreationViewModel product)
        {
            try
            {
                LoadGender();
                ViewBag.ListCategories = LoadCategories();
                product.Gender = GetGenderById(product.IdGender);
                string filePath = string.Empty;
                if (ModelState.IsValid)
                {
                    var saveFile = _saleFilesFromRequest.SaveFile(Request, Server.MapPath("~/Images/").ToString(), product);
                    filePath = ValidationPath(product, saveFile);
                    var productBussines = MappingUtility.MappFromProductViewToProductBO(product);
                    var productBO = new Product(productBussines);
                    productBO.AddProduct();
                    //hub
                    ProductHub.ProductData();
                    ViewBag.Message = "Product created success";
                }
                else
                {
                    throw new NoValidaDataException("The form is not right please check it again");                    
                }
                    
                                
                return View(LoadCategories());
            }
            catch (FilesRequestFailedException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(LoadCategories());
            }
            catch (NotValidExtentionException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(LoadCategories());
            }
            catch (NoValidaDataException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(LoadCategories());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ups something it's wrong please try again later";
                return View(LoadCategories());
            }
        }

        private string ValidationPath(ProdutCreationViewModel product, bool saveFile)
        {
            string filePath;
            if (saveFile)
                filePath = _getFilesFromRequest.GetUrlFileFromRequest(Request, Server.MapPath("~/Images/").ToString(), product);
            else
                throw new FilesRequestFailedException("The file is mandatory");

            if (!string.IsNullOrEmpty(filePath))
                product.Image = filePath;
            else
                throw new FilesRequestFailedException("The file is mandatory");
            return filePath;
        }

        private Gender GetGenderById(int idGender)
        {
            var genderBO = new Gender();
            return genderBO.GetGenderById(idGender);
        }

        public ActionResult GetCategoriesByProduct(int id)
        {
            var ProductCategoryBO = new ProductCategory();
            var ProductCategory = ProductCategoryBO.GetCategoriesByProduct(id);

            return View(ProductCategory);
        }

    }
}
