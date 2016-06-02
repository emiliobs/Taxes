using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Taxes.Models
{
    public class TaxesContext : DbContext
    {
        public TaxesContext() : base("DefaultConnection")
        {
            
        }

        protected override void Dispose(bool disposing)
        {
           
            base.Dispose(disposing);
        }

        public DbSet<PropertyType> PropertyTypes { get; set; }

        public DbSet<Departament> Departaments { get; set; }

        public DbSet<Municipality> Municipalities { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }
    }
}