
using System.Net;
using System.Net.Sockets;

namespace tester
{
    public class Program
    {

        static class roomlist {
            public static List<ChatRoom> Roomlist = new List<ChatRoom>();
        }

        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipend=new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            server.Bind(ipend);
            while (true)
            {
                server.Listen(0);
                Socket client = server.Accept();
                Console.WriteLine("We got new client!\n");
                Thread clientThread = new Thread(() => ClientConnection(client));

                try
                {
                    clientThread.Start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        static void ClientConnection(Socket client)
        {
            byte[] buffer = new byte[client.ReceiveBufferSize];
            User user= new User(roomlist.Roomlist);
            while (true)
            {
                int read = client.Receive(buffer);
                byte[] data = new byte[read];
                Array.Copy(buffer, data, read);
                string p = System.Text.Encoding.UTF8.GetString(data);
                switch (p) {
                    case "a":
                        Console.WriteLine("client try to login!\n");
                        read=client.Receive(buffer);
                        data = new byte[read];
                        Array.Copy(buffer, data, read);
                        string Name, password;
                        string q=System.Text.Encoding.UTF8.GetString(data);

                        Name = q.Substring(0, q.IndexOf(' '));

                        password = q.Substring(q.IndexOf(' ') + 1);
                        user.setname(Name);
                        Console.WriteLine(Name+"\n");
                        string a = "T";
                        client.Send(System.Text.Encoding.UTF8.GetBytes(a));
                        Console.WriteLine("client try to login!\n");
                        break;
                    case "b":
                        Console.WriteLine("client try to register!\n");
                        read=client.Receive(buffer);
                        data = new byte[read];
                        Array.Copy(buffer, data, read);
                        string rest;
                        q = System.Text.Encoding.UTF8.GetString(data);
                        Name = q.Substring(0, p.IndexOf(' '));
                        rest = q.Substring(p.IndexOf(' ') + 1);
                        user.setname(Name);
                        string b = "T";
                        client.Send(System.Text.Encoding.UTF8.GetBytes(b));
                        break;
                    case "c":
                        Console.WriteLine("client try to list joined chat room!\n");
                        List<ChatRoom> list = user.getjoined();
                        int c = list.Count;
                        
                        client.Send(System.Text.Encoding.UTF8.GetBytes(Convert.ToString(c)));
                        Thread.Sleep(1);
                        foreach (ChatRoom room in list)
                        {
                            client.Send(System.Text.Encoding.UTF8.GetBytes(room.getroomName()+" "+room.getcid()));
                        }
                        break;
                    case "d":
                        Console.WriteLine("client try to list avaliable chat room!\n");
                        list = user.getnotjoined();
                        c = list.Count;
                        Console.WriteLine(c);
                        client.Send(System.Text.Encoding.UTF8.GetBytes(Convert.ToString(c)));
                        Thread.Sleep(1);
                        foreach (ChatRoom room in list)
                        {
                            client.Send(System.Text.Encoding.UTF8.GetBytes(room.getroomName() + " " + room.getcid()));
                        }
                        break;
                    case "e":
                        Console.WriteLine("client try to receive message!\n");
                        read = client.Receive(buffer);
                        Console.WriteLine("We got chat id!\n");
                        data = new byte[read];
                        Array.Copy(buffer, data, read);
                        string chatid=System.Text.Encoding.UTF8.GetString(data);
                        foreach (ChatRoom r in roomlist.Roomlist)
                        {
                            if (chatid == r.getcid())
                            {
                                r.add_new_sokcket(client);
                                r.send_old(client);
                            }
                        }
                        break;
                    case "f":
                        Console.WriteLine("client try to send a message!\n");

                        read = client.Receive(buffer);
                        data = new byte[read];
                        Array.Copy(buffer, data, read);
                        string x= System.Text.Encoding.UTF8.GetString(data);
                        chatid = x.Substring(0, x.IndexOf(' '));
                        string msg= x.Substring(x.IndexOf(' ')+1);
                        Console.WriteLine("id and message received!\n");
                        foreach (ChatRoom r in roomlist.Roomlist)
                        {
                            Console.WriteLine(msg);
                            if (chatid == r.getcid())
                            {
                                r.msg("["+user.getname()+"]: " +msg);
                                break;
                            }
                        }
                        break;
                    case "g":
                        Console.WriteLine("client try to leave chat room!\n");
                        list = user.getjoined();
                        read = client.Receive(buffer);
                        data = new byte[read];
                        Array.Copy(buffer, data, read);
                        chatid = System.Text.Encoding.UTF8.GetString(data);
                        foreach (ChatRoom r in roomlist.Roomlist)
                        {
                            if (chatid == r.getcid())
                            {
                                r.remove_socket(client);
                            }
                        }
                        foreach (ChatRoom r in list)
                        {
                            if (chatid == r.getcid())
                            {
                                user.leave(r);
                            }
                        }
                        Console.WriteLine("Removing you from "+chatid+"!\n");
                        break;
                    case "h":
                        Console.WriteLine("client try to create a new room\n");
                        read = client.Receive(buffer);
                        data = new byte[read];
                        Array.Copy(buffer, data, read);
                        string new_room = System.Text.Encoding.UTF8.GetString(data);
                        Console.WriteLine("New room name: "+new_room+"\n");
                        ChatRoom chat=new ChatRoom(new_room);
                        //user.newchat(chat);
                        roomlist.Roomlist.Add(chat);
                        client.Send(System.Text.Encoding.UTF8.GetBytes(chat.getcid()));//send new room id
                        break;
                    case "i":
                        Console.WriteLine("client want to join a new room!\n");
                        read = client.Receive(buffer);
                        data = new byte[read];
                        Array.Copy(buffer, data, read);
                        new_room = System.Text.Encoding.UTF8.GetString(data);
                        Console.WriteLine(new_room);
                        foreach (ChatRoom r in user.getnotjoined())
                        {
                            if (new_room == r.getcid())
                            {
                                user.add(r);
                            }
                        }
                        Console.WriteLine("We will insert you to room with this room id: " + new_room + "\n");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
