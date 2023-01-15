using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Gestionale_Hotel.Models
{
    public class Employees
    {
        [Key]
        public int IdEmployes { get; set; }
        public string Username { get; set; }
        public string Pwd { get; set; }
        public static Employees IsAuth(string username, string pwd)
        {

            // modificare con il return su true ( se il login ha successo ) e false
            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();
            try
            {

                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Pwd", pwd);

                command.CommandText = "Select * from Employees Where Username=@Username and Pwd=@Pwd";
                command.Connection = connection;

                SqlDataReader reader = command.ExecuteReader();
                Employees employees = new Employees();

                if (reader.HasRows)
                {
                    while(reader.Read()) {
                        
                        employees.Username = reader["Username"].ToString();
                        employees.Pwd = reader["Pwd"].ToString();                 
                    }
                }
                return employees;
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
        public static List<Employees> GetAllCustomers()
        {
            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();
            List<Employees> ListEmployees = new List<Employees>();

            SqlDataReader reader = Shared.GetReaderAfterSql("Select * from Employees", connection);

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employees employee = new Employees();
                        employee.IdEmployes = Convert.ToInt32(reader["IdEmployes"]);
                        employee.Username = reader["Username"].ToString();
                        employee.Pwd = reader["Pwd"].ToString();
                        
                        ListEmployees.Add(employee);
                    }
                }
                return ListEmployees;
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
        public static Employees GetSingleCustomer(int id)
        {
            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@Id", id);

            command.CommandText = "Select * from Employees where IdEmployes=@Id";
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();
            Employees employee = new Employees();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        employee.IdEmployes = Convert.ToInt32(reader["IdEmployes"]);
                        employee.Username = reader["Username"].ToString();
                        employee.Pwd = reader["Pwd"].ToString();
                    }
                }
                return employee;
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
        public static void EditEmployee(Employees employee)
        {

            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "EditEmployee";

            command.Parameters.AddWithValue("@Username", employee.Username);
            command.Parameters.AddWithValue("@Pwd", employee.Pwd);
 
            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteEmployee(Employees employee)
        {

            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "DeleteEmployee";

            command.Parameters.AddWithValue("@IdEmployes", employee.IdEmployes);

            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void InsertEmployee(Employees employee)
        {

            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "InsertEmployee";

            command.Parameters.AddWithValue("@Username", employee.Username);
            command.Parameters.AddWithValue("@Pwd", employee.Pwd);

            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}