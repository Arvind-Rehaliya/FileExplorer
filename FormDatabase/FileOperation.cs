﻿using System;
using System.IO;

namespace FormDatabase
{
    public class FileOperation
    {
        private static Base b;
        
        public FileOperation(Base b)
        {
            FileOperation.b = b;
            Fill(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        }

        public static void Fill(string path)
        {
            b.ClearSpace();
            try
            {
                b.tb_path.Text = path;
                b.AddPathHistory(path);

                string[] allFiles = Directory.GetFileSystemEntries(path);
                if (allFiles.Length == 0) b.lb_info.Visible = true;
                else b.lb_info.Visible = false;

                foreach (string s in allFiles)
                {                        
                    if (Directory.Exists(s))
                      {
                          b.FillFiles(new DirectoryInfo(s).Name, Type.Directory);
                      }
                     else
                      {
                        b.FillFiles(new DirectoryInfo(s).Name, Type.File);
                    }                    
                }

            }
            catch(Exception) { throw; }
        }

        public static bool CopyFile(string srcFile, string destfile)
        {
            try
            {
                System.IO.File.Copy(srcFile, destfile, true);
                Console.WriteLine("done.");
                return true;
            }
            catch(Exception e) { Console.WriteLine(e.Message + " : " + e.StackTrace); }
            return false;
        }
    }
}
