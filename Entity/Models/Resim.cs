using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Resim
    {
        [Key]
        public int ResimID { get; set; }
        [Required]
        [Display(Name = "Resim Yolu")]
        public string ResimYolu { get; set; }
        public virtual Film Filmler { get; set; }
    }
}
