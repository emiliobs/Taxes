using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taxes.Models
{
    public class Municipality
    {
        [Key]
        public int MunicipalityId { get; set; }

        public int DepartmentId { get; set; }

        [Required(ErrorMessage ="The field is required.")]
        [Index("Municipality_Name_Index", IsUnique = true)]
        [StringLength(30, ErrorMessage = "The field {0} ca contain maximum {1} and minimum {2} characters", MinimumLength = 1)]
        [Display(Name= "Municipality Name")]
        public string Name { get; set; }

        //relacion con el departament(un municipio tiene un departamento) lado varios de la relación:
        public virtual Departament Departament { get; set; }

        public virtual ICollection<TaxPaer> TaxPaers { get; set; }




    }
}