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
    public partial class FileChangedLog : Form
    {
        public FileChangedLog()
        {
            InitializeComponent();
        }

        private void FileLog_Load(object sender, EventArgs e)
        {
            foreach(FileLog f in FileSystemWatchManager.FileLogs)
            {
                ListViewItem l = new ListViewItem(f.Type.ToString());
                l.SubItems.Add(f.directory);
                l.SubItems.Add(f.Time.ToString("HH:mm:ss"));
                this.listView1.Items.Add(l);
            }
            listView1.EnsureVisible(listView1.Items.Count - 1);
        }
    }
}
