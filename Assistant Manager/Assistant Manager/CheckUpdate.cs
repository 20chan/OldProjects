using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckUpdate;

namespace Assistant_Manager
{
    public partial class CheckUpdate : Form
    {
        public static bool isUpdating = false;
        public const string AppName = "Assistant";
        public const float CurrentVersion = 0.06f;




        public CheckUpdate()
        {
            InitializeComponent();
        }

        private void CheckUpdate_Shown(object sender, EventArgs e)
        {
            DoUpdate();
            this.Close();
        }

        private void DoUpdate()
        {
            UpdateChecker updateChecker = new UpdateChecker(AppName);
            VERSION NewistVersion = updateChecker.Get();
            if (!NewistVersion.SUCCEED)
            {
                MessageBox.Show("업데이트를 확인할 수 없습니다!", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NewistVersion.Version > CurrentVersion)
            {
                if (MessageBox.Show("업데이트 하시겠습니까?", "업데이트", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(NewistVersion.DownloadLink);
                    isUpdating = true;
                }
            }
        }

        private void CheckUpdate_Load(object sender, EventArgs e)
        {
            this.Size = new Size(0, 0);
        }
    }
}
