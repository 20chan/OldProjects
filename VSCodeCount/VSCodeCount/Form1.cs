﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSCodeCount
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string dir = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            this.label1.Text = System.IO.Path.GetFileName(dir);
            this.textBox1.AppendText("--" + dir + "--\r\n");
            string[] csprojs = Counter.GetCsproj(dir);
            int Lines = 0;
            foreach (string csproj in csprojs)
            {
                string[] codes = Counter.GetCodelist(csproj, false);
                foreach (string c in codes)
                {
                    int line = System.IO.File.ReadAllLines(c).Length;
                    Lines += line;
                    this.textBox1.AppendText(string.Format("{0:50} : {1:000} 줄\r\n", c.PadRight(50), line));
                }
            }
            this.textBox1.AppendText("-----------------------------------------------------------\r\n");
            this.textBox1.AppendText(string.Format("총:                                                : {0:000} 줄\r\n\r\n", Lines));

        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Move : DragDropEffects.None;
        }
    }
}
