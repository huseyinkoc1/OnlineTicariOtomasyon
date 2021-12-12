using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BilisimOfisiTicariOtomasyon.Models.Sınıflar
{
    public class Admin
    {
        [Key]
        public int adminId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string adminKullaniciAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string adminSifre { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string adminYetki { get; set; }
    }
}