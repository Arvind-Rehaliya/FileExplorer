using System;
using System.Collections;

namespace FileExplorer {
    class SelectedFiles {
        private static ArrayList locations = new ArrayList();
       
        public static object[] GetNames() {
            return locations.ToArray();
        }

        public static  void Add(string name) {
            locations.Add(name);
        }

        public static void Remove(string name) {
            locations.Remove(name);
        }

        public static void Clear() {
            locations.Clear();
        }

        
    }
}
