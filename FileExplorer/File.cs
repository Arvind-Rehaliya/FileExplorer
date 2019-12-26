using System;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace FileExplorer {
    public partial class File : Form {
        private string name;
        private Enum type;
        private bool isClicked = false;
        private Base b;
        private Timer timer;

        public File(string name, Enum type, Base b) {
            InitializeComponent();
            this.name = name;
            this.type = type;
            this.b = b;

            CreateFile();
            SetTimer();
            CreateContextMenu();
        }

        private void CreateFile() {
            tb_name.Text = name;
            if(type.ToString().Equals("Directory"))
                pb_file.Image = Properties.Resources.folder;
            else
                pb_file.Image = Properties.Resources.document_160;
        }

        private void File_MouseHover(object sender, EventArgs e) { }

        public string GetName() {
            return name;
        }

        public void SelectFile() {
            fl_file.BackColor = Color.SteelBlue;
        }

        public void UnSelectFile() {
            fl_file.BackColor = Color.Empty;
        }

        public bool IsClicked() {
            return isClicked;
        }

        public void SetClicked(bool b) {
            isClicked = b;
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
            b.ClickFile();
            if(type.ToString().Equals("Directory"))
                b.LoadFiles(b.tb_path.Text + @"\" + name);
        }

        private void File_MouseClicked(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                if(!isClicked) {
                    b.UnClickLastFile();
                    SelectFile();
                    isClicked = true;
                    b.ClickFile();
                } else {
                    UnSelectFile();
                    isClicked = false;
                }
            } else {

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
            tb_name.ReadOnly = false;
            tb_name.SelectAll();
        }

        private void Name_MouseDown(object sender, MouseEventArgs e) {
            new Thread(() => {
                if(!isClicked) {
                    b.UnClickLastFile();
                    SelectFile();
                    isClicked = true;
                    b.ClickFile();
                } else {
                    UnSelectFile();
                    isClicked = false;
                }
            }).Start();

            timer.Enabled = true;
        }

        private void Name_MouseUp(object sender, MouseEventArgs e) {
            timer.Enabled = false;
        }

        private void Name_KeyUp(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {
                tb_name.ReadOnly = true;
            }
        }
    }
}
