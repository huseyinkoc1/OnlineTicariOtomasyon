using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilisimOfisiTicariOtomasyon.Models.Sınıflar;
namespace BilisimOfisiTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A")]
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = c.Urunlers.Where(x => x.urunlerId == 1).ToList();
            cs.Deger2 = c.Detays.Where(y => y.detayId == 1).ToList();
            return View(cs);
        }
    }
}