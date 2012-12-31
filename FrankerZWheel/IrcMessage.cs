using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IrcBotFramework
{
    public class IrcMessage
    {
        public IrcMessage(string RawMessage)
        {
            this.RawMessage = RawMessage;
            string raw = RawMessage;
            if (raw.StartsWith(":"))
            {
                raw = raw.Substring(1);
                Prefix = raw.Remove(raw.IndexOf(' '));
                raw = raw.Substring(raw.IndexOf(' ') + 1);
            }
            Command = raw.Remove(raw.IndexOf(' ')).ToUpper();
            raw = raw.Substring(raw.IndexOf(' ') + 1);
            Payload = raw;
            Parameters = raw.Split(' ');
        }

        public string RawMessage, Prefix, Command, Payload;
        public string[] Parameters;
    }
}
