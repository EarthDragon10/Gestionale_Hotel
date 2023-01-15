using Gestionale_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gestionale_Hotel.Controllers
{
    public class CustomersController : Controller
    {
        //[Authorize]
        // GET: Customers
        public ActionResult Index()
        {
            List<Customers> customers = Customers.GetAllCustomers();
            return View(customers);
        }



    }
}