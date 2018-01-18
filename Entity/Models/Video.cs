using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Video
    {
        [Key]
        public int VideoID { get; set; }
        [Required]
        [Display(Name = "Video-URL")]
        public string VideoURL { get; set; }
        public virtual Film Filmler { get; set; }
    }
}
