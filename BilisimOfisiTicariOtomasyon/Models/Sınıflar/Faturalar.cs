using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BilisimOfisiTicariOtomasyon.Models.Sınıflar
{
    public class Faturalar
    {
        [Key]
        public int faturaId { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(2, ErrorMessage = "En Fazla 2 Karakter Yazabilirsiniz.")]
        public string faturaSeriNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string faturaSıraNo { get; set; }

        public DateTime faturaTarih { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string faturaVergiDairesi { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string faturaSaat { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string faturaTeslimAlan { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string faturaTeslimEden { get; set; }

        public decimal faturaToplam { get; set; }

        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}