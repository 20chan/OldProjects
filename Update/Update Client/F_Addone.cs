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
using Nemiro.OAuth;

namespace Update_Client
{
    public partial class F_Addone : Form
    {
        public delegate void StringEventHandler(string programName, double vers, string link, string Updated);
        public event StringEventHandler stringevent;
        string programname;
        public F_Addone(string programName = "", double vers = 0, string link = "", string Updated = "")
        {
            InitializeComponent();
            /*for (int i = 0; i <= comboBox1.Items.Count - 1; i++)
            {
                if(programName == comboBox1.Items[i].ToString())
                {
                    comboBox1.Select(i, 1);
                }
            }*/
            this.programname = programName;
            this.textBox1.Text = vers.ToString();
            this.textBox2.Text = link;
            this.textBox3.Text = Updated;
        }

        private void BTN_Close_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == comboBox1.Items.Count - 1)
            {
                foreach(OneProgram op in Form1.programs)
                {
                    if (this.textBox4.Text == op.programName)
                    {
                        MessageBox.Show("동일한 이름의 프로그램이 존재합니다");
                        return;
                    }
                }
                stringevent(this.textBox4.Text, Convert.ToDouble(this.textBox1.Text), this.textBox2.Text, this.textBox3.Text);
            }
            else
                stringevent(this.comboBox1.SelectedItem.ToString(), Convert.ToDouble(this.textBox1.Text), this.textBox2.Text, this.textBox3.Text);

            this.Dispose();
            this.Close();

        }

        private void F_Addone_Load(object sender, EventArgs e)
        {
            foreach(OneProgram pr in Form1.programs)
            {
                foreach(String str in this.comboBox1.Items)
                {
                    if (pr.programName == str)
                        goto Label1;
                }
                this.comboBox1.Items.Add(pr.programName);
                Label1:
                continue;
            }
            this.comboBox1.Items.Add("프로그램 추가");

            this.comboBox1.SelectedIndex = comboBox1.Items.IndexOf(programname);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == comboBox1.Items.Count - 1)
            {
                if (textBox1.Location.Y == 51)
                {
                    this.label2.Location = new Point(this.label2.Location.X, this.label2.Location.Y + 32);
                    this.label3.Location = new Point(this.label3.Location.X, this.label3.Location.Y + 32);
                    this.label4.Location = new Point(this.label4.Location.X, this.label4.Location.Y + 32);
                    this.textBox1.Location = new Point(this.textBox1.Location.X, this.textBox1.Location.Y + 32);
                    this.textBox2.Location = new Point(this.textBox2.Location.X, this.textBox2.Location.Y + 32);
                    this.textBox3.Location = new Point(this.textBox3.Location.X, this.textBox3.Location.Y + 32);
                    this.textBox3.Size = new Size(this.textBox3.Size.Width, this.textBox3.Size.Height - 32);
                    this.textBox4.Location = new System.Drawing.Point(130, 51);
                    this.button2.Location = new Point(this.button2.Location.X, this.button2.Location.Y + 32);
                }
            }
            else
            {
                this.textBox4.Location = new Point(1000, 1000);
                this.textBox1.Location = new System.Drawing.Point(130, 51);
                this.label2.Location = new System.Drawing.Point(12, 54);
                this.label3.Location = new System.Drawing.Point(12, 87);
                this.textBox2.Location = new System.Drawing.Point(130, 84);
                this.label4.Location = new System.Drawing.Point(12, 123);
                this.textBox3.Location = new System.Drawing.Point(130, 120);
                this.textBox3.Size = new System.Drawing.Size(381, 136);
                this.button2.Location = new Point(427,82);
            }
        }
        private string CurrentPath = "/";
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Application.StartupPath;
            //openFileDialog1.FileName = "version.txt";
            if (openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK) { return; }
            //MessageBox.Show(Path.GetFileName(openFileDialog1.FileName));
            OAuthUtility.PutAsync
            (
              "https://api-content.dropbox.com/1/files_put/auto/",
              new HttpParameterCollection
        {
          {"access_token", Properties.Settings.Default.AccessToken},
          {"path", Path.Combine(CurrentPath, Path.GetFileName(openFileDialog1.FileName))},
          {"overwrite", "true"},
          {"autorename","true"},
          {openFileDialog1.OpenFile()}
        },
              callback: Upload_Result
            );
        }

        private void Upload_Result(RequestResult result)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<RequestResult>(Upload_Result), result);
                return;
            }

            if (result.StatusCode == 200)
            {
                //여기에 링크...가져오는거 구현
                //UniValue file = (UniValue)listBox1.SelectedItem;
                //String.Format("https://api-content.dropbox.com/1/files/auto{0}?access_token={1}", file["path"], Properties.Settings.Default.AccessToken
            
            }
            else
            {
                if (result["error"].HasValue)
                {
                    MessageBox.Show(result["error"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(result.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
