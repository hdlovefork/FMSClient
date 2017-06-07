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
using FileSystem.Data;

namespace FileSystem
{
    public partial class frmUpload : Form
    {
        FileBLL _fileBLL = new FileBLL();
        private int _fid;
        private int _newfileid;
        private int _id;
        private int _depid;
        private string _status;
        private string _fname;
        private bool refurbishdep;

        public frmUpload()
        {
            InitializeComponent();
        }

        public frmUpload(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmUpload_Load(object sender, EventArgs e)
        {
            //加载个人文件目录结构
            LoadComboxPersonl();
            LoadComboxDep();
        }

        private void LoadComboxDep()
        {
            IList<Department> d = new DepBLL().GetAll();
            comboBox2.DataSource = d;
            comboBox2.ValueMember = "DepartmentID";
            comboBox2.DisplayMember = "DepartmentName";
        }

        private void LoadComboxPersonl()
        {
            //this.comboBox1.Items.Add("个人文件");
            IList<FileNode> fnList = new List<FileNode>();
            AddChild(fnList, "   ", 0, -1);
            foreach (var fileNode in fnList)
            {
                comboBox1.Items.Add(fileNode);
            }
            if (_id > 0)
            {
                for (int i = 0; i < fnList.Count; i++)
                {
                    FileNode o = fnList[i];
                    if (o.File.FileID == _id)
                    {
                        this.comboBox1.SelectedIndex = (i);       //因为做了一个假定的参数所以要+1
                        break;
                    }
                }
            }
            else
                this.comboBox1.SelectedIndex = 0;
            if (comboBox1.Items.Count > 0)
            {
                lblCatelog.Text = comboBox1.Text.Trim();
            }
        }

        private void AddChild(IList<FileNode> fnList, string ch, int deep, int pid)
        {
            string chartStr = CloneStr(ch, deep);
            IList<File> fileList = _fileBLL.GetFilePersonlTree(pid, LoginUser.UserId);
            if (fileList.Count == 0)
            {
                return;
            }
            foreach (var file in fileList)
            {
                fnList.Add(new FileNode
                {
                    File = file,
                    ChartStr = chartStr,
                });
                AddChild(fnList, ch, deep + 1, file.FileID);
            }
        }

        private string CloneStr(string ch, int count)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append(ch);
            }
            return sb.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text))
            {
                MessageBox.Show("请选择上传文件!", "系统提示");
                return;
            }
            //获得目录编号，其子文件，都在父编号添加数据
            var t = comboBox1.SelectedItem as FileNode;
            if (t != null)
            {
                var fid = (comboBox1.SelectedItem as FileNode).File.FileID;
                var fname = comboBox1.Text.Trim();
                _fid = fid;
                _fname = fname;
                string aFirstName = this.textBox1.Text.Substring(this.textBox1.Text.LastIndexOf("\\") + 1, (this.textBox1.Text.LastIndexOf(".") - this.textBox1.Text.LastIndexOf("\\") - 1));   //文件名
                string aLastName = this.textBox1.Text.Substring(this.textBox1.Text.LastIndexOf(".") + 1, (this.textBox1.Text.Length - this.textBox1.Text.LastIndexOf(".") - 1));                //扩展名
                byte[] tmpfile = FileKit.GetFileData(this.textBox1.Text);
                File file = new File
                {
                    FileName = aFirstName,
                    FileCreateTime = DateTime.Now,
                    FileExt = aLastName,
                    FileData = tmpfile,
                    FilePID = fid,
                    FileSize = tmpfile.Length,
                    UserID = LoginUser.UserId
                };
                var check = new FileBLL().AddFile(file);
                NewFileId = new FileBLL().MaxId();
                if (check)
                {
                    _status = "personal";
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                    MessageBox.Show("文件添加失败！", "系统提示");
            }
            else
                MessageBox.Show("请选择对应目录！", "系统提示");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(jpg,gif,bmp,png,psd,ai,tif,mp3,wav,wma,flv,mpg,avi,wmv,mp4,txt,doc,docx,xls,xlsx,ppt,pptx)|*.jpg;*.bmp;*.png;*.psd;*.ai;*.tif;*.mp3;*.wav;*.wma;*.flv;*.mpg;*.avi;*.wmv;*.mp4;*.txt;*.doc;*.docx;*.xls;*.xlsx;*.ppt;*.pptx|All files(*.*)|*.*";
            openFileDialog1.FileName = "";
            DialogResult result = openFileDialog1.ShowDialog();
            var filePath = "";
            if (result == DialogResult.OK)
            {
                filePath = this.openFileDialog1.FileName;
                this.textBox1.Text = filePath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int Id
        {
            get { return _id; }
        }
        public int NewFileId
        {
            get { return _newfileid; }
            set { _newfileid = value; }
        }
        public int SelectFid
        {
            get { return _fid; }
            set { _fid = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string Fname
        {
            get { return _fname; }
        }
        public bool Refurbishdep
        {
            get { return refurbishdep; }
            set { refurbishdep = value; }
        }
        public int Depid
        {
            get { return _depid; }
            set { _depid = value; }
        }

        //部门上传
        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox2.Text))
            {
                MessageBox.Show("请选择上传文件!", "系统提示");
                return;
            }
            //获得目录编号，其子文件，都在父编号添加数据
            var t = comboBox2.SelectedItem as Department;
            if (t != null)
            {
                if (comboBox2.SelectedItem as Department == null) return;
                _depid = (comboBox2.SelectedItem as Department).DepartmentID;
                var fname = comboBox2.Text.Trim();
                _fname = fname;
                string aFirstName = this.textBox2.Text.Substring(this.textBox2.Text.LastIndexOf("\\") + 1, (this.textBox2.Text.LastIndexOf(".") - this.textBox2.Text.LastIndexOf("\\") - 1));   //文件名
                string aLastName = this.textBox2.Text.Substring(this.textBox2.Text.LastIndexOf(".") + 1, (this.textBox2.Text.Length - this.textBox2.Text.LastIndexOf(".") - 1));                //扩展名
                byte[] tmpfile = FileKit.GetFileData(this.textBox2.Text);
                File file = new File
                {
                    FileName = aFirstName,
                    FileCreateTime = DateTime.Now,
                    FileExt = aLastName,
                    FileData = tmpfile,
                    FilePID = -1,
                    FileSize = tmpfile.Length,
                    UserID = LoginUser.UserId
                };
                NewFileId = new FileBLL().AddFileDep(file, _depid);
                if (NewFileId > 0)
                {
                    _status = "department";
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                    MessageBox.Show("文件添加失败！", "系统提示");
            }
            else
                MessageBox.Show("请选择对应目录！", "系统提示");
        }

        public class FileNode
        {
            public File File { get; set; }
            public string ChartStr { set; get; }
            public override string ToString()
            {
                return string.Format("{0}{1}", ChartStr, File.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(jpg,gif,bmp,png,psd,ai,tif,mp3,wav,wma,flv,mpg,avi,wmv,mp4,txt,doc,docx,xls,xlsx,ppt,pptx)|*.jpg;*.bmp;*.png;*.psd;*.ai;*.tif;*.mp3;*.wav;*.wma;*.flv;*.mpg;*.avi;*.wmv;*.mp4;*.txt;*.doc;*.docx;*.xls;*.xlsx;*.ppt;*.pptx|All files(*.*)|*.*";
            openFileDialog1.FileName = "";
            DialogResult result = openFileDialog1.ShowDialog();
            var filePath = "";
            if (result == DialogResult.OK)
            {
                filePath = this.openFileDialog1.FileName;
                this.textBox2.Text = filePath;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox1.Text = this.comboBox1.Text.Trim();
            lblCatelog.Text = this.comboBox1.Text.Trim();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            this.comboBox1.Text = this.comboBox1.Text.Trim();
        }

        private void lblCatelog_Click(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }
    }
}
