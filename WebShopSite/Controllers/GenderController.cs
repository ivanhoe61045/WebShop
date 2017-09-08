using AutoMapper;
using Business.Module.BusinessEntyties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transversal.Module.CustomException;
using WebShopSite.Models.WebShopViewModels;
using WebShopSite.Utilities;

namespace WebShopSite.Controllers
{
    public class GenderController : Controller
    {
        // GET: Gender
        public ActionResult Index()
        {
            var GenderBO = new Gender();
            var ListGenderViewModel = new List<GenderViewModel>();
            var ListGender = GenderBO.GetAllGender();
            if (((List<Gender>)ListGender).Count == 0)
                return View(ListGenderViewModel);
                        
            var ListGenderEntityViewModel = MappingUtility.MappFromGenderBOToGenderViewModel(ListGender);
            return View(ListGenderEntityViewModel);
        }
        
        // GET: Gender/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gender/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GenderViewModel gender)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var genderBussines = MappingUtility.MappFromGenderViewModelToGenderBO(gender);
                    if (genderBussines != null)
                    {
                        var genderBO = new Gender(genderBussines);
                        genderBO.AddGender();
                    }
                    else
                        throw new MappingFailedException("The Gender mapping failed");
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
