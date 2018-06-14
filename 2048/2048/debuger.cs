using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class debuger : Form
    {
        public debuger()
        {
            InitializeComponent();
        }

        public void Append(BlockManager.Arrow arrow ,Block[,] blocks, int x, int y)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(arrow.ToString());
            for(int i = 0; i < x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    sb.Append(blocks[i, j].Value + ", ");
                }
                sb.AppendLine();
            }
            sb.AppendLine();

            this.textBox1.AppendText(sb.ToString());
        }
    }
}
