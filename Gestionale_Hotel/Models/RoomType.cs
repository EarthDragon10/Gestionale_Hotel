using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gestionale_Hotel.Models
{
    public class RoomType
    {
        [Key]
        public int IdRoomType { get; set; }
        public string DescrType { get; set; }
    }
}