using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CheckUpdate;
using System.Threading;

namespace Assistant_Manager
{
    public partial class Load : Form
    {


        private Point currentPos = new Point();

        public Load()
        {
            InitializeComponent();

            this.MouseDown += Load_MouseDown;
            this.MouseMove += Load_MouseMove;
        }

        public void FindAllChildControl(Control rootControl)
        {
            foreach(Control childcontrol in rootControl.Controls)
            {
                childcontrol.MouseDown += Childcontrol_MouseDown;
                childcontrol.MouseMove += Childcontrol_MouseMove;

                FindAllChildControl(childcontrol);
            }
        }

        private void Childcontrol_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + currentPos.X + e.X + (sender as Control).Left,
                    this.Location.Y + currentPos.Y + e.Y + (sender as Control).Top);
            }
        }

        private void Childcontrol_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                currentPos = new Point(-e.X - (sender as Control).Left, -e.Y - (sender as Control).Top);
            }
        }

        private void Load_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + currentPos.X + e.X, this.Location.Y + currentPos.Y + e.Y);
            }
        }

        private void Load_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentPos = new Point(-e.X, -e.Y);
            }
        }

        private void Load_Shown(object sender, EventArgs e)
        {
            CheckUpdate form = new CheckUpdate();
            form.Show();
            form.FormClosed += Form_FormClosed;
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void Load_Load(object sender, EventArgs e)
        {
            this.label1.Text = "Assistant Manager " + CheckUpdate.CurrentVersion.ToString();
        }
    }
}
