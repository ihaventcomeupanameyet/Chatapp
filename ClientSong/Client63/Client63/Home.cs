using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace Client63
{
   
    public partial class HomeForm : Form
    {
        CreateChatroom Create = new CreateChatroom();
        public HomeForm()
        {
            InitializeComponent();
        }
        /*public static class chatlist
        {
            public static List<chatRoom> JoinedChats = new List<chatRoom>();
            public static List<chatRoom> NotJoinedChats = new List<chatRoom>();
        }*/
        string username;
        string chatroom;
        

        //static List<chatRoom> JoinedChats = new List<chatRoom>();
        //static List<chatRoom> NotJoinedChats = new List<chatRoom>();
        string[] Messages = new string[100];
        string msg; 

        private void HomeForm_Load(object sender, EventArgs e)
        {
            // Query Joined Chatrooms, load them into array, increment numOfEntries
            // accordingly (didn't know how to declare array without size)


            Ws_OnMessage_joinedChats();

            //JoinedChats[0] = "CSCI";
            //JoinedChats[1] = "Math";
            //int numOfEntries = 2;

            //JoinedChatsCombo.Items.Add("Math");
            foreach (chatRoom i in Program.web.JoinedChats)
            {
                JoinedChatsCombo.Items.Add(i.getroomName());
                leaveChatsCombo.Items.Add(i.getroomName());
            }

            // Query Joined Chatrooms, load them into array, increment numOfEntries
            // accordingly (didn't know how to declare array without size)

            //NotJoinedChats[0] = "MediaDesing";
            //NotJoinedChats[1] = "Math";
            //numOfEntries = 2;

            //JoinedChatsCombo.Items.Add("Math");

            Ws_OnMessage_NotjoinedChats();
            foreach (chatRoom i in Program.web.NotJoinedChats)
            {
                NotJoinedChatsCombo.Items.Add(i.getroomName());
            }


        }

        private void Ws_OnMessage_joinedChats()
        {
            
                Program.web.ws.Send(System.Text.Encoding.UTF8.GetBytes("c"));//signal
                byte[] buffer=new byte[Program.web.ws.SendBufferSize];
                Program.web.ws.Receive(buffer);
                int s = Int32.Parse(System.Text.Encoding.UTF8.GetString(buffer));

                string chatRoomName, chatRoomId;
                for (int i=0; i < s; i++)
                {
                    int x=Program.web.ws.Receive(buffer);
                    byte[] data = new byte[x];
                    Array.Copy(buffer, data, x);
                    string p = System.Text.Encoding.UTF8.GetString(data);
                    chatRoomName = p.Substring(0, p.IndexOf(' '));
                    chatRoomId = p.Substring(p.IndexOf(' ') + 1);
                    chatRoom temp = new chatRoom(chatRoomName, chatRoomId);
                    Program.web.JoinedChats.Add(temp);
                }
            
        }

        private void Ws_OnMessage_NotjoinedChats()
        {
            Program.web.ws.Send(System.Text.Encoding.UTF8.GetBytes("d"));//signal
            byte[] buffer = new byte[Program.web.ws.SendBufferSize];
            Program.web.ws.Receive(buffer);
            int s = Int32.Parse(System.Text.Encoding.UTF8.GetString(buffer));

            string chatRoomName, chatRoomId;
            for (int i = 0; i < s; i++)
            {
                int x = Program.web.ws.Receive(buffer);
                byte[] data = new byte[x];
                Array.Copy(buffer, data, x);
                string p = System.Text.Encoding.UTF8.GetString(data);
                chatRoomName = p.Substring(0, p.IndexOf(' '));
                chatRoomId = p.Substring(p.IndexOf(' ') + 1);
                chatRoom temp = new chatRoom(chatRoomName, chatRoomId);
                Program.web.NotJoinedChats.Add(temp);

            }
        }

        private void JoinedChatsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enter Chat
            // Load old Messages into Array
            // Display them in Textbox
            /* chatroom = JoinedChatsCombo.SelectedItem.ToString();
             string chatId="";
             foreach (chatRoom i in JoinedChats)
             {
                 if (chatroom == i.getroomName())
                 {
                     chatId = i.getroomID();
                 }
             }
             Program.web.ws.OnMessage += Ws_OnMessage_Message;
             Program.web.ws.Send("e"); //singal 
             Program.web.ws.Send(chatId);

            /* Messages[0] = "[Peter] Hi!";
             Messages[1] = "[Peter] How're you?";

             MessagesTextBox.Text = chatroom + "\n";
             for(int i = 0; i < 2; i++)
             {
                 MessagesTextBox.AppendText("\n" + Messages[i]); //  + Messages [1];

             }
            */
            string chatId = "";
            chatroom = JoinedChatsCombo.SelectedItem.ToString();
            foreach (chatRoom i in Program.web.JoinedChats)
            {
                if (chatroom == i.getroomName())
                {
                    chatId = i.getroomID();
                    break;
                }
            }
            Program.web.ws.Send(System.Text.Encoding.UTF8.GetBytes("e")); //singal 

            Program.web.ws.Send(System.Text.Encoding.UTF8.GetBytes(chatId));
            byte[] vs = new byte[1024];
            Thread listen = new Thread(() => {
                while (true)
                {
                    int read = Program.web.ws.Receive(vs);
                    byte[] data = new byte[read];
                    Array.Copy(vs, data, read);
                    string p = System.Text.Encoding.UTF8.GetString(data);
                    string chatRoomId, message;
                    chatRoomId = p.Substring(0, p.IndexOf(' '));
                    message = p.Substring(p.IndexOf(' ') + 1);
                    if (chatRoomId == chatId)
                    {
                        MessagesTextBox.AppendText(("\n" + message));
                    }
                }
            });
            listen.Start();
        }



        private void NotJoinedChatsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Join Chat, update user and his chats in the DB
            // Enter Chat
            // Load old Messages into Array
            // Display them in Textbox
            chatroom = NotJoinedChatsCombo.SelectedItem.ToString();
            string chatid = "";
            foreach (chatRoom i in Program.web.NotJoinedChats)
            {
                if (chatroom == i.getroomName())
                {
                    chatid = i.getroomID();
                    Program.web.JoinedChats.Add(i);
                    Program.web.NotJoinedChats.Remove(i);
                    break;
                }
            }
            Program.web.ws.Send(System.Text.Encoding.UTF8.GetBytes("i"));//signal
            Thread.Sleep(10);
            Program.web.ws.Send(System.Text.Encoding.UTF8.GetBytes(chatid));

            JoinedChatsCombo.Items.Add(chatroom);
            leaveChatsCombo.Items.Add(chatroom);
            NotJoinedChatsCombo.Items.Remove(chatroom);

           
        }

        private void SendMsgButton_Click(object sender, EventArgs e)
        {
            msg = msgText.Text;
            if (!string.IsNullOrEmpty(msg))
            {

                chatroom = JoinedChatsCombo.SelectedItem.ToString();
                string chatId = "";
                foreach (chatRoom i in Program.web.JoinedChats)
                {
                    if (chatroom == i.getroomName())
                    {
                        chatId = i.getroomID();
                        break;
                    }
                }
                
                Program.web.ws.Send(System.Text.Encoding.UTF8.GetBytes("f")); //signal send message
                Thread.Sleep(10);
                Program.web.ws.Send(System.Text.Encoding.UTF8.GetBytes(chatId+" "+msg));
                // Send message
                // Save message to DB 
            }
           
        }

        private void MessagesTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void leaveChatsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // remove the user from the chatroom, 
            // update the chatrooms they can enter and 
            // the chatrooms they can join 
            chatroom=leaveChatsCombo.SelectedItem.ToString();
            string chatid = "";
            foreach (chatRoom i in Program.web.JoinedChats)
            {
                if (chatroom == i.getroomName())
                {
                    chatid = i.getroomID();
                    Program.web.JoinedChats.Remove(i);
                    Program.web.NotJoinedChats.Add(i);
                    break;
                }
            }
            Program.web.ws.Send(System.Text.Encoding.UTF8.GetBytes("g"));
            Thread.Sleep(10);
            Program.web.ws.Send(System.Text.Encoding.UTF8.GetBytes(chatid));
            leaveChatsCombo.Items.Remove(chatroom);
            JoinedChatsCombo.Items.Remove(chatroom);
            leaveChatsCombo.Items.Add(chatroom);
        }

        private void CreateChatBttn_Click(object sender, EventArgs e)
        {
            Create.Show();
        }



        private void update(object sender, EventArgs e)
        {
            JoinedChatsCombo.Items.Clear();
            leaveChatsCombo.Items.Clear();
            foreach (chatRoom i in Program.web.JoinedChats)
            {
                JoinedChatsCombo.Items.Add(i.getroomName());
                leaveChatsCombo.Items.Add(i.getroomName());
            }
        }
    }
}
