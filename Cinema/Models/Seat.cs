using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }
        public int HallId { get; set; }
        public string  Row { get; set; }
        public int Column { get; set; }
        public Hall Hall { get; set; }
        
    }
}