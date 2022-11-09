using System;
using System.Collections.Generic;
using System.Text;

namespace Chat
{
    class Conversation
    {
        public int id;
        public string[] members;
        public Message[] messages;
        private int msgCount = 0;
        private int memberCount = 0;
        public Conversation(int id)
        {
            this.id = id;
            this.members = new string[10];
            this.messages = new Message[100];
            this.messages[msgCount++] = new Message(this.messages.Length, "system", "Conversation start");
        }
        public void invite(User user)
        {
            this.members[memberCount++] = user.username;
        }
        public void send(Message message)
        {
            this.messages[msgCount++] = message;
        }
        public void showMsgs()
        {
            for (int i = 0; i < this.messages.Length; i++)
            {
                if(this.messages[i]!=null) Console.WriteLine(this.messages[i].author + " - " + this.messages[i].text);
            }
        }
        public void showMembers()
        {
            for (int i = 0; i < this.members.Length; i++)
            {
                if (this.members[i] != null) Console.WriteLine(this.members[i]);
            }
        }
    }
}
