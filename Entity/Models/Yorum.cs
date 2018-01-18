using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Yorum
    {
        [Key]
        public int YorumID { get; set; }
        [Display(Name = "Yapılan Yorum")]
        public string YapılanYorum { get; set; }
        [Display(Name = "Yorum Yapan Kişi")]
        public string YorumYapanKisi { get; set; }
        [Display(Name = "Yorum Yapılan Film")]
        public string FilmAdi { get; set; }
    }
}
