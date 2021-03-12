using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class IndexViewModel
    {
      public  List<Film> Films { get; set; }
      public  List<Country> Countries { get; set; }
      public  List<Janre> Janres { get; set; }
      public List<FilmCountry> FilmCountries { get; set; }
      public List<FilmJanre> FilmJanres { get; set; }

    }
}