using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Oylama
    {
        [Key]
        public int OylamaID { get; set; }
        [Display(Name ="Oy Veren Kişi")]
        public string OyVerenKisi { get; set; }
        [Display(Name = "Oylama Tarihi")]
        public DateTime OylamaTarihi { get; set; }
        [Display(Name = "Verdiği Oy")]
        public int VerdigiOy { get; set; }
        [Display(Name = "Oy Verilen Film")]
        public string FilmAdi { get; set; }
        public Oylama()
        {
            OylamaTarihi =DateTime.Today;
        }
    }
}
