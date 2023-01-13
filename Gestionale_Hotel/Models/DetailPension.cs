using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestionale_Hotel.Models
{
    public class DetailPension
    {
        public int IdDetailPension { get; set; }
        public string TypePension { get; set; }
        public decimal Tariff { get; set; }
    }
}