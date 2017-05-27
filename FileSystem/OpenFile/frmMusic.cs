using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FileSystem
{
    public partial class frmMusic : Form
    {
        private string path;
        public string ext;
        private string name;
        public frmMusic()
        {
            InitializeComponent();
        }

        public frmMusic(string p, string e, string n)
        {
            InitializeComponent();
            path = p;
            ext = e;
            name = n;
        }

        private void frmMusic_Load(object sender, EventArgs e)
        {
            this.Text = "媒体影音：" + name;
            axWindowsMediaPlayer1.URL = path;
            axWindowsMediaPlayer1.Ctlcontrols.play();//播放文件
        }

    }
}
