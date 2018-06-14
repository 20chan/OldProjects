using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Anti_Anti_.Net_Reflector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AntiReflector(string path)
        {
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Write);
            stream.Seek(0xf4, SeekOrigin.Begin);
            stream.WriteByte(11);
            stream.Flush();
            stream.Close();
            MessageBox.Show("적용 완료!", "Anti-Reflector", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void AntiAntiReflector(string path)
        {
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Write);
            stream.Seek(0xf4, SeekOrigin.Begin);
            stream.WriteByte(16);
            stream.Flush();
            stream.Close();
            MessageBox.Show("적용 완료!", "Anti-Reflector", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                openFileDialog.FileName = openFileDialog.FileName;
                AntiReflector(openFileDialog.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                openFileDialog.FileName = openFileDialog.FileName;
                AntiAntiReflector(openFileDialog.FileName);
            }
        }

        private void button2_DragDrop(object sender, DragEventArgs e)
        {
            string[] arrpath = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            AntiAntiReflector(arrpath[0]);
        }

        private void button1_DragDrop(object sender, DragEventArgs e)
        {
            string[] arrpath = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            AntiReflector(arrpath[0]);
        }

        private void button1_DragEnter(object sender, DragEventArgs e)
        {
            string[] arrpath = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            AntiReflector(arrpath[0]);
        }

        private void button2_DragEnter(object sender, DragEventArgs e)
        {
            string[] arrpath = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            AntiAntiReflector(arrpath[0]);
        }
    }
}
