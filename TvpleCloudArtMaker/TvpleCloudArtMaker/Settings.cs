using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CubeMit.Hook;
using MaterialSkin;
using MaterialSkin.Controls;

namespace TvpleCloudArtMaker
{
    public partial class Settings : MaterialForm
    {
        public Settings()
        {
            InitializeComponent();
            this.materialSingleLineTextField1.Text = Form1.toSend;
            this.materialSingleLineTextField2.Text = Form1.drawInterval.ToString();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            Form1.toSend = Properties.Settings.Default.toSend = this.materialSingleLineTextField1.Text;
            Form1.drawInterval = Properties.Settings.Default.drawInterval = Convert.ToInt32(this.materialSingleLineTextField2.Text);
            Properties.Settings.Default.Save();
            this.Close();
        }
        
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialSingleLineTextField2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
                e.Handled = true;
        }
    }
}