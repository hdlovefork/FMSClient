using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileSystem
{
    public partial class frmTxt : Form
    {
        private string path;
        public string ext;
        private string name;

        public frmTxt()
        {
            InitializeComponent();
        }

        public frmTxt(string p, string e, string n)
        {
            InitializeComponent();
            path = p;
            ext = e;
            name = n;
        }

        private void frmTxt_Load(object sender, EventArgs e)
        {
            this.Text = "记事本文件：" + name;
            string[] lines = File.ReadAllLines(path, UnicodeEncoding.GetEncoding("GB2312"));
            // 先清空textBox1
            this.richTextBox1.Clear();
            // 在textBox1中显示
            foreach (string line in lines)
            {
                richTextBox1.AppendText(line + Environment.NewLine);
            }
        }
    }
}
