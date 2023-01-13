using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gestionale_Hotel.Models
{
    public class Bookings
    {
        public int IdBookings { get; set; }
        public DateTime DateBooking { get; set; }
        public int IdentifierBooking { get; set; }
        public DateTime DateCheckIn { get; set; }
        public DateTime DateCheckOut { get; set; }
        public decimal Deposit { get; set; }
        public decimal Tariff { get; set; }
        public Room Room { get; set; }
        public DetailPension DetailPension { get; set; }
        public AdditionalServices AdditionalServices { get; set; }
        public Customers Customers{ get; set; }

        public static List<Bookings> GetAllBookings()
        {
            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();

            List<Bookings> ListBookings = new List<Bookings>();

            SqlDataReader reader = Shared.GetReaderAfterSql("Select * from Bookings", connection);

            try
            {

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Bookings bookings = new Bookings();
                        bookings.IdBookings = Convert.ToInt32(reader["IdBookings"])
                       
                     }
                }
                return ListBookings;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        //public static List<SelectListItem> RoomListDrop()
        //{

        //}

    }
}