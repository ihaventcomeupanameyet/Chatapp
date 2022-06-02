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
    public partial class RegisterForm : Form
    {
        HomeForm Home = new HomeForm();
        public RegisterForm()
        {
            InitializeComponent();
        }

        string username;
        string email; 
        string password; 
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            username = UsernameTextBox.Text;
            email = EmailTextBox.Text;
            password = PasswordTextBox.Text;

            Program.web.ws.Send(System.Text.Encoding.UTF8.GetBytes("b"));
            Program.web.ws.Send(System.Text.Encoding.UTF8.GetBytes(username));
            Program.web.ws.Send(System.Text.Encoding.UTF8.GetBytes(email));
            Program.web.ws.Send(System.Text.Encoding.UTF8.GetBytes(password));
            byte[] bytes = new byte[Program.web.ws.SendBufferSize];
            int x = Program.web.ws.Receive(bytes);
            byte[] data = new byte[x];
            Array.Copy(bytes, data, x);
            string a = System.Text.Encoding.UTF8.GetString(data);
            if (a == "T")
            {
                this.Hide();
                Home.Show();
            }
            else if (a == "F")
            {
                MessageBox.Show("Ooops! Looks like you're not a user!");
            }


            //this.Hide();
            //Home.Show();
            // Validate User doesn't already exist
            // If valid, update user in DB 

        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //LogIn2.Show(); 
            
        }
    }
}
