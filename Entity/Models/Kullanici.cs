using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Kullanici:IdentityUser
    {   
        public string KullaniciAdi { get; set; }
        
        public string sifre { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        public string telefon { get; set; }
        
        [DataType(DataType.DateTime)]
        public string DogumTarihi { get; set; }
    }
}
