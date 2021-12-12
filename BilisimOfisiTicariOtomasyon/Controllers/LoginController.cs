using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BilisimOfisiTicariOtomasyon.Models.Sınıflar;
namespace BilisimOfisiTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Partial1(Cari p)
        {
            p.durum = true;
            c.Caris.Add(p);
            c.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult CariLogin1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariLogin1(Cari p)
        {
            var bilgiler = c.Caris.FirstOrDefault(x => x.cariMail == p.cariMail && x.cariSifre == p.cariSifre);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.cariMail, false);
                Session["cariMail"] = bilgiler.cariMail.ToString();
                return RedirectToAction("Index","CariPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault
                (x => x.adminKullaniciAd == p.adminKullaniciAd && x.adminSifre == p.adminSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.adminKullaniciAd, false);
                Session["KullaniciAd"] = bilgiler.adminKullaniciAd.ToString();
                return RedirectToAction("Index","Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}