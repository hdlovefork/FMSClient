using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FileSystem
{
    public partial class frmPic : Form
    {
        private string path;
        public string ext;
        private string name;

        public frmPic()
        {
            InitializeComponent();
        }

        public frmPic(string p, string e, string n)
        {
            InitializeComponent();
            path = p;
            ext = e;
            name = n;
        }

        private void frmPic_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "图片文件：" + name;
                this.skinPictureBox1.Image = Image.FromFile(path);
            }
            catch { }
        }
    }
}
