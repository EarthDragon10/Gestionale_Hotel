using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestionale_Hotel.Models
{
    public class AdditionalServices
    {
        public int IdAddtionalServices { get; set; }
        public string DescrAdditionalServices { get; set; }
        public decimal Tariff { get; set; }
    }
}