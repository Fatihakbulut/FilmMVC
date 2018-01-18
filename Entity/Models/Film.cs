using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Film
    {
        [Key]

        public int FilmID { get; set; }
        [Required]
        [Display(Name = "Film Başlık")]
        public string FilmBaslik { get; set; }
        [Required]
        [Display(Name = "Film İçerik")]
        public string FilmIcerik { get; set; }
        [Required]
        [Display(Name = "Film Tür")]
        public string FilmTur { get; set; }
        [Required]
        [Display(Name = "Dil")]
        public string Dil { get; set; }
        [Required]
        [Display(Name = "Yönetmen Adı")]
        public string YonetmenAdi { get; set; }
        [Required]
        [Display(Name = "IMDB Puanı")]
        public double IMDBPuan { get; set; }
        [Required]
        [Display(Name = "Yayınlanma Tarihi")]
        public DateTime YayinlanmaTarihi { get; set; }
        public int ToplamOy { get; set; }

        public virtual List<Resim> Resimler { get; set; }
        public virtual List<Video> Fragman { get; set; } = new List<Video>();
        //public Video Fragman { get; set; }
        // public List<Oyuncu> Oyuncular { get; set; }


        public Film()
        {
            Resimler = new List<Resim>();
        }
    }
}
