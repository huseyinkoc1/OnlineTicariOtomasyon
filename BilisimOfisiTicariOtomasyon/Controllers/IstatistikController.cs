using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilisimOfisiTicariOtomasyon.Models.Sınıflar;
namespace BilisimOfisiTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A")]
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Caris.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = c.Urunlers.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;

            var deger5 = c.Urunlers.Sum(x => x.urunStok).ToString();
            ViewBag.d5 = deger5;

            var deger6 = (from x in c.Urunlers select x.urunMarka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;

            var deger7 = c.Urunlers.Count(x => x.urunStok <= 10).ToString();
            ViewBag.d7 = deger7;

            var deger8 = (from x in c.Urunlers orderby x.urunSatisiyat descending select x.urunAd).FirstOrDefault().ToString();
            ViewBag.d8 = deger8;

            var deger9 = (from x in c.Urunlers orderby x.urunSatisiyat ascending select x.urunAd).FirstOrDefault().ToString();
            ViewBag.d9 = deger9;

            var deger10 = c.Urunlers.GroupBy(x => x.urunMarka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d10 = deger10;

            var deger11 = c.Urunlers.Count(x => x.urunAd == "Buzdolabı").ToString();
            ViewBag.d11 = deger11;

            var deger12 = c.Urunlers.Count(x => x.urunAd == "Laptop").ToString();
            ViewBag.d12 = deger12;

            var deger13 = c.Urunlers.Where(u => u.urunlerId == (c.SatisHarekets.GroupBy(x => x.urunlerId).OrderByDescending(z => z.Count())
                                                            .Select(y => y.Key).FirstOrDefault())).Select(k => k.urunAd).FirstOrDefault();
            ViewBag.d13 = deger13;

            var deger14 = c.SatisHarekets.Sum(x => x.satisHareketToplamTutar).ToString();
            ViewBag.d14 = deger14;


            var deger15 = c.SatisHarekets.Count(x => x.satisHareketTarih == DateTime.Today).ToString();
            ViewBag.d15 = deger15;


            var deger16 = c.SatisHarekets.Where(x => x.satisHareketTarih == DateTime.Today).Sum(y => (decimal?)y.satisHareketToplamTutar).ToString();
            //var deger16 = c.SatisHarekets.Where(x => x.satisHareketTarih == DateTime.Today).Sum(y => y.satisHareketToplamTutar).ToString();
            ViewBag.d16 = deger16;
            return View();
        }

    }
}