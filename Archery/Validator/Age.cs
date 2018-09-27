using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Views.Validator
{
    [AttributeUsage(AttributeTargets.Property)] // Sinon declarer la class en Sealed
    public class Age : ValidationAttribute
    {
        public int MinimumAge { get; private set; }
        public int? maximumAge;


        public int MaximumAge
        {
            get { return (int)maximumAge; } // casting de données ?
            set { maximumAge = value; }
        }

        public Age(int minimumAge) // Constructeur de la class Age qui herite de la class ValidationAttribute
        {
            this.MinimumAge = minimumAge;
        }

        public override bool IsValid(object value)
        {
            if (value is DateTime);

            {
                if (value is DateTime)
                {
                    if (this.maximumAge == null)
                        return DateTime.Now.AddYears(-this.MinimumAge) >= (DateTime)value;
                    else
                        return DateTime.Now.AddYears(-this.MinimumAge) >= (DateTime)value
                            && ((DateTime)value).AddYears(this.MaximumAge) >= DateTime.Now;
                }
                else
                throw new ArgumentException("Le type doit être un DateTime"); // retour message error
            }
        }

        public override string FormatErrorMessage(string name)
        {
            if (this.maximumAge == null)
                return string.Format(this.ErrorMessage, name, this.MinimumAge.ToString());
            return string.Format(this.ErrorMessage, name, this.MinimumAge.ToString(), this.MaximumAge.ToString());
        }
    }
}