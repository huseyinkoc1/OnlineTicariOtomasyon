using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BilisimOfisiTicariOtomasyon.Models.Sınıflar
{
    public class Urunler
    {
        [Key]
        public int urunlerId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string urunAd  { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string urunMarka { get; set; }
        public short urunStok { get; set; }
        public decimal urunAlisFiyat { get; set; }
        public decimal urunSatisiyat { get; set; }
        public bool urunDurum { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string urunGorsel { get; set; }

        public int kategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
        
    }
}