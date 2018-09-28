using Archery.Data;
using Archery.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
//using System.Web.Services.Description;
using static Archery.Tools.Message;

namespace Archery.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ArcheryDbContext db = new ArcheryDbContext();

        /// <summary>
        /// Affiche un message dans le Layout success ou ereur avec ou
        /// </summary>
        /// <param name="text">le text a afficher</param>
        /// <param name="type">le type de message</param>
        public void Display(string text, MessageType type = MessageType.SUCCESS)
        {// les paramtres type et txt sont dans l'ordre dans le lequel il se presente dans la methode
            var m = new Message (type, text);
            TempData["MESSAGE"] = m;
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        protected override void Dispose(bool disposing) // l.13 pour eviter l'empilement des donner et saturer la connection
        {
            base.Dispose(disposing);
            if (!disposing)
                this.db.Dispose();
        }

    }
}