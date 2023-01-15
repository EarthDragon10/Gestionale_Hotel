using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Gestionale_Hotel.Models
{
    public class Customers
    {

        [Key]
        public int IdCustomers { get; set; }
        public string FiscalCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
        public int Cellular { get; set; }
        public static List<Customers> GetAllCustomers()
        {
            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();
            List<Customers> ListCustomers = new List<Customers>();

            SqlDataReader reader = Shared.GetReaderAfterSql("Select * from Customers", connection);

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Customers customers = new Customers();
                        customers.IdCustomers = Convert.ToInt32(reader["IdCustomers"]);
                        customers.FiscalCode = reader["FiscalCode"].ToString();
                        customers.LastName = reader["LastName"].ToString();
                        customers.FirstName = reader["FirstName"].ToString();
                        customers.City = reader["City"].ToString();
                        customers.Province = reader["Province"].ToString();
                        customers.Email = reader["Email"].ToString();
                        customers.Telephone = Convert.ToInt32(reader["Telephone"]);
                        customers.Cellular = Convert.ToInt32(reader["Cellular"]);
                        ListCustomers.Add(customers);
                    }
                }
                return ListCustomers;
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
        public static Customers GetSingleCustomer(int id)
        {
            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@Id", id);

            command.CommandText = "Select * from Customers where IdCustomers=@Id";
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();
            Customers customers = new Customers();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        customers.IdCustomers = Convert.ToInt32(reader["IdCustomers"]);
                        customers.FiscalCode = reader["FiscalCode"].ToString();
                        customers.LastName = reader["LastName"].ToString();
                        customers.FirstName = reader["FirstName"].ToString();
                        customers.City = reader["City"].ToString();
                        customers.Province = reader["Province"].ToString();
                        customers.Email = reader["Email"].ToString();
                        customers.Telephone = Convert.ToInt32(reader["Telephone"]);
                        customers.Cellular = Convert.ToInt32(reader["Cellular"]);
       
                    }
                }
                return customers;
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
        public static void EditCustomer(Customers customer)
        {

            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "EditCustomer";

            command.Parameters.AddWithValue("@FiscalCode", customer.FiscalCode);
            command.Parameters.AddWithValue("@LastName", customer.LastName);
            command.Parameters.AddWithValue("@FirstName", customer.FirstName);
            command.Parameters.AddWithValue("@City", customer.City);
            command.Parameters.AddWithValue("@Province", customer.Province);
            command.Parameters.AddWithValue("@Email", customer.Email);
            command.Parameters.AddWithValue("@Telephone", customer.Telephone);
            command.Parameters.AddWithValue("@Cellular", customer.Cellular);

            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void InsertCustomer(Customers customer)
        {

            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "InsertCustomer";

            command.Parameters.AddWithValue("@FiscalCode", customer.FiscalCode);
            command.Parameters.AddWithValue("@LastName", customer.LastName);
            command.Parameters.AddWithValue("@FirstName", customer.FirstName);
            command.Parameters.AddWithValue("@City", customer.City);
            command.Parameters.AddWithValue("@Province", customer.Province);
            command.Parameters.AddWithValue("@Email", customer.Email);
            command.Parameters.AddWithValue("@Telephone", customer.Telephone);
            command.Parameters.AddWithValue("@Cellular", customer.Cellular);

            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void DeleteCustomer(Customers customer)
        {

            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "DeleteCustomer";

            command.Parameters.AddWithValue("@IdCustomers", customer.IdCustomers);

            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}