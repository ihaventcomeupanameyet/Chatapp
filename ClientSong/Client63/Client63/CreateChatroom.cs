using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client63
{
    public partial class CreateChatroom : Form
    {
        public CreateChatroom()
        {
            InitializeComponent();
        }

        private void CancelBttn_Click(object sender, EventArgs e)
        {
            this.Hide(); 
        }

        private void ConfirmBttn_Click(object sender, EventArgs e)
        {
            // Create Chatroom
            // update chats in db, make user become member, show new 
            // chatroom in their joined chatrooms, 
            // show new chatroom in the chatrooms to join for other users
            string name = textBox1.Text;
            if (!string.IsNullOrEmpty(name))
            {
                Program.web.ws.Send(System.Text.Encoding.UTF8.GetBytes("h"));
                System.Threading.Thread.Sleep(10);
                Program.web.ws.Send(System.Text.Encoding.UTF8.GetBytes(name));

                byte[] buffer = new byte[Program.web.ws.SendBufferSize];
                int x = Program.web.ws.Receive(buffer);
                byte[] data = new byte[x];
                Array.Copy(buffer, data, x);
                string chatid = System.Text.Encoding.UTF8.GetString(data);
                chatRoom a = new chatRoom(name, chatid);
                Program.web.JoinedChats.Add(a);
                this.Hide();
            }
        }
    }
}
