using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cinema.Context
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext() : base("myDb") { }
        public DbSet<Film> Films { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Janre> Janres { get; set; }

    }
}