using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Archery.Tools
{
    public sealed class Message
    {
        // sealed, bloque l'heritage et donc empeche sa reutilisation > override (<?)
        public MessageType MessageType { get; private set; }
        public string   Text { get; private set; }
   
        public Message(MessageType messageType, string text)
        {
            MessageType = messageType;
            Text = text;
        }

    }

    public enum MessageType
    {
        SUCCESS,
        ERROR,
        ALREADYUSE, // ajout de message type pour retour mail/mdp
        RETRY
    }

}