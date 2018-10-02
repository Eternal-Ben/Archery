// Etude sur les parametres

using Archery.Tools;
using Archery.Views.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public abstract class User
    {
        public int ID { get; set; }

        [Display(Name = "Adresse mail")]
        [Required(ErrorMessage=" Le champ {0} est obligatoire. ")]// Attribut requis donc Required | on lui definit la valeur de son parametre required ErrorMessage
        [StringLength(150, ErrorMessage =" Le champ {0} doit contenir {1} caractères max.")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
            , ErrorMessage = "Le format n'est pas bon.")]
        [Index(IsUnique = true)]
        [Email(ErrorMessage = "Mail déjà existant, veuillez en donner un nouveau mail pour votre enregistrement")]
        public string Mail { get; set; }

        // Utilisation du HtmlHelper pour recup les info dans tout les formulaires en du MDP avec le DataType(Datatype.Password)


        [Display(Name = "Mot de passe")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$",
            ErrorMessage = "{0} incorrect.")]
        [StringLength(150)]
        public string Password { get; set; }


        [Display(Name = "Confirmation du mot de passe")]
        [NotMapped]
        [Compare("Password", ErrorMessage = "La confirmation n'est pas bonne.")]
        [DataType(DataType.Password)]
        //[Compare(]
        public string ConfirmedPassword { get; set; }


        // parametre d'affichage du champs
        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [StringLength(50)]
        public string LastName { get; set; }


        [Display(Name = "Prénom")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [StringLength(50)]
        public string  FirstName { get; set; }


        [Display(Name = "Date de naissance")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        //Parametre Date : Afin de ne recuperer uniquement la date | apport des elements au model grace aux helpers
        [DataType(DataType.Date)]
        //[nom d'un attribut]
        [Age(9, MaximumAge = 90, ErrorMessage = "Pour le champ {0}, vous devez avoir plus de {1} ans")] // Class utilisé sous forme d'attribut. propritée de l'objet Age de la class Age
        [Column(TypeName = "datetime2")]
        public DateTime ? BirthDate { get; set; } // ? = nullable, l'objet peut etre à null (<?)
    }
 
}