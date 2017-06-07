/**************************************************************** 
 * 作    者：陶湘程
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2017-05-11 14:13:04 
 * 当前版本：1.0.0.0
 *  
 * 描述说明： 
 * 
 * 修改历史： 
 * 
***************************************************************** 
 * Copyright @ Dean 2017 All rights reserved 
*****************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PanGu;
using FileSystem.BLL;

namespace FileSystem
{
    public partial class frmFind : Form
    {
        public frmFind()
        {
            InitializeComponent();
            Segment.Init(); 
        }

        private void frmFind_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now.Date;
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.rtfRichTextBox1.Text)){
                MessageBox.Show("请输入搜索关键字！", "系统提示");
                return;
            }
            string _key = this.rtfRichTextBox1.Text.Trim();
            if (!string.IsNullOrEmpty(_key))
            {
                string str = this.rtfRichTextBox1.Text;
                Segment segment = new Segment();
                ICollection<WordInfo> words = segment.DoSegment(str);
                DataTable dt = new FileBLL().FindFile(words);
                _dresult = dt;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请输入查询的关键词！", "系统提示");
            }
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string _key;
        private DataTable _dresult;
        public DataTable _Dresult
        {
            get { return _dresult; }

        }

        public string Key
        {
            get { return _key; }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void skinLabel4_Click(object sender, EventArgs e)
        {

        }

        private void skinButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
            _key = this.skinTextBox1.SkinTxt.Text.Trim();
            if (!string.IsNullOrEmpty(_key) || !string.IsNullOrEmpty(this.comboBox1.Text) || !string.IsNullOrEmpty(this.skinTextBox2.SkinTxt.Text) || !string.IsNullOrEmpty(this.dateTimePicker1.Text) || !string.IsNullOrEmpty(this.dateTimePicker2.Text))
            {
                Segment segment = new Segment();
                ICollection<WordInfo> words = segment.DoSegment(_key);
                DataTable dt = new FileBLL().SeniorFindFile(words, this.comboBox1.Text, this.skinTextBox2.SkinTxt.Text, Convert.ToDateTime(this.dateTimePicker1.Value), Convert.ToDateTime(this.dateTimePicker2.Value));
                _dresult = dt;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请输入查询的关键词！", "系统提示");
            }
        }

    }
}
