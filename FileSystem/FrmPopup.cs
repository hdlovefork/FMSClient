using SufeiUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystem
{
    public partial class FrmPopup : CCWin.CCSkinMain
    {
        public static event System.EventHandler ClickNotice;

        static FrmPopup _frmPopup;
        static Timer _timer1;
        static bool _isPopup;

        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);


        //下面是可用的常量，根据不同的动画效果声明自己需要的
        private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志
        private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        private const int AW_HIDE = 0x10000;//隐藏窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        private const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果

        private void FrmPopup_Load(object sender, EventArgs e)
        {
            try
            {
                MediaHandler.ASyncPlayWAV("msg.wav");
            }
            catch { }
            int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            this.Location = new Point(x, y);//设置窗体在屏幕右下角显示
            AnimateWindow(this.Handle, 1000, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE);
        }

        private void FrmPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            //AnimateWindow(this.Handle, 1000, AW_BLEND | AW_HIDE);
            //int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            //int y = Screen.PrimaryScreen.WorkingArea.Bottom;
            //this.Location = new Point(x, y);
            AnimateWindow(this.Handle, 1000, AW_BLEND | AW_HIDE);
            _isPopup = false;
        }

        public FrmPopup()
        {
            InitializeComponent();
            _timer1 = new Timer();
            _timer1.Interval = 6000;//默认显示6秒
            _timer1.Tick += timer1_Tick;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void Show(string caption, string content, int duration)
        {
            if (_isPopup) return;
            _isPopup = true;
            _frmPopup = new FrmPopup();
            _frmPopup.Text = caption;
            _frmPopup.lblContent.Text = content;
            if (duration > 0)
            {
                _timer1.Interval = duration;
                _timer1.Enabled = true;
            }
            _frmPopup.Show();
        }
        public static void Show(string content)
        {
            Show("新消息", content, 0);
        }

        public static void ClosePopup()
        {
            if (_frmPopup != null)
                _frmPopup.Close();
        }

        private void FrmPopup_Click(object sender, EventArgs e)
        {
            if (ClickNotice != null)
                ClickNotice(sender, e);
            _frmPopup.Close();
        }
    }
}
