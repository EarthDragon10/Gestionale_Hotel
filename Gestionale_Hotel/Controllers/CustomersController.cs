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
        [Authorize]
        // GET: Customers
        public ActionResult Index()
        {
            List<Customers> customers = Customers.GetAllCustomers();
            return View(customers);
        }

        public ActionResult Details(int id) {
            Customers customers = Customers.GetSingleCustomer(id);
            return View(customers);
        }

        public ActionResult Edit(int id)
        {
            Customers customer = Customers.GetSingleCustomer(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customers customer) {
            Customers.EditCustomer(customer);
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Delete(int id)
        {
            Customers customer = Customers.GetSingleCustomer(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(Customers customer)
        {
            Customers.DeleteCustomer(customer);
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customers customer)
        {
            Customers.InsertCustomer(customer);
            return RedirectToAction("Index", "Customers");
        }
    }
}