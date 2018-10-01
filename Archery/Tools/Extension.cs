using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace Archery.Tools
{
    public static class Password
    {// Creation de la methode d'extension grace au "this" avant le string
        public static string HashMD5 (this string value)
        {// on fournit un tableau de bytes pour traiter la demande de hashage
            byte[] valueBytes = System.Text.Encoding.Default.GetBytes(value);

            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] calcul = provider.ComputeHash(valueBytes);

            string result = "";
            foreach(byte b in calcul)
            {

                if (b < 16)
                    result += "0" + b.ToString("x");
                else
                    result += b.ToString("x");
            }
            return result;
        }
    }
}