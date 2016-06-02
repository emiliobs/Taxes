using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes.Models
{
   public class PropertyType
    {
        [Key]
        public int PropertyTypeId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Index("Property_TypeDescription_Index", IsUnique = true)]
        [StringLength(30, ErrorMessage ="The field {0} can contain maximum {1} ad minnimum {2} characters", MinimumLength = 1)]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

    }
}
