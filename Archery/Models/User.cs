// Etude sur les parametres

using Archery.Views.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public abstract class User
    {
        public int ID { get; set; }

        [Required(ErrorMessage=" Le champ {0} est obligatoire. ")]// Attribut requis donc Required | on lui definit la valeur de son parametre required ErrorMessage
        [StringLength(150, ErrorMessage =" Le champ {0} doit contenir {1} caractères max.")]
        [Display(Name = "Adresse mail")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
            , ErrorMessage = "Le format n'est pas bon.")]
        public string Mail { get; set; }

        // Utilisation du HtmlHelper pour recup les info dans tout les formulaires en du MDP avec le DataType(Datatype.Password)

        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$",
            ErrorMessage = "{0} incorrect.")]
        public string Password { get; set; }

        [Display(Name = "Confirmation du mot de passe")]
        [DataType(DataType.Password)]
        //[Compare(]
        public string ConfirmedPassword { get; set; }

        // parametre d'affichage du champs
        [Display(Name = "Nom")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Prénom")]
        [Required]
        public string  FirstName { get; set; }

        [Display(Name = "Date de naissance")]
        //Parametre Date : Afin de ne recuperer uniquement la date | apport des elements au model grace aux helpers
        [DataType(DataType.Date)]
        [Required]// Attribut requis donc Required
        //[CustomValidation(DateTime, avec creeation d'une class en statique...')]
        [Age(9,ErrorMessage = "Pour le champ {0}, vous devez avoir plus de {} ans")]
        public DateTime ? BirthDate { get; set; } // ? = nullable, permet de valider le IsValid pour la bd (<?)
    }
 
}