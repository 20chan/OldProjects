using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using WinHttp;

namespace TvpleCloudArtMaker
{
    public partial class Load : MaterialForm
    {
        public static bool isReady = false;
        public Load()
        {
            InitializeComponent();
        }

        private bool CheckCorrectLink()
        {
            if (!this.materialSingleLineTextField1.Text.StartsWith("http://tvple.com/"))
                return false;
            if (!this.materialSingleLineTextField2.Text.StartsWith("http://api.tvple.com/v1/player/cloud/write?"))
                return false;
            try
            {
                WinHttpRequest Winhttp = new WinHttpRequest();

                Winhttp.Open("GET", this.materialSingleLineTextField1.Text);
                Winhttp.Send();
                Winhttp.WaitForResponse();
                string result = Encoding.UTF8.GetString(Winhttp.ResponseBody);

                string[] Separators = new string[] { "fa fa-fw fa-television" };
                string[] strResults = result.Split(Separators, StringSplitOptions.None);

                string[] results1 = strResults[1].Split(new string[] { "</span>" }, StringSplitOptions.None);
                string[] size = results1[1].Split(new string[] { "</li>" }, StringSplitOptions.None);
                string finalsize = size[0];

                int x = Convert.ToInt32(System.Text.RegularExpressions.Regex.Replace(finalsize.Split('x')[0], @"\D", ""));
                int y = Convert.ToInt32(System.Text.RegularExpressions.Regex.Replace(finalsize.Split('x')[1], @"\D", ""));
            }
            catch { return false; }



            return true;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (!CheckCorrectLink()) { MessageBox.Show("링크 값이 잘못되었습니다."); return; }
            Form1.headerLink = this.materialSingleLineTextField2.Text;
            Form1.tvpleLink = this.materialSingleLineTextField1.Text;
            isReady = true;
            this.Close();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            Process.Start("http://blog.naver.com/cubemit314/220434885795");
        }
    }
}
