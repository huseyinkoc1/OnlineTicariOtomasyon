using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BilisimOfisiTicariOtomasyon.Models.Sınıflar
{
    public class FaturaKalem
    {
        [Key]
        public int faturaKalemId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string faturaKalemAciklama { get; set; }
        public int faturaKalemMiktar { get; set; }
        public decimal faturaKalemBirimFiyat { get; set; }
        public decimal faturaKalemTutar { get; set; }
        public int faturaId { get; set; }
        public virtual Faturalar Faturalar { get; set; }
    }
}