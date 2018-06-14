using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assistant_Manager
{
    public partial class Setting : Form
    {
        public static bool isPlaySound;
        public static bool isStartAuto;


        public Setting()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isPlaySound = CB_Say.Checked;
            isStartAuto = CB_StartAuto.Checked;
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            this.CB_Say.Checked = isPlaySound;
        }
    }
}
