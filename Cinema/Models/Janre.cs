using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Janre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}