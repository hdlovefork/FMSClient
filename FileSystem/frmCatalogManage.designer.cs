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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.skinGroupBox2 = new CCWin.SkinControl.SkinGroupBox();
            this.skinButton2 = new CCWin.SkinControl.SkinButton();
            this.skinButton1 = new CCWin.SkinControl.SkinButton();
            this.skinTextBox1 = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinPanel2.SuspendLayout();
            this.skinGroupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.skinGroupBox2.SuspendLayout();
            this.skinTextBox1.SuspendLayout();
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
            this.skinGroupBox1.BorderColor = System.Drawing.Color.Transparent;
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
            this.skinTreeView1.ImageList = this.imageList1;
            this.skinTreeView1.Location = new System.Drawing.Point(3, 29);
            this.skinTreeView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skinTreeView1.Name = "skinTreeView1";
            this.skinTreeView1.SelectedImageIndex = 0;
            this.skinTreeView1.Size = new System.Drawing.Size(510, 454);
            this.skinTreeView1.TabIndex = 0;
            this.skinTreeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.skinTreeView1_NodeMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(182, 110);
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.新建ToolStripMenuItem.Text = "新建";
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.新建ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.编辑ToolStripMenuItem.Text = "编辑";
            this.编辑ToolStripMenuItem.Click += new System.EventHandler(this.编辑ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder_open.png");
            this.imageList1.Images.SetKeyName(1, "folder.png");
            // 
            // skinGroupBox2
            // 
            this.skinGroupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.skinGroupBox2.BorderColor = System.Drawing.Color.Transparent;
            this.skinGroupBox2.Controls.Add(this.skinButton2);
            this.skinGroupBox2.Controls.Add(this.skinButton1);
            this.skinGroupBox2.Controls.Add(this.skinTextBox1);
            this.skinGroupBox2.Controls.Add(this.skinLabel1);
            this.skinGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinGroupBox2.Enabled = false;
            this.skinGroupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinGroupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.skinGroupBox2.Location = new System.Drawing.Point(516, 0);
            this.skinGroupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skinGroupBox2.Name = "skinGroupBox2";
            this.skinGroupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skinGroupBox2.RectBackColor = System.Drawing.SystemColors.Control;
            this.skinGroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.skinGroupBox2.Size = new System.Drawing.Size(321, 485);
            this.skinGroupBox2.TabIndex = 2;
            this.skinGroupBox2.TabStop = false;
            this.skinGroupBox2.Text = "功能详细信息";
            this.skinGroupBox2.TitleBorderColor = System.Drawing.Color.Transparent;
            this.skinGroupBox2.TitleRectBackColor = System.Drawing.Color.Transparent;
            // 
            // skinButton2
            // 
            this.skinButton2.BackColor = System.Drawing.Color.Transparent;
            this.skinButton2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton2.DownBack = null;
            this.skinButton2.Location = new System.Drawing.Point(171, 189);
            this.skinButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skinButton2.MouseBack = null;
            this.skinButton2.Name = "skinButton2";
            this.skinButton2.NormlBack = null;
            this.skinButton2.Size = new System.Drawing.Size(75, 35);
            this.skinButton2.TabIndex = 8;
            this.skinButton2.Text = "放弃";
            this.skinButton2.UseVisualStyleBackColor = false;
            this.skinButton2.Click += new System.EventHandler(this.skinButton2_Click);
            // 
            // skinButton1
            // 
            this.skinButton1.BackColor = System.Drawing.Color.Transparent;
            this.skinButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton1.DownBack = null;
            this.skinButton1.Location = new System.Drawing.Point(59, 189);
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
            // skinTextBox1
            // 
            this.skinTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox1.DownBack = null;
            this.skinTextBox1.Icon = null;
            this.skinTextBox1.IconIsButton = false;
            this.skinTextBox1.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox1.Location = new System.Drawing.Point(12, 115);
            this.skinTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox1.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox1.MouseBack = null;
            this.skinTextBox1.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox1.Name = "skinTextBox1";
            this.skinTextBox1.NormlBack = null;
            this.skinTextBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.skinTextBox1.Size = new System.Drawing.Size(289, 40);
            // 
            // skinTextBox1.BaseText
            // 
            this.skinTextBox1.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox1.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox1.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox1.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox1.SkinTxt.Multiline = true;
            this.skinTextBox1.SkinTxt.Name = "BaseText";
            this.skinTextBox1.SkinTxt.Size = new System.Drawing.Size(279, 30);
            this.skinTextBox1.SkinTxt.TabIndex = 0;
            this.skinTextBox1.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox1.SkinTxt.WaterText = "";
            this.skinTextBox1.TabIndex = 1;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(7, 68);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(166, 27);
            this.skinLabel1.TabIndex = 0;
            this.skinLabel1.Text = "文件夹名称（*）:";
            // 
            // frmCatalogManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 485);
            this.Controls.Add(this.skinGroupBox2);
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
            this.skinGroupBox2.ResumeLayout(false);
            this.skinGroupBox2.PerformLayout();
            this.skinTextBox1.ResumeLayout(false);
            this.skinTextBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel2;
        public CCWin.SkinControl.SkinGroupBox skinGroupBox1;
        private CCWin.SkinControl.SkinTreeView skinTreeView1;
        public CCWin.SkinControl.SkinGroupBox skinGroupBox2;
        private CCWin.SkinControl.SkinTextBox skinTextBox1;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinButton skinButton2;
        private CCWin.SkinControl.SkinButton skinButton1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;


    }
}