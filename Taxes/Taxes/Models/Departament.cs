using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes.Models
{
  public  class Departament
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "The field {0} is required ")]
        [Index("Departament_Name_Index", IsUnique =  true)]
        [StringLength(30, ErrorMessage = "The field {0} can contain maximum {1} ad minimum {2} characters", MinimumLength = 1)]
        [Display(Name="Department Name")]
        public string Name { get; set; }

        //lado uno de la relacion(un departamento tiene muchos muicipios)
        public virtual  ICollection<Municipality> Municipalities { get; set; }

        public virtual ICollection<TaxPaer> TaxPaers { get; set; }

    }
}
