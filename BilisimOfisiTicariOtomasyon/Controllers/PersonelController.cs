using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilisimOfisiTicariOtomasyon.Models.Sınıflar;
namespace BilisimOfisiTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A")]
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.Where(x=>x.durum==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.departmanAd,
                                               Value = x.departmanId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.Where(x => x.durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.departmanAd,
                                               Value = x.departmanId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var prs = c.Personels.Find(id);
            return View("PersonelGetir",prs);
        }

        public ActionResult PersonelGuncelle(Personel p)
        {
            var prsn = c.Personels.Find(p.personelId);
            prsn.personelAd = p.personelAd;
            prsn.personelSoyad = p.personelSoyad;
            prsn.personelGorsel = p.personelGorsel;
            prsn.departmanId = p.departmanId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelListe()
        {
            var personeller = c.Personels.ToList();
            return View(personeller);
        }
    }
}