using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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

        //Dabilitar borrado en cascada:
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<PropertyType> PropertyTypes { get; set; }

        public DbSet<Departament> Departaments { get; set; }

        public DbSet<Municipality> Municipalities { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public System.Data.Entity.DbSet<Taxes.Models.TaxPaer> TaxPaers { get; set; }
    }
}