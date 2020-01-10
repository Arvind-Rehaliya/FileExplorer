using System;
using System.Collections;

namespace FileExplorer {
    internal class SelectedFiles {
        private static ArrayList locations = new ArrayList();
        private static object[] copy_buffer;
        internal static string LastSelectedFile { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static object[] GetNames() {
            return locations.ToArray();
        }

        public static void SetCopyBuffer() {
            copy_buffer = locations.ToArray();
        }

        public static object[] GetCopyBufferValues() {
            try {
                return copy_buffer;
            } catch(Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); }
            return null;
        }
        
        public static int GetByPath(string path) {
            return locations.LastIndexOf(path);
        }

        public static void Add(string name) {
            locations.Add(name);
        }

        public static void Remove(string name) {
            locations.Remove(name);
        }

        public static void Clear() {
            locations.Clear();
            LastSelectedFile = null;
        }

        public static void ClearCopyBuffer() {
            copy_buffer = null;
        }

    }
}
