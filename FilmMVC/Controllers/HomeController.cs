using BLL;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            FilmRepository frep = new FilmRepository();
            return View(frep.GetAll());
        }

        public ActionResult Slider()
        {           
            return View();
        }

        FilmRepository frep = new FilmRepository();
        public ActionResult YabancıFilmler()
        {           
            return View(frep.YabancıFilmler());
        }

        public ActionResult Detay(int id)
        {
            return View(new FilmRepository().GetById(id));
        }

        public ActionResult TurkceFilmler()
        {                     
            return View(frep.TurkceFilmler());
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateFilm()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public ActionResult CreateFilm(Film newFilm)
        {
            FilmRepository frep = new FilmRepository();
            frep.Insert(newFilm);
            return RedirectToAction("CreateResim");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateResim()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateResim(Resim yeniResim, HttpPostedFileBase resimm)
        {
            var klasor = Server.MapPath("/Content/Upload/");
            if (resimm != null && resimm.ContentLength != 0)
            {
                if (resimm.ContentLength > 2 * 1024 * 1024)
                    ModelState.AddModelError(null, "Resim boyutu 2 Mb'den büyük olamaz.");
                else
                {
                    try
                    {
                        FileInfo fi = new FileInfo(resimm.FileName);
                        var dosyaAdi = fi.Name;
                        resimm.SaveAs(klasor + dosyaAdi);
                        yeniResim.ResimYolu = dosyaAdi;
                    }
                    catch { }
                }
                if (ModelState.IsValid)
                    new ResimRepository().Insert(yeniResim);
            }
            return RedirectToAction("CreateVideo");
        }

        public JsonResult FilmSil(int id)
        {
            try
            {
                ResimRepository frep = new ResimRepository();
                frep.Delete(id);
                return Json("Film Silindi.");
            }

            catch (Exception ex)
            {
                return Json("Bir hata oluştu." + ex.Message);
            }
        }

        //Configuration Roles ekleme.
        public ActionResult CreateKullanici()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateVideo()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateVideo(Video yeniVideo)
        {
            VideoRepository vrep = new VideoRepository();
            vrep.Insert(yeniVideo);
            return View();
        }

        public JsonResult FilmOylama(int id, int oy)
        {
            try
            {
                if (Session["HasVoted_" + id] == null || (bool)Session["HasVoted_" + id] != true) //Daha önceden oy vermediyse
                {
                    FilmRepository frep = new FilmRepository();
                    OyRepository orep = new OyRepository();
                    Oylama o = new Oylama();
                    Film secilen = frep.GetById(id);
                    if (secilen.ToplamOy != 0)
                    {
                        o.FilmAdi = secilen.FilmBaslik;
                        o.OyVerenKisi = User.Identity.Name;
                        o.VerdigiOy = oy;
                        secilen.ToplamOy = secilen.ToplamOy + oy;
                        orep.Insert(o);
                    }
                    else
                    {
                        o.FilmAdi = secilen.FilmBaslik;
                        o.OyVerenKisi = User.Identity.Name;
                        o.VerdigiOy = oy;
                        secilen.ToplamOy = oy;
                        orep.Insert(o);
                    }
                    frep.Update(secilen);
                    Session["HasVoted_" + id] = true;
                    return Json("Oy Verdiğiniz için Teşekkürler!");

                }
                else
                    return Json("Tekrar Oy Kullanamazsınız!");
            }

            catch (Exception ex)
            {
                return Json("Bir Hata Oluştu." + ex.Message);
            }
        }
    }
}