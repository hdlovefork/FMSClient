using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileSystem.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace WatchDog
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("安全狗启动！开始监视BlueSky应用程序！...");
            bool bRun;
            try
            {
                System.Threading.Mutex m = new System.Threading.Mutex(true, "bc342945-3e75-430a-8948-0e2dcfa958be", out bRun);
                if (!bRun)
                    m.WaitOne();
            }
            finally
            {
                try
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("准备清理文件");
                    var path = string.Format("{0}\\temp", Application.StartupPath);
                    //KillProcess();
                    if (Directory.Exists(path))
                    {
                        FileKit.DeleteFolder(path);
                        Console.WriteLine("安全狗已为主人自动清空了文件！");
                    }
                    else
                    {
                        Directory.CreateDirectory(path);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("删除文件发生异常:{0}",e.Message);
                }
            }
        }

        //private static void KillProcess()
        //{
        //    Process[] ps = Process.GetProcessesByName("ffplay.exe");
        //    Debug.Print("{0}", ps.Length);
        //    foreach (Process p in ps)
        //    {
        //        p.Kill();
        //    }
        //}
    }
}
