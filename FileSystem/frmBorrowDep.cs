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
    public partial class frmBorrowDep : Form
    {
        public frmBorrowDep()
        {
            InitializeComponent();
        }
        private int FileId;
        public frmBorrowDep(int FileId)
        {
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
            Department d = sli.Tag as Department;
            bool ok = new File_ShareBLL().AddFile_Dep(FileId,d.DepartmentID);
            if (ok)
            {
                MessageBox.Show("借阅成功");
                this.Close();
            }
        }

        private void frmBorrowDep_Load(object sender, EventArgs e)
        {
            List<Department> deps = new DepBLL().GetAll();
            if (deps != null && deps.Count > 0)
            {
                foreach (var t in deps)
                {
                    SkinListBoxItem sli = new SkinListBoxItem();
                    sli.Text = t.DepartmentName;
                    sli.Tag = t;
                    sli.Image = imageList1.Images[0];
                    this.skinListBox1.Items.Add(sli);
                }
            }
        }
    }
}
