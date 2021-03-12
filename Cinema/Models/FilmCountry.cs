using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class FilmCountry
    {
        [Key]
        public int Id { get; set; }
        public int FilmId { get; set; }
        public int CountryId { get; set; }
        public Film GetFilm { get; set; }
        public Country Country { get; set; }

        public FilmCountry(int countryId, int filmId)
        {
            CountryId = countryId;
            FilmId = filmId;
        }
        public FilmCountry()
        {

        }

    }
}