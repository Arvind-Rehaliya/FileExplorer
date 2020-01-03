using System;
using System.IO;

namespace FileExplorer {
    public class FileOperation {
        private static Base b;

        public FileOperation(Base b) {
            FileOperation.b = b;
            Fill(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            b.AddPathHistory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        }

        public static void Fill(string path) {
            b.ClearSpace();
            try {
                b.SetLocationBar(path);

                string[] allFiles = Directory.GetFileSystemEntries(path);
                if(allFiles.Length == 0) {
                    b.lb_info.Visible = true;
                } else {
                    b.lb_info.Visible = false;
                }

                foreach(string s in allFiles) {
                    if(Directory.Exists(s)) {
                        b.FillFiles(s, FileType.Directory);
                    } else {
                        b.FillFiles(s, FileType.File);
                    }
                }

            } catch(Exception) { throw; }
        }

        public static void CopyFile(string srcFile, string destfile) {
            try {
                System.IO.File.Copy(srcFile, destfile, true);
                Console.WriteLine("done.");

            } catch(Exception) { throw; }
        }

        public static void RenameFile(string source, string destination) {
            try {
                System.IO.File.Move(source, destination);

            } catch(Exception) { throw; }
        }

        public static void CreateFolder(string path) {
            try {
                string t;
                int s = 0;
                while (Directory.Exists(t = (path + @"\New Folder" + (++s).ToString())));
                
                Directory.CreateDirectory(t);
                Fill(path);
                

            } catch(Exception) { throw; }
        }

        public static void CreateDocument(string path) {
            try {
                string t;
                ushort s = 0;
                while(System.IO.File.Exists(t = (path + @"\File" + (++s).ToString() + ".txt")));

                System.IO.File.Create(t);
                Fill(path);
                
            } catch(Exception) { throw; }
        }

        private static void disp(string msg) {
            System.Windows.Forms.MessageBox.Show(msg);
        }
    }
}
