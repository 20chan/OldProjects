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

namespace RoyCompiler
{
    public partial class AssemblyReferences : Form
    {
        public AssemblyReferences()
        {
            InitializeComponent();
        }

        private void AssemblyReferences_Load(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("Assemblies.txt", Encoding.Default);
                while (sr.Peek() > -1)
                {
                    string line = sr.ReadLine();
                    ListViewItem l = new ListViewItem(line);

                    this.listView1.Items.Add(l);
                }

                foreach(string ass in Form1.ReferencedAssemblies)
                {
                    int count = 0;
                    foreach(ListViewItem i in this.listView1.Items)
                    {
                        if(ass == i.Text)
                        {
                            i.Checked = true;
                            break;
                        }
                        count++;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BTN_Ok_Click(object sender, EventArgs e)
        {
            Form1.ReferencedAssemblies.Clear();
            foreach(ListViewItem item in this.listView1.CheckedItems)
            {
                Form1.ReferencedAssemblies.Add(item.Text);
            }
            this.Close();
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
