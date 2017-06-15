using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stationnement.Models
{
    public class Inscription
    {
        public int InscriptionID { get; set; }
        [StringLength(50)]
        public string Nom { get; set; }
        [MaxLength(75)]
        public string Courriel { get; set; }
        public int Annees { get; set; }
        
        public string Pays { get; set; }


    }
}