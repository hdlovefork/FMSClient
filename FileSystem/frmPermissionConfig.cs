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
using EXControls;
using FileSystem.Service;

namespace FileSystem
{
    public partial class frmPermissionConfig : Form
    {
        int[] _accessArray_Values = new int[] {
                (int)FilePermission.Read,
                (int)FilePermission.Write,
                (int)FilePermission.Delete,
                (int)FilePermission.Upload,
                (int)FilePermission.Download,
                (int)FilePermission.Archive,
                (int)FilePermission.Share
            };
        string[] _accessArray_Name = new string[] {
              "Read",
              "Write",
              "Delete",
              "Upload",
              "Download",
              "Archive",
              "Share"
        };
        string[] _accessArray_Desc = new string[] {
            "可查看",
            "可保存",
            "可删除",
            "可上传",
            "可下载",
            "可归档",
            "可借阅",
        };

        bool[] _accessArray_Default = new bool[]
        {
            true,
            true,
            false,
            false,
            true,
            false,
            true
        };

        DepBLL _depBll = new DepBLL();
        UserBLL _userBll = new UserBLL();
        FileBLL _fileBll = new FileBLL();

        List<User> _users;
        List<Department> _deps;

        List<ACL_File_User> _fileUsersOriginal;//原始已共享的用户
        List<File_Department> _fileDepsOriginal;//原始已共享的部门

        List<ACL_File_User> _fileUsersPreAdd;//待共享的用户
        List<ACL_File_User> _fileUsersPreDelete;//待取消共享的用户
        List<File_Department> _fileDepsPreAdd;//待共享的部门
        List<File_Department> _fileDepsPreDelete;//待移除共享的部门

        private int _fileID;

        public frmPermissionConfig(int fid)
        {
            InitializeComponent();
            _fileUsersPreAdd = new List<ACL_File_User>();
            _fileUsersPreDelete = new List<ACL_File_User>();
            _fileDepsPreAdd = new List<File_Department>();
            _fileDepsPreDelete = new List<File_Department>();
            _fileID = fid;
            _users = _userBll.GetAllUser();
            _deps = _depBll.GetAll();

            _fileUsersOriginal = _fileBll.GetUserShareFiles(fid);
            _fileDepsOriginal = _fileBll.GetDepShareFiles(fid);
        }

        /// <summary>
        /// 添加快捷菜单中的部门，如果已添加则跳过
        /// </summary>
        private void InitDepMenu(CancelEventArgs e)
        {
            cxtMenuDep.Items.Clear();
            bool cancel = true;
            foreach (Department d in _deps)
            {
                if (ExistsDep(d)) continue;
                cancel = false;
                ToolStripMenuItem item = new ToolStripMenuItem(d.DepartmentName, imageList1.Images["dep"]);
                item.Tag = d;
                item.Click += DepItem_Click;
                cxtMenuDep.Items.Add(item);
            }
            if (e != null)
                e.Cancel = cancel;
        }

        private bool ExistsDep(Department d)
        {
            foreach (ListViewItem item in lvPermission.Items)
            {
                File_Department fd = item.Tag as File_Department;
                if (fd != null)
                {
                    if (fd.DepartmentID == d.DepartmentID) return true;
                }
            }
            return false;
        }


        /// <summary>
        /// 添加快捷菜单中的用户，如果已添加则跳过
        /// </summary>
        private void InitUserMenu(CancelEventArgs e)
        {
            cxtMenuUser.Items.Clear();
            bool cancel = true;
            foreach (User u in _users)
            {
                if (ExistsUser(u) || u.UserID == LoginUser.UserId) continue;
                cancel = false;
                ToolStripMenuItem item = new ToolStripMenuItem(u.UserRealName, imageList1.Images["user"]);
                item.Tag = u;
                item.Click += UserItem_Click;
                cxtMenuUser.Items.Add(item);
            }
            if (e != null)
                e.Cancel = cancel;
        }

