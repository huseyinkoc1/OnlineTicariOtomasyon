using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BilisimOfisiTicariOtomasyon.Models.Sınıflar
{
    public class Cari
    {
        [Key]
        public int cariId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En Fazla 30 Karakter Yazabilirsiniz.")]
        public string cariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu Alan Boş Geçilemez.")]
        public string cariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string cariSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string cariMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string cariSifre { get; set; }

        public bool durum { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}