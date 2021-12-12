using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BilisimOfisiTicariOtomasyon.Models.Sınıflar
{
    public class Giderler
    {
        [Key]
        public int giderId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string giderAciklama { get; set; }
        public DateTime giderTarih { get; set; }
        public decimal giderTutar { get; set; }
    }
}