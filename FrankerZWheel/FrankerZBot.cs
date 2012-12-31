using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IrcBotFramework;

namespace FrankerZWheel
{
    class FrankerZBot : IrcBot
    {
        public FrankerZBot(string ServerAddress, IrcUser User) : base(ServerAddress, User)
        {
            RegisterCommand("ping", (command) => "pong");
        }
    }
}
