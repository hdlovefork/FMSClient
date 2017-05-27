using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileSystem.Model;
using FileSystem.BLL;
using CCWin.SkinControl;


namespace FileSystem
{
    public partial class frmBorrowPersonal : Form
    {
        
        public frmBorrowPersonal()
        {
            InitializeComponent();
        }
        private int FileId;
        public frmBorrowPersonal(int FileId){
            this.FileId = FileId;
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SkinListBoxItem sli = skinListBox1.SelectedItem as SkinListBoxItem;
            if (sli == null) return;
            User u = sli.Tag as User;
            if (u == null)
                return;
                bool ok = new File_ShareBLL().AddFile_Share(FileId, u.UserID);
                if (ok)
                {
                    bool ok1 = new File_Share_NoticeBLL().Add(
                        new File_User_Notice
                        {
                            FileID = FileId,
                            FromUserID = LoginUser.UserId,
                            ToUserID = u.UserID,
                        });
                    if (ok1)
                    {
                        MessageBox.Show("借阅成功");
                        this.Close();
                    }
                }
            
        }

        private void frmBorrowPersonal_Load(object sender, EventArgs e)
        {
            List<User> users = new UserBLL().GetAllUser();
            if (users != null && users.Count > 0)
            {
                foreach (var t in users)
                {
                    if (t.UserID == LoginUser.UserId)
                        continue;
                    SkinListBoxItem sli = new SkinListBoxItem();
                    sli.Text = t.UserRealName;
                    sli.Tag = t;
                    sli.Image = imageList1.Images[0];
                    this.skinListBox1.Items.Add(sli);
                }
            }
        }

        private void skinListBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}
