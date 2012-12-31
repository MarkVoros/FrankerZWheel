using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RotatePictureBox;

namespace FrankerZWheel
{
    public partial class FrankerZForm : Form
    {
        Image frankerZ;
        float angle = 0f;
        public float speed = 0f;

        public FrankerZForm()
        {
            InitializeComponent();
        }

        private void FrankerZForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            frankerZ = new Bitmap("Images/frankerz.png");
            pictureBox1.Image = (Bitmap)frankerZ.Clone();

            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Start();
        }

        //decelrator
        void timer2_Tick(object sender, EventArgs e)
        {
            speed -= 0.025f;

            if (speed < 0)
            {
                speed = 0;
            }
        }

        //accelerator
        void timer1_Tick(object sender, EventArgs e)
        {
            angle += speed;

            if (angle > 360)
            {
                angle -= 360;
            }

            pictureBox1.Image = Utilities.RotateImage(frankerZ, angle);
        }
    }
}
