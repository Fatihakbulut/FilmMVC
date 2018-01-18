using Entity.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FilmContext: IdentityDbContext<Kullanici>
    {
        public static DAL.FilmContext db;

        public FilmContext() : base("DefaultConnection")
        {

        }
        public virtual DbSet<Film> Filmler { get; set; }
        public virtual DbSet<Resim> Resimler { get; set; }
        public virtual DbSet<Video> Videolar { get; set; }
        public virtual DbSet<Oylama> Oylar { get; set; }
        //public virtual DbSet<Kullanici> Kullanicilar { get; set; }
    }
}
