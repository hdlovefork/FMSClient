namespace FileSystem
{
    partial class frmCatalogManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCatalogManage));
            this.skinPanel2 = new CCWin.SkinControl.SkinPanel();
            this.skinGroupBox1 = new CCWin.SkinControl.SkinGroupBox();
            this.skinTreeView1 = new CCWin.SkinControl.SkinTreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.skinButton2 = new CCWin.SkinControl.SkinButton();
            this.skinButton1 = new CCWin.SkinControl.SkinButton();
            this.txtFileName = new CCWin.SkinControl.SkinTextBox();
            this.skinGroupBox2 = new CCWin.SkinControl.SkinGroupBox();
            this.skinButton3 = new CCWin.SkinControl.SkinButton();
            this.label1 = new System.Windows.Forms.Label();
            this.skinPanel2.SuspendLayout();
            this.skinGroupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.txtFileName.SuspendLayout();
            this.skinGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.Controls.Add(this.skinGroupBox1);
            this.skinPanel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.skinPanel2.DownBack = null;
            this.skinPanel2.Location = new System.Drawing.Point(0, 0);
            this.skinPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skinPanel2.MouseBack = null;
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.NormlBack = null;
            this.skinPanel2.Size = new System.Drawing.Size(516, 485);
            this.skinPanel2.TabIndex = 1;
            // 
            // skinGroupBox1
            // 
            this.skinGroupBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.skinGroupBox1.BorderColor = System.Drawing.Color.Silver;
            this.skinGroupBox1.Controls.Add(this.skinTreeView1);
            this.skinGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinGroupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.skinGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.skinGroupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skinGroupBox1.Name = "skinGroupBox1";
            this.skinGroupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skinGroupBox1.RectBackColor = System.Drawing.SystemColors.Control;
            this.skinGroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.skinGroupBox1.Size = new System.Drawing.Size(516, 485);
            this.skinGroupBox1.TabIndex = 1;
            this.skinGroupBox1.TabStop = false;
            this.skinGroupBox1.Text = "功能列表(右键可以编辑节点)";
            this.skinGroupBox1.TitleBorderColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.TitleRectBackColor = System.Drawing.Color.Transparent;
            // 
            // skinTreeView1
            // 
            this.skinTreeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.skinTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTreeView1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinTreeView1.ImageIndex = 1;
            this.skinTreeView1.ImageList = this.imageList2;
            this.skinTreeView1.Location = new System.Drawing.Point(3, 29);
            this.skinTreeView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skinTreeView1.Name = "skinTreeView1";
            this.skinTreeView1.SelectedImageIndex = 0;
            this.skinTreeView1.Size = new System.Drawing.Size(510, 454);
            this.skinTreeView1.TabIndex = 0;
            this.skinTreeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.skinTreeView1_NodeMouseClick);
            this.skinTreeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.skinTreeView1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(115, 82);
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.新建ToolStripMenuItem.Text = "新建";
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.新建ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.编辑ToolStripMenuItem.Text = "编辑";
            this.编辑ToolStripMenuItem.Click += new System.EventHandler(this.编辑ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "book_open.png");
            this.imageList2.Images.SetKeyName(1, "book.png");
            this.imageList2.Images.SetKeyName(2, "folder_open.png");
            this.imageList2.Images.SetKeyName(3, "folder.png");
            // 
            // skinButton2
            // 
            this.skinButton2.BackColor = System.Drawing.Color.Transparent;
            this.skinButton2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton2.DownBack = null;
            this.skinButton2.Location = new System.Drawing.Point(175, 128);
            this.skinButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skinButton2.MouseBack = null;
            this.skinButton2.Name = "skinButton2";
            this.skinButton2.NormlBack = null;
            this.skinButton2.Size = new System.Drawing.Size(75, 35);
            this.skinButton2.TabIndex = 8;
            this.skinButton2.Text = " 放弃";
            this.skinButton2.UseVisualStyleBackColor = false;
            this.skinButton2.Click += new System.EventHandler(this.skinButton2_Click);
            // 
            // skinButton1
            // 
            this.skinButton1.BackColor = System.Drawing.Color.Transparent;
            this.skinButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton1.DownBack = null;
            this.skinButton1.Location = new System.Drawing.Point(40, 128);
            this.skinButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skinButton1.MouseBack = null;
            this.skinButton1.Name = "skinButton1";
            this.skinButton1.NormlBack = null;
            this.skinButton1.Size = new System.Drawing.Size(75, 35);
            this.skinButton1.TabIndex = 7;
            this.skinButton1.Text = "保存";
            this.skinButton1.UseVisualStyleBackColor = false;
            this.skinButton1.Click += new System.EventHandler(this.skinButton1_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.Color.Transparent;
            this.txtFileName.DownBack = null;
            this.txtFileName.Icon = null;
            this.txtFileName.IconIsButton = false;
            this.txtFileName.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtFileName.Location = new System.Drawing.Point(111, 68);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(0);
            this.txtFileName.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtFileName.MouseBack = null;
            this.txtFileName.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.NormlBack = null;
            this.txtFileName.Padding = new System.Windows.Forms.Padding(5);
            this.txtFileName.Size = new System.Drawing.Size(174, 39);
            // 
            // txtFileName.txtName
            // 
            this.txtFileName.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileName.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFileName.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtFileName.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtFileName.SkinTxt.Multiline = true;
            this.txtFileName.SkinTxt.Name = "txtName";
            this.txtFileName.SkinTxt.Size = new System.Drawing.Size(164, 29);
            this.txtFileName.SkinTxt.TabIndex = 0;
            this.txtFileName.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtFileName.SkinTxt.WaterText = "";
            this.txtFileName.TabIndex = 1;
            // 
            // skinGroupBox2
            // 
            this.skinGroupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.skinGroupBox2.BorderColor = System.Drawing.Color.Silver;
            this.skinGroupBox2.Controls.Add(this.txtFileName);
            this.skinGroupBox2.Controls.Add(this.skinButton1);
            this.skinGroupBox2.Controls.Add(this.skinButton2);
            this.skinGroupBox2.Controls.Add(this.label1);
            this.skinGroupBox2.Enabled = false;
            this.skinGroupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinGroupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.skinGroupBox2.Location = new System.Drawing.Point(522, 11);
            this.skinGroupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skinGroupBox2.Name = "skinGroupBox2";
            this.skinGroupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skinGroupBox2.RectBackColor = System.Drawing.SystemColors.Control;
            this.skinGroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.skinGroupBox2.Size = new System.Drawing.Size(303, 186);
            this.skinGroupBox2.TabIndex = 2;
            this.skinGroupBox2.TabStop = false;
            this.skinGroupBox2.Text = " 编辑目录";
            this.skinGroupBox2.TitleBorderColor = System.Drawing.Color.Transparent;
            this.skinGroupBox2.TitleRectBackColor = System.Drawing.Color.Transparent;
            // 
            // skinButton3
            // 
            this.skinButton3.BackColor = System.Drawing.Color.Transparent;
            this.skinButton3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton3.DownBack = null;
            this.skinButton3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton3.Location = new System.Drawing.Point(742, 439);
            this.skinButton3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skinButton3.MouseBack = null;
            this.skinButton3.Name = "skinButton3";
            this.skinButton3.NormlBack = null;
            this.skinButton3.Size = new System.Drawing.Size(75, 35);
            this.skinButton3.TabIndex = 8;
            this.skinButton3.Text = " 关闭";
            this.skinButton3.UseVisualStyleBackColor = false;
            this.skinButton3.Click += new System.EventHandler(this.skinButton3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 27);
            this.label1.TabIndex = 9;
            this.label1.Text = "目录名称：";
            // 
            // frmCatalogManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 485);
            this.Controls.Add(this.skinGroupBox2);
            this.Controls.Add(this.skinButton3);
            this.Controls.Add(this.skinPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCatalogManage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "目录管理";
            this.Load += new System.EventHandler(this.frmCatalogManage_Load);
            this.skinPanel2.ResumeLayout(false);
            this.skinGroupBox1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.txtFileName.ResumeLayout(false);
            this.txtFileName.PerformLayout();
            this.skinGroupBox2.ResumeLayout(false);
            this.skinGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel2;
        public CCWin.SkinControl.SkinGroupBox skinGroupBox1;
        private CCWin.SkinControl.SkinTreeView skinTreeView1;
        private CCWin.SkinControl.SkinTextBox txtFileName;
        private CCWin.SkinControl.SkinButton skinButton2;
        private CCWin.SkinControl.SkinButton skinButton1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList2;
        public CCWin.SkinControl.SkinGroupBox skinGroupBox2;
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinButton skinButton3;
    }
}