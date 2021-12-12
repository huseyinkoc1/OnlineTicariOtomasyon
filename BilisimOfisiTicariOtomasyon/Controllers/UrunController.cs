using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilisimOfisiTicariOtomasyon.Models.Sınıflar;
namespace BilisimOfisiTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A")]
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var urunler = from x in c.Urunlers select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.urunAd.Contains(p));
            }
            return View(urunler.ToList());
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.kategoriAd,
                                               Value = x.kategoriId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urunler p)
        {
            c.Urunlers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var deger = c.Urunlers.Find(id);
            deger.urunDurum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.kategoriAd,
                                               Value = x.kategoriId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var urundeger = c.Urunlers.Find(id);
            return View("UrunGetir", urundeger);
        }
        public ActionResult UrunGuncelle(Urunler p)
        {
            var urun = c.Urunlers.Find(p.urunlerId);
            urun.urunAlisFiyat = p.urunAlisFiyat;
            urun.urunDurum = p.urunDurum;
            urun.kategoriId = p.kategoriId;
            urun.urunMarka = p.urunMarka;
            urun.urunSatisiyat = p.urunSatisiyat;
            urun.urunStok = p.urunStok;
            urun.urunAd = p.urunAd;
            urun.urunGorsel = p.urunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {
            var degerler = c.Urunlers.ToList();
            return View(degerler);
        }
    }
}