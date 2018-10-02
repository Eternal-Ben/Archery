﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public class Shooter : BaseModel
    {
        [Required]
        [Display(Name ="Tournoi")]
        public int TournamentID { get; set; }

        [ForeignKey("TournamentID")]
        public Tournament Tournament  { get; set; }

        [Required]
        [Display(Name ="Arme")]
        public int WeaponID { get; set; }

        [ForeignKey("WeaponId")]
        public Weapon Weapon { get; set; }

        [Required]
        [ForeignKey("Archer")]
        public  int ArcherID { get; set; }

        [ForeignKey("ArcherId")]
        public Archer Archer { get; set; }

        [Display(Name ="Départ")]
        public DateTime? Departure { get; set; }
    }
}