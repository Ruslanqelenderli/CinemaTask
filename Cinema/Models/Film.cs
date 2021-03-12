using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public  class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
        public double Duration { get; set; }
        public string Link { get; set; }
        public int CountryId { get; set; }
        public int JanreId { get; set; }

        public  Country Country { get; set; }
        public  Janre Janre { get; set; }
    }
}