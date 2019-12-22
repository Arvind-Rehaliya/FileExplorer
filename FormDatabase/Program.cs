using System;
using System.Windows.Forms;

namespace FileExplorer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Base b = new Base();
            FileOperation op = new FileOperation(b);

            Application.EnableVisualStyles();
         //   Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(b);
            
        }
    }
}
