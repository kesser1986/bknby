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
using BknDal.Models;
using AutoMapper;
using BknDto.Dto;

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
            var model = _realEstateObjectsService.GetRealEstateObjects();
            var result = Mapper.Map<List<RealEstateObjectDto>>(model);
            return View(result);
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetRealEstateObject(int id)
        {
            var realObject = _realEstateObjectsService.GetRealEstateObject(id);
            var realEstateObjectPhotos = _realEstateObjectsService.GetRealEstateObjectPhotos(realObject.Unid);
            var resultObject = Mapper.Map<RealEstateObjectDto>(realObject);
            var objectPhotos = Mapper.Map<List<RealEstateObjectPhotoDto>>(realEstateObjectPhotos);
            resultObject.ObjectPhotos = objectPhotos;
            return View("RealEstateObjectPage", resultObject);
        }

        [Authorize]
        public ActionResult ImportRealEstateObjects()
        {
            _realEstateObjectsService.ImportRealEstateObjects();
            var model = _realEstateObjectsService.GetRealEstateObjects();
            var result = Mapper.Map<List<RealEstateObjectDto>>(model);

            return View("Index", result);
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