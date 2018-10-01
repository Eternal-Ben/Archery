using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public class Challenge : BaseModel
    {
        public string Place { get; set; }

        [Required]
        public string Weapon { get; set; }

        [Required]
        [Display(Name="Début")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name ="Fin")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        [Display]
        public int ArcherCount { get; set; }

        [Display(Name ="Prix")]
        public decimal? Price { get; set; }
    }
}