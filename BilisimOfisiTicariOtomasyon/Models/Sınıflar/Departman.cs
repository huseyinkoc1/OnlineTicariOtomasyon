using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BilisimOfisiTicariOtomasyon.Models.Sınıflar
{
    public class Departman
    {
        [Key]
        public int departmanId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string departmanAd { get; set; }
        public bool durum { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}