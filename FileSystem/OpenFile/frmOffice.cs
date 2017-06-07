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
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FileSystem
{
    public partial class frmOffice : Form
    {
        private string path = "";
        public frmOffice()
        {
            InitializeComponent();
        }

        Process _process;
        string _filePath;
        string _fileName;

        public frmOffice(string filePath, string fileName)
        {
            InitializeComponent();
            _filePath = filePath;
            _fileName = fileName;
        }

        public new void Show()
        {
            base.Show();
            //_process = Process.Start(_filePath);
        }

        public frmOffice(string p, bool readOnly, string ext)
        {
            InitializeComponent();
            path = p;
            mReadOnly = readOnly;
            mExt = ext;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // this.axFramerControl1.Open(path,false,LoadOpenFileType(mExt),null,null);
            //this.axFramerControl2.Open(path, mReadOnly, null, null, null);
            //this.webBrowser1.Navigate(path);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 根据后缀名得到打开方式
        /// </summary>
        /// <param name="_sExten"></param>
        /// <returns></returns>
        private string LoadOpenFileType(string _sExten)
        {
            try
            {
                string sOpenType = "";
                switch (_sExten.ToLower())
                {
                    case "xls":
                        sOpenType = "Excel.Sheet";
                        break;
                    case "doc":
                        sOpenType = "Word.Document";
                        break;
                    case "ppt":
                    case "pptx":
                        sOpenType = "PowerPoint.Show";
                        break;
                    case "vsd":
                        sOpenType = "Visio.Drawing";
                        break;
                    default:
                        sOpenType = "Word.Document";
                        break;
                }
                return sOpenType;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool mReadOnly { get; set; }

        public string mExt { get; set; }

        private void frmOffice_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
               // _process.Kill();
            }
            catch { }
        }
    }
}
