namespace Assistant_Manager
{
    partial class Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.CB_Say = new System.Windows.Forms.CheckBox();
            this.BTN_Close = new System.Windows.Forms.Button();
            this.BTN_Cancle = new System.Windows.Forms.Button();
            this.CB_StartAuto = new System.Windows.Forms.CheckBox();
            this.GB_Set = new System.Windows.Forms.GroupBox();
            this.GB_Set.SuspendLayout();
            this.SuspendLayout();
            // 
            // CB_Say
            // 
            this.CB_Say.AutoSize = true;
            this.CB_Say.Location = new System.Drawing.Point(6, 23);
            this.CB_Say.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CB_Say.Name = "CB_Say";
            this.CB_Say.Size = new System.Drawing.Size(118, 19);
            this.CB_Say.TabIndex = 0;
            this.CB_Say.Text = "명령시 음성 재생";
            this.CB_Say.UseVisualStyleBackColor = true;
            this.CB_Say.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // BTN_Close
            // 
            this.BTN_Close.Location = new System.Drawing.Point(144, 142);
            this.BTN_Close.Name = "BTN_Close";
            this.BTN_Close.Size = new System.Drawing.Size(302, 29);
            this.BTN_Close.TabIndex = 1;
            this.BTN_Close.Text = "적용";
            this.BTN_Close.UseVisualStyleBackColor = true;
            // 
            // BTN_Cancle
            // 
            this.BTN_Cancle.Location = new System.Drawing.Point(12, 142);
            this.BTN_Cancle.Name = "BTN_Cancle";
            this.BTN_Cancle.Size = new System.Drawing.Size(126, 29);
            this.BTN_Cancle.TabIndex = 2;
            this.BTN_Cancle.Text = "취소";
            this.BTN_Cancle.UseVisualStyleBackColor = true;
            // 
            // CB_StartAuto
            // 
            this.CB_StartAuto.AutoSize = true;
            this.CB_StartAuto.Location = new System.Drawing.Point(6, 49);
            this.CB_StartAuto.Name = "CB_StartAuto";
            this.CB_StartAuto.Size = new System.Drawing.Size(158, 19);
            this.CB_StartAuto.TabIndex = 3;
            this.CB_StartAuto.Text = "윈도우 시작시 자동 실행";
            this.CB_StartAuto.UseVisualStyleBackColor = true;
            this.CB_StartAuto.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // GB_Set
            // 
            this.GB_Set.Controls.Add(this.CB_Say);
            this.GB_Set.Controls.Add(this.CB_StartAuto);
            this.GB_Set.Location = new System.Drawing.Point(12, 12);
            this.GB_Set.Name = "GB_Set";
            this.GB_Set.Size = new System.Drawing.Size(434, 124);
            this.GB_Set.TabIndex = 4;
            this.GB_Set.TabStop = false;
            this.GB_Set.Text = "Settings";
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 183);
            this.Controls.Add(this.GB_Set);
            this.Controls.Add(this.BTN_Cancle);
            this.Controls.Add(this.BTN_Close);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Setting";
            this.ShowInTaskbar = false;
            this.Text = "Setting";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Setting_Load);
            this.GB_Set.ResumeLayout(false);
            this.GB_Set.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox CB_Say;
        private System.Windows.Forms.Button BTN_Close;
        private System.Windows.Forms.Button BTN_Cancle;
        private System.Windows.Forms.CheckBox CB_StartAuto;
        private System.Windows.Forms.GroupBox GB_Set;
    }
}