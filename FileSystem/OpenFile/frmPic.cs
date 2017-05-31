using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        private void SkinPictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            skinPictureBox1.Width += e.Delta;
            skinPictureBox1.Height += e.Delta;
            //Debug.WriteLine(e.Delta);
            //int width = skinPictureBox1.Image.Width + e.Delta;
            //int height = skinPictureBox1.Image.Height + e.Delta;
            //skinPictureBox1.Image = skinPictureBox1.Image.AdjImageToFitSize(width, height);
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
            skinPictureBox1.MouseWheel += SkinPictureBox1_MouseWheel;
        }

        private int _downX = 0;
        private int _downY = 0;
        private bool _moveing = false;
        private void skinPictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _downX = e.X;
            _downY = e.Y;
            this.skinPictureBox1.Focus();
            _moveing = true;
        }

        private void skinPictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _moveing = false;
        }

        private void skinPictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_moveing) return;
            //Debug.WriteLine("X:{0},Y:{1},_downX:{2},_downY:{3},offsetX:{4},offsetY:{5}",e.X,e.Y,_downX,_downY, e.X - _downX,e.Y-_downY);
            skinPictureBox1.Left += (e.X - _downX);
            skinPictureBox1.Top += (e.Y - _downY);
        }
    }
}
