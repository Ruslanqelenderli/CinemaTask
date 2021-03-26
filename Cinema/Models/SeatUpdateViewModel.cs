using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class SeatUpdateViewModel
    {
        public List<Hall> Halls { get; set; }
        public Seat Seat { get; set; }
    }
}