using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class AddSeatViewModel
    {
        public List<Seat> Seats { get; set; }
        public List<Hall> Halls { get; set; }

    }
}