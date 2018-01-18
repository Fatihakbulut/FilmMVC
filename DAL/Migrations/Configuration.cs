namespace DAL.Migrations
{
    using Entity.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.FilmContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DAL.FilmContext context)
        {

            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole() { Name = "Admin" });
            if (context.Users.Count() == 0)
            {
                
                UserStore<Kullanici> us = new UserStore<Kullanici>(context);
                UserManager<Kullanici> um = new UserManager<Kullanici>(us);

                var admin = new Kullanici() { Email = "fatih@fatih.com", UserName = "fatih@fatih.com", KullaniciAdi = "Akbulut", telefon = "055555555", sifre = "Aa123456!",DogumTarihi="1994" } ;

                um.Create(admin, "Aa123456!");
                um.AddToRole(admin.Id, "Admin");


            }
        }
    }
}
