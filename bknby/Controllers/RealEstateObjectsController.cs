using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BknDal.Repositories.Classes;
using BknDal.Repositories.Interfaces;
using BknService.Services.Classes;
using BknService.Services.Interfaces;
using Ninject;

namespace bknby.Controllers
{
    public class RealEstateObjectsController : Controller
    {
        private readonly IRealEstateObjectsService _realEstateObjectsService;

        public RealEstateObjectsController(IRealEstateObjectsService realEstateObjectsService)
        {
            _realEstateObjectsService = realEstateObjectsService;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult ImportRealEstateObjects()
        {

            _realEstateObjectsService.ImportRealEstateObjects();

            return View("Index");
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}