using DAL;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FilmRepository : BaseRepo<Film>
    {
        FilmContext db = new FilmContext();
        public List<Film> TurkceFilmler()
        {
            return db.Filmler.Where(x => x.Dil == "Türkçe").ToList();
        }

        public List<Film> YabancıFilmler()
        {
            return db.Filmler.Where(x => x.Dil != "Türkçe").ToList();
        }
    }

    public class ResimRepository : BaseRepo<Resim> { }
    public class OyRepository:BaseRepo<Oylama> { }
    public class VideoRepository : BaseRepo<Video> { }
    public class KullaniciRepository : BaseRepo<Kullanici> { }

}
