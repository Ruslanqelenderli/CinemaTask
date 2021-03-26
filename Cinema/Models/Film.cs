using Cinema.Models.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
        public double Duration { get; set; }
        public string Link { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<FilmJanre> FilmJanres { get; set; }
        public List<FilmCountry> FilmCountries{ get; set; }
    }
   
}