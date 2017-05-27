/**************************************************************** 
 * 作    者：费彬彬
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
using FileSystem.Model;

namespace FileSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            string name = this.skinTextBox1.SkinTxt.Text.ToString();
            string pwd = this.skinTextBox2.SkinTxt.Text.ToString();
            if (string.IsNullOrEmpty(name)) {
                MessageBox.Show("请输入用户名！","系统提示");
                return;
            }
            if (string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("请输入密码！", "系统提示");
                return;
            }
            List<User> user = new UserBLL().CheckLogin(name, pwd);
            if (user != null && user.Count > 0)
            { 
                //记录用户权限
                LoginUser.UserId = user[0].UserID;
                LoginUser.UserName = user[0].UserName;
                LoginUser.UserRealName = user[0].UserRealName;
                //登陆主窗体
                DialogResult = DialogResult.OK;
            }else
                MessageBox.Show("用户名或密码错误！", "系统提示");
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            this.skinTextBox1.SkinTxt.Text = "";
            this.skinTextBox2.SkinTxt.Text = "";
        }
    }
}
