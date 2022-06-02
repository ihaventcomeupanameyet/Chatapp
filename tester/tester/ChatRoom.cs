using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace tester
{
    internal class ChatRoom
    {
        private string cid;
        private string roomName;
        private List<Socket> sockets;
        private List<string> messages;

        public ChatRoom(string roomName)
        {
            this.roomName = roomName;
            Random rnd = new Random();
            cid = rnd.Next(10000000, 99999999).ToString() ;
            sockets = new List<Socket>();
            messages = new List<string>();
        }
        public void add_new_sokcket(Socket soc)
        {
            sockets.Add(soc);
        }
        public void remove_socket(Socket soc)
        {
            sockets.Remove(soc);
        }
        public void msg(string msg)
        {
            messages.Add(msg);

            foreach (Socket soc in sockets)
            {
                Console.WriteLine(msg);
                soc.Send(System.Text.Encoding.UTF8.GetBytes(cid + " " + msg));
            }
        }
       
        public void send_old(Socket soc)
        {
            foreach(string msg in messages)
            {
                soc.Send(System.Text.Encoding.UTF8.GetBytes(cid + " " + msg));
                Thread.Sleep(10);
            }
        }

        public string getcid()
        {
            return cid;
        }
        public string getroomName()
        {
            return roomName;
        }
    }
}
