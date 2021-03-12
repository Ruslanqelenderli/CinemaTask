using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class FilmJanre
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int JanreId { get; set; }
        public Janre Janre { get; set; }
        public FilmJanre(int janrId,int filmId)
        {
            FilmId = filmId;
            JanreId = janrId;
        }
        public FilmJanre() { }
        
    }
}