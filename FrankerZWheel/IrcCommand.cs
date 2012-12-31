using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IrcBotFramework
{
    public class IrcCommand
    {
        public IrcCommand(IrcUser Source, string Message, string Prefix)
        {
            this.Source = Source;
            this.Prefix = Prefix;
            if (Message.IndexOf(' ') == -1)
                this.Message = "";
            else
                this.Message = Message.Substring(Message.IndexOf(' ') + 1).Trim();
            string[] parts = Message.Split(' ');
            this.Command = parts[0].Substring(1);
            if (parts.Length > 1)
                this.Parameters = parts.Skip(1).ToArray();
            else
                this.Parameters = new string[0];
        }

        public IrcUser Source;
        public string Message, Command, Prefix;
        public string[] Parameters;
        public string Destination;
    }
}
