using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BilisimOfisiTicariOtomasyon.Models.Sınıflar
{
    public class SatisHareket
    {
        [Key]
        public int satisHareketId { get; set; }
        //urun
        //cari
        //personel
        public DateTime satisHareketTarih { get; set; }
        public int satisHareketAdet { get; set; }
        public decimal satisHareketFiyat { get; set; }
        public decimal satisHareketToplamTutar { get; set; }
        
        public int urunlerId { get; set; }
        public int cariId { get; set; }
        public int personelId { get; set; }

        public virtual Urunler Urunler { get; set; }
        public virtual Cari Cari { get; set; }
        public virtual Personel Personel { get; set; }

    }
}