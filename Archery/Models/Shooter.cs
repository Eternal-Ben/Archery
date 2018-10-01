using System;
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
        public int ChallengeID { get; set; }

        [ForeignKey("ChallengeID")]
        public Challenge Challenge  { get; set; }

        [Required]
        [Display(Name ="Arme")]
        public int WeaponID { get; set; }

        [ForeignKey("WeaponId")]
        public Weapon Weapon { get; set; }

        [ForeignKey("Archer")]
        public  int ArcherID { get; set; }

        [ForeignKey("ArcherId")]
        public Archer Archer { get; set; }

        public DateTime? Departure { get; set; }
    }
}