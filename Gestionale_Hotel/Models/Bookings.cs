using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gestionale_Hotel.Models
{
    public class Bookings
    {
        [Key]
        public int IdBookings { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateBooking { get; set; }
        public int IdentifierBooking { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateCheckIn { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateCheckOut { get; set; }
        public decimal Deposit { get; set; }
        public decimal Tariff { get; set; }
        [Display( Name = "Selezionare la Stanza")]
        public int IdRoom { get; set; }
        [Display(Name = "Selezionare la tipologia della Pensione")]
        public int IdDetailPension { get; set; }
        [Display(Name = "Selezionare un servizio aggiuntivo")]
        public int IdAdditionalServices { get; set; }
        [Display(Name = "Selezionare il cliente")]
        public int IdCustomers { get; set; }

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
                        bookings.IdBookings = Convert.ToInt32(reader["IdBookings"]);
                        bookings.DateBooking = Convert.ToDateTime(reader["DateBooking"]);
                        bookings.IdentifierBooking = Convert.ToInt32(reader["IdentifierBooking"]);
                        bookings.DateCheckIn = Convert.ToDateTime(reader["DateCheckIn"]);
                        bookings.DateCheckOut = Convert.ToDateTime(reader["DateCheckOut"]);
                        bookings.Deposit = Convert.ToDecimal(reader["Deposit"]);
                        bookings.Tariff = Convert.ToDecimal(reader["Tariff"]);
                        bookings.IdRoom = Convert.ToInt32(reader["IdRoom"]);
                        bookings.IdDetailPension = Convert.ToInt32(reader["IdDetailPension"]);
                        bookings.IdAdditionalServices = Convert.ToInt32(reader["IdAdditionalServices"]);
                        bookings.IdCustomers = Convert.ToInt32(reader["IdCustomers"]);
                        ListBookings.Add(bookings);
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

        public static Bookings GetSingleBooking(int id)
        {
            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();

            SqlCommand command = new SqlCommand();

            command.Parameters.AddWithValue("@IdBooking", id);

            command.CommandText = "Select * from Bookings where IdBookings=@IdBooking";
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();
            Bookings bookings = new Bookings();

            try
            {

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        bookings.IdBookings = Convert.ToInt32(reader["IdBookings"]);
                        bookings.DateBooking = Convert.ToDateTime(reader["DateBooking"]);
                        bookings.IdentifierBooking = Convert.ToInt32(reader["IdentifierBooking"]);
                        bookings.DateCheckIn = Convert.ToDateTime(reader["DateCheckIn"]);
                        bookings.DateCheckOut = Convert.ToDateTime(reader["DateCheckOut"]);
                        bookings.Deposit = Convert.ToDecimal(reader["Deposit"]);
                        bookings.Tariff = Convert.ToDecimal(reader["Tariff"]);
                        bookings.IdRoom = Convert.ToInt32(reader["IdRoom"]);
                        bookings.IdDetailPension = Convert.ToInt32(reader["IdDetailPension"]);
                        bookings.IdAdditionalServices = Convert.ToInt32(reader["IdAdditionalServices"]);
                        bookings.IdCustomers = Convert.ToInt32(reader["IdCustomers"]);
                        
                    }
                }
                return bookings;
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

        public static void EditBooking(Bookings booking)
        {

            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "UpdateBooking";

            command.Parameters.AddWithValue("@IdBookings", booking.IdBookings);
            command.Parameters.AddWithValue("@DateBooking", booking.DateBooking);
            command.Parameters.AddWithValue("@IdentifierBooking", booking.IdentifierBooking);
            command.Parameters.AddWithValue("@DateCheckIn", booking.DateCheckIn);
            command.Parameters.AddWithValue("@DateCheckOut", booking.DateCheckOut);
            command.Parameters.AddWithValue("@Deposit", booking.Deposit);
            command.Parameters.AddWithValue("@Tariff", booking.Tariff);
            command.Parameters.AddWithValue("@IdRoom", booking.IdRoom);
            command.Parameters.AddWithValue("@IdDetailPension", booking.IdDetailPension);
            command.Parameters.AddWithValue("@IdAdditionalServices", booking.IdAdditionalServices);
            command.Parameters.AddWithValue("@IdCustomers", booking.IdCustomers);

            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteBooking(Bookings bookings)
        {

            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "deleteBooking";

            command.Parameters.AddWithValue("@IdBookings", bookings.IdBookings);

            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void InsertBewBooking(Bookings booking)
        {
            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "InsertBooking";

            command.Parameters.AddWithValue("@DateBooking", booking.DateBooking);
            command.Parameters.AddWithValue("@IdentifierBooking", booking.IdentifierBooking);
            command.Parameters.AddWithValue("@DateCheckIn", booking.DateCheckIn);
            command.Parameters.AddWithValue("@DateCheckOut", booking.DateCheckOut);
            command.Parameters.AddWithValue("@Deposit", booking.Deposit);
            command.Parameters.AddWithValue("@Tariff", booking.Tariff);
            command.Parameters.AddWithValue("@IdRoom", booking.IdRoom);
            command.Parameters.AddWithValue("@IdDetailPension", booking.IdDetailPension);
            command.Parameters.AddWithValue("@IdAdditionalServices", booking.IdAdditionalServices);
            command.Parameters.AddWithValue("@IdCustomers", booking.IdCustomers);

            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static List<SelectListItem> RoomsDropdownList()
        {
            List<SelectListItem> selectListItems= new List<SelectListItem>();

            SelectListItem selectItemEmpty = new SelectListItem
            {
                Value = "0",
                Text = "",
            };
            selectListItems.Add(selectItemEmpty);

            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();
            SqlDataReader reader = Shared.GetReaderAfterSql("Select * from Room", connection);

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SelectListItem selectItem = new SelectListItem
                        {
                            Value = reader["IdRoom"].ToString(),
                            Text = reader["NumberRoom"].ToString(),
                        };
                        selectListItems.Add(selectItem);
                    }
                }
                return selectListItems;
            }
            catch (Exception)
            {
                return null; 
            }
            finally
            {
                connection.Close();
            }
        }

        public static List<SelectListItem> PensionDropdownList()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();
            SqlDataReader reader = Shared.GetReaderAfterSql("Select * from DetailPension", connection);

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SelectListItem selectItem = new SelectListItem
                        {
                            Value = reader["IdDetailPension"].ToString(),
                            Text = reader["TypePension"].ToString() + " " + reader["Tariff"].ToString() + "Є",
                        };
                        selectListItems.Add(selectItem);
                    }
                }
                return selectListItems;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public static List<SelectListItem> AdditionalServicesDropdownList()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();
            SqlDataReader reader = Shared.GetReaderAfterSql("Select * from AdditionalServices", connection);

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SelectListItem selectItem = new SelectListItem
                        {
                            Value = reader["IdAdditionalServices"].ToString(),
                            Text = reader["AdditionalServices"].ToString() + " " + reader["Tariff"].ToString() + "Є",
                        };
                        selectListItems.Add(selectItem);
                    }
                }
                return selectListItems;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public static List<SelectListItem> CustomersDropdownList()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();
            SqlDataReader reader = Shared.GetReaderAfterSql("Select * from Customers", connection);

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SelectListItem selectItem = new SelectListItem
                        {
                            Value = reader["IdCustomers"].ToString(),
                            Text = reader["LastName"].ToString() + " " + reader["FirstName"].ToString(),
                        };
                        selectListItems.Add(selectItem);
                    }
                }
                return selectListItems;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}