using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public class Info
    {
        // Le mapping de type va être fait par le conroller, donc il faut creer une dans notre controlleur Home pour se cas <<???? WTF ?
        public string DevName { get; set; }
        public DateTime CreateDate { get; set; }
        public string ContactMail { get; set; }

    }
}