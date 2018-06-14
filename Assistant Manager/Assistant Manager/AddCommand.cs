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
    public partial class AddCommand : Form
    {
        public AddCommand()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        Main_Form.mainForm.command.Command_Voice.AddCommand(this.textBox1.Text);
                        break;
                    }
                case 1:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            this.Close();
        }
    }
}