        private bool ExistsUser(User u)
        {
            foreach (ListViewItem item in lvPermission.Items)
            {
                ACL_File_User fu = item.Tag as ACL_File_User;
                if (fu != null)
                {
                    if (fu.UserID == u.UserID) return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 点击添加用户菜单项需要向ListView中添加用户共享
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserItem_Click(object sender, EventArgs e)
        {
            //在ListView中添加一个用户项
            ToolStripMenuItem mi = sender as ToolStripMenuItem;
            if (mi == null || mi.Tag == null) return;
            User u = mi.Tag as User;
            if (u == null) return;
            //向ListView项中添加一个ACL_File_User对象，ListViewItem中保存2种对象，1：File_Department 2:ACL_File_User
            ACL_File_User fu = new ACL_File_User
            {
                UserID = u.UserID,
                FileID = _fileID,
                FilePermission = GetDefaultPermission()
            };
            EXListViewItem item = new EXImageListViewItem(u.UserRealName, imageList1.Images["user"]);
            item.Tag = fu;

            for (int i = 0; i < _accessArray_Values.Length; i++)
            {
                EXBoolListViewSubItem sub = CreateBoolSubItem(_accessArray_Name[i], _accessArray_Values[i], _accessArray_Default[i]);
                item.SubItems.Add(sub);
            }
            lvPermission.Items.Add(item);

            if (!_fileUsersPreAdd.Contains(fu) && !_fileUsersOriginal.Contains(fu))
                _fileUsersPreAdd.Add(fu);
            _fileUsersPreDelete.Remove(fu);
        }

        /// <summary>
        /// 获取新增借阅时的默认权限
        /// </summary>
        /// <returns></returns>
        private int GetDefaultPermission()
        {
            int access = 0;
            for (int i = 0; i < _accessArray_Default.Length; i++)
            {
                if (_accessArray_Default[i])
                {
                    access |= _accessArray_Values[i];
                }
            }
            return access;
        }

        private void Permission_ValueChanged(ListViewItem item, EXBoolListViewSubItem subItem, int colIndex, bool value)
        {
            //权限值更改后即时修改ListViewItem.Tag中对象里面的FilePermission属性
            File_Department fd = item.Tag as File_Department;
            int index = colIndex - 1;
            if (index < 0 || index >= _accessArray_Values.Length) return;
            if (fd != null)
            {
                if (value)
                    fd.FilePermission |= _accessArray_Values[index];
                else
                    fd.FilePermission = fd.FilePermission & ~_accessArray_Values[index];
                return;
            }
            ACL_File_User fu = item.Tag as ACL_File_User;
            if (fu == null) return;
            if (value)
                fu.FilePermission |= _accessArray_Values[index];
            else
                fu.FilePermission = fu.FilePermission & ~_accessArray_Values[index];
        }

        private void DepItem_Click(object sender, EventArgs e)
        {
            //在ListView中添加一个部门项
            ToolStripMenuItem mi = sender as ToolStripMenuItem;
            if (mi == null || mi.Tag == null) return;
            Department d = mi.Tag as Department;
            if (d == null) return;
            File_Department fd = new File_Department
            {
                FileID = _fileID,
                DepartmentID = d.DepartmentID,
                FilePermission = GetDefaultPermission()
            };
            EXListViewItem item = new EXImageListViewItem(d.DepartmentName, imageList1.Images["dep"]);
            item.Tag = fd;

            for (int i = 0; i < _accessArray_Values.Length; i++)
            {
                EXBoolListViewSubItem sub = CreateBoolSubItem(_accessArray_Name[i], _accessArray_Values[i], _accessArray_Default[i]);
                item.SubItems.Add(sub);
            }
            lvPermission.Items.Add(item);

            if (!_fileDepsPreAdd.Contains(fd) && !_fileDepsOriginal.Contains(fd))
                _fileDepsPreAdd.Add(fd);
            _fileDepsPreDelete.Remove(fd);
        }

        private EXBoolListViewSubItem CreateBoolSubItem(string key, object tag, bool value)
        {
            EXBoolListViewSubItem sub = new EXBoolListViewSubItem(value);
            sub.ValueChanged += Permission_ValueChanged;
            sub.Name = key;
            sub.Tag = tag;
            return sub;
        }

        private void btnAddDep_MouseDown(object sender, MouseEventArgs e)
        {
            //在按钮右边显示快捷菜单
            cxtMenuDep.Show(btnAddDep, btnAddDep.Width, 0);
        }

        private void frmPermissionConfig_Load(object sender, EventArgs e)
        {

            InitExListView();//初始化列头  
            //在ListView中显示已有的共享权限
            AddDepAndUserToListView(_fileDepsOriginal, _fileUsersOriginal);
            InitDepMenu(null);
            InitUserMenu(null);
        }


        private void InitExListView()
        {
            lvPermission.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvPermission.MySortBrush = SystemBrushes.ControlLight;
            lvPermission.MyHighlightBrush = Brushes.Goldenrod;
            lvPermission.GridLines = true;
            lvPermission.ControlPadding = 4;
            //调整ListView的行高
            ImageList iList = new ImageList();
            iList.ImageSize = new Size(1, 24);
            lvPermission.SmallImageList = iList;

            EXColumnHeader textCol = new EXColumnHeader("部门或用户");
            lvPermission.Columns.Add(textCol);
            for (int i = 0; i < _accessArray_Desc.Length; i++)
            {
                EXBoolColumnHeader col = new EXBoolColumnHeader(_accessArray_Desc[i]);
                col.Editable = true;
                col.TrueImage = Properties.Resources._true;
                col.FalseImage = Properties.Resources._false;
                lvPermission.Columns.Add(col);
            }
            lvPermission.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnAddUser_MouseDown(object sender, MouseEventArgs e)
        {
            //在按钮右边显示快捷菜单
            cxtMenuUser.Show(btnAddUser, btnAddUser.Width, 0);
        }

        //显示文件已有的共享权限
        private void AddDepAndUserToListView(List<File_Department> deps, List<ACL_File_User> users)
        {
            lvPermission.Items.Clear();
            foreach (File_Department fd in deps)
            {
                EXListViewItem item = new EXImageListViewItem(fd.DepartmentName, imageList1.Images["dep"]);
                item.Tag = fd;
                for (int i = 0; i < _accessArray_Values.Length; i++)
                {
                    EXBoolListViewSubItem sub = CreateBoolSubItem(_accessArray_Name[i], _accessArray_Values[i], (_accessArray_Values[i] & fd.FilePermission) == _accessArray_Values[i]);
                    item.SubItems.Add(sub);
                }
                lvPermission.Items.Add(item);
            }

            foreach (ACL_File_User fu in users)
            {
                EXListViewItem item = new EXImageListViewItem(fu.UserRealName, imageList1.Images["user"]);
                item.Tag = fu;
                for (int i = 0; i < _accessArray_Values.Length; i++)
                {
                    EXBoolListViewSubItem sub = CreateBoolSubItem(_accessArray_Name[i], _accessArray_Values[i], (_accessArray_Values[i] & fu.FilePermission) == _accessArray_Values[i]);
                    item.SubItems.Add(sub);
                }
                lvPermission.Items.Add(item);
            }
        }


        private void cxtMenuDep_Opening(object sender, CancelEventArgs e)
        {
            InitDepMenu(e);//打开部门菜单时移除已添加的部门选项
        }

        private void cxtMenuUser_Opening(object sender, CancelEventArgs e)
        {
            InitUserMenu(e);//打开用户菜单时移除已添加的用户选项
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ACLFileUserBLL fileUserBll = new ACLFileUserBLL();
            FileDepartmentBLL fileDepBll = new FileDepartmentBLL();
            File_Share_NoticeBLL fileShareBll = new File_Share_NoticeBLL();
            File_User_Notice notice = new File_User_Notice
            {
                FromUserID = LoginUser.UserId,
                FileID = _fileID,
            };

            #region 更新权限
            foreach (ACL_File_User fu in _fileUsersOriginal)
            {
                fileUserBll.UpdateFileUser(fu);
            }

            foreach (File_Department fd in _fileDepsOriginal)
            {
                fileDepBll.UpdateFileDepartment(fd);
            }
            #endregion
            #region 添加权限
            foreach (ACL_File_User fu in _fileUsersPreAdd)
            {
                fileUserBll.AddFileUser(fu);
                notice.ToUserID = (int)fu.UserID;
                fileShareBll.Add(notice);//添加消息通知
            }
            foreach (File_Department fd in _fileDepsPreAdd)
            {
                fileDepBll.AddFilDepartment(fd);
            }
            #endregion

            #region 删除权限
            foreach (ACL_File_User fu in _fileUsersPreDelete)
            {
                fileUserBll.DeleteFileUser(fu);
                notice.ToUserID = (int)fu.UserID;
                notice.FileID = _fileID;
                fileShareBll.DeleteNotice(notice);
            }
            foreach (File_Department fd in _fileDepsPreDelete)
            {
                fileDepBll.DeleteFileDepartment(fd);
            }
            #endregion
            DialogResult = DialogResult.OK;
        }

        private bool ExistsOriginDep(int depid)
        {
            foreach (File_Department fd in _fileDepsOriginal)
            {
                if (fd.DepartmentID == depid) return true;
            }
            return false;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvPermission.SelectedItems.Count == 0) return;
            CollectAddOrDelFileShare();
            lvPermission.Items.Remove(lvPermission.SelectedItems[0]);
        }

        /// <summary>
        /// 收集添加和删除的文件-用户，文件-部门的数据
        /// </summary>
        private void CollectAddOrDelFileShare()
        {
            ACL_File_User fu = null;
            File_Department fd = null;
            if (lvPermission.SelectedItems.Count == 0) return;
            fu = lvPermission.SelectedItems[0].Tag as ACL_File_User;
            if (fu != null)
            {
                AddToPreDeleteList(fu);
                return;
            }
            fd = lvPermission.SelectedItems[0].Tag as File_Department;
            if (fd != null)
            {
                AddToPreDeleteList(fd);
            }
        }

        private void AddToPreDeleteList(File_Department fd)
        {
            if (_fileDepsOriginal.Contains(fd))
                _fileDepsPreDelete.Add(fd);
            else
                _fileDepsPreDelete.Remove(fd);
            _fileDepsPreAdd.Remove(fd);
        }

        private void AddToPreDeleteList(ACL_File_User fu)
        {
            if (_fileUsersOriginal.Contains(fu))
                _fileUsersPreDelete.Add(fu);
            else
                _fileUsersPreDelete.Remove(fu);
            _fileUsersPreAdd.Remove(fu);
        }
    }
}
