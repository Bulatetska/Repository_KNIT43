using System;
using System.Collections.Generic;
using System.Text;

namespace Chat
{
    public class Message
    {
        public int id;
        public string author;
        public string text;
        public Message(int id, string author, string text)
        {
            this.id = id;
            this.author = author;
            this.text = text;
        }
    }
}
