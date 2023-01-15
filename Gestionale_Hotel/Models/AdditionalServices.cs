using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Gestionale_Hotel.Models
{
    public class AdditionalServices
    {
        [Key]
        public int IdAddtionalServices { get; set; }
        public string DescrAdditionalServices { get; set; }
        public decimal Tariff { get; set; }
        public static List<AdditionalServices> GetAllAdditionalServices()
        {
            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();
            List<AdditionalServices> ListAdditionalServices = new List<AdditionalServices>();

            SqlDataReader reader = Shared.GetReaderAfterSql("Select * from AdditionalServices", connection);

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AdditionalServices AddServ = new AdditionalServices();
                        AddServ.IdAddtionalServices = Convert.ToInt32(reader["IdAdditionalServices"]);
                        AddServ.DescrAdditionalServices = reader["AdditionalServices"].ToString();
                        AddServ.Tariff = Convert.ToDecimal(reader["Tariff"]);
                        ListAdditionalServices.Add(AddServ);
                    }
                }
                return ListAdditionalServices;
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
        public static AdditionalServices GetSingleAdditionalServices(int id)
        {
            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@Id", id);
            command.CommandText = "Select * from AdditionalServices Where IdAdditionalServices=@Id";
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();
            AdditionalServices AddServ = new AdditionalServices();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        AddServ.IdAddtionalServices = Convert.ToInt32(reader["IdAddtionalServices"]);
                        AddServ.DescrAdditionalServices = reader["AdditionalServices"].ToString();
                        AddServ.Tariff = Convert.ToDecimal(reader["Tariff"]);
;
                    }
                }
                return AddServ;
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
        public static void EditAdditionalServices(AdditionalServices AddServ)
        {
            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "EditAdditionalServices";

            command.Parameters.AddWithValue("@AdditionalServices", AddServ.DescrAdditionalServices);
            command.Parameters.AddWithValue("@Tariff", AddServ.Tariff);

            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteAdditionalServices(AdditionalServices AddServ)
        {
            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "DeleteAdditionalServices";

            command.Parameters.AddWithValue("@IdAddtionalServices", AddServ.IdAddtionalServices);

            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void InsertAdditionalServices(AdditionalServices AddServ)
        {
            SqlConnection connection = Shared.GetConnectionDB();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "InsertAdditionalServices";

            command.Parameters.AddWithValue("@AdditionalServices", AddServ.DescrAdditionalServices);
            command.Parameters.AddWithValue("@Tariff", AddServ.Tariff); ;

            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}