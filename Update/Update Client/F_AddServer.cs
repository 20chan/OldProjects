using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Update_Client
{
    public partial class F_AddServer : Form
    {
        public delegate void StringEventHandler(string programName, double vers, string link, string Updated);
        public event StringEventHandler stringevent;

        public F_AddServer()
        {
            InitializeComponent();
        }
    }
}
