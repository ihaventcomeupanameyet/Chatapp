using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tester
{
    internal class User
    {
        private string name;
        private List<ChatRoom> notJoined;
        private List<ChatRoom> joined;
        public User(List<ChatRoom> notJoined)
        {
            this.notJoined = notJoined;
            name = "";
            joined = new List<ChatRoom>();
        }
        public void setname(string name)
        {
            this.name = name;
        }
        public void add(ChatRoom c)
        {
            joined.Add(c);
            //notJoined.Remove(c);
        }
        public void newchat(ChatRoom c)
        {
            notJoined.Add(c);
        }
        public void leave(ChatRoom c)
        {
            joined.Remove(c);
            notJoined.Add(c);
        }
        public List<ChatRoom> getnotjoined()
        {
            return notJoined;
        }
        public List<ChatRoom> getjoined()
        {
            return joined;
        }
        public string getname()
        {
            return name;
        }
    }
}
