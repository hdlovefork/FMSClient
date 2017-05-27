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
using FileSystem.BLL;

namespace FileSystem
{
    public partial class frmComment : Form
    {
        private int fid;
        public frmComment()
        {
            InitializeComponent();
        }

        public frmComment(int fileId) {
            fid = fileId;
            InitializeComponent();
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtfRichTextBox1.Text)) {
                MessageBox.Show("请输入评论信息！","系统提示");
                return;
            }
            int uid = LoginUser.UserId;
            int i = new CommentBLL().InsertComment(uid, fid, rtfRichTextBox1.Text);
            if (i > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else {
                MessageBox.Show("评论添加失败！", "系统提示");
            }
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
