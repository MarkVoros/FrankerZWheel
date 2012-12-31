using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IrcBotFramework;

namespace FrankerZWheel
{
    class BotController
    {
        FrankerZBot bot;
        IrcUser user;
        string address, channel;

        FrankerZForm frankerZForm;

        public BotController(IrcUser user, string address, string channel)
        {
            this.user = user;
            this.address = address;
            this.channel = channel;
        }

        public void Initialize()
        {
            bot = new FrankerZBot(address, user);

            bot.ConnectionComplete += new EventHandler(bot_ConnectionComplete);
            bot.UserMessageRecieved += new EventHandler<UserMessageEventArgs>(bot_UserMessageRecieved);

            bot.Run();

            frankerZForm = new FrankerZForm();
            frankerZForm.Show();
        }

        void bot_UserMessageRecieved(object sender, UserMessageEventArgs e)
        {
            if (e.UserMessage.Message.Contains("FrankerZ"))
            {
                bot.SendMessage(channel, "FrankerZ");
                frankerZForm.speed += 4f;
            }
        }

        void bot_ConnectionComplete(object sender, EventArgs e)
        {
            bot.JoinChannel(channel);
            //mainForm.StatusMessage = "Connected to " + channel + " at " + address;
        }

        public void Disconnect()
        {
            //mainForm.lblStatus.Text = "";
            bot.SendMessage(channel, "Goodbye");
            bot.PartChannel(channel, "");
        }

    }
}
