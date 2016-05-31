using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

    }
}
