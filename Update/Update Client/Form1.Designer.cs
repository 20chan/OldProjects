namespace Update_Client
{
    partial class Form1
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.Program = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Link = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Changes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CMS_ListViewRightClicked = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.추가ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.수정EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.삭제DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BTN_Add = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.내보내기SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.업로드UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.설정CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도움말HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.정보IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BTN_Server = new System.Windows.Forms.Button();
            this.CMS_ListViewRightClicked.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Program,
            this.Version,
            this.Link,
            this.Changes});
            this.listView1.ContextMenuStrip = this.CMS_ListViewRightClicked;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(12, 31);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(532, 366);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Program
            // 
            this.Program.Text = "Program";
            this.Program.Width = 136;
            // 
            // Version
            // 
            this.Version.Text = "Version";
            this.Version.Width = 65;
            // 
            // Link
            // 
            this.Link.Text = "Link";
            // 
            // Changes
            // 
            this.Changes.Text = "Changes";
            this.Changes.Width = 255;
            // 
            // CMS_ListViewRightClicked
            // 
            this.CMS_ListViewRightClicked.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMS_ListViewRightClicked.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.추가ToolStripMenuItem,
            this.수정EToolStripMenuItem,
            this.삭제DToolStripMenuItem});
            this.CMS_ListViewRightClicked.Name = "CMS_ListViewRightClicked";
            this.CMS_ListViewRightClicked.Size = new System.Drawing.Size(130, 76);
            // 
            // 추가ToolStripMenuItem
            // 
            this.추가ToolStripMenuItem.Name = "추가ToolStripMenuItem";
            this.추가ToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.추가ToolStripMenuItem.Text = "추가(&N)";
            this.추가ToolStripMenuItem.Click += new System.EventHandler(this.추가ToolStripMenuItem_Click);
            // 
            // 수정EToolStripMenuItem
            // 
            this.수정EToolStripMenuItem.Name = "수정EToolStripMenuItem";
            this.수정EToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.수정EToolStripMenuItem.Text = "수정(&E)";
            this.수정EToolStripMenuItem.Click += new System.EventHandler(this.수정EToolStripMenuItem_Click);
            // 
            // 삭제DToolStripMenuItem
            // 
            this.삭제DToolStripMenuItem.Name = "삭제DToolStripMenuItem";
            this.삭제DToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.삭제DToolStripMenuItem.Text = "삭제(&D)";
            this.삭제DToolStripMenuItem.Click += new System.EventHandler(this.삭제DToolStripMenuItem_Click);
            // 
            // BTN_Add
            // 
            this.BTN_Add.Location = new System.Drawing.Point(550, 31);
            this.BTN_Add.Name = "BTN_Add";
            this.BTN_Add.Size = new System.Drawing.Size(159, 44);
            this.BTN_Add.TabIndex = 2;
            this.BTN_Add.Text = "추가";
            this.BTN_Add.UseVisualStyleBackColor = true;
            this.BTN_Add.Click += new System.EventHandler(this.BTN_Add_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일FToolStripMenuItem,
            this.도움말HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(721, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일FToolStripMenuItem
            // 
            this.파일FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.내보내기SToolStripMenuItem,
            this.업로드UToolStripMenuItem,
            this.toolStripSeparator1,
            this.설정CToolStripMenuItem});
            this.파일FToolStripMenuItem.Name = "파일FToolStripMenuItem";
            this.파일FToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.파일FToolStripMenuItem.Text = "파일(&F)";
            // 
            // 내보내기SToolStripMenuItem
            // 
            this.내보내기SToolStripMenuItem.Name = "내보내기SToolStripMenuItem";
            this.내보내기SToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.내보내기SToolStripMenuItem.Text = "내보내기(&S)";
            this.내보내기SToolStripMenuItem.Click += new System.EventHandler(this.내보내기SToolStripMenuItem_Click);
            // 
            // 업로드UToolStripMenuItem
            // 
            this.업로드UToolStripMenuItem.Name = "업로드UToolStripMenuItem";
            this.업로드UToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.업로드UToolStripMenuItem.Text = "업로드(&U)";
            this.업로드UToolStripMenuItem.Click += new System.EventHandler(this.업로드UToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);
            // 
            // 설정CToolStripMenuItem
            // 
            this.설정CToolStripMenuItem.Name = "설정CToolStripMenuItem";
            this.설정CToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.설정CToolStripMenuItem.Text = "설정(&C)";
            this.설정CToolStripMenuItem.Click += new System.EventHandler(this.설정CToolStripMenuItem_Click);
            // 
            // 도움말HToolStripMenuItem
            // 
            this.도움말HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.정보IToolStripMenuItem});
            this.도움말HToolStripMenuItem.Name = "도움말HToolStripMenuItem";
            this.도움말HToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.도움말HToolStripMenuItem.Text = "도움말(&H)";
            // 
            // 정보IToolStripMenuItem
            // 
            this.정보IToolStripMenuItem.Name = "정보IToolStripMenuItem";
            this.정보IToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.정보IToolStripMenuItem.Text = "정보(&I)";
            this.정보IToolStripMenuItem.Click += new System.EventHandler(this.정보IToolStripMenuItem_Click);
            // 
            // BTN_Server
            // 
            this.BTN_Server.Location = new System.Drawing.Point(550, 81);
            this.BTN_Server.Name = "BTN_Server";
            this.BTN_Server.Size = new System.Drawing.Size(159, 44);
            this.BTN_Server.TabIndex = 4;
            this.BTN_Server.Text = "서버 추가";
            this.BTN_Server.UseVisualStyleBackColor = true;
            this.BTN_Server.Click += new System.EventHandler(this.BTN_Server_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 409);
            this.Controls.Add(this.BTN_Server);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.BTN_Add);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Update Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.CMS_ListViewRightClicked.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Program;
        private System.Windows.Forms.ColumnHeader Version;
        private System.Windows.Forms.ColumnHeader Link;
        private System.Windows.Forms.ColumnHeader Changes;
        private System.Windows.Forms.Button BTN_Add;
        private System.Windows.Forms.ContextMenuStrip CMS_ListViewRightClicked;
        private System.Windows.Forms.ToolStripMenuItem 추가ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 수정EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 삭제DToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 내보내기SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도움말HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 정보IToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 업로드UToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 설정CToolStripMenuItem;
        private System.Windows.Forms.Button BTN_Server;

    }
}

