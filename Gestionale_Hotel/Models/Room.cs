using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gestionale_Hotel.Models
{
    public class Room
    {
        [Key]
        public int IdRoom { get; set; }
        public int NumberRoom { get; set; }
        public string DescriptionRoom { get; set; }
        public int IdRoomType { get; set; }
        public RoomType RoomType { get; set; }
    }
}