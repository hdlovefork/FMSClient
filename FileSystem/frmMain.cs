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
using FileSystem.Model;
using FileSystem.BLL;
using System.IO;
using FileSystem.Service;
using FileSystem.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace FileSystem
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            FrmPopup.ClickNotice += new EventHandler(FrmPopup_Click);
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            CreatePersonlTree();
            CreatDepTree();
            CreatePositionTree();
            this.skinLabelName.Text = "当前登陆用户：" + LoginUser.UserRealName;
        }

        #region 生成个人树

        /// <summary>
        /// 顾挺2017-05-11编写加载跟人树示例
        /// </summary>
        /// <param name="node"></param>
        private void CreatePersonlTree()
        {
            try
            {
                TreeNode node = new TreeNode(); //定义根节点
                node.Name = "-1"; //将类Model的各个属性赋值给根节点
                node.Text = "个人文件";
                TreeNode node1 = new TreeNode();
                node1.Name = "-1";
                node1.Text = "我的借阅";
                skinTreeViewPersonl.Nodes.Add(node);
                skinTreeViewPersonl.Nodes.Add(node1);
                cFilePersonlTree(node, node.Name); //调用另一个方法为根节点添加其他子节点
                skinTreeViewPersonl.NodeMouseClick += (s, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (!string.IsNullOrEmpty(e.Node.Name))
                        {
                            if (e.Node.Text == "我的借阅")
                            {
                                DataTable dt = new File_ShareBLL().GetFile_Share(LoginUser.UserId);
                                this.skinDataGridView1.DataSource = dt;
                                if (dt != null && dt.Rows.Count > 0)
                                    skinDataGridView1.Rows[0].Selected = false;
                                this.skinGroupBox1.Text = "[" + e.Node.Text + "]" + "共" + dt.Rows.Count +
                                                          "份文档(下列文档点击右键可以进行操作)";
                            }
                            else
                            {
                                DataTable dt = new FileBLL().GetFileByUser(LoginUser.UserId,
                                    Convert.ToInt32(e.Node.Name));
                                this.skinDataGridView1.DataSource = dt;
                                if (dt != null && dt.Rows.Count > 0)
                                    skinDataGridView1.Rows[0].Selected = false;
                                this.skinGroupBox1.Text = "[" + e.Node.Text + "]" + "共" + dt.Rows.Count +
                                                          "份文档(下列文档点击右键可以进行操作)";
                            }
                        }
                    }
                };
                skinTreeViewPersonl.ExpandAll(); //展开所有节点
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        private void cFilePersonlTree(TreeNode node, string p)
        {
            var lst = new FileBLL().GetFilePersonlTree(Convert.ToInt32(p), LoginUser.UserId);
            if (lst != null && lst.Count > 0)
            {
                foreach (var file in lst)
                {
                    TreeNode n = new TreeNode();
                    n.Name = file.FileID.ToString();
                    n.Text = file.FileName.ToString();
                    n.Tag = file.FileID.ToString();
                    node.Nodes.Add(n);
                    cFilePersonlTree(n, n.Name); //用递归的方法添加完整的树节点
                }
            }
        }

        #endregion

        #region 生成部门树

        /// <summary>
        /// 陶湘成2017-05-12编写加载部门文件
        /// </summary>
        /// <param name="node"></param>
        private void CreatDepTree()
        {
            try
            {
                var node = new TreeNode();
                node.Name = "-1";
                node.Text = "部门文件";
                node.Tag = "";
                skinTreeViewDep.Nodes.Add(node);
                cDepTree(node);
                skinTreeViewDep.ExpandAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        /// <summary>
        /// 陶湘成2017-05-12编写网格颜色变换
        /// </summary>
        /// <param name="node"></param>
        private void ChangeColor(CCWin.SkinControl.SkinDataGridView skinDataGridView, DataGridViewCellEventArgs b)
        {
            //若行已是选中状态就不再进行设置
            if (skinDataGridView.Rows[b.RowIndex].Selected == false)
            {
                skinDataGridView.ClearSelection();
                skinDataGridView.Rows[b.RowIndex].Selected = true;
            }
            //只选中一行时设置活动单元格
            if (skinDataGridView.SelectedRows.Count == 1)
            {
                if (b.ColumnIndex != -1)
                {
                    skinDataGridView.CurrentCell = skinDataGridView.Rows[b.RowIndex].Cells[b.ColumnIndex];
                }
            }
        }


        /// <summary>
        /// 陶湘成2017-05-12编写加载部门树
        /// </summary>
        /// <param name="node"></param>
        private void cDepTree(TreeNode node)
        {
            var lst = new DepBLL().GetDepTree();
            if (lst != null && lst.Count > 0)
            {
                lst.ForEach(d =>
                {
                    var n = new TreeNode();
                    n.Name = Convert.ToString(d.DepartmentID);
                    n.Text = d.DepartmentName;
                    n.Tag = d;
                    node.Nodes.Add(n);
                });
            }
        }

        #endregion

        #region 生成岗位树

        /// <summary>
        /// 费彬彬2017-05-12编写岗位树
        /// </summary>
        /// <param name="node"></param>
        private void CreatePositionTree()
        {
            try
            {
                TreeNode node = new TreeNode();
                node.Name = "-1";
                node.Text = "岗位文件";
                skinTreeViewGW.Nodes.Add(node);
                cPositionTree(node);
                skinTreeViewGW.NodeMouseClick += (s, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        User u = e.Node.Tag as User;
                        if (u != null)
                        {
                            DataTable dt = new FileBLL().GetFileByUserId(u.UserID);
                            this.skinDataGridView1.DataSource = dt;
                            if (dt != null && dt.Rows.Count > 0)
                                skinDataGridView1.Rows[0].Selected = false;
                            this.skinGroupBox1.Text = "[" + e.Node.Text + "]" + "共" + dt.Rows.Count +
                                                      "份文档(下列文档点击右键可以进行操作)";
                        }
                    }
                };
                skinTreeViewGW.ExpandAll();
            }
            catch (Exception b)
            {
                throw new Exception(b.Message.ToString());
            }
        }

        private void CommentFrm(DataGridViewCellEventArgs b)
        {
            DataGridViewColumn column = new DataGridViewColumn();
            if (b.ColumnIndex == -1)
                column = skinDataGridView1.Columns[0];
            else
                column = skinDataGridView1.Columns[b.ColumnIndex];
            var fileId = Convert.ToInt32(skinDataGridView1.Rows[b.RowIndex].Cells["FileId"].Value);
            var dtpl = new CommentBLL().FindComment(fileId);
            this.skinDataGridView2.DataSource = dtpl;
            if (column is DataGridViewImageColumn)
            {
                frmComment frm = new frmComment(fileId);
                //开启一个模态窗体，格挡其他窗体
                DialogResult result = frm.ShowDialog();
                //模态窗体返回一个完成运行的状态值
                if (result == DialogResult.OK)
                {
                    //加载评论列表
                    dtpl = new CommentBLL().FindComment(fileId);
                    this.skinDataGridView2.DataSource = dtpl;
                    if (dtpl != null && dtpl.Rows.Count > 0)
                        skinDataGridView2.Rows[0].Selected = false;
                }
            }
            this.skinGroupBox2.Text = "[" + skinDataGridView1.Rows[b.RowIndex].Cells["FileName"].Value.ToString() + "]" +
                                   "共" + dtpl.Rows.Count.ToString() + "条评论";
        }

        /// <summary>
        /// 费彬彬2017-05-12编写岗位文件
        /// </summary>
        /// <param name="node"></param>
        private void cPositionTree(TreeNode node)
        {
            List<Position> lst = new PositionBLL().GetPositionTree();
            foreach (Position p in lst)
            {
                TreeNode node1 = new TreeNode();
                node1.Name = Convert.ToString(p.PositionID);
                node1.Text = p.PositionName;
                node.Nodes.Add(node1);
                cPositionTreeUser(node1, node1.Name);
            }
        }

        private void cPositionTreeUser(TreeNode node1, string p)
        {
            IList<User> ilst = new PositionBLL().GetUserByPositionId(Convert.ToInt32(p));

            foreach (User u in ilst)
            {
                TreeNode unode = new TreeNode();
                unode.Name = Convert.ToString(u.UserID);
                unode.Text = u.UserRealName;
                unode.Tag = u;
                node1.Nodes.Add(unode);
            }
        }

        #endregion

        #region 文件网格操作

        /// <summary>
        /// Add by 陶湘程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void skinDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView) sender;
            if (e.RowIndex >= 0)
            {
                try
                {
                    ChangeColor(skinDataGridView1, e);
                    CommentFrm(e);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// Add by 陶湘程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinDataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (skinDataGridView1.Rows[e.RowIndex].Selected == false)
                    {
                        skinDataGridView1.ClearSelection();
                        skinDataGridView1.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (skinDataGridView1.SelectedRows.Count == 1)
                    {
                        if (e.ColumnIndex == -1)
                        {
                            skinDataGridView1.CurrentCell = skinDataGridView1.Rows[e.RowIndex].Cells[1];
                        }
                        else
                        {
                            skinDataGridView1.CurrentCell = skinDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        }
                    }
                    //弹出操作菜单
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void skinDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (e.RowIndex >= 0)
            {
                try
                {
                    //若行已是选中状态就不再进行设置
                    if (skinDataGridView1.Rows[e.RowIndex].Selected == false)
                    {
                        skinDataGridView1.ClearSelection();
                        skinDataGridView1.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (skinDataGridView1.SelectedRows.Count == 1)
                    {
                        skinDataGridView1.CurrentCell = skinDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                }
                catch
                {
                }
            }

            frmLoading.ShowTop();
            //Add By 顾挺 2017-05-12  意图:学员单线程打开文件，体验实在太差，为了增强用户体验，因为大文件加载速度实在太慢，添加多线程
            string fileID = skinDataGridView1.Rows[e.RowIndex].Cells["FileId"].Value.ToString();
            OpenFile(fileID);
        }

        private void OpenFile(string fileID)
        {
            if (string.IsNullOrWhiteSpace(fileID)) return;
            //开启任务
            AT.Create<string[]>(() =>
            {
                string fileid = fileID;
                bool check = AuthPermission.Auth(LoginUser.UserId, Convert.ToInt32(fileid), FilePermission.Read);
                if (check)
                    return LoadData(fileid);
                else
                    MessageBox.Show("您没有权限阅读该文件", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
                //上一步任务成功之后，执行下一个操作
            }).Run((i) =>
            {
                if (i != null)
                    ShowFileDialog(i[2], i[0], i[1], i[3]);
                //完成所有操作执行操作
            }, () => { frmLoading.Close(); });
        }

        //方法二：随机生成字符串（数字和字母混和）
        private int rep = 0;

        private string GenerateCheckCode(int codeCount)
        {
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + this.rep;
            this.rep++;
            Random random = new Random(((int) (((ulong) num2) & 0xffffffffL)) | ((int) (num2 >> this.rep)));
            for (int i = 0; i < codeCount; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char) (0x30 + ((ushort) (num % 10)));
                }
                else
                {
                    ch = (char) (0x41 + ((ushort) (num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }

        private string GetExtByFileID(string fileID)
        {
            string ext = string.Empty;
            var lst = new FileBLL().GetOne(Convert.ToInt32(fileID));
            ;
            if (lst != null && lst.Count > 0)
            {
                //生成本地文件
                var Files = (Byte[]) lst[0].FileData;
                var name = GenerateCheckCode(20);
                ext = lst[0].FileExt.ToLower();
                var path = string.Format("{0}\\temp\\{1}.{2}", Application.StartupPath, name, ext);
                var bw = new BinaryWriter(System.IO.File.Open(path, FileMode.OpenOrCreate));
                bw.Write(Files, 0, Files.Length);
                bw.Flush();
                bw.Close();
            }
            return ext;
        }

        //开启文件窗口
        private void ShowFileDialog(string path, string name, string ext, string realName)
        {
            try
            {
                if (ext == "txt")
                {
                    var frm = new frmTxt(path, ext, realName);
                    frm.Show();
                }
                else if (ext == "flv" || ext == "mp4" || ext == "avi"
                         || ext == "wmv" || ext == "mpg" || ext == "psd" || ext == "ai")
                {
                    FrmPlayer frm = new FrmPlayer(path, realName);
                    frm.Show();
                }
                else if(ext == "gif" || ext == "jpg"
                         || ext == "png" || ext == "tif" || ext == "bmp")
                {
                    frmPic frm = new frmPic(path, ext, realName);
                    frm.Show();
                }
                else if (ext == "mp3" || ext == "wav" || ext == "wma")
                {
                    frmMusic frm = new frmMusic(path, ext, realName);
                    frm.Show();
                }
                else if (ext == "ppt" || ext == "pptx" || ext == "doc" || ext == "docx" || ext == "xls" || ext == "xlsx")
                {
                    //var frm = new frmOffice(path, true, ext);
                    //frm.Show();
                    Process.Start(path);
                }
                //部分格式文件还没有找到合适插件，所以暂时使用系统自动识别
                else
                {
                    Process.Start(path);
                }
            }
            catch (Exception ex)
            {
                Debug.Print("{0}:{1}", ex.Source, ex.Message);
                //MessageBox.Show("您未安装可打开该文件的应用，请安装之后再打开！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Process.Start(path);
            }
        }

        private string[] LoadData(string fileid)
        {
            var lst = new FileBLL().GetOne(Convert.ToInt32(fileid));
            ;
            if (lst != null && lst.Count > 0)
            {
                try
                {
                    var fpath = string.Format("{0}\\temp", Application.StartupPath);
                    if (!Directory.Exists(fpath))
                    {
                        Directory.CreateDirectory(fpath);
                    }

                    //生成本地文件
                    var Files = (Byte[]) lst[0].FileData;
                    var name = GenerateCheckCode(20);
                    var ext = lst[0].FileExt.ToLower();
                    var path = string.Format("{0}\\temp\\{1}.{2}", Application.StartupPath, name, ext);
                    var bw = new BinaryWriter(System.IO.File.Open(path, FileMode.OpenOrCreate));
                    bw.Write(Files, 0, Files.Length);
                    bw.Flush();
                    bw.Close();
                    return new string[] {name, ext, path, lst[0].FileName};
                }
                catch
                {
                    //奇葩文件不报错
                }
            }
            return null;
        }

        #endregion

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            new frmNotice().ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show( "真的要退出程序吗？","系统提示", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }


        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 帮助信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmNotice().ShowDialog();
        }

        /// Add by 陶湘程
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmFind fm = new frmFind();
            if (fm.ShowDialog() == DialogResult.OK)
            {
                this.skinDataGridView1.DataSource = fm._Dresult;
                if (fm._Dresult != null && fm._Dresult.Rows.Count > 0)
                    skinDataGridView1.Rows[0].Selected = false;
                this.skinGroupBox1.Text =
                    this.skinGroupBox1.Text =
                        "[本次查询:" + fm.Key + "]" + "共" + fm._Dresult.Rows.Count + "份文档(下列文档点击右键可以进行操作)";
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmPersonal frm = new frmPersonal();
            frm.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            new frmNotice().ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmUpload frm = new frmUpload();
            DialogResult dlg = frm.ShowDialog();
            if (dlg == System.Windows.Forms.DialogResult.OK)
            {
                SetPermission(frm);
                //刷新网格
                string str = frm.Status;
                if (str == "personal")
                {
                    DataTable dt = new FileBLL().GetFileByUser(LoginUser.UserId, Convert.ToInt32(frm.SelectFid));
                    this.skinDataGridView1.DataSource = dt;
                    if (dt != null && dt.Rows.Count > 0)
                        skinDataGridView1.Rows[0].Selected = false;
                    this.skinGroupBox1.Text = "[" + frm.Fname + "]" + "共" + dt.Rows.Count + "份文档(下列文档点击右键可以进行操作)";
                }
                else
                {
                    DataTable dt = new FileBLL().GetFileByDepartment(frm.Depid);
                    this.skinDataGridView1.DataSource = dt;
                    if (dt != null && dt.Rows.Count > 0)
                        skinDataGridView1.Rows[0].Selected = false;
                    this.skinGroupBox1.Text = "[" + frm.Fname + "]" + "共" + dt.Rows.Count + "份文档(下列文档点击右键可以进行操作)";
                }
            }
        }

        private void SetPermission(frmUpload frm)
        {
            if (frm.NewFileId > 0)
            {
                DialogResult d = MessageBox.Show("上传成功，是否进入权限设置？", "系统提示", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    frmPermissionConfig frmPer = new frmPermissionConfig(frm.NewFileId);
                    frmPer.ShowDialog();
                }
            }
        }

        //目录管理
        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            frmTemplet frm = new frmTemplet();
            frm.ShowDialog();
        }

        #region 网格右键

        private void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoading.ShowTop();
            //Add By 顾挺 2017-05-12  意图:学员单线程打开文件，体验实在太差，为了增强用户体验，因为大文件加载速度实在太慢，添加多线程
            //开启任务
            AT.Create<string[]>(() =>
            {
                string fileid = skinDataGridView1.CurrentRow.Cells["FileId"].Value.ToString();
                bool check = AuthPermission.Auth(LoginUser.UserId, Convert.ToInt32(fileid), FilePermission.Read);
                if (check)
                    return LoadData(fileid);
                else
                {
                    MessageBox.Show("您没有权限阅读该文件", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
                //上一步任务成功之后，执行下一个操作
            }).Run((i) =>
            {
                if (i != null)
                    ShowFileDialog(i[2], i[0], i[1], i[3]);
                //完成所有操作执行操作
            }, () => { frmLoading.Close(); });
        }

        private void 下载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获得文件编号
            string fileid = skinDataGridView1.CurrentRow.Cells["FileId"].Value.ToString();
            string ext = skinDataGridView1.CurrentRow.Cells["FileExt"].Value.ToString();
            //检测是否具备下载权限
            bool check = AuthPermission.Auth(LoginUser.UserId, Convert.ToInt32(fileid), FilePermission.Download);
            if (check)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = string.Format("资料文件（*.{0}）|*.{1}", ext, ext);
                sfd.FilterIndex = 1; //设置顺序
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string localFilePath = sfd.FileName.ToString(); //获得文件路径 
                    var lst = new FileBLL().GetOne(Convert.ToInt32(fileid));
                    ;
                    if (lst != null && lst.Count > 0)
                    {
                        try
                        {
                            //生成本地文件
                            var Files = (Byte[]) lst[0].FileData;
                            var name = GenerateCheckCode(20);
                            var path = localFilePath;
                            var bw = new BinaryWriter(System.IO.File.Open(path, FileMode.OpenOrCreate));
                            bw.Write(Files, 0, Files.Length);
                            bw.Flush();
                            bw.Close();
                        }
                        catch
                        {
                        }
                    }
                }
            }
            else
                MessageBox.Show("您没有权限下载该文件", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获得文件编号
            string fileid = skinDataGridView1.CurrentRow.Cells["FileId"].Value.ToString();
            bool check = AuthPermission.Auth(LoginUser.UserId, Convert.ToInt32(fileid), FilePermission.Delete);
            if (check)
            {
                List<FileSystem.Model.File> model = new FileBLL().GetOne(Convert.ToInt32(fileid));
                if (model != null && model.Count > 0)
                {
                    if (!model[0].FileArchive)
                    {
                        DialogResult dlg = MessageBox.Show("您是否确认要删除该文件？", "系统提示", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if (dlg == DialogResult.Yes)
                        {
                            //删除文件
                            bool c = new FileBLL().Delete(Convert.ToInt32(fileid));
                            if (c)
                            {
                                MessageBox.Show("删除成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                this.skinDataGridView1.Rows.Remove(skinDataGridView1.CurrentRow);
                            }
                            else
                                MessageBox.Show("删除失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("删除失败,该文件已归档！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
                MessageBox.Show("您没有权限删除该文件", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void 评论ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileid = skinDataGridView1.CurrentRow.Cells["FileId"].Value.ToString();
            frmComment frm = new frmComment(Convert.ToInt32(fileid));
            DataTable dtpl = new DataTable();
            //开启一个模态窗体，格挡其他窗体
            DialogResult result = frm.ShowDialog();
            //模态窗体返回一个完成运行的状态值
            if (result == DialogResult.OK)
            {
                //加载评论列表
                dtpl = new CommentBLL().FindComment(Convert.ToInt32(fileid));
                this.skinDataGridView2.DataSource = dtpl;
                if (dtpl != null && dtpl.Rows.Count > 0)
                    skinDataGridView2.Rows[0].Selected = false;
            }
            this.skinGroupBox2.Text = "[" + skinDataGridView1.CurrentRow.Cells["FileName"].Value.ToString() + "]" + "共" +
                                   dtpl.Rows.Count.ToString() + "条评论";
        }

        private void 归档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileid = skinDataGridView1.CurrentRow.Cells["FileId"].Value.ToString();
            bool check = AuthPermission.Auth(LoginUser.UserId, Convert.ToInt32(fileid), FilePermission.Archive);
            if (check)
            {
                DialogResult dlg = MessageBox.Show("是否归档该文件", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    bool c = new FileBLL().UpdateFileArchive(Convert.ToInt32(fileid), true);
                    if (c)
                        MessageBox.Show("归档该文件成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("归档该文件失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
                MessageBox.Show("您没有权限归档该文件", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void 上传ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileId = this.skinTreeViewPersonl.SelectedNode.Tag as string;
            frmUpload frm = new frmUpload(Convert.ToInt32(fileId));
            DialogResult dlg = frm.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                SetPermission(frm);
                DataTable dt = new FileBLL().GetFileByUser(LoginUser.UserId, Convert.ToInt32(frm.SelectFid));
                this.skinDataGridView1.DataSource = dt;
                if (dt != null && dt.Rows.Count > 0)
                    skinDataGridView1.Rows[0].Selected = false;
                this.skinGroupBox1.Text = "[" + frm.Fname + "]" + "共" + dt.Rows.Count + "份文档(下列文档点击右键可以进行操作)";
            }
        }

        private void 借阅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileid = skinDataGridView1.CurrentRow.Cells["FileId"].Value.ToString();
            bool check = AuthPermission.Auth(LoginUser.UserId, Convert.ToInt32(fileid), FilePermission.Share);
            if (check)
            {
                frmPermissionConfig frm = new frmPermissionConfig(Convert.ToInt32(fileid));
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("您没有权限借阅该文件", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            frmCatalogManage frm = new frmCatalogManage();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.skinTreeViewPersonl.Nodes.Clear();
                CreatePersonlTree();
            }
        }

        private int _noticeFileID;
        private int _noticeID;
        private List<int> _popupFileID = new List<int>(); //已经提醒过的消息
        private File_Share_NoticeBLL _fileShareBll = new File_Share_NoticeBLL();

        private void timer1_Tick(object sender, EventArgs e)
        {
            //读取Notice表，取出未读消息 ToUser == LoginUser.UserID AND IsRead==false
            // FrmPopup.Show("34224");
            File_User_Notice notice = _fileShareBll.GetNotice(LoginUser.UserId);
            if (notice != null && !_popupFileID.Contains(notice.NoticeID))
            {
                _popupFileID.Add(notice.NoticeID);
                _noticeID = notice.NoticeID;
                _noticeFileID = notice.FileID;
                FrmPopup.Show(string.Format("{0}借阅了一份文件给你", notice.UserRealName));
            }
        }


        void FrmPopup_Click(object sender, EventArgs e)
        {
            Debug.Print("点击了");
            if (_noticeFileID == 0) return;
            OpenFile(_noticeFileID.ToString());
            //标记已读  _noticeID   SET IsRead=1
            _fileShareBll.UpdateNotice(_noticeID);
        }

        private void skinTreeViewDep_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var d = e.Node.Tag as Department;
                if (d != null)
                {
                    var dt = new FileBLL().GetFileByDepartment(d.DepartmentID);
                    this.skinDataGridView1.DataSource = dt;
                    if (dt != null && dt.Rows.Count > 0)
                        skinDataGridView1.Rows[0].Selected = false;
                    this.skinGroupBox1.Text = "[" + e.Node.Text + "]" + "共" + dt.Rows.Count + "份文档(下列文档点击右键可以进行操作)";
                }
                var f = e.Node.Tag as FileSystem.Model.File;
                if (f != null)
                {
                    //点击了部门里面的一个文件夹
                }
            }
        }

        private void skinTreeViewDep_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeView tv = sender as TreeView;
                if (tv == null) return;
                TreeNode node = tv.GetNodeAt(e.X, e.Y);
                if (node == null) return;
                tv.SelectedNode = node;
                //通过反射找到所点击的TreeView，然后调用它的节点左键点击方法
                MethodInfo method = tv.GetType().GetMethod("OnNodeMouseClick", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                method?.Invoke(sender, new object[] { new TreeNodeMouseClickEventArgs(node, MouseButtons.Left, 1, 0, 0) });
            }
        }
    }
}