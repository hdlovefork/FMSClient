namespace FileSystem
{
    partial class frmOffice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOffice));
            this.axFramerControl2 = new AxDSOFramer.AxFramerControl();
            ((System.ComponentModel.ISupportInitialize)(this.axFramerControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // axFramerControl2
            // 
            this.axFramerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axFramerControl2.Enabled = true;
            this.axFramerControl2.Location = new System.Drawing.Point(0, 0);
            this.axFramerControl2.Name = "axFramerControl2";
            this.axFramerControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axFramerControl2.OcxState")));
            this.axFramerControl2.Size = new System.Drawing.Size(1262, 753);
            this.axFramerControl2.TabIndex = 0;
            // 
            // frmOffice
            // 
            this.ClientSize = new System.Drawing.Size(1262, 753);
            this.Controls.Add(this.axFramerControl2);
            this.Name = "frmOffice";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axFramerControl2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private AxDSOFramer.AxFramerControl axFramerControl1;
        private AxDSOFramer.AxFramerControl axFramerControl1;
        private AxDSOFramer.AxFramerControl axFramerControl2;
    }
}