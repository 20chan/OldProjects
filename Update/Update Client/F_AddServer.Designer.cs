namespace Update_Client
{
    partial class F_AddServer
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
            this.BTN_GenerateText = new System.Windows.Forms.Button();
            this.TB_Link = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // BTN_GenerateText
            // 
            this.BTN_GenerateText.Location = new System.Drawing.Point(650, 10);
            this.BTN_GenerateText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTN_GenerateText.Name = "BTN_GenerateText";
            this.BTN_GenerateText.Size = new System.Drawing.Size(110, 31);
            this.BTN_GenerateText.TabIndex = 0;
            this.BTN_GenerateText.Text = "Make";
            this.BTN_GenerateText.UseVisualStyleBackColor = true;
            // 
            // TB_Link
            // 
            this.TB_Link.Location = new System.Drawing.Point(69, 12);
            this.TB_Link.Name = "TB_Link";
            this.TB_Link.Size = new System.Drawing.Size(575, 27);
            this.TB_Link.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Link : ";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(722, 69);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(38, 30);
            this.vScrollBar1.TabIndex = 3;
            // 
            // F_AddServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 388);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_Link);
            this.Controls.Add(this.BTN_GenerateText);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "F_AddServer";
            this.Text = "서버 추가";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_GenerateText;
        private System.Windows.Forms.TextBox TB_Link;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}