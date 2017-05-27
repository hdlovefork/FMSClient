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
                CreatCatalogTreeByPid(node,node.Name, LoginUser.UserId);
  
                skinTreeView1.ExpandAll();
            }
            catch { 
            
            
            }
            
        }
        
        private void CreatCatalogTreeByPid(TreeNode node, string p,int UserId)
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
                    CreatCatalogTreeByPid(n, n.Name,UserId);    //用递归的方法添加完整的树节点
                }
            }
        
        }

        private void frmCatalogManage_Load(object sender, EventArgs e)
        {
            CreatCatalogTree();
        }

        private void skinTreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            File f = e.Node.Tag as File;
            _selectedNode = e.Node;//保存当前选中的节点
            if (_selectedNode.Name == "-1")
            {
                this.skinTextBox1.SkinTxt.Text = "目录管理";
            }else
            {
                if (f == null) return;
                this.skinTextBox1.SkinTxt.Text = f.FileName;
            }
            
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.skinGroupBox2.Enabled = true;
            _bAdd = true;
            
        }

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
        }
        private bool AddFunction()
        {
            bool pd = false;
            if (_selectedNode.Name != "-1")
            {
                File f = _selectedNode.Tag as File;
                File f1 = new File
                {
                    FileName = this.skinTextBox1.SkinTxt.Text,
                    FileSize = 0,
                    FilePID = f.FileID,

                };
                bool ok = new FileBLL().AddCatalogFile(f1);
                if (ok)
                {
                    ACL_File_User acl = new ACL_File_User()
                    {
                        FileID = new FileBLL().MaxId(),
                        UserID = LoginUser.UserId
                    };
                    bool o = new ACLFileUserBLL().AddFilUser(acl);
                    if (o)
                    {
                        ReloadTree();
                        pd = true;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("添加失败");
                    }
                }
            }
            if (_selectedNode.Name == "-1")
            {
                File f1 = new File
                {
                    FileName = this.skinTextBox1.SkinTxt.Text,
                    FileSize = 0,
                    FilePID = -1,

                };
                bool ok = new FileBLL().AddCatalogFile(f1);
                if (ok)
                {
                    ACL_File_User acl = new ACL_File_User()
                    {
                        FileID = new FileBLL().MaxId(),
                        UserID = LoginUser.UserId
                    };
                    bool o = new ACLFileUserBLL().AddFilUser(acl);
                    if (o)
                    {
                        ReloadTree();
                        pd = true;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("添加失败");
                    }
                }
            }
            return pd;
        }


        private bool UpdateCatalog() {
            this.skinGroupBox2.Enabled = true;
            if (_selectedNode == null) return true;
            if (_selectedNode.Name == "-1")
            {
                MessageBox.Show("主目录不可修改");
            }
            string bname = _selectedNode.Text;
            string lname = this.skinTextBox1.SkinTxt.Text.Trim();
            if (string.IsNullOrWhiteSpace(lname))
            {
                MessageBox.Show("目录名不能为空");
                return  false;
            }
            //更新的方法
            bool ok = new FileBLL().UpdateCatalog(lname,bname);
            if (ok)
            {
                MessageBox.Show("更新成功");
                ReloadTree();
            }
            return true;
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
            if (_selectedNode.Name == "-1") {
                MessageBox.Show("主目录不可删除");
            }
            File f = _selectedNode.Tag as File;
            if (f == null) return;
            if (new FileBLL().GetFileByUser(LoginUser.UserId,f.FileID).Rows.Count > 0)
            {
                MessageBox.Show("请先删除该目录下的文件", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //从数据库中删除
            DialogResult d = MessageBox.Show("是否删除 "+f.FileName+" 目录？","温馨提示",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (d == DialogResult.Yes)
            {
                bool ok = new FileBLL().DeleteCatalog(f.FileID);
                /////
                if (ok)
                {
                    this.skinTreeView1.Nodes.Remove(_selectedNode);
                    ReloadTree();
                }
            }
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.skinGroupBox2.Enabled = true;
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            this.skinGroupBox2.Enabled = false;
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
    }
}

