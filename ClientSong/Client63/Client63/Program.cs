using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
namespace Client63
{
    
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static class web
        {
            public static Socket ws = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
            public static IPEndPoint ipend=new IPEndPoint(IPAddress.Parse("127.0.0.1"),8080);
            public static List<chatRoom> JoinedChats = new List<chatRoom>();
            public static List<chatRoom> NotJoinedChats = new List<chatRoom>();
        }
  
        [STAThread]
        static void Main()
        {
            try
            {
                web.ws.Connect(web.ipend);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogInForm());
        }

    }
}
