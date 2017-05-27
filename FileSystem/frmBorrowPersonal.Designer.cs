namespace FileSystem
{
    partial class frmBorrowPersonal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBorrowPersonal));
            this.skinGroupBox1 = new CCWin.SkinControl.SkinGroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.skinListBox1 = new CCWin.SkinControl.SkinListBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.skinGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinGroupBox1
            // 
            this.skinGroupBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.skinGroupBox1.BorderColor = System.Drawing.SystemColors.Menu;
            this.skinGroupBox1.Controls.Add(this.button2);
            this.skinGroupBox1.Controls.Add(this.button1);
            this.skinGroupBox1.Controls.Add(this.skinListBox1);
            this.skinGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinGroupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.skinGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.skinGroupBox1.Name = "skinGroupBox1";
            this.skinGroupBox1.RectBackColor = System.Drawing.SystemColors.Menu;
            this.skinGroupBox1.Size = new System.Drawing.Size(252, 253);
            this.skinGroupBox1.TabIndex = 0;
            this.skinGroupBox1.TabStop = false;
            this.skinGroupBox1.Text = "请选择借阅的用户";
            this.skinGroupBox1.TitleBorderColor = System.Drawing.SystemColors.MenuBar;
            this.skinGroupBox1.TitleRectBackColor = System.Drawing.SystemColors.Menu;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(136, 217);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // skinListBox1
            // 
            this.skinListBox1.Back = null;
            this.skinListBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinListBox1.FormattingEnabled = true;
            this.skinListBox1.ItemHeight = 30;
            this.skinListBox1.Location = new System.Drawing.Point(3, 22);
            this.skinListBox1.MouseColor = System.Drawing.Color.CornflowerBlue;
            this.skinListBox1.Name = "skinListBox1";
            this.skinListBox1.RowBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.skinListBox1.SelectedColor = System.Drawing.SystemColors.Highlight;
            this.skinListBox1.Size = new System.Drawing.Size(246, 184);
            this.skinListBox1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "group_go.png");
            // 
            // frmBorrowPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 253);
            this.Controls.Add(this.skinGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBorrowPersonal";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "个人借阅";
            this.Load += new System.EventHandler(this.frmBorrowPersonal_Load);
            this.skinGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinGroupBox skinGroupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private CCWin.SkinControl.SkinListBox skinListBox1;
        private System.Windows.Forms.ImageList imageList1;
    }
}