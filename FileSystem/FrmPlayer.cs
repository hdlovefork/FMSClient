using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FileSystem
{
    public partial class FrmPlayer : Form
    {
        [DllImport("user32")]
        private static extern bool SetWindowText(IntPtr hwnd, string title);
        [DllImport("user32")]
        private static extern bool SendMessage(IntPtr hwnd, uint msg, int wparam, int lparam);
        [DllImport("user32")]
        private extern static bool DestroyIcon(IntPtr handle);

        Process _process;
        string _filePath;
        string _fileName;

        public FrmPlayer(string filePath,string fileName)
        {
            InitializeComponent();
            _filePath = filePath;
            _fileName = fileName;
        }

        public new void Show()
        {
            base.Show();
            _process = new Process
            {
                StartInfo =
                        {
                            FileName="ffplay",
                            Arguments = _filePath,
                            //UseShellExecute=false,
                            WindowStyle = ProcessWindowStyle.Hidden
                        }
            };
            _process.Start();
            Thread.Sleep(200);
            SetWindowText(_process.MainWindowHandle, _fileName);//设置窗口标题
            IntPtr hIcon =  this.Icon.ToBitmap().GetHicon();
            SendMessage(_process.MainWindowHandle, 0x80, 0, hIcon.ToInt32());
            DestroyIcon(hIcon);//释放图标资源
        }

        private void FrmPlayer_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _process.Kill();
            }
            catch { }
        }
    }
}
