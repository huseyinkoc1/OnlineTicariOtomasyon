using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilisimOfisiTicariOtomasyon.Models.Sınıflar;
namespace BilisimOfisiTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A")]
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x=>x.durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var dp = c.Departmans.Find(id);
            dp.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dp = c.Departmans.Find(id);
            return View("DepartmanGetir",dp);
        }
        public ActionResult DepartmanGuncelle(Departman p)
        {
            var dp = c.Departmans.Find(p.departmanId);
            dp.departmanAd = p.departmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.departmanId == id).ToList();
            var dp = c.Departmans.Where(x => x.departmanId == id).Select(y => y.departmanAd).FirstOrDefault();
            ViewBag.d = dp;
            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.personelId == id).ToList();
            var per = c.Personels.Where(x => x.personelId == id).Select(y => y.personelAd +" "+ y.personelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }

    }
}