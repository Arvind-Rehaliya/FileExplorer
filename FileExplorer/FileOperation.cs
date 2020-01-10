using System;
using System.IO;

namespace FileExplorer {
    public class FileOperation {
        private static Base b;

        public FileOperation(Base b) {
            FileOperation.b = b;
            LoadFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            b.AddPathHistory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

        }

        public static void LoadFiles(string path) {
            if(!IsFileExists(path)) {
                System.Windows.Forms.MessageBox.Show("File path Not Exists: " + path);
                return;
            }

            b.ClearSpace();
            if(Directory.Exists(path)) {
                b.SetLocation(path);
                InternalLoadFiles(path);
            } else {
                string dirPath = new FileInfo(path).DirectoryName;
                b.SetLocation(dirPath);
                InternalLoadFiles(dirPath);
            }
        }

        private static void InternalLoadFiles(string dirpath) {
            string[] files = Directory.GetFileSystemEntries(dirpath);

            if(files.Length == 0) {
                b.lb_info.Visible = true;
                return;
            } else
                b.lb_info.Visible = false;

            foreach(string file in files) {
                if(Directory.Exists(file)) {
                    b.FillFiles(file, FileType.Directory);
                } else {
                    b.FillFiles(file, FileType.File);
                }
            }
        }

        public static void CopyFiles(string destPath, bool refresh, params object[] srcFiles) {
            try {
                foreach(string srcFile in srcFiles) {
                    if(Directory.Exists(srcFile)) {
                        string[] allFiles = Directory.GetFileSystemEntries(srcFile);
                        CopyFiles(CreateFolder(destPath, new DirectoryInfo(srcFile).Name, refresh), refresh, allFiles);

                    } else {
                        string destFile = CreateDocument(destPath + @"\" + new FileInfo(srcFile).Name, false);
                        System.IO.File.Copy(srcFile, destFile, true);
                    }
                }

            } catch(Exception) { throw; }
        }

        public static void DeleteFiles(object[] files) {
            foreach(string path in files) {
                if(IsDirectory(path)) {
                    DeleteFiles(Directory.GetFileSystemEntries(path));
                } else if(!IsFileExists(path))
                    return;
                try {
                    System.IO.File.Delete(path);
                } catch(Exception) { throw; }
            }
            SelectedFiles.Clear();
        }

        public static void RenameFile(string source, string destination) {
            try {
                System.IO.File.Move(source, destination);
            } catch(Exception) { throw; }
        }

        public static string CreateFolder(string path, string name, bool refresh) {
            try {
                string dirPath;
                int s = 0;
                if(Directory.Exists(dirPath = (path + @"\" + name)))
                    while(Directory.Exists(dirPath = (path + @"\" + (string.IsNullOrEmpty(name) ? "New Folder" + (++s).ToString() : name + " (" + (++s).ToString() + ")"))))
                        ;
                Directory.CreateDirectory(dirPath);
                if(refresh)
                    LoadFiles(path);
                return dirPath;

            } catch(Exception) { throw; }
        }

        public static string CreateDocument(string path, bool refresh) {
            try {
                string filePath, extn, name;
                int s = 0;

                if(Directory.Exists(path))
                    while(System.IO.File.Exists(filePath = (path + @"\File" + (++s).ToString() + ".txt")))
                        ;
                else {
                    extn = new System.IO.FileInfo(path).Extension;
                    name = new System.IO.FileInfo(path).Name;
                    name = name.Substring(0, name.LastIndexOf(extn));

                    if(System.IO.File.Exists(filePath = path))
                        while(System.IO.File.Exists(filePath = (path.Substring(0, path.LastIndexOf(name)) + name + " (" + (++s).ToString() + ")" + extn)))
                            ;
                }
                System.IO.File.Create(filePath).Close();
                if(refresh)
                    LoadFiles(path);
                return filePath;
            } catch(Exception) { throw; }
        }

        private static void Disp(string msg) {
            System.Windows.Forms.MessageBox.Show(msg);
        }

        public static bool IsDirectory(string path) {
            return Directory.Exists(path);
        }

        public static bool IsFileExists(string path) {
            return (System.IO.File.Exists(path) || Directory.Exists(path));
        }

    }
}
