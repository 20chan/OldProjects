//
//
//                                                                  Roy's Update Client
//                                                                      version : 0.1a
// 
//                                                                   Developted by Roy.
//                                                     Copyright 2015. Roy all rights reserved.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.IO;
using Nemiro.OAuth.LoginForms;
using Nemiro.OAuth;

namespace Update_Client
{
    public partial class Form1 : Form
    {
        private string CurrentPath = "/";
        public static List<OneProgram> programs = new List<OneProgram>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("Settings.cfg");
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(sr.ReadLine());
                sr.Dispose();
                sr.Close();
                StreamReader reader = new StreamReader(stream, Encoding.Default);
                int numThatProgramIncludedInLists;

                while (reader.Peek() >= 0)
                {
                    string[] str = reader.ReadLine().Split('$');
                    do
                    {
                        int i = 0;
                        foreach (OneProgram op in programs)
                        {
                            if (op.programName == str[0])
                            {
                                numThatProgramIncludedInLists = i;
                                goto Label1;
                            }
                            i++;
                        }
                        Version version_ = new Version(Convert.ToDouble(str[1]), str[2], str[3]);
                        OneProgram op_ = new OneProgram(str[0]);
                        op_.addVersion(version_);
                        programs.Add(op_);
                        goto Label2;
                    }
                    while (false);
                Label1:
                    Version version = new Version(Convert.ToDouble(str[1]), str[2], str[3]);
                    programs[numThatProgramIncludedInLists].addVersion(version);

                Label2:
                    continue;
                }

