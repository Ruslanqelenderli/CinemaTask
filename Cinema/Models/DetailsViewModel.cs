using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class DetailsViewModel
    {
        public List<FilmJanre> FilmJanres { get; set; }
        public List<FilmCountry> FilmCountries { get; set; }
    }
}