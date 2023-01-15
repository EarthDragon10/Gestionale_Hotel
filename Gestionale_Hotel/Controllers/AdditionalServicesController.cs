using Gestionale_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gestionale_Hotel.Controllers
{
    [Authorize]
    public class AdditionalServicesController : Controller
    {
        // GET: AdditionalServices
        public ActionResult Index()
        {
            List<AdditionalServices> ListAddServ = AdditionalServices.GetAllAdditionalServices();
            return View(ListAddServ);
        }

        public ActionResult Details(int id)
        {
            AdditionalServices AddServ = AdditionalServices.GetSingleAdditionalServices(id);
            return View(AddServ);
        }

        public ActionResult Edit(int id)
        {
            AdditionalServices AddServ = AdditionalServices.GetSingleAdditionalServices(id);
            return View(AddServ);
        }

        [HttpPost]
        public ActionResult Edit(AdditionalServices AddServ)
        {
            AdditionalServices.EditAdditionalServices(AddServ);
            return RedirectToAction("Index", "AdditionalServices");
        }

        public ActionResult Delete(int id)
        {
            AdditionalServices AddServ = AdditionalServices.GetSingleAdditionalServices(id);
            return View(AddServ);
        }
        [HttpPost]
        public ActionResult Delete(AdditionalServices AddServ)
        {
            AdditionalServices.DeleteAdditionalServices(AddServ);
            return RedirectToAction("Index", "AdditionalServices");
        }
        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AdditionalServices AddServ)
        {
            AdditionalServices.InsertAdditionalServices(AddServ);
            return RedirectToAction("Index", "AdditionalServices");
        }
    }
}