using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Views.Validator
{
    public class Age : ValidationAttribute
    {
        public  int MinimumAge { get; private set; }

        public Age(int minimumAge) // Constructeur de la class Age qui herite de la class ValidationAttribute
        {
            this.MinimumAge = minimumAge;
        }

        public override bool IsValid(object value)
        {
            if (value is DateTime)
            {
                return DateTime.Now.AddYears(-MinimumAge) <= (DateTime)value;
            }
            else
                throw new ArgumentException("Le type doit être un DateTime"); // retour message error
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(this.ErrorMessage, name, this.MinimumAge.ToString());
        }
    }
}