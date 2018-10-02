using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Models
{
    public class Tournament : BaseModel
    {
        [Required]
        [Display(Name ="Nom")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name="Armes")]
        public ICollection <Weapon> Weapons {get;set;}

        [Display(Name ="Tireur")]
        public ICollection <Shooter> Shooters { get; set; }

        [Required]
        [Display(Name="Début")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name ="Fin")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        [Display(Name ="Nombre d'archer maximum")]
        public int ArcherCount { get; set; }

        [Display(Name ="Prix")]
        public decimal? Price { get; set; }

        [Display(Name = "Description")]
        [AllowHtml] // permet le passage des données en html, uniquement
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}