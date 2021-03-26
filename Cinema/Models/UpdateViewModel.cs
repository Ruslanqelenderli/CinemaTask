using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class UpdateViewModel
    {
       
        public Film Films { get; set; }

        public List<Country> Countries { get; set; }
        public List<Janre> Janres { get; set; }

    }
}