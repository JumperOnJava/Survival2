using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Survival
{
    public partial class Form2 : Form
    {
        public static Image spriteSheet;
        public bool ok = true;
        Random rnd = new Random();
        public Form2()
        {
            //Graphics g = Graphics.FromImage(spriteSheet);
            InitializeComponent();
            spriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\clouds.png"));
            //g.DrawImage(spriteSheet, new Rectangle(new Point(300, 300), new Size(300, 300)), 330, 297, 300, 300, GraphicsUnit.Pixel); //tree

            //pictureBoxCloud1.Image = spriteSheet;
            timerClouds.Interval = 1000;
            timerClouds.Tick += new EventHandler(UpdateClouds);
            timerClouds.Start();
        }

        private void UpdateClouds(object sender, EventArgs e)
        {
            //Graphics g = e.Graphics;

            if (pictureBoxCloud1.Visible)
            {
                pictureBoxCloud1.Visible = false;
                pictureBoxCloud2.Visible = true;
                pictureBoxCloud3.Visible = false;
                pictureBoxCloud4.Visible = false;
            }
            else if (pictureBoxCloud2.Visible)
            {
                pictureBoxCloud1.Visible = false;
                pictureBoxCloud2.Visible = false;            
                pictureBoxCloud3.Visible = true;
                pictureBoxCloud4.Visible = false;
            }
            else if (pictureBoxCloud3.Visible)
            {
                pictureBoxCloud1.Visible = false;
                pictureBoxCloud2.Visible = false;
                pictureBoxCloud3.Visible = false;
                pictureBoxCloud4.Visible = true;
            }
            else
            {
                pictureBoxCloud1.Visible = true;
                pictureBoxCloud2.Visible = false;
                pictureBoxCloud3.Visible = false;
                pictureBoxCloud4.Visible = false;
            }
        }

        private void labelStart_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(this);
            //form1.gameIsStart = true;
            form1.Show();
            //newForm.gameIsStart = true;

            this.Hide();
        }



        private void labelExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelStart_MouseEnter(object sender, EventArgs e)
        {
            labelStart.ForeColor = Color.White;
        }

        private void labelStart_MouseLeave(object sender, EventArgs e)
        {
            labelStart.ForeColor = SystemColors.ControlText;
        }

        private void labelExit_MouseEnter(object sender, EventArgs e)
        {
            labelExit.ForeColor = Color.White;
        }

        private void labelExit_MouseLeave(object sender, EventArgs e)
        {
            labelExit.ForeColor = SystemColors.ControlText;
        }



    }
}
