using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taxes.Models
{
    public class DocumentType
    {
        [Key]
        public int DocumentTypeId { get; set; }

        [Required(ErrorMessage = "The field {0} is required ")]
        [Index("DocumentType_Description _Index", IsUnique = true)]
        [StringLength(30, ErrorMessage = "The field {0} can contain maximum {1} ad minimum {2} characters", MinimumLength = 1)]
        
        public string Description { get; set; }

       
    }
}