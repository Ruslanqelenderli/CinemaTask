using Cinema.Models;
using Cinema.Models.UserModels;
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
        public DbSet<FilmCountry> FilmCountries { get; set; }
        public DbSet<FilmJanre> FilmJanres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Seat> Seats { get; set; }




    }
}