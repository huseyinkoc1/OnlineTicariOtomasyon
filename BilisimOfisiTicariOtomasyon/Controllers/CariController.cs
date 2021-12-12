using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilisimOfisiTicariOtomasyon.Models.Sınıflar;
namespace BilisimOfisiTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A")]
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Caris.Where(x=>x.durum==true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniCari(Cari p)
        {
            p.durum = true;
            c.Caris.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var dp = c.Caris.Find(id);
            dp.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var cari = c.Caris.Find(id);
            return View("CariGetir", cari);
        }
        public ActionResult CariGuncelle(Cari p)
        {
            if(!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = c.Caris.Find(p.cariId);
            cari.cariAd = p.cariAd;
            cari.cariSoyad = p.cariSoyad;
            cari.cariSehir = p.cariSehir;
            cari.cariMail = p.cariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.cariId == id).ToList();
            var per = c.Caris.Where(x => x.cariId == id).Select(y => y.cariAd + " " + y.cariSoyad).FirstOrDefault();
            ViewBag.cari = per;
            return View(degerler);
        }
    }
}