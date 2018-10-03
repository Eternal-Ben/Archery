using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Areas.BackOffice.Models
{
    public class AuthentificationLoginViewModel
    {   
        [Display (Name="Login")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        public string Mail { get; set; }

        [Display (Name="Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        public string Password { get; set; }
    }
}