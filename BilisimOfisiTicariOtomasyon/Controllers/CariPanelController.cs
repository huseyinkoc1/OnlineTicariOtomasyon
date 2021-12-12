﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BilisimOfisiTicariOtomasyon.Models.Sınıflar;
namespace BilisimOfisiTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["cariMail"];
            var degerler = c.Caris.FirstOrDefault(x => x.cariMail == mail);
            ViewBag.m = mail;
            return View(degerler);
        }
        [Authorize]
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["cariMail"];
            var id = c.Caris.Where(x => x.cariMail == mail.ToString()).Select(y=>y.cariId).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.cariId == id).ToList();
            return View(degerler);
        }

        [Authorize]
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Alici == mail).OrderByDescending(x => x.MesajID).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        [Authorize]
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Gonderici == mail).OrderByDescending(z => z.MesajID).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        [Authorize]
        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Mesajlars.Where(x => x.MesajID == id).ToList();
            var mail = (string)Session["CariMail"];
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(degerler);
        }
        [Authorize]
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["CariMail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gonderici = mail;
            c.Mesajlars.Add(m);
            c.SaveChanges();
            return View();
        }
        public ActionResult KargoTakip(string p)
        {
          
                var k = from x in c.KargoDetays select x;
                k = k.Where(y => y.kargoTakipKodu.Equals(p));
                return View(k.ToList());
            
            
        }
        public ActionResult CariKargoTakip(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.kargoTakipKodu == id).ToList();
            return View(degerler);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult Partial1()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Caris.Where(x => x.cariMail == mail).Select(y => y.cariId).FirstOrDefault();
            var caribul = c.Caris.Find(id);
            return PartialView("Partial1", caribul);
        }
        public PartialViewResult Partial2()
        {
            var veriler = c.Mesajlars.Where(x => x.Gonderici == "admin").ToList();
            return PartialView(veriler);
        }
        public ActionResult CariBilgiGuncelle(Cari cr)
        {
            var cari = c.Caris.Find(cr.cariId);
            cari.cariAd = cr.cariAd;
            cari.cariSoyad = cr.cariSoyad;
            cari.cariSifre = cr.cariSifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}