using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilisimOfisiTicariOtomasyon.Models.Sınıflar;
namespace BilisimOfisiTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A")]
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var kargolar = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                kargolar = kargolar.Where(y => y.kargoTakipKodu.Contains(p));
            }
            return View(kargolar.ToList());
        }


        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random rnd = new Random();

            int sayi1, sayi2, sayi3, sayi4, sayi5;

            int harf, harf2, harf3, harf4;

            sayi1 = rnd.Next(1, 9);

            sayi2 = rnd.Next(0, 9);

            sayi3 = rnd.Next(0, 9);

            sayi4 = rnd.Next(1, 9);







            harf = rnd.Next(65, 91);

            sayi5 = rnd.Next(65, 91);

            harf2 = rnd.Next(65, 91);



            harf3 = rnd.Next(65, 91);

            harf4 = rnd.Next(65, 91);

            if (harf == harf2)

            {

                harf2 = rnd.Next(65, 91);

            }

            if (harf2 == harf3)

            {

                harf3 = rnd.Next(65, 91);

            }

            if (harf3 == harf4)

            {

                harf4 = rnd.Next(65, 91);

            }

            if (sayi1 == sayi2)

            {

                sayi2 = rnd.Next(1, 9);

            }

            if (sayi2 == sayi3)

            {

                sayi3 = rnd.Next(0, 9);

            }

            if (sayi3 == sayi4)

            {

                sayi4 = rnd.Next(1, 9);

            }

            if (sayi4 == sayi5)

            {

                sayi5 = rnd.Next(0, 9);

            }



            char karakter;

            char karakter2;

            char karakter3;

            char karakter4;

            karakter = Convert.ToChar(harf);

            karakter2 = Convert.ToChar(harf2);

            karakter3 = Convert.ToChar(harf3);

            karakter4 = Convert.ToChar(harf4);



            string kod = sayi1.ToString() + sayi2.ToString() + karakter + sayi3.ToString() + sayi4.ToString() + karakter2 + sayi4.ToString() + karakter3 + sayi5.ToString() + karakter4;



            ViewBag.takip = kod;
            return View();
        }
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay d)
        {
            c.KargoDetays.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KargoTakip(string id)
        {
            
            var degerler = c.KargoTakips.Where(x => x.kargoTakipKodu == id).ToList();
            return View(degerler);
        }


    }
}