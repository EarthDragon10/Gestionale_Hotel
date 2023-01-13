using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Gestionale_Hotel.Models
{
    public class Employees
    {
        public int IdEmployes { get; set; }
        public string Username { get; set; }
        public string Pwd { get; set; }
        public static Employees GetEmployees(string username, string pwd)
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
    }
}