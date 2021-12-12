using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BilisimOfisiTicariOtomasyon.Models.Sınıflar
{
    public class KargoTakip
    {
        [Key]
        public int kargoTakipId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(11)]
        public string kargoTakipKodu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string kargoTakipAciklama { get; set; }
        public DateTime kargoTakipTarih { get; set; }
    }
}