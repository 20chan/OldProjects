using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TvpleCloudArtMaker
{
    public partial class DEBUG : Form
    {
        public void SetText(string s)
        {
            this.textBox1.Text += s;
        }
        public DEBUG()
        {
            InitializeComponent();
        }
    }
}
