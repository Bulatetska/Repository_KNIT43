using System;

namespace Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] users = new User[3];
            Conversation[] convs = new Conversation[10];
            Console.WriteLine("newU newC listU listC invite send check");
            string input = Console.ReadLine();
            while (input != "exit")
            {
                switch (input)
                {
                    case "newU":
                        {
                            Console.Write("choose slot: ");
                            int slot = Int32.Parse(Console.ReadLine());
                            slot = slot > 2 || slot < 0 ? 2 : slot;
                            Console.Write("enter user name: ");
                            users[slot] = new User(slot, Console.ReadLine());
                            Console.WriteLine();
                            Console.WriteLine("user created");
                            break;
                        }
                    case "newC":
                        {
                            Console.Write("choose slot: ");
                            int slot = Int32.Parse(Console.ReadLine());
                            slot = slot > 9 || slot < 0 ? 9 : slot;
                            convs[slot] = new Conversation(slot);
                            Console.WriteLine();
                            Console.WriteLine("conv created");
                            break;
                        }
                    case "listU":
                        {
                            Console.WriteLine();
                            for (int i = 0; i < users.Length; i++)
                            {
                                if(users[i]!=null) Console.WriteLine(users[i].username);
                            }
                            break;
                        }
                    case "listC":
                        {
                            for (int i = 0; i < convs.Length; i++)
                            {
                                if(convs[i]!=null)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine(convs[i].id);
                                    convs[i].showMembers();
                                }
                            }
                            break;
                        }
                    case "invite":
                        {
                            Console.Write("choose conv: ");
                            int slot = Int32.Parse(Console.ReadLine());
                            slot = slot > 9 || slot < 0 ? 9 : slot;
                            Console.Write("choose user: ");
                            int user = Int32.Parse(Console.ReadLine());
                            user = user > 2 || user < 0 ? 2 : user;
                            convs[slot].invite(users[user]);
                            users[user].invited(convs[slot].id);
                            Console.WriteLine();
                            Console.WriteLine("user invited");
                            break;
                        }
                    case "send":
                        {
                            Console.Write("choose conv: ");
                            int slot = Int32.Parse(Console.ReadLine());
                            slot = slot > 9 || slot < 0 ? 9 : slot;
                            Console.Write("choose user: ");
                            int user = Int32.Parse(Console.ReadLine());
                            user = user > 2 || user < 0 ? 2 : user;
                            Console.Write("message: ");
                            Message msg = new Message(convs[slot].messages.Length, users[user].username, Console.ReadLine());
                            convs[slot].send(msg);
                            Console.WriteLine();
                            Console.WriteLine("msg sent");
                            break;
                        }
                    case "check":
                        {
                            Console.Write("choose user: ");
                            int user = Int32.Parse(Console.ReadLine());
                            user = user > 2 || user < 0 ? 2 : user;
                            for(int i=0;i<users[user].convs.Length;i++)
                            {
                                if(users[user].convs[i]!=-1)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine(convs[users[user].convs[i]].id);
                                    convs[users[user].convs[i]].showMsgs();
                                }
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("wrong command");
                            break;
                        }
                }
                Console.WriteLine();
                Console.WriteLine("newU newC listU listC invite send check");
                input = Console.ReadLine();
            }
        }
    }
}