                foreach (OneProgram op in programs)
                {
                    foreach (Version ver in op.vers)
                    {
                        ListViewItem item = new ListViewItem(op.programName);
                        //item.SubItems.Add(String.Format("{0:0.00}", ver.version));
                        item.SubItems.Add(ver.version.ToString());
                        item.SubItems.Add(ver.DownloadLink);
                        item.SubItems.Add(ver.Updated);
                        this.listView1.Items.Add(item);
                    }

                }
                //this.SortPrograms();
                reader.Close();
            }
            catch(System.Net.WebException)
            {
                MessageBox.Show("인터넷 연결이 되지 않습니다.");
            }
            if (String.IsNullOrEmpty(Properties.Settings.Default.AccessToken))
                this.GetAccessToken();
            else
                this.GetFiles();

        }

        private void GetAccessToken()
        {
            var Login = new DropboxLogin("7yquk6d8zwdffcl", "gfx5dxjy9c6ejcr");
            Login.Owner = this;
            Login.ShowDialog();
            if(Login.IsSuccessfully)
            {
                Properties.Settings.Default.AccessToken = Login.AccessToken.Value;
                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("로그인 에러");
            }
        }

        private void GetFiles()
        {
            OAuthUtility.GetAsync("https://api.dropbox.com/1/metadata/auto/", new HttpParameterCollection
                {
                    {"path", this.CurrentPath}, 
                    {"access_token", Properties.Settings.Default.AccessToken}
                },
        callback: GetFiles_Result
        );
        }

        private void GetFiles_Result(RequestResult result)
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new Action<RequestResult>(GetFiles_Result), result);
                return;
            }

            if(result.StatusCode == 200)
            {

            }
            else
            {
                MessageBox.Show("에러!!!!!!!!");
            }
        }
        
        private void BTN_Add_Click(object sender, EventArgs e)
        {
            F_Addone form = new F_Addone();
            form.stringevent += AddProgram;
            form.Show();
        }

        public void AddProgram(string programName, double vers, string link, string Updated)
        {
            List<OneProgram> pros = new List<OneProgram>();
            foreach (OneProgram p in programs)
                pros.Add(p);
            int i = 0;
            foreach (OneProgram pr in pros)
            {
                if (pr.programName == programName)
                {
                    goto Label4;
                }
                else
                {
                    i++;
                    continue;
                }
            Label4:
                programs[i].addVersion(new Version(vers, link, Updated));
            goto Label6;
            }
            programs.Add(new OneProgram(programName));
            programs[programs.Count - 1].addVersion(new Version(vers, link, Updated));
        Label6:

            //programs.Sort();
            foreach(OneProgram op in programs)
                op.vers.Sort(new VersionComparer());                                           // 버젼순서대로 정렬하기 구현하기

            this.listView1.Items.Clear();
            foreach (OneProgram op in programs)
            {
                foreach (Version ver in op.vers)
                {
                    ListViewItem item = new ListViewItem(op.programName);
                    //item.SubItems.Add(String.Format("{0:0.00}", ver.version));
                    item.SubItems.Add(ver.version.ToString());
                    item.SubItems.Add(ver.DownloadLink);
                    item.SubItems.Add(ver.Updated);
                    this.listView1.Items.Add(item);
                }
            }
            this.SortPrograms();
        }

        private void 추가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BTN_Add_Click(null, null);
        }

        private void 정보IToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Credit form = new F_Credit();
            form.Show();
        }

        private void 내보내기SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach(OneProgram op in programs)
            {
                foreach(Version vr in op.vers)
                {
                    sb.Append(op.programName + "$" + vr.version + "$" + vr.DownloadLink + "$" + vr.Updated);
                    sb.AppendLine();
                }
            }
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*.*";
            sf.FileName = "version.txt";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sf.FileName, FileMode.Create);
                StreamWriter w = new StreamWriter(fs, System.Text.Encoding.Default);
                w.BaseStream.Seek(0, SeekOrigin.Begin);
                w.Write(sb.ToString());
                w.Flush();
                w.Close();
            }
        }

        private void 삭제DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = programs.FindIndex(
                delegate(OneProgram op)
                {
                    return op.programName == this.listView1.SelectedItems[0].SubItems[0].Text;
                });
            int _index = programs[index].vers.FindIndex(
                delegate(Version vs)
                {
                    return vs.version.ToString() == this.listView1.SelectedItems[0].SubItems[1].Text;
                });
            programs[index].vers.RemoveAt(_index);
            listView1.FocusedItem.Remove();

            this.SortPrograms();
        }

        private void 업로드UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach(OneProgram op in programs)
            {
                foreach(Version vr in op.vers)
                {
                    sb.Append(op.programName + "$" + vr.version + "$" + vr.DownloadLink + "$" + vr.Updated);
                    sb.AppendLine();
                }
            }
                FileStream fs = new FileStream("version.txt", FileMode.Open);
                StreamWriter w = new StreamWriter(fs, System.Text.Encoding.Default);
                w.BaseStream.Seek(0, SeekOrigin.Begin);
                w.Write(sb.ToString());
                w.Flush();
                w.Close();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.FileName = "version.txt";
            //if (openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK) { return; }
            //MessageBox.Show(Path.GetFileName(openFileDialog1.FileName));
            OAuthUtility.PutAsync
            (
              "https://api-content.dropbox.com/1/files_put/auto/",
              new HttpParameterCollection
        {
          {"access_token", Properties.Settings.Default.AccessToken},
          {"path", Path.Combine(this.CurrentPath, Path.GetFileName(openFileDialog1.FileName))},
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
                this.GetFiles();
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

        private void 설정CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Setting form = new F_Setting();
            form.ShowDialog();
        }

        private void SortPrograms()
        {
            foreach (OneProgram op in programs)
                op.vers.Sort(new VersionComparer());
            programs.Sort(new ProgramComparer());

            this.listView1.Items.Clear();
            foreach (OneProgram op in programs)
            {
                foreach (Version ver in op.vers)
                {
                    ListViewItem item = new ListViewItem(op.programName);
                    //item.SubItems.Add(String.Format("{0:0.00}", ver.version));
                    item.SubItems.Add(ver.version.ToString());
                    item.SubItems.Add(ver.DownloadLink);
                    item.SubItems.Add(ver.Updated);
                    this.listView1.Items.Add(item);
                }

            }
        }

        private void 수정EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Addone form = new F_Addone(this.listView1.FocusedItem.SubItems[0].Text, Convert.ToDouble(this.listView1.FocusedItem.SubItems[1].Text), this.listView1.FocusedItem.SubItems[2].Text, this.listView1.FocusedItem.SubItems[3].Text);
            form.stringevent += AddProgram;
            form.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = programs.FindLastIndex(
                delegate(OneProgram op)
                {
                    return op.programName == this.listView1.SelectedItems[0].SubItems[0].Text;
                });
            int _index = programs[index].vers.FindLastIndex(
                delegate(Version vs)
                {
                    return vs.version == Convert.ToDouble(this.listView1.SelectedItems[0].SubItems[1].Text);
                });
            if (programs[index].vers[_index].hasServer)
                this.BTN_Server.Text = "서버 추가";
            else
                this.BTN_Server.Text = "서버 관리";
            
        }

        private void BTN_Server_Click(object sender, EventArgs e)
        {
            if(this.BTN_Server.Text.StartsWith("서버 추가"))
            {
                F_AddServer form = new F_AddServer();
                form.Show();
            }
            else
            {

            }
        }
    }

    public class OneProgram
    {
        //private bool hasServer = false;
        public string programName;
        public List<Version> vers = new List<Version>();

        public OneProgram(string name)
        {
            programName = name;
        }

        public void addVersion(Version ver)
        {
            foreach (Version v in vers)
                if (ver.version == v.version)
                {
                    EditVersion(ver); return;
                }
            vers.Add(ver);
        }

        private void EditVersion(Version ver)
        {
            int i = vers.FindIndex(delegate(Version vs)
            {
                return vs.version == ver.version;
            }
            );
            vers[i] = ver;

        }

        public Version newistVersion()
        {
            Version newistOne = new Version(0);
            foreach(Version v in vers)
            {
                if (v.version > newistOne.version)
                    newistOne = v;
            }
            return newistOne;
        }
    }

    public class Version
    {
        public bool hasServer = false;
        public Server server;

        public double version;
        public string DownloadLink;
        public string Updated;
        public Version(double vers, string link = "", string Updated = "")
        {
            version = vers;
            DownloadLink = link;
            this.Updated = Updated;
        }

        public void makeServer(Server serv)
        {
            this.hasServer = true;
            this.server = serv;
        }
        public void removeServer()
        {
            this.hasServer = false;
            this.server.Clear();
        }
        
    }
    
    public class VersionComparer : IComparer<Version>
    {
        public VersionComparer()
        {
        }

        public int Compare(Version x, Version y)
        {
            return string.Compare(((Version)x).version.ToString(), ((Version)y).version.ToString());
        }
    }

    public class ProgramComparer : IComparer<OneProgram>
    {
        public ProgramComparer()
        {
        }

        public int Compare(OneProgram x, OneProgram y)
        {
            return string.Compare(x.programName, y.programName);
        }
    }

    public class Server
    {
        public string serverDirectory = string.Empty;
        private int width = 0;
        private int height = 0;
        public Server(string directory = "", int w = 0, int h = 0)
        {
            this.serverDirectory = directory;
            width = w;
            height = h;
        }

        public void Clear()
        {
            this.serverDirectory = string.Empty;
            this.width = 0;
            this.height = 0;
        }

        public void Set(string directory = "", int w = 0, int h = 0)
        {
            this.serverDirectory = directory;
            width = w;
            height = h;
        }
    }
}