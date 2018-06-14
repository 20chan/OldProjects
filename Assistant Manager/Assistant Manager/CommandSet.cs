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
    public partial class CommandSet : Form
    {
        public CommandType commandType = CommandType.NONE;
        public string Command = string.Empty;
        public CommandSet(CommandType type, string cmd)
        {
            InitializeComponent();
            this.Command = cmd;
            this.Text = "명령어 : " + cmd;
        }

        private void RestoreListView()
        {
            this.listView1.Items.Clear();
            
            foreach (Work w in Main_Form.mainForm.command.workList[Command])
            {
                ListViewItem l = new ListViewItem(w.workType.ToString());
                l.SubItems.Add(w.info);
                this.listView1.Items.Add(l);
            }
        }

        AddWork f;
        //string oldCmd = string.Empty;
        int index = 0;
        private void EditClickedValue()
        {
            f = new AddWork();
            f.cmd = this.Command;
            //oldCmd = f.cmd = listView1.SelectedItems[0].SubItems[0].Text;
            f.work = Main_Form.mainForm.command.workList[Command][this.listView1.SelectedItems[0].Index];
            index = this.listView1.SelectedItems[0].Index;
            f.FormClosed += F_FormClosed;
            f.RestoreControls();
            f.ShowDialog();
        }
        
        private void F_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!f.isCleared)
            {
#if DEBUGING
                MessageBox.Show("수정할때 바로 리턴", "디버그");
#endif
                return;
            }
            Main_Form.mainForm.command.EditWork(commandType, f.cmd, index, f.work);
            Main_Form.mainForm.command.SaveCommands();
            this.RestoreListView();
            Main_Form.mainForm.command.Command_Voice.Reload();
        }

        private void DeleteClickedValue()
        {
            if (listView1.Items.Count == 1)
            {
                MessageBox.Show("명령어는 최소 한개 이상이어야 합니다!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (MessageBox.Show("정말로 명령을 삭제하시겠습니까?", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Main_Form.mainForm.command.DeleteCommand(commandType, this.listView1.SelectedItems[0].SubItems[0].Text);
            }
            Main_Form.mainForm.command.SaveCommands();
            this.RestoreListView();
            Main_Form.mainForm.command.Command_Voice.Reload();
        }

        AddWork F_Addcmd;
        private void button1_Click(object sender, EventArgs e)
        {
            F_Addcmd = new AddWork();
            F_Addcmd.cmd = this.Command;
             
            F_Addcmd.FormClosed += F_Addcmd_FormClosed;
            F_Addcmd.ShowDialog();
        }

        private void F_Addcmd_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!F_Addcmd.isCleared) return;
            Main_Form.mainForm.command.AddWork(commandType, F_Addcmd.cmd, F_Addcmd.work);
            Main_Form.mainForm.command.SaveCommands();
            Main_Form.mainForm.command.Command_Voice.Reload();
            this.RestoreListView();
        }

        private void CommandSet_Load(object sender, EventArgs e)
        {
            this.RestoreListView();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            EditClickedValue();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditClickedValue();
        }

        private void 삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteClickedValue();
        }
    }
}
