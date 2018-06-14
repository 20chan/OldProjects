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
    public partial class CommandList : Form
    {
        public CommandList()
        {
            InitializeComponent();
        }

        private void RestoreListView()
        {
            this.listView1.Items.Clear();
            foreach(cmd c in Main_Form.mainForm.command.Commands)
            {
                ListViewItem l = new ListViewItem(c.type.ToString());
                l.SubItems.Add(c.text);

                string s = string.Empty;
                int i = 0;
                foreach (Work w in Main_Form.mainForm.command.workList[c.text])
                {
                    if (i == Main_Form.mainForm.command.workList[c.text].Count - 1)
                        s += w.workType.ToString();
                    else s += w.workType.ToString() + ", ";
                    ++i;
                }
                l.SubItems.Add(s);
                this.listView1.Items.Add(l);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CommandList_Load(object sender, EventArgs e)
        {
            RestoreListView();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            AddCommand form = new AddCommand();
            form.FormClosed += F_Addcmd_FormClosed;
            form.Show();
            this.RestoreListView();
        }

        private void F_Addcmd_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.RestoreListView();
        }

        string oldCmd = string.Empty;

        private void EditClickedValue()
        {
            CommandSet form = new CommandSet(Main_Form.mainForm.command.Commands[listView1.SelectedItems[0].Index].type, this.listView1.SelectedItems[0].SubItems[1].Text);
            form.FormClosed += Form_FormClosed;
            form.Show();
            /*f = new AddCommand();
            oldCmd = f.cmd = listView1.SelectedItems[0].SubItems[0].Text;
            f.work = Main_Form.mainForm.command.workList[listView1.SelectedItems[0].SubItems[0].Text];
            f.FormClosed += F_FormClosed;
            f.RestoreControls();
            f.ShowDialog();*/
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.RestoreListView();
        }

        private void DeleteClickedValue()
        {
            if(listView1.Items.Count == 1)
            {
                MessageBox.Show("명령어는 최소 한개 이상이어야 합니다!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(MessageBox.Show("정말로 명령을 삭제하시겠습니까?", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Main_Form.mainForm.command.DeleteCommand(Main_Form.mainForm.command.Commands[listView1.SelectedItems[0].Index].type, this.listView1.SelectedItems[0].SubItems[0].Text);
            }
            Main_Form.mainForm.command.SaveCommands();
            this.RestoreListView();
            Main_Form.mainForm.command.Command_Voice.Reload();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            EditClickedValue();
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
