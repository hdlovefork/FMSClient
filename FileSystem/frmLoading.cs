using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileSystem
{
    public partial class frmLoading : Form
    {
        private static readonly frmLoading _frm = new frmLoading();

        public frmLoading()
        {
            InitializeComponent();
        }

        public static void ShowTop()
        {
            _frm.Show();
        }

        public static new void Close()
        {
            _frm.Hide();
        }
    }
}
