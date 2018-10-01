using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public class Weapon :BaseModel
    {// mise en place des attribues
            [Required]
            [Display(Name = "Nom de l'arc")]
            public string Name { get; set; }

        // relation many to many donc une clé et on regarde dans la collection les types d'armes possible
            public ICollection<Challenge> Challenges { get; set; }
            
}