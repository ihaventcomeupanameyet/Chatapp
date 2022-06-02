using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
namespace Client63
{
    class chatRoom
    {
        private string roomName;
        private string roomId;

        public chatRoom(string roomName, string roomId)
        {
            this.roomName = roomName;
            this.roomId = roomId;
        }
        public string getroomName()
        {
            return roomName;
        }
        public string getroomID()
        {
            return roomId;
        }
        public void setroomName(string roomName)
        {
            this.roomName=roomName;
        }
        public void setroomId(string roomId)
        {
            this.roomId = roomId;
        }
    }
    
}