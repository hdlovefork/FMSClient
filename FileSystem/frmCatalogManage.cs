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

namespace FileSystem
{
    public partial class frmCatalogManage : Form
    {
        TreeNode _selectedNode = null;//保存最后一次点击的节点
        bool _bAdd = false;//当前是否正在添加目录

        public frmCatalogManage()
        {
            InitializeComponent();
        }

        private void CreatCatalogTree()
        {
            try
            {
                TreeNode node = new TreeNode();             //定义根节点
                node.Name = "-1";                            //将类Model的各个属性赋值给根节点
                node.Text = "目录管理";
                this.skinTreeView1.Nodes.Add(node);
                CreatCatalogTreeByPid(node, node.Name, LoginUser.UserId);
                skinTreeView1.ExpandAll();
            }
            catch
            {


            }

        }

        private void CreatCatalogTreeByPid(TreeNode node, string p, int UserId)
        {

            IList<File> lst = new FileBLL().GetCatalogTree(Convert.ToInt32(p), UserId);
            if (lst != null && lst.Count > 0)
            {
                foreach (File file in lst)
                {
                    TreeNode n = new TreeNode();
                    n.Name = file.FileID.ToString();
                    n.Text = file.FileName.ToString();
                    n.Tag = file;
                    node.Nodes.Add(n);
                    CreatCatalogTreeByPid(n, n.Name, UserId);    //用递归的方法添加完整的树节点
                }
            }

        }

        private void frmCatalogManage_Load(object sender, EventArgs e)
        {
            CreatCatalogTree();
        }

        private void skinTreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _selectedNode = e.Node; //保存当前选中的节点
            ShowSelectedNode(_selectedNode);
        }

        /// <summary>
        /// 在右边显示当前选中的目录名称
        /// </summary>
        /// <param name="node"></param>
        private void ShowSelectedNode(TreeNode node)
        {
            if (node == null) return;
            if (node.Name == "-1")
            {
                this.txtFileName.SkinTxt.Text = "目录管理";
            }
            else
            {
                File f = node.Tag as File;
                if (f == null) return;
                this.txtFileName.SkinTxt.Text = f.FileName;
            }
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.skinGroupBox2.Enabled = true;
            _bAdd = true;
            txtFileName.SkinTxt.Text = string.Empty;
        }

        private bool _hasUpdate;//记录是否成功添加/更新目录到数据库
        private void skinButton1_Click(object sender, EventArgs e)
        {
            if (_bAdd)
            {
                //执行添加操作，没有添加成功不作任何操作               
                if (!AddFunction()) return;
                _bAdd = false;//把添加状态改为更新状态
            }
            else
            {
                if (!UpdateCatalog()) return;
            }
            this.skinGroupBox2.Enabled = false;
            _hasUpdate = true;
            ReloadTree();
        }
        private bool AddFunction()
        {
            bool ok = false;
            File file = _selectedNode.Tag as File;
            int? fileID = file?.FileID;
            fileID = fileID ?? -1;
            File f1 = new File
            {
                FileName = this.txtFileName.SkinTxt.Text,
                FileSize = 0,
                FilePID = fileID,
                UserID = LoginUser.UserId,
            };
            ok = new FileBLL().AddCatalogFile(f1);
            if (!ok)
            {
                MessageBox.Show("添加失败");
            }
            return ok;
        }


        private bool UpdateCatalog()
        {
            this.skinGroupBox2.Enabled = true;
            if (_selectedNode == null) return true;
            if (_selectedNode.Name == "-1")
            {
                MessageBox.Show("主目录不可修改");
                return false;
            }
            string lname = this.txtFileName.SkinTxt.Text.Trim();
            if (string.IsNullOrWhiteSpace(lname))
            {
                MessageBox.Show("目录名不能为空");
                return false;
            }
            File file = _selectedNode.Tag as File;
            int? fileID = file?.FileID;
            if (fileID == null) return false;
           
            File f = new File()
            {
                FileID = (int)fileID,
                FileName = lname
            };
            //更新的方法
            bool ok = new FileBLL().UpdateCatalog(f);
            if (ok)
            {
                MessageBox.Show("更新成功");
                ReloadTree();
            }
            return ok;
        }


        private void ReloadTree()
        {
            skinTreeView1.Nodes.Clear();//清空所有节点
            CreatCatalogTree();//初始化所有节点
            skinTreeView1.ExpandAll();//展开所有 节点
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedNode == null) return;
            if (_selectedNode.Name == "-1")
            {
                MessageBox.Show("主目录不可删除");
            }
            File f = _selectedNode.Tag as File;
            if (f == null) return;
            if (new FileBLL().GetFileByUser(LoginUser.UserId, f.FileID).Rows.Count > 0)
            {
                MessageBox.Show("请先删除该目录下的文件", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //从数据库中删除
            DialogResult d = MessageBox.Show("是否删除 " + f.FileName + " 目录？", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (d == DialogResult.Yes)
            {
                bool ok = new FileBLL().DeleteCatalog(f.FileID);
                /////
                if (ok)
                {
                    this.skinTreeView1.Nodes.Remove(_selectedNode);
                    ReloadTree();
                    _hasUpdate = true;
                }
            }
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _bAdd = false;
            this.skinGroupBox2.Enabled = true;
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            this.skinGroupBox2.Enabled = false;
            ShowSelectedNode(_selectedNode);
        }

        private void skinTreeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) return;
            TreeView tv = sender as TreeView;
            if (tv == null) return;
            TreeNode node = tv.GetNodeAt(e.X, e.Y);
            if (node == null) return;
            tv.SelectedNode = node;
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
            if (_hasUpdate)
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;
        }
    }
}

