using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Taxes.Models;

namespace Taxes.Models
{
    [NotMapped]
    public class DepartmentView : Departament
    {
        public List <Municipality> MunicipalityList { get; set; }
    }
}