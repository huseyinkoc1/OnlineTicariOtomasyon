using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilisimOfisiTicariOtomasyon.Models.Sınıflar;
namespace BilisimOfisiTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A")]
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.Urunlers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.urunMarka+" "+x.urunAd,
                                                Value = x.urunlerId.ToString()
                                            }).ToList();
            List<SelectListItem> deger2 = (from x in c.Caris.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.cariAd + " " + x.cariSoyad,
                                                Value = x.cariId.ToString()
                                            }).ToList();
            List<SelectListItem> deger3 = (from x in c.Personels.Where(x=>x.departmanId == 3).ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.personelAd + " " + x.personelSoyad,
                                                    Value = x.personelId.ToString()
                                                }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.satisHareketTarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Urunlers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.urunMarka + " " + x.urunAd,
                                               Value = x.urunlerId.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.cariAd + " " + x.cariSoyad,
                                               Value = x.cariId.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.Personels.Where(x => x.departmanId == 3).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.personelAd + " " + x.personelSoyad,
                                               Value = x.personelId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = c.SatisHarekets.Find(id);
            return View("SatisGetir", deger);
        }

        public ActionResult SatisGuncelle(SatisHareket p)
        {
            var deger = c.SatisHarekets.Find(p.satisHareketId);
            deger.cariId = p.cariId;
            deger.satisHareketAdet = p.satisHareketAdet;
            deger.satisHareketFiyat = p.satisHareketFiyat;
            deger.personelId = p.personelId;
            deger.satisHareketTarih = p.satisHareketTarih;
            deger.satisHareketToplamTutar = p.satisHareketToplamTutar;
            deger.urunlerId = p.urunlerId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.satisHareketId == id).ToList();
            return View(degerler);
        }
    }
}