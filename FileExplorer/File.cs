using System;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace FileExplorer {
    public partial class File : Form {
        private string Path, FileName;
        private Enum type;
        private bool isNameClicked = false;
        public bool Clicked { get; set; }
        public bool Selected { get; private set; }
        private Base b;
        private Timer timer;
        private MenuItem m_open, m_cut, m_copy, m_delete, m_paste, m_rename, m_prop;


        public File(string Path, Enum type, Base b) {
            InitializeComponent();
            this.Path = Path;
            this.type = type;
            this.b = b;

            CreateFile();
            SetTimer();
            CreateContextMenu();

        }

        private void CreateFile() {
            FileName = new System.IO.DirectoryInfo(Path).Name;
            tb_name.Text = FileName;
            if(type.ToString().Equals("Directory"))
                pb_file.Image = Properties.Resources.folder;
            else
                pb_file.Image = Properties.Resources.document_160;
        }

        private void File_MouseHover(object sender, EventArgs e) { }

        public string GetName() {
            return FileName;
        }

        public string GetPath() {
            return Path;
        }

        public void SelectFile() {
            if(Selected)
                return;
            fl_file.Focus();
            Selected = true;
            fl_file.BackColor = Color.SteelBlue;
            SelectedFiles.Add(Path);
        }

        public void UnSelectFile() {
            if(!Selected)
                return;
            Selected = false;
            fl_file.BackColor = Color.Empty;
        }

        private void CreateContextMenu() {
            m_open = new MenuItem("Open");
            m_cut = new MenuItem("Cut");
            m_copy = new MenuItem("Copy");
            m_delete = new MenuItem("Delete");
            m_paste = new MenuItem("Paste");
            m_rename = new MenuItem("Rename");
            m_prop = new MenuItem("Properties");

            m_open.Click += (o, e) => {
                FileDoubleClicked();
            };

            m_cut.Click += (o, e) => {
                b.CutClicked = true;
                b.pn_flow.ContextMenu.MenuItems[2].Enabled = true;
                SelectedFiles.SetCopyBuffer();
            };

            m_copy.Click += (o, e) => {
                b.CopyClicked = true;
                b.pn_flow.ContextMenu.MenuItems[2].Enabled = true;
                SelectedFiles.SetCopyBuffer();
            };

            m_delete.Click += (o, e) => {
                try {
                    FileOperation.DeleteFiles(SelectedFiles.GetNames());
                    b.LoadFiles(b.CurrentLocation);
                } catch(Exception ex) { MessageBox.Show(ex.Message); UnSelectFile(); }
            };


            m_paste.Click += (o, e) => {
                b.PasteFiles();
            };

            m_rename.Click += (o, e) => {
                RenameFile();
            };

            m_prop.Click += (o, e) => {
                FileProperties();
            };

            ContextMenu menu = new ContextMenu(new MenuItem[] { m_open, m_cut, m_copy, m_delete, m_rename, m_prop });
            fl_file.ContextMenu = menu;

            fl_file.ContextMenu.Popup += (o, ev) => {
                if(b.CutClicked || b.CopyClicked) {
                    if(!fl_file.ContextMenu.MenuItems.Contains(m_paste))
                        fl_file.ContextMenu.MenuItems.Add(4, m_paste);
                } else if(fl_file.ContextMenu.MenuItems.Contains(m_paste))
                    fl_file.ContextMenu.MenuItems.Remove(m_paste);
            };
        }

        private void File_MouseDoubleClicked(object sender, MouseEventArgs e) {
            FileDoubleClicked();
        }

        private void File_MouseClicked(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left && Base.ControlKey) {
                if(Clicked) {
                    UnSelectFile();
                    Clicked = false;
                } else {
                    SelectFile();
                    Clicked = true;
                    SelectedFiles.LastSelectedFile = Path;
                }

            } else if(e.Button == MouseButtons.Left && Base.ControlKey == false) {
                if(Clicked) {
                    UnSelectFile();
                    Clicked = false;
                } else {
                    b.UnClickAll();
                    SelectFile();
                    Clicked = true;
                    SelectedFiles.LastSelectedFile = Path;
                }
            }
        }

        private void SetTimer() {
            timer = new Timer() {
                AutoReset = true,
                Enabled = false
            };
            timer.Elapsed += TimerEvent;
        }

        private void TimerEvent(object o, ElapsedEventArgs e) {
            Thread t = new Thread(() => {
                Thread.Sleep(500);
            });
            t.Start();
            t.Join();
            isNameClicked = true;
        }

        private void Name_MouseDown(object sender, MouseEventArgs e) {
            b.UnClickAll();
            new Thread(() => {
                if(Clicked) {
                    UnSelectFile();
                } else {
                    b.UnClickAll();
                    SelectFile();
                }
            }).Start();

            timer.Enabled = true;
        }

        private void Name_MouseUp(object sender, MouseEventArgs e) {
            timer.Enabled = false;
            if(isNameClicked) {
                RenameFile();
            } else
                tb_name.Text = FileName;
        }

        private void Name_KeyUp(object sender, KeyEventArgs e) {
            try {
                if(e.KeyCode == Keys.Enter) {
                    string newName = new System.IO.FileInfo(Path).DirectoryName + @"\" + tb_name.Text;
                    FileOperation.RenameFile(Path, newName);
                    SelectedFiles.Remove(Path);
                    tb_name.ReadOnly = true;
                    FileName = tb_name.Text;
                    Path = newName;
                    SelectFile();
                }
            } catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tb_name_Leave(object sender, EventArgs e) {
            tb_name.Text = FileName;
        }

        private void FileDoubleClicked() {
            b.UnClickAll();
            if(type.ToString().Equals("Directory"))
                b.LoadFiles(Path);
        }

        private void RenameFile() {
            isNameClicked = false;
            tb_name.ReadOnly = false;
            tb_name.SelectAll();
            UnSelectFile();
        }

        private void FileProperties() { }

    }
}
