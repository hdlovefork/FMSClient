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
using FileSystem.Model;

namespace FileSystem
{
    public partial class frmPersonal : Form
    {
        public frmPersonal()
        {
            InitializeComponent();
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            //更新
            int i = new BLL.UserBLL().UpdateUser(
                new User()
                {
                    UserID = LoginUser.UserId,
                    UserRealName = this.skinTextBox1.SkinTxt.Text,
                    UserName = this.skinTextBox2.SkinTxt.Text,
                    //UserSex = this.skinTextBox3.SkinTxt.Text == "男" ? true : false,
                    UserSex = cboSex.SelectedIndex == 1,
                    UserPassword = this.skinTextBox4.SkinTxt.Text,
                    UserAddress = this.skinTextBox5.SkinTxt.Text
                });
            if (i > 0)
            {
                MessageBox.Show("更新成功！", "系统提示");
                this.Close();
            }
            else
                MessageBox.Show("更新失败！", "系统提示");
        }

        private void skinButton2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPersonal_Load(object sender, EventArgs e)
        {
            LoadMsg();
        }

        private void LoadMsg()
        {
            List<User> user = new BLL.UserBLL().GetOne(LoginUser.UserId);
            if (user != null && user.Count > 0)
            {
                User u = user[0];
                this.skinTextBox1.SkinTxt.Text = u.UserRealName;
                this.skinTextBox2.SkinTxt.Text = u.UserName;
                //this.skinTextBox3.SkinTxt.Text = u.UserSex.Value ? "男" : "女";
                cboSex.SelectedIndex = (bool)u.UserSex ? 1 : 0;
                this.skinTextBox4.SkinTxt.Text = u.UserPassword;
                this.skinTextBox5.SkinTxt.Text = u.UserAddress;
            }
        }
    }
}
