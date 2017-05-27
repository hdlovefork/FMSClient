using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileSystem.Model;
using FileSystem.BLL;

namespace FileSystem
{
    public partial class frmPermissionConfig : Form
    {
        int[] _accessArray = new int[] { 0x1, 0x2, 0x4, 0x8, 0x10, 0x20, 0x40 };
        private int FileId;

        public frmPermissionConfig()
        {
            InitializeComponent();
        }
        public frmPermissionConfig(int fid)
        {
            this.FileId = fid;
            InitializeComponent();
        }

        private void frmPermissionConfig_Load(object sender, EventArgs e)
        {
            CreatlstRoles();
        }

        private void CreatlstRoles()
        {
            this.chklstRoles.Items.Clear();
            List<ACL_Role> lst = new RoleBLL().GetAll();
            foreach (ACL_Role a in lst) {
                this.chklstRoles.Items.Add(a);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int defAcesss = 0;
            //共享组权限
            for (int i = 0; i < chklstPersmissions.Items.Count; i++)
            {
                if (chklstPersmissions.GetItemChecked(i))
                {
                    defAcesss |= _accessArray[i];
                }
            }
          bool ok=  new FileBLL().AddPermission(FileId, defAcesss);
          defAcesss = 0;
          bool ok1=false;
            //文件分配到组操作
          if (ok)
          {
              for (int i = 0; i < chklstRoles.Items.Count; i++)
              {
                  if (chklstRoles.GetItemChecked(i))
                  {
                      //进行插入组操作
                      ACL_Role a = chklstRoles.Items[i] as ACL_Role;
                      if (a != null)
                      {
                        ok1= new ACL_File_RoleBLL().Add(FileId, a.RoleID);
                      }
                  }
              }
          }
            //其他组权限

          if (ok1) {
              for (int i = 0; i < checkedListBox1.Items.Count; i++)
              {
                  if (checkedListBox1.GetItemChecked(i))
                  {
                      defAcesss |= _accessArray[i];
                  }
              }
          
          }
          ok = new FileBLL().AddOtherPer(FileId,defAcesss);
          if (ok) {
              this.DialogResult = DialogResult.OK;
          }


        }
    }
}
