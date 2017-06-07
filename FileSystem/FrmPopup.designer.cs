namespace FileSystem
{
    partial class FrmPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPopup));
            this.lblContent = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinPictureBox1 = new CCWin.SkinControl.SkinPictureBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblContent
            // 
            this.lblContent.BackColor = System.Drawing.Color.Transparent;
            this.lblContent.BorderColor = System.Drawing.Color.White;
            this.lblContent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblContent.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblContent.Location = new System.Drawing.Point(29, 50);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(168, 51);
            this.lblContent.TabIndex = 0;
            this.lblContent.Text = "小张给您分享了一个文档";
            this.lblContent.Click += new System.EventHandler(this.FrmPopup_Click);
            // 
            // skinLabel2
            // 
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(10, 109);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(206, 1);
            this.skinLabel2.TabIndex = 1;
            this.skinLabel2.Text = "skinLabel2";
            // 
            // skinPictureBox1
            // 
            this.skinPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.skinPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("skinPictureBox1.Image")));
            this.skinPictureBox1.Location = new System.Drawing.Point(151, 116);
            this.skinPictureBox1.Name = "skinPictureBox1";
            this.skinPictureBox1.Size = new System.Drawing.Size(37, 27);
            this.skinPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.skinPictureBox1.TabIndex = 2;
            this.skinPictureBox1.TabStop = false;
            this.skinPictureBox1.Click += new System.EventHandler(this.FrmPopup_Click);
            // 
            // skinLabel1
            // 
            this.skinLabel1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.skinLabel1.Location = new System.Drawing.Point(181, 119);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(36, 17);
            this.skinLabel1.TabIndex = 3;
            this.skinLabel1.Text = " 查看";
            this.skinLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.skinLabel1.Click += new System.EventHandler(this.FrmPopup_Click);
            // 
            // FrmPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackShade = false;
            this.BackToColor = false;
            this.ClientSize = new System.Drawing.Size(227, 150);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.skinPictureBox1);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.lblContent);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Mobile = CCWin.MobileStyle.None;
            this.Name = "FrmPopup";
            this.ShowBorder = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = " 新消息";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPopup_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPopup_FormClosed);
            this.Load += new System.EventHandler(this.FrmPopup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox1;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinLabel lblContent;
    }
}