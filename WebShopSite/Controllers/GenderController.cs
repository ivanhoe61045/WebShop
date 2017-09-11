using Application.GenderA.Commands;
using Application.GenderA.Queries;
using Business.Module.BusinessEntyties;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Transversal.Module.CustomException;
using WebShopSite.Models.WebShopViewModels;
using WebShopSite.Utilities;

namespace WebShopSite.Controllers
{
    public class GenderController : Controller
    {
        private readonly IGenderListQuery _getGenderListQuery;
        private readonly ICommandsGender _createGenderCommand;

        public GenderController(ICommandsGender commandGender, IGenderListQuery genderListQuery)
        {
            _createGenderCommand = commandGender;
            _getGenderListQuery = genderListQuery;
        }
        // GET: Gender
        public ActionResult Index()
        {
            var ListGenderViewModel = new List<GenderViewModel>();
            var ListGender = _getGenderListQuery.GetAllGender();
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
                        _createGenderCommand.AddGender(genderBussines);                    
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
