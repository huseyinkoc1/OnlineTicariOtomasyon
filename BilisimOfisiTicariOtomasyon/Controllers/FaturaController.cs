using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilisimOfisiTicariOtomasyon.Models.Sınıflar;
namespace BilisimOfisiTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A")]
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir", fatura);
        }

        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var ft = c.Faturalars.Find(f.faturaId);
            ft.faturaSeriNo = f.faturaSeriNo;
            ft.faturaSıraNo = f.faturaSıraNo;
            ft.faturaSaat = f.faturaSaat;
            ft.faturaTarih = f.faturaTarih;
            ft.faturaTeslimAlan = f.faturaTeslimAlan;
            ft.faturaTeslimEden = f.faturaTeslimEden;
            ft.faturaVergiDairesi = f.faturaVergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.faturaId == id).ToList();
            var dp = c.Faturalars.Where(x => x.faturaId == id).Select(y => y.faturaSeriNo + y.faturaSıraNo).FirstOrDefault();
            var dpp = c.Faturalars.Where(x => x.faturaId == id).Select(y => y.faturaId).FirstOrDefault();
            ViewBag.d = dp;
            ViewBag.id = dpp;
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }


        public ActionResult YeniKalem(FaturaKalem p ,int id)
        {
            var fatura = c.Faturalars.Where(x => x.faturaId == id).Select(y => y.faturaId).FirstOrDefault();

            p.faturaId = fatura;
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("/FaturaDetay/"+fatura);
        }

        public ActionResult Dinamik()
        {
            Class4 cs = new Class4();
            cs.deger1 = c.Faturalars.ToList();
            cs.deger2 = c.FaturaKalems.ToList();
            return View(cs);
        }
        public ActionResult FaturaKaydet(string FaturaSeriNo, string FaturaSıraNo, DateTime faturaTarih, string faturaVergiDairesi, string faturaSaat, string faturaTeslimEden, string faturaTeslimAlan, string faturaToplam, FaturaKalem[] kalemler)
        {
            Faturalar f = new Faturalar();
            f.faturaSeriNo = FaturaSeriNo;
            f.faturaSıraNo = FaturaSıraNo;
            f.faturaTarih = faturaTarih;
            f.faturaVergiDairesi = faturaVergiDairesi;
            f.faturaSaat = faturaSaat;
            f.faturaTeslimEden = faturaTeslimEden;
            f.faturaTeslimAlan = faturaTeslimAlan;
            f.faturaToplam = decimal.Parse(faturaToplam);
            c.Faturalars.Add(f);
            foreach (var x in kalemler)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.faturaKalemAciklama = x.faturaKalemAciklama;
                fk.faturaKalemBirimFiyat = x.faturaKalemBirimFiyat;
                fk.faturaId = x.faturaKalemId;
                fk.faturaKalemMiktar = x.faturaKalemMiktar;
                fk.faturaKalemTutar = x.faturaKalemTutar;
                c.FaturaKalems.Add(fk);
            }
            c.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}