namespace Assistant_Manager
{
    partial class Main_Form
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.명령어목록ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.언제나창위ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.해제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.시스템로그ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.키보드기록ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.파일변경로그ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.설정ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Assistant Manager";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.명령어목록ToolStripMenuItem,
            this.언제나창위ToolStripMenuItem,
            this.시스템로그ToolStripMenuItem,
            this.설정ToolStripMenuItem1,
            this.종료ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 114);
            // 
            // 명령어목록ToolStripMenuItem
            // 
            this.명령어목록ToolStripMenuItem.Name = "명령어목록ToolStripMenuItem";
            this.명령어목록ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.명령어목록ToolStripMenuItem.Text = "명령어 목록";
            this.명령어목록ToolStripMenuItem.Click += new System.EventHandler(this.명령어목록ToolStripMenuItem_Click);
            // 
            // 언제나창위ToolStripMenuItem
            // 
            this.언제나창위ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.설정ToolStripMenuItem,
            this.해제ToolStripMenuItem});
            this.언제나창위ToolStripMenuItem.Name = "언제나창위ToolStripMenuItem";
            this.언제나창위ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.언제나창위ToolStripMenuItem.Text = "언제나 창 위";
            // 
            // 설정ToolStripMenuItem
            // 
            this.설정ToolStripMenuItem.Name = "설정ToolStripMenuItem";
            this.설정ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.설정ToolStripMenuItem.Text = "설정";
            this.설정ToolStripMenuItem.Click += new System.EventHandler(this.설정ToolStripMenuItem_Click);
            // 
            // 해제ToolStripMenuItem
            // 
            this.해제ToolStripMenuItem.Name = "해제ToolStripMenuItem";
            this.해제ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.해제ToolStripMenuItem.Text = "해제";
            this.해제ToolStripMenuItem.Click += new System.EventHandler(this.해제ToolStripMenuItem_Click);
            // 
            // 시스템로그ToolStripMenuItem
            // 
            this.시스템로그ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.키보드기록ToolStripMenuItem,
            this.파일변경로그ToolStripMenuItem});
            this.시스템로그ToolStripMenuItem.Name = "시스템로그ToolStripMenuItem";
            this.시스템로그ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.시스템로그ToolStripMenuItem.Text = "시스템 로그";
            // 
            // 키보드기록ToolStripMenuItem
            // 
            this.키보드기록ToolStripMenuItem.Name = "키보드기록ToolStripMenuItem";
            this.키보드기록ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.키보드기록ToolStripMenuItem.Text = "키보드 기록";
            this.키보드기록ToolStripMenuItem.Click += new System.EventHandler(this.키보드입력보기ToolStripMenuItem_Click);
            // 
            // 파일변경로그ToolStripMenuItem
            // 
            this.파일변경로그ToolStripMenuItem.Name = "파일변경로그ToolStripMenuItem";
            this.파일변경로그ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.파일변경로그ToolStripMenuItem.Text = "파일 변경 로그";
            this.파일변경로그ToolStripMenuItem.Click += new System.EventHandler(this.파일변경로그ToolStripMenuItem_Click);
            // 
            // 설정ToolStripMenuItem1
            // 
            this.설정ToolStripMenuItem1.Name = "설정ToolStripMenuItem1";
            this.설정ToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.설정ToolStripMenuItem1.Text = "설정";
            this.설정ToolStripMenuItem1.Click += new System.EventHandler(this.설정ToolStripMenuItem1_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 375);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main_Form";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Form_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_Form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_Form_MouseMove);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 명령어목록ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 언제나창위ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 해제ToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem 설정ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 시스템로그ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 키보드기록ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 파일변경로그ToolStripMenuItem;
    }
}

