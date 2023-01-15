using Gestionale_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gestionale_Hotel.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            List<Employees> ListEmployees = Employees.GetAllCustomers();
            return View(ListEmployees);
        }

        public ActionResult Details(int id)
        {
            Employees employee = Employees.GetSingleCustomer(id);
            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            Employees employee = Employees.GetSingleCustomer(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employees employee)
        {
            Employees.EditEmployee(employee);
            return RedirectToAction("Index", "Employees");
        }

        public ActionResult Delete(int id)
        {
            Employees employee = Employees.GetSingleCustomer(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(Employees employee)
        {
            Employees.DeleteEmployee(employee);
            return RedirectToAction("Index", "Employees");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employees employee)
        {
            Employees.InsertEmployee(employee);
            return RedirectToAction("Index", "Employees");
        }
    }
}