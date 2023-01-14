using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}