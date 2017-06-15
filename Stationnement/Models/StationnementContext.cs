using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Stationnement.Models
{
    public class StationnementContext  : DbContext
    {
        public StationnementContext() : base ("stationnement2")
        { }


        public DbSet<Inscription> Inscriptions { get; set; }
    }
}