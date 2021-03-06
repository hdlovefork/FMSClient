﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using FileSystem.Data;
using System.Threading;

namespace FileSystem
{

    public class LoginUser
    {
        public static int UserId;
        public static string UserName;
        public static string UserRealName;
    }

    static class Program
    {
        //[DllImport("dsoframer.ocx", EntryPoint = "DllRegisterServer")]
        //public static extern int DllRegisterServer();//注册时用
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //int result = DllRegisterServer();
            //Debug.Print("注册dsoframer.ocx返回{0}", result);
            bool bRun = true;
            System.Threading.Mutex m = new System.Threading.Mutex(true, "bc342945-3e75-430a-8948-0e2dcfa958be", out bRun);
            if (!bRun)
            {
                MessageBox.Show("程序已经在运行！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //与安全狗的互斥锁，当本进程退出时可以通知安全狗清空temp文件夹
            if (!File.Exists("watchdog.exe"))
            {
                MessageBox.Show("缺少必需文件 watchdog.exe ，请重新安装程序！","系统提示",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            Process psWatchDog = new Process
            {
                StartInfo =
                {
                    FileName="watchdog",
                    UseShellExecute=false,//如果直接从可执行文件创建进程，则为 false
                    RedirectStandardOutput=true,
                    CreateNoWindow=true,
                }
            };
            psWatchDog.OutputDataReceived += (sender, e) =>
                Debug.WriteLine(e.Data, "dog");
            psWatchDog.Start();//开启安全狗
            psWatchDog.BeginOutputReadLine();//开始异步读取安全狗在控制台的输出

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin frm = new frmLogin();
            if (frm.ShowDialog() == DialogResult.OK)
                Application.Run(new frmMain());
            try
            {
                Job.Instance.Dispose();
                m.ReleaseMutex();
                psWatchDog.WaitForExit();
                psWatchDog.Close();
            }
            catch { }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {

        }
    }
}
