using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileSystem.Data
{
    public class FileKit
    {
        /// <summary>
        /// 将文件转换成byte[] 数组
        /// </summary>
        /// <param name="fileUrl">文件路径文件名称</param>
        /// <returns>byte[]</returns>
        public static byte[] GetFileData(string fileUrl)
        {
            FileStream fs = new FileStream(fileUrl, FileMode.Open, FileAccess.Read);
            try
            {
                byte[] buffur = new byte[fs.Length];
                fs.Read(buffur, 0, (int)fs.Length);
                return buffur;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                if (fs != null)
                {
                    //关闭资源
                    fs.Close();
                }
            }
        }

        /// 清空指定的文件夹，但不删除文件夹
        /// </summary>
        /// <param name="dir"></param>
        public static void DeleteFolder(string dir)
        {
            foreach (string d in Directory.GetFileSystemEntries(dir))
            {
                if (File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        fi.Attributes = FileAttributes.Normal;
                    File.Delete(d);//直接删除其中的文件  
                }
                else
                {
                    DirectoryInfo d1 = new DirectoryInfo(d);
                    if (d1.GetFiles().Length != 0)
                    {
                        DeleteFolder(d1.FullName);////递归删除子文件夹
                    }
                    Directory.Delete(d);
                }
            }
        }        /// <summary>
        /// 删除文件夹及其内容
        /// </summary>
        /// <param name="dir"></param>
        public static void DeleteFolder1(string dir)
        {
            foreach (string d in Directory.GetFileSystemEntries(dir))
            {
                if (File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        fi.Attributes = FileAttributes.Normal;
                    File.Delete(d);//直接删除其中的文件  
                }
                else
                    DeleteFolder(d);////递归删除子文件夹
                Directory.Delete(d);
            }
        }

        /// <summary>  
        /// 转换方法  
        /// </summary>  
        /// <param name="size">字节值</param>  
        /// <returns></returns>  
        private static String HumanReadableFilesize(double size)
        {
            String[] units = new String[] { "B", "KB", "MB", "GB", "TB", "PB" };
            double mod = 1024.0;
            int i = 0;
            while (size >= mod)
            {
                size /= mod;
                i++;
            }
            return Math.Round(size) + units[i];
        }  

        /// <summary>
        /// 将文件转换成byte[] 数组
        /// </summary>
        /// <param name="fileUrl">文件路径文件名称</param>
        /// <returns>byte[]</returns>

        public static byte[] AuthGetFileData(string fileUrl)
        {
            using (FileStream fs = new FileStream(fileUrl, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                byte[] buffur = new byte[fs.Length];
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write(buffur);
                    bw.Close();
                }
                return buffur;
            }
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="dirName"></param>
        /// <returns></returns>
        public static bool CreateDir(string dirName)
        {
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            return true;
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool CreateFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                FileStream fs = File.Create(fileName);
                fs.Close();
                fs.Dispose();
            }
            return true;
        }

        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool Exists(string fileName)
        {
            if (fileName == null || fileName.Trim() == "")
            {
                return false;
            }

            if (File.Exists(fileName))
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="content">文件内容</param>
        /// <returns></returns>
        public static bool Write(string fileName, string content)
        {
            if (!Exists(fileName) || content == null)
            {
                return false;
            }

            //将文件信息读入流中
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                lock (fs)//锁住流
                {
                    if (!fs.CanWrite)
                    {
                        throw new System.Security.SecurityException("文件fileName=" + fileName + "是只读文件不能写入!");
                    }

                    byte[] buffer = Encoding.Default.GetBytes(content);
                    fs.Write(buffer, 0, buffer.Length);
                    return true;
                }
            }
        }

        /// <summary>
        /// 写入一行
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public static bool WriteLine(string fileName, string content)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate | FileMode.Append))
            {
                lock (fs)
                {
                    if (!fs.CanWrite)
                    {
                        throw new System.Security.SecurityException("文件fileName=" + fileName + "是只读文件不能写入!");
                    }

                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(content);
                    sw.Dispose();
                    sw.Close();
                    return true;
                }
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileName">文件的完整路径</param>
        /// <returns></returns>
        public static bool DeleteFile(string fileName)
        {
            if (Exists(fileName))
            {
                File.Delete(fileName);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 在指定的目录中查找文件
        /// </summary>
        /// <param name="dir">目录</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static bool FindFile(string dir, string fileName)
        {
            if (dir == null || dir.Trim() == "" || fileName == null || fileName.Trim() == "" || !Directory.Exists(dir))
            {
                return false;
            }
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            return FindFile(dirInfo, fileName);
        }


        public static bool FindFile(DirectoryInfo dir, string fileName)
        {
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                if (File.Exists(d.FullName + "\\" + fileName))
                {
                    return true;
                }
                FindFile(d, fileName);
            }
            return false;
        }
    }
}
