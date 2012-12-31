using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IrcBotFramework;

namespace FrankerZWheel
{
    public partial class Form1 : Form
    {
        BotController controller = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmdConnect.Click += new EventHandler(cmdConnect_Click);
            cmdLeaveChannel.Click += new EventHandler(cmdLeaveChannel_Click);
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (controller != null)
            {
                controller.Disconnect();
            }
        }

        void cmdConnect_Click(object sender, EventArgs e)
        {
            cmdConnect.Enabled = false;
            cmdLeaveChannel.Enabled = true;

            //BotController controller = new BotController(new IrcUser(txtName.Text, txtName.Text), txtAddress.Text, txtChannel.Text);
            controller = new BotController(new IrcUser("foxmcbot", "foxmcbot"), "irc.freenode.net", "#foxmcbottest");
            //BotController controller = new BotController(new IrcUser("foxmcbot", "foxmcbot"), "irc.speedrunslive.com", "#bottest");
            
            //controller = new BotController(new IrcUser("foxmcbot", "foxmcbot", "O2u0w64O4s6s723"), "mrlandmaster.jtvirc.com", "#mrlandmaster");
            controller.Initialize();
        }

        void cmdLeaveChannel_Click(object sender, EventArgs e)
        {
            if (controller != null)
            {
                controller.Disconnect();
            }

            cmdLeaveChannel.Enabled = false;
            cmdConnect.Enabled = true;
        }

        public string StatusMessage
        {
            get
            {
                return lblStatus.Text;
            }
            set
            {
                lblStatus.Text = value;
            }
        }
    }
}
