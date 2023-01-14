using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gestionale_Hotel.Models
{
    public class DetailPension
    {
        [Key]
        public int IdDetailPension { get; set; }
        public string TypePension { get; set; }
        public decimal Tariff { get; set; }
    }
}