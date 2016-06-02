﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taxes.Models
{
    public class TaxPaer
    {
        [Key]
        public int TaxPaerId { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(30, ErrorMessage = "The field {0} can contain maximum {1} annd minnimum {2} characters", MinimumLength =2)]
        [Display(Name = "First Name")]
        public string FirsName { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(30, ErrorMessage = "The field {0} can contain maximum {1} annd minnimum {2} characters", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(50, ErrorMessage = "The field {0} can contain maximum {1} annd minnimum {2} characters", MinimumLength = 7)]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        [Index("TaxPaer_ UserName_Idex", IsUnique = true)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(80, ErrorMessage = "The field {0} can contain maximum {1} annd minnimum {2} characters", MinimumLength = 7)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [StringLength(80, ErrorMessage = "The field {0} can contain maximum {1} annd minnimum {2} characters", MinimumLength = 5)]
        public string Address { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        public int MunicipalityId { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        public int DocumentTypeId { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(20, ErrorMessage = "The field {0} can contain maximum {1} annd minnimum {2} characters", MinimumLength = 5)]
        [Index("TaxPaer_Document_Index", IsUnique = true)]
        public string Document { get; set; }

        //lado varios de la relación:
        public virtual Departament Departament { get; set; }
        public virtual Municipality Municipality { get; set; }
        public virtual DocumentType DocumentType { get; set; }

    }
}