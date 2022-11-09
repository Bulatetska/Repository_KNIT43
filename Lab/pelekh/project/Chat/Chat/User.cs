using System;
using System.Collections.Generic;
using System.Text;

namespace Chat
{
    class User
    {
        public int id;
        public string username;
        public int[] convs = new int[10];
        private int convsCount = 0;
        public User(int id, string username)
        {
            this.id = id;
            this.username = username;
            for(int i=0;i<10;i++)
            {
                this.convs[i] = -1;
            }
        }
        public void invited(int id)
        {
            this.convs[convsCount++] = id;
        }
    }
}
