using Gestionale_Hotel.Models;
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
        [Authorize]
        public ActionResult TableBookings()
        {
            List<Bookings> ListBookings = Bookings.GetAllBookings();
            ViewBag.AfterLogin = true;
            return View(ListBookings);
        }

        public ActionResult EditBooking(int id)
        {
            Bookings booking = Bookings.GetSingleBooking(id);

            ViewBag.ListRooms = Bookings.RoomsDropdownList();

            ViewBag.ListPension = Bookings.PensionDropdownList();

            ViewBag.ListAdditionalServices = Bookings.AdditionalServicesDropdownList();

            return View(booking);
        }
    }
}