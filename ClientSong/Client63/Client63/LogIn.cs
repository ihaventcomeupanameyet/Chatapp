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
    public partial class LogInForm : Form
    {
        RegisterForm Register = new RegisterForm();
        HomeForm Home = new HomeForm();
        public LogInForm()
        {
            InitializeComponent();
        }

        string username; 
        string password;
        private void LogInButton_Click(object sender, EventArgs e)
        {
            username = UsernameTextBox.Text;
            password = PasswordTextBox.Text;
            Program.web.ws.Send(System.Text.Encoding.UTF8.GetBytes("a"));
            Program.web.ws.Send(System.Text.Encoding.UTF8.GetBytes(username));
            Program.web.ws.Send(System.Text.Encoding.UTF8.GetBytes(" "));
            Program.web.ws.Send(System.Text.Encoding.UTF8.GetBytes(password));
            byte[] bytes = new byte[Program.web.ws.SendBufferSize];
            int x=Program.web.ws.Receive(bytes);
            byte[] data=new byte[x];
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
            // Validate User
            // If user not valid: 
            // MessageBox.Show("Ooops! Looks like you're not a user!");
            //this.Hide(); 
            //Home.Show(); 

        }

       

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.Hide();             
            Register.Show();
        }
    }
}
