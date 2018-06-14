#define DEBUGING

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Assistant_Manager
{
    public partial class Main_Form : Form
    {
        public static string PressedKeys = string.Empty;

        public static Main_Form mainForm;
        public string myName = "Assistance K.";
        public Command command = new Command();
        CommandList F_CommandList = new CommandList();


        HOOK hookManager;
        FileSystemWatchManager systemWatcherManager;

        public Main_Form()
        {
            InitializeComponent();
            mainForm = this;
            this.Text = myName;
            this.notifyIcon1.Text = myName;
            this.notifyIcon1.BalloonTipTitle = myName;
            this.toolTip1.ToolTipTitle = myName;
            try
            {
                command.LoadCommands();
                command.Command_Voice.StartRecord();

                hookManager = new HOOK();
                this.systemWatcherManager = new FileSystemWatchManager();

                Image bg = Image.FromFile("Data\\Image\\image.png");
                this.BackgroundImage = bg;
                this.Size = bg.Size;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Show(string text)
        {
            this.toolTip1.SetToolTip(this, text);
            this.notifyIcon1.ShowBalloonTip(3, myName, text, ToolTipIcon.Info);
        }

        private Point currentPos = new Point();
        private void Main_Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                currentPos = new Point(e.X, e.Y);
        }

        private void Main_Form_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Left - currentPos.X + e.X, this.Top - currentPos.Y + e.Y);
            }
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_CommandList.Dispose();
            Application.Exit();
        }

        private void 명령어목록ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_CommandList = new CommandList();
            F_CommandList.Show();
        }

        private void 설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void 해제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
        }

        private void 설정ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.notifyIcon1.Visible = false;
            this.notifyIcon1.Dispose();
        }

        private void 키보드입력보기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeysPressed form = new KeysPressed();
            form.Show();
        }

        private void 파일변경로그ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileChangedLog form = new FileChangedLog();
            form.Show();
        }
    }
}
