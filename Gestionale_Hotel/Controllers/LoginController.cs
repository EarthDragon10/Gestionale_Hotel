using Gestionale_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Gestionale_Hotel.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Employees employees)
        {
            if (Employees.GetEmployees(employees.Username, employees.Pwd) != null)
            {
                ViewBag.IsAuth = true;
                FormsAuthentication.SetAuthCookie(employees.Username, false);
                return Redirect(FormsAuthentication.DefaultUrl);
            } else {
                ViewBag.ErrorAuth = "Username e/o password errate!";
            }

            return View();
        }

        public ActionResult LogOut()
        {
            ViewBag.IsAuth = false;
            FormsAuthentication.SignOut();
            return RedirectToAction(FormsAuthentication.LoginUrl);
        }
    }
}