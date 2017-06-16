using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stationnement.Models
{
    public class BlogViewModel
    {
        public int Annee { get; set; }
        public int Mois { get; set; }
        public int Jour{ get; set; }
        public string Description { get; set; }
    }
}