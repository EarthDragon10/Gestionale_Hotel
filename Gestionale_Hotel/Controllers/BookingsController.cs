using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gestionale_Hotel.Controllers
{
    public class BookingsController : Controller
    {
        // GET: Bookings
        public ActionResult Bookings()
        {
            return View();
        }
    }
}