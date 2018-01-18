using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Oyuncu
    {
        [Key]
        public int OyuncuID { get; set; }
        public string OyuncuAdi { get; set; }
    }
}
