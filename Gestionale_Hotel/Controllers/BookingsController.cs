using Gestionale_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gestionale_Hotel.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        public ActionResult TableBookings()
        {
            List<Bookings> ListBookings = Bookings.GetAllBookings();
            ViewBag.AfterLogin = true;
            return View(ListBookings);
        }

        public ActionResult DeleteBooking(int id) {
            Bookings booking = Bookings.GetSingleBooking(id);
            return View(booking);
        }

        [HttpPost]
        public ActionResult DeleteBooking()
        {
            
            return RedirectToAction("TableBookings", "Bookings");
        }

        public ActionResult EditBooking(int id)
        {
            Bookings booking = Bookings.GetSingleBooking(id);

            ViewBag.ListRooms = Bookings.RoomsDropdownList();

            ViewBag.ListPension = Bookings.PensionDropdownList();

            ViewBag.ListAdditionalServices = Bookings.AdditionalServicesDropdownList();

            ViewBag.ListCustomers = Bookings .CustomersDropdownList();

            return View(booking);
        }

        [HttpPost]
        public ActionResult EditBooking(Bookings booking)
        {

            Bookings.EditBooking(booking);

            return RedirectToAction("TableBookings", "Bookings");
        }
    }
}