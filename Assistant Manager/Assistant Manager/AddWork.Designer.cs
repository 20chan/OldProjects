namespace Assistant_Manager
{
    partial class AddWork
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddWork));
            this.TB_Program = new System.Windows.Forms.TextBox();
            this.TB_Args = new System.Windows.Forms.TextBox();
            this.LB_Program = new System.Windows.Forms.Label();
            this.LB_Args = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.RB_Program = new System.Windows.Forms.RadioButton();
            this.RB_Close = new System.Windows.Forms.RadioButton();
            this.RB_SendKey = new System.Windows.Forms.RadioButton();
            this.LB_Keys = new System.Windows.Forms.Label();
            this.TB_Keys = new System.Windows.Forms.TextBox();
            this.BTN_Browse_Program = new System.Windows.Forms.Button();
            this.BTN_Browse_Args = new System.Windows.Forms.Button();
            this.RB_Start = new System.Windows.Forms.RadioButton();
            this.RB_Stop = new System.Windows.Forms.RadioButton();
            this.RB_Say = new System.Windows.Forms.RadioButton();
            this.LB_Say = new System.Windows.Forms.Label();
            this.TB_Say = new System.Windows.Forms.TextBox();
            this.GB_Work = new System.Windows.Forms.GroupBox();
            this.GB_Work.SuspendLayout();
            this.SuspendLayout();
            // 
            // TB_Program
            // 
            this.TB_Program.Location = new System.Drawing.Point(213, 71);
            this.TB_Program.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TB_Program.Name = "TB_Program";
            this.TB_Program.Size = new System.Drawing.Size(260, 23);
            this.TB_Program.TabIndex = 1;
            // 
            // TB_Args
            // 
            this.TB_Args.Location = new System.Drawing.Point(213, 97);
            this.TB_Args.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TB_Args.Name = "TB_Args";
            this.TB_Args.Size = new System.Drawing.Size(260, 23);
            this.TB_Args.TabIndex = 2;
            // 
            // LB_Program
            // 
            this.LB_Program.AutoSize = true;
            this.LB_Program.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.LB_Program.Location = new System.Drawing.Point(143, 74);
            this.LB_Program.Name = "LB_Program";
            this.LB_Program.Size = new System.Drawing.Size(64, 15);
            this.LB_Program.TabIndex = 4;
            this.LB_Program.Text = "Program : ";
            // 
            // LB_Args
            // 
            this.LB_Args.AutoSize = true;
            this.LB_Args.Location = new System.Drawing.Point(143, 100);
            this.LB_Args.Name = "LB_Args";
            this.LB_Args.Size = new System.Drawing.Size(42, 15);
            this.LB_Args.TabIndex = 5;
            this.LB_Args.Text = "Args : ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(163, 328);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(457, 26);
            this.button1.TabIndex = 6;
            this.button1.Text = "추가";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 328);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 26);
            this.button2.TabIndex = 7;
            this.button2.Text = "취소";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RB_Program
            // 
            this.RB_Program.AutoSize = true;
            this.RB_Program.Location = new System.Drawing.Point(18, 72);
            this.RB_Program.Name = "RB_Program";
            this.RB_Program.Size = new System.Drawing.Size(101, 19);
            this.RB_Program.TabIndex = 8;
            this.RB_Program.Text = "프로그램 실행";
            this.RB_Program.UseVisualStyleBackColor = true;
            this.RB_Program.CheckedChanged += new System.EventHandler(this.RB_Program_CheckedChanged);
            // 
            // RB_Close
            // 
            this.RB_Close.AutoSize = true;
            this.RB_Close.Location = new System.Drawing.Point(15, 136);
            this.RB_Close.Name = "RB_Close";
            this.RB_Close.Size = new System.Drawing.Size(105, 19);
            this.RB_Close.TabIndex = 9;
            this.RB_Close.Text = "최상위 창 종료";
            this.RB_Close.UseVisualStyleBackColor = true;
            this.RB_Close.CheckedChanged += new System.EventHandler(this.RB_Program_CheckedChanged);
            // 
            // RB_SendKey
            // 
            this.RB_SendKey.AutoSize = true;
            this.RB_SendKey.Location = new System.Drawing.Point(15, 161);
            this.RB_SendKey.Name = "RB_SendKey";
            this.RB_SendKey.Size = new System.Drawing.Size(89, 19);
            this.RB_SendKey.TabIndex = 10;
            this.RB_SendKey.Text = "키보드 입력";
            this.RB_SendKey.UseVisualStyleBackColor = true;
            this.RB_SendKey.CheckedChanged += new System.EventHandler(this.RB_Program_CheckedChanged);
            // 
            // LB_Keys
            // 
            this.LB_Keys.AutoSize = true;
            this.LB_Keys.Location = new System.Drawing.Point(143, 163);
            this.LB_Keys.Name = "LB_Keys";
            this.LB_Keys.Size = new System.Drawing.Size(42, 15);
            this.LB_Keys.TabIndex = 12;
            this.LB_Keys.Text = "Keys : ";
            // 
            // TB_Keys
            // 
            this.TB_Keys.Location = new System.Drawing.Point(213, 160);
            this.TB_Keys.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TB_Keys.Name = "TB_Keys";
            this.TB_Keys.Size = new System.Drawing.Size(260, 23);
            this.TB_Keys.TabIndex = 11;
            // 
            // BTN_Browse_Program
            // 
            this.BTN_Browse_Program.Location = new System.Drawing.Point(479, 70);
            this.BTN_Browse_Program.Name = "BTN_Browse_Program";
            this.BTN_Browse_Program.Size = new System.Drawing.Size(103, 24);
            this.BTN_Browse_Program.TabIndex = 13;
            this.BTN_Browse_Program.Text = "찾아보기";
            this.BTN_Browse_Program.UseVisualStyleBackColor = true;
            this.BTN_Browse_Program.Click += new System.EventHandler(this.BTN_Browse_Program_Click);
            // 
            // BTN_Browse_Args
            // 
            this.BTN_Browse_Args.Location = new System.Drawing.Point(479, 95);
            this.BTN_Browse_Args.Name = "BTN_Browse_Args";
            this.BTN_Browse_Args.Size = new System.Drawing.Size(103, 24);
            this.BTN_Browse_Args.TabIndex = 14;
            this.BTN_Browse_Args.Text = "찾아보기";
            this.BTN_Browse_Args.UseVisualStyleBackColor = true;
            this.BTN_Browse_Args.Click += new System.EventHandler(this.BTN_Browse_Args_Click);
            // 
            // RB_Start
            // 
            this.RB_Start.AutoSize = true;
            this.RB_Start.Location = new System.Drawing.Point(18, 22);
            this.RB_Start.Name = "RB_Start";
            this.RB_Start.Size = new System.Drawing.Size(105, 19);
            this.RB_Start.TabIndex = 15;
            this.RB_Start.Text = "비서 작동 시작";
            this.RB_Start.UseVisualStyleBackColor = true;
            this.RB_Start.CheckedChanged += new System.EventHandler(this.RB_Program_CheckedChanged);
            // 
            // RB_Stop
            // 
            this.RB_Stop.AutoSize = true;
            this.RB_Stop.Location = new System.Drawing.Point(18, 47);
            this.RB_Stop.Name = "RB_Stop";
            this.RB_Stop.Size = new System.Drawing.Size(105, 19);
            this.RB_Stop.TabIndex = 16;
            this.RB_Stop.Text = "비서 작동 중지";
            this.RB_Stop.UseVisualStyleBackColor = true;
            this.RB_Stop.CheckedChanged += new System.EventHandler(this.RB_Program_CheckedChanged);
            // 
            // RB_Say
            // 
            this.RB_Say.AutoSize = true;
            this.RB_Say.Location = new System.Drawing.Point(15, 186);
            this.RB_Say.Name = "RB_Say";
            this.RB_Say.Size = new System.Drawing.Size(61, 19);
            this.RB_Say.TabIndex = 17;
            this.RB_Say.Text = "말하기";
            this.RB_Say.UseVisualStyleBackColor = true;
            this.RB_Say.CheckedChanged += new System.EventHandler(this.RB_Program_CheckedChanged);
            // 
            // LB_Say
            // 
            this.LB_Say.AutoSize = true;
            this.LB_Say.Location = new System.Drawing.Point(145, 188);
            this.LB_Say.Name = "LB_Say";
            this.LB_Say.Size = new System.Drawing.Size(40, 15);
            this.LB_Say.TabIndex = 19;
            this.LB_Say.Text = "Text : ";
            // 
            // TB_Say
            // 
            this.TB_Say.Location = new System.Drawing.Point(213, 185);
            this.TB_Say.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TB_Say.Name = "TB_Say";
            this.TB_Say.Size = new System.Drawing.Size(260, 23);
            this.TB_Say.TabIndex = 18;
            // 
            // GB_Work
            // 
            this.GB_Work.Controls.Add(this.RB_Start);
            this.GB_Work.Controls.Add(this.RB_Say);
            this.GB_Work.Controls.Add(this.TB_Program);
            this.GB_Work.Controls.Add(this.LB_Say);
            this.GB_Work.Controls.Add(this.TB_Args);
            this.GB_Work.Controls.Add(this.TB_Say);
            this.GB_Work.Controls.Add(this.LB_Program);
            this.GB_Work.Controls.Add(this.RB_Stop);
            this.GB_Work.Controls.Add(this.LB_Args);
            this.GB_Work.Controls.Add(this.RB_Program);
            this.GB_Work.Controls.Add(this.BTN_Browse_Args);
            this.GB_Work.Controls.Add(this.RB_Close);
            this.GB_Work.Controls.Add(this.BTN_Browse_Program);
            this.GB_Work.Controls.Add(this.TB_Keys);
            this.GB_Work.Controls.Add(this.RB_SendKey);
            this.GB_Work.Controls.Add(this.LB_Keys);
            this.GB_Work.Location = new System.Drawing.Point(15, 12);
            this.GB_Work.Name = "GB_Work";
            this.GB_Work.Size = new System.Drawing.Size(605, 310);
            this.GB_Work.TabIndex = 20;
            this.GB_Work.TabStop = false;
            this.GB_Work.Text = "작업";
            // 
            // AddWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 374);
            this.Controls.Add(this.GB_Work);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AddWork";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "명령 추가 : ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AddWork_Load);
            this.GB_Work.ResumeLayout(false);
            this.GB_Work.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox TB_Program;
        private System.Windows.Forms.TextBox TB_Args;
        private System.Windows.Forms.Label LB_Program;
        private System.Windows.Forms.Label LB_Args;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton RB_Program;
        private System.Windows.Forms.RadioButton RB_Close;
        private System.Windows.Forms.RadioButton RB_SendKey;
        private System.Windows.Forms.Label LB_Keys;
        private System.Windows.Forms.TextBox TB_Keys;
        private System.Windows.Forms.Button BTN_Browse_Program;
        private System.Windows.Forms.Button BTN_Browse_Args;
        private System.Windows.Forms.RadioButton RB_Start;
        private System.Windows.Forms.RadioButton RB_Stop;
        private System.Windows.Forms.RadioButton RB_Say;
        private System.Windows.Forms.Label LB_Say;
        private System.Windows.Forms.TextBox TB_Say;
        private System.Windows.Forms.GroupBox GB_Work;
    }
}