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
    public partial class KeysPressed : Form
    {
        public KeysPressed()
        {
            InitializeComponent();
        }

        private void KeysPressed_Load(object sender, EventArgs e)
        {
            foreach(TimeKey t in HOOK.PressedKeys)
            {
                ListViewItem l = new ListViewItem(t.Key.ToString());
                l.SubItems.Add(t.Time.ToString("HH:mm:ss"));
                l.SubItems.Add(t.IME.ToString());
                this.listView1.Items.Add(l);
            }
        }
    }
}
