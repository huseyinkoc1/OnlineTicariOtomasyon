using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BilisimOfisiTicariOtomasyon.Models.Sınıflar
{
    public class KargoDetay
    {
        [Key]
        public int kargoId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string kargoAciklama { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(11)]
        public string kargoTakipKodu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string kargoPersonel { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string kargoMusteri { get; set; }
        public DateTime kargoTarih { get; set; }
    }
}