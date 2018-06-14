//#define DEBUGING

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
    public partial class AddWork : Form
    {
        public bool isCleared = false;
        public string cmd = string.Empty;
        public Work work;

        public AddWork()
        {
            InitializeComponent();
            isCleared = false;
            //cmd = string.Empty;
            RB_Program_CheckedChanged(null, null);
        }

        public void RestoreControls()
        {
            if (work == null)
            {
#if DEBUGING
                MessageBox.Show("work 가 null 입니다.", "디버그");
#endif
                return;
            }
            isCleared = false;
            switch(work.workType)
            {
                case WorkType.OPEN:
                    {
                        this.RB_Program.Checked = true;
                        this.TB_Program.Text = ((WORK_OPEN)work).program;
                        this.TB_Args.Text = ((WORK_OPEN)work).args;
                        break;
                    }
                case WorkType.CLOSE:
                    {
                        this.RB_Close.Checked = true;
                        break;
                    }
                case WorkType.SENDKEY:
                    {
                        this.RB_SendKey.Checked = true;
                        this.TB_Keys.Text = ((WORK_SENDKEY)work).keys;
                        break;
                    }
                case WorkType.START:
                    {
                        this.RB_Start.Checked = true;
                        break;
                    }
                case WorkType.STOP:
                    {
                        this.RB_Stop.Checked = true;
                        break;
                    }
                case WorkType.SAY:
                    {
                        this.RB_Say.Checked = true;
                        this.TB_Say.Text = ((WORK_SAY)work).Text;
                        break;
                    }
                default:
                    {
#if DEBUGING
                        MessageBox.Show(work.workType.ToString(), "디버그");
#endif
                        break;
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.isCleared = false;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (RB_Program.Checked)
            {
                if (!CheckIsRightinProgram()) { MessageBox.Show("올바르지 않는 명령입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                work = new WORK_OPEN(TB_Program.Text, TB_Args.Text);
                this.isCleared = true;
                this.Close();
            }
            else if (RB_Close.Checked)
            {
                work = new WORK_CLOSE();
                this.isCleared = true;
                this.Close();
            }
            else if (RB_SendKey.Checked)
            {
                if (!CheckIsRightinSendKeys()) { MessageBox.Show("문자열이 올바르지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                work = new WORK_SENDKEY(this.TB_Keys.Text);
                this.isCleared = true;
                this.Close();
            }
            else if (RB_Start.Checked)
            {
                work = new WORK_START();
                this.isCleared = true;
            }
            else if (RB_Stop.Checked)
            {
                work = new WORK_STOP();
                this.isCleared = true;
            }
            else if (RB_Say.Checked)
            {
                work = new WORK_SAY(this.TB_Say.Text);
                this.isCleared = true;
            }
            else
            {
#if DEBUGING
                MessageBox.Show("AddCommand.cs 에서 발생한 오류입니다.", "디버그");
#endif
            }
            this.Close();
        }

        private bool CheckIsRightinProgram()
        {
            if (this.TB_Program.Text == null || this.TB_Program.Text == string.Empty)
                return false;
            //if (this.TB_Args.Text == null || this.TB_Args.Text == string.Empty)
            //    return false;
            if (!checkFile(TB_Program.Text)) return false;
            
            return true;
        }

        private bool CheckIsRightinSendKeys()
        {
            string _text = this.TB_Keys.Text;
            if (_text.Contains("{") || _text.Contains("}") || _text.Contains("%") || _text.Contains("~") ||
                _text.Contains("^") || _text.Contains("+") || _text.Contains("(") || _text.Contains(")"))
            {
                return false;
            }
            return true;
        }

        private bool checkFile(string name)
        {
            if (name.Contains("?") || name.Contains("*") || name.Contains("<") || name.Contains(">") || name.Contains("|") || name.Contains("\""))
                return false;
            return true;
        }

        private void BTN_Browse_Program_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                this.TB_Program.Text = ofd.FileName;
            }
        }

        private void BTN_Browse_Args_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.TB_Args.Text = ofd.FileName;
            }
        }

        private void RB_Program_CheckedChanged(object sender, EventArgs e)
        {
            if(this.RB_Program.Checked)
            {
                this.TB_Keys.Enabled = false;
                this.TB_Program.Enabled = true;
                this.TB_Args.Enabled = true;
                this.BTN_Browse_Args.Enabled = true;
                this.BTN_Browse_Program.Enabled = true;
                this.TB_Say.Enabled = false;
            }
            else if (this.RB_Close.Checked)
            {
                this.TB_Keys.Enabled = false;
                this.TB_Program.Enabled = false;
                this.TB_Args.Enabled = false;
                this.BTN_Browse_Args.Enabled = false;
                this.BTN_Browse_Program.Enabled = false;
                this.TB_Say.Enabled = false;
            }
            else if(this.RB_SendKey.Checked)
            {
                this.TB_Keys.Enabled = true;
                this.TB_Program.Enabled = false;
                this.TB_Args.Enabled = false;
                this.BTN_Browse_Args.Enabled = false;
                this.BTN_Browse_Program.Enabled = false;
                this.TB_Say.Enabled = false;
            }
            else if (this.RB_Start.Checked)
            {
                this.TB_Keys.Enabled = false;
                this.TB_Program.Enabled = false;
                this.TB_Args.Enabled = false;
                this.BTN_Browse_Args.Enabled = false;
                this.BTN_Browse_Program.Enabled = false;
                this.TB_Say.Enabled = false;
            }
            else if (this.RB_Stop.Checked)
            {
                this.TB_Keys.Enabled = false;
                this.TB_Program.Enabled = false;
                this.TB_Args.Enabled = false;
                this.BTN_Browse_Args.Enabled = false;
                this.BTN_Browse_Program.Enabled = false;
                this.TB_Say.Enabled = false;
            }
            else if(this.RB_Say.Checked)
            {
                this.TB_Keys.Enabled = false;
                this.TB_Program.Enabled = false;
                this.TB_Args.Enabled = false;
                this.BTN_Browse_Args.Enabled = false;
                this.BTN_Browse_Program.Enabled = false;
                this.TB_Say.Enabled = true;
            }
        }

        private void AddWork_Load(object sender, EventArgs e)
        {
            this.Text = "명령 추가 : " + cmd;
        }
    }
}
