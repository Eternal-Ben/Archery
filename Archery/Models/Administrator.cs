using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    //public sealed class Administrator : SEALED > Fin de l'heritage, celle l'heritage du parent | confirmer la definition

    public class Administrator : User
    {
        // sachant qu'il y a un heritage sur le model User qui recupère deja ses attributs que l'on ne va pas reecrir, alors on cree un ViewModel
    }
}