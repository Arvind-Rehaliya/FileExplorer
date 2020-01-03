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
        public bool Clicked {get; set;}
        public bool Selected { get; private set; }
        private Base b;
        private Timer timer;
        
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
            if(Selected) return;
            fl_file.Focus();
            Selected = true;
            fl_file.BackColor = Color.SteelBlue;
            SelectedFiles.Add(Path);
        }

        public void UnSelectFile() {
            if(!Selected) return;
            Selected = false;
            fl_file.BackColor = Color.Empty;
        }

        private void CreateContextMenu() {
            MenuItem m_open = new MenuItem("Open");
            MenuItem m_cut = new MenuItem("Cut");
            MenuItem m_copy = new MenuItem("Copy");
            MenuItem m_paste = new MenuItem("Paste");
            MenuItem m_delete = new MenuItem("Delete");
            MenuItem m_rename = new MenuItem("Rename");
            MenuItem m_prop = new MenuItem("Properties");
            
            m_open.Click += (o, e) => {
                MessageBox.Show("Open");
            };

            m_cut.Click += (o, e) => {
                MessageBox.Show("Cut");
            };

            m_paste.Click += (o, e) => {
                MessageBox.Show("Copy");
            };

            m_paste.Click += (o, e) => {
                MessageBox.Show("Paste");
            };

            m_delete.Click += (o, e) => {
                MessageBox.Show("Delete");
            };

            m_rename.Click += (o, e) => {
                MessageBox.Show("Rename");
            };

            m_prop.Click += (o, e) => {
                MessageBox.Show("Properties");
            };

            ContextMenu menu = new ContextMenu(new MenuItem[] { m_open, m_cut, m_copy, m_paste, m_delete, m_rename, m_prop });
            fl_file.ContextMenu = menu;

        }

        private void File_MouseDoubleClicked(object sender, MouseEventArgs e) {
            b.UnClickAll();
            if(type.ToString().Equals("Directory"))
                b.LoadFiles(Path);
        }

        public void SelectMultipleFiles() {
            Clicked = true;
            SelectFile();
        }

        private void File_MouseClicked(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left && Base.ControlKey) {
                if(Clicked) {
                    UnSelectFile();
                    Clicked = false;
                } else {
                    SelectFile();
                    Clicked = true;
                }
             
            } else if(e.Button == MouseButtons.Left && Base.ControlKey == false) {
                if(Clicked) {
                    UnSelectFile();
                    Clicked = false;
                } else {
                    b.UnClickAll();
                    SelectFile();
                    Clicked = true;
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
                isNameClicked = false;
                tb_name.ReadOnly = false;
                tb_name.SelectAll();
                UnSelectFile();
            } else
                tb_name.Text = FileName;
        }

        private void Name_KeyUp(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {
                string newName = tb_name.Text;
                FileOperation.RenameFile(Path, new System.IO.FileInfo(Path).DirectoryName);
                tb_name.ReadOnly = true;
                SelectFile();
                fl_file.Focus();
            }
        }

        private void tb_name_Leave(object sender, EventArgs e) {
            tb_name.Text = FileName;
        }


    }
}
