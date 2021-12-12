using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BilisimOfisiTicariOtomasyon.Models.Sınıflar
{
    public class Personel
    {
        [Key]
        public int personelId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string personelAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]

        public string personelSoyad { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string personelGorsel { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string personelTelefon { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string personelAdres { get; set; }


        public ICollection<SatisHareket> SatisHarekets { get; set; }
        public int departmanId { get; set; }
        public virtual Departman Departman { get; set; }
    }
}