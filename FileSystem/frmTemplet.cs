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
using System.IO;
using System.Diagnostics;

namespace FileSystem
{
    public partial class frmTemplet : Form
    {
        public frmTemplet()
        {
            InitializeComponent();
        }

        private void frmTemplet_Load(object sender, EventArgs e)
        {
            LoadWorldDoc();
            LoadExcelDoc();
            LoadPPTDoc();
        }

        private void LoadPPTDoc()
        {
            DataTable dt = new DOCTempleteBLL().GetTempleteByType(3);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.listViewPPT.View = View.LargeIcon;
                this.listViewPPT.LargeImageList = this.imageList1;
                this.listViewPPT.BeginUpdate();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.ImageIndex = 2;
                    lvi.Text = dt.Rows[i]["TempleteName"].ToString();
                    lvi.Tag = dt.Rows[i]["TempleteID"].ToString();
                    this.listViewPPT.Items.Add(lvi);
                }
                this.listViewPPT.EndUpdate();
            }
        }

        private void LoadExcelDoc()
        {
            DataTable dt = new DOCTempleteBLL().GetTempleteByType(2);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.listViewExcel.View = View.LargeIcon;
                this.listViewExcel.LargeImageList = this.imageList1;
                this.listViewExcel.BeginUpdate();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.ImageIndex = 1;
                    lvi.Text = dt.Rows[i]["TempleteName"].ToString();
                    lvi.Tag = dt.Rows[i]["TempleteID"].ToString();
                    this.listViewExcel.Items.Add(lvi);
                }
                this.listViewExcel.EndUpdate();
            }
        }

        private void LoadWorldDoc()
        {
            DataTable dt = new DOCTempleteBLL().GetTempleteByType(1);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.listViewWord.View = View.LargeIcon;
                this.listViewWord.LargeImageList = this.imageList1;
                this.listViewWord.BeginUpdate();  
                for(int i=0;i<dt.Rows.Count;i++){
                    ListViewItem lvi = new ListViewItem();
                    lvi.ImageIndex = 0;
                    lvi.Text = dt.Rows[i]["TempleteName"].ToString();
                    lvi.Tag = dt.Rows[i]["TempleteID"].ToString();
                    this.listViewWord.Items.Add(lvi);  
                }
                this.listViewWord.EndUpdate();  
            }
        }

        private void listViewWord_DoubleClick(object sender, EventArgs e)
        {
            var items = this.listViewWord.SelectedItems;
            foreach (ListViewItem item in items)
            {
                int id = Convert.ToInt32(item.Tag);
                ProcessFile(id);
            }
        }

        private void listViewExcel_DoubleClick(object sender, EventArgs e)
        {
            var items = this.listViewExcel.SelectedItems;
            foreach (ListViewItem item in items)
            {
                int id = Convert.ToInt32(item.Tag);
                ProcessFile(id);
            }
        }

        private void listViewPPT_DoubleClick(object sender, EventArgs e)
        {
            var items = this.listViewPPT.SelectedItems;
            foreach (ListViewItem item in items)
            {
                int id = Convert.ToInt32(item.Tag);
                ProcessFile(id);
            }
        }

        //方法二：随机生成字符串（数字和字母混和）
        private int rep = 0;
        private string GenerateCheckCode(int codeCount)
        {
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + this.rep;
            this.rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> this.rep)));
            for (int i = 0; i < codeCount; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }

        private void ProcessFile(int id)
        {
            List<DOC_Templete> lst = new DOCTempleteBLL().GetOne(id);
            if (lst != null && lst.Count > 0) {
                try
                {
                    //生成本地文件
                    var Files = (Byte[])lst[0].TempleteData;
                    var name = GenerateCheckCode(20);
                    var ext = lst[0].TempleteExt;
                    var path = string.Format("{0}\\temp\\{1}.{2}", Application.StartupPath, name, ext);
                    var bw = new BinaryWriter(System.IO.File.Open(path, FileMode.OpenOrCreate));
                    bw.Write(Files, 0, Files.Length);
                    bw.Flush();
                    bw.Close();
                    Process.Start(path);
                }
                catch
                {
                    //奇葩文件不报错
                }
            }
        }
    }
}
