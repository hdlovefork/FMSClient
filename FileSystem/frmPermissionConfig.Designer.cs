namespace FileSystem
{
    partial class frmPermissionConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPermissionConfig));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvPermission = new EXControls.EXListView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddDep = new System.Windows.Forms.Button();
            this.cxtMenuDep = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.cxtMenuUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvPermission);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 394);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "借阅给以下部门或用户：";
            // 
            // lvPermission
            // 
            this.lvPermission.ControlPadding = 4;
            this.lvPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPermission.FullRowSelect = true;
            this.lvPermission.Location = new System.Drawing.Point(3, 21);
            this.lvPermission.Name = "lvPermission";
            this.lvPermission.OwnerDraw = true;
            this.lvPermission.Size = new System.Drawing.Size(556, 370);
            this.lvPermission.TabIndex = 0;
            this.lvPermission.UseCompatibleStateImageBehavior = false;
            this.lvPermission.View = System.Windows.Forms.View.Details;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnCancel.Location = new System.Drawing.Point(590, 369);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 32);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = " 取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnAddDep
            // 
            this.btnAddDep.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAddDep.ContextMenuStrip = this.cxtMenuDep;
            this.btnAddDep.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddDep.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnAddDep.Location = new System.Drawing.Point(590, 33);
            this.btnAddDep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddDep.Name = "btnAddDep";
            this.btnAddDep.Size = new System.Drawing.Size(108, 32);
            this.btnAddDep.TabIndex = 4;
            this.btnAddDep.Text = " 添加部门";
            this.btnAddDep.UseVisualStyleBackColor = false;
            this.btnAddDep.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAddDep_MouseDown);
            // 
            // cxtMenuDep
            // 
            this.cxtMenuDep.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cxtMenuDep.Name = "cxtMenuDep";
            this.cxtMenuDep.Size = new System.Drawing.Size(67, 4);
            this.cxtMenuDep.Opening += new System.ComponentModel.CancelEventHandler(this.cxtMenuDep_Opening);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnOK.Location = new System.Drawing.Point(590, 326);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(108, 32);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = " 确定";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cxtMenuUser
            // 
            this.cxtMenuUser.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cxtMenuUser.Name = "cxtMenuDep";
            this.cxtMenuUser.Size = new System.Drawing.Size(67, 4);
            this.cxtMenuUser.Opening += new System.ComponentModel.CancelEventHandler(this.cxtMenuUser_Opening);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Black;
            this.imageList1.Images.SetKeyName(0, "dep");
            this.imageList1.Images.SetKeyName(1, "user");
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAddUser.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddUser.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnAddUser.Location = new System.Drawing.Point(590, 81);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(108, 32);
            this.btnAddUser.TabIndex = 4;
            this.btnAddUser.Text = " 添加用户";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAddUser_MouseDown);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRemove.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRemove.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnRemove.Location = new System.Drawing.Point(590, 129);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(108, 32);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = " 移除选中";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // frmPermissionConfig
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(721, 410);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.btnAddDep);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPermissionConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 借阅设置";
            this.Load += new System.EventHandler(this.frmPermissionConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddDep;
        private System.Windows.Forms.Button btnOK;
        private EXControls.EXListView lvPermission;
        private System.Windows.Forms.ContextMenuStrip cxtMenuDep;
        private System.Windows.Forms.ContextMenuStrip cxtMenuUser;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnRemove;
    }
}