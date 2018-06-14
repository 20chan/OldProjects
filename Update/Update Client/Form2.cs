using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Update_Client
{
    public partial class Form2 : Form
    {
        public static bool isClosed = false;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            while(this.Opacity != 1)
            {
                this.Opacity += 0.01;
                Thread.Sleep(10);
                Application.DoEvents();
            }
            Thread.Sleep(300);
            while(this.Opacity != 0)
            {
                this.Opacity -= 0.01;
                Thread.Sleep(10);
                Application.DoEvents();
            }
           this.Close();
        }
    }
}
