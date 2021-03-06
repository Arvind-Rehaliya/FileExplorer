﻿using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace FileExplorer {
    public partial class Base : Form {
        private SortedList files = new SortedList();
        private Graphics g;
        private bool isDown = false;
        internal static bool ControlKey = false;
        private int X = 0, Y = 0;
        private Point pointXY;
        private SortedList fileBounds = new SortedList();
        private TreeNode[] lib_nodes = new TreeNode[5];
        private TreeNode[] fav_nodes = new TreeNode[4];
        private SortedList history_path = new SortedList();
        private int seek = -1, current = -1, currentX = 0;
        private string _CurrentLocation;
        public string CurrentLocation { get; private set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        internal bool CopyClicked = false;
        internal bool CutClicked = false;

        /*  private bool _CutClicked = false;
          internal bool CutClicked1 { get { return _CutClicked; } set { _CutClicked = value; pn_flow.ContextMenu.MenuItems[2].Enabled = value; } }
          private bool _CopyClicked1 = false;
          internal bool CopyClicked1 { get { return _CopyClicked; } set { _CopyClicked = value; pn_flow.ContextMenu.MenuItems[2].Enabled = value; } }
          */

        private MenuItem m_new, m_folder, m_doc, m_refresh, m_paste, m_prop;


        public Base() {
            InitializeComponent();
            SetProperties();
            CreateContextMenu();
            InitNodes();
        }

        public void SetLocation(string path) {
            this.CurrentLocation = path;
            this.tb_path.Text = CurrentLocation;
        }

        private void SetProperties() {
            currentX = this.Width;
        }

        public void FillFiles(string fileName, Enum type) {
            File file = CreateNewFile(fileName, type);
            files.Add(fileName, file);
            pn_flow.Controls.Add(file.fl_file);
            fileBounds.Add(fileName, file.fl_file.Bounds);
        }

        private File CreateNewFile(String path, Enum type) {
            return new File(path, type.ToString().Equals("Directory") ? FileType.Directory : FileType.File, this);
        }

        private void pn_flow_MouseMove(object sender, MouseEventArgs me) {
            if(isDown) {
                pointXY = me.Location;
                Refresh();

            }
        }

        private void pn_flow_MouseUp(object sender, MouseEventArgs me) {
            if(isDown) {
                pointXY = me.Location;
                isDown = false;
                Refresh();
            }

        }

        private void CreateContextMenu() {
            m_new = new MenuItem("New");
            m_folder = new MenuItem("Folder");
            m_doc = new MenuItem("Document");
            m_refresh = new MenuItem("Refresh");
            m_paste = new MenuItem("Paste") { Enabled = false };
            m_prop = new MenuItem("Properties");

            m_new.MergeMenu(new ContextMenu(new MenuItem[] { m_folder, m_doc }));

            m_refresh.Click += (o, e) => RefreshFiles(CurrentLocation);

            m_folder.Click += (o, e) => CreateNewFolder();

            m_doc.Click += (o, e) => CreateNewDocument();

            m_paste.Click += (o, e) => PasteFiles();

            m_prop.Click += (o, e) => FileProperties();

            ContextMenu menu = new ContextMenu(new MenuItem[] { m_new, m_refresh, m_paste, m_prop });
            pn_flow.ContextMenu = menu;
        }

        private void CreateNewFolder() {
            try {
                FileOperation.CreateFolder(CurrentLocation, null, true);

            } catch(Exception e) { MessageBox.Show("from Base: OnCreateNewFolder: \n" + e); }
        }

        private void CreateNewDocument() {
            try {
                FileOperation.CreateDocument(CurrentLocation, true);

            } catch(Exception e) { MessageBox.Show("from Base: OnCreateNewDocument: \n" + e); }
        }

        internal void PasteFiles() {
            try {
                FileOperation.CopyFiles(SelectedFiles.LastSelectedFile == null ? CurrentLocation : SelectedFiles.LastSelectedFile, true, SelectedFiles.GetCopyBufferValues());
                if(CutClicked == true) {
                    CutClicked = false;
                    pn_flow.ContextMenu.MenuItems[2].Enabled = false;
                    if(CopyClicked)
                        CopyClicked = false;
                    LoadFiles(SelectedFiles.LastSelectedFile);
                    FileOperation.DeleteFiles(SelectedFiles.GetCopyBufferValues());
                    SelectedFiles.ClearCopyBuffer();
                }

            } catch(Exception ex) { MessageBox.Show(ex.Message); UnClickAll(); }

        }

        private void FileProperties() {

        }

        private void pn_flow_MouseDown(object sender, MouseEventArgs me) {
            Refresh();
            isDown = true;
            X = me.X;
            Y = me.Y;
            UnClickAll();
        }

        public void UnClickAll() {
            for(int i = 0; i < SelectedFiles.GetNames().Length; i++) {
                int index = files.IndexOfKey(SelectedFiles.GetNames()[i].ToString());
                if(index < 0)
                    return;
                ((File) files.GetByIndex(index)).UnSelectFile();
            }
            SelectedFiles.Clear();
        }

        private void NodeDocuments_Clicked() {
            LoadFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        }

        private void NodeMusic_Clicked() {
            LoadFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
        }

        private void NodePictures_Clicked() {
            LoadFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
        }

        private void NodeVideos_Clicked() {
            LoadFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
        }

        private void NodeDesktop_Clicked() {
            LoadFiles(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
        }

        private void NodeDownloads_Clicked() {
            LoadFiles(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads");
        }

        private void NodeRecentPlaces_Clicked() {
            LoadFiles(Environment.GetFolderPath(Environment.SpecialFolder.Recent));
        }

        private void tv_favorites_AfterSelect(object sender, TreeViewEventArgs e) {
            switch(e.Node.Name) {
                case "Desktop":
                    NodeDesktop_Clicked();
                    break;
                case "Downloads":
                    NodeDownloads_Clicked();
                    break;
                case "Recent Places":
                    NodeRecentPlaces_Clicked();
                    break;
            }
        }

        private void tv_libraries_AfterSelect(object sender, TreeViewEventArgs e) {
            switch(e.Node.Name) {
                case "Documents":
                    NodeDocuments_Clicked();
                    break;
                case "Music":
                    NodeMusic_Clicked();
                    break;
                case "Pictures":
                    NodePictures_Clicked();
                    break;
                case "Videos":
                    NodeVideos_Clicked();
                    break;
            }
        }

        private void InitNodes() {
            fav_nodes[0] = tv_favorites.Nodes[0].Nodes[0];
            fav_nodes[1] = tv_favorites.Nodes[0].Nodes[1];
            fav_nodes[2] = tv_favorites.Nodes[0].Nodes[2];
            fav_nodes[3] = tv_favorites.Nodes[0];

            lib_nodes[0] = tv_libraries.Nodes[0].Nodes[0];
            lib_nodes[1] = tv_libraries.Nodes[0].Nodes[1];
            lib_nodes[2] = tv_libraries.Nodes[0].Nodes[2];
            lib_nodes[3] = tv_libraries.Nodes[0].Nodes[3];
            lib_nodes[4] = tv_libraries.Nodes[0];

            tv_favorites.ExpandAll();
            tv_libraries.ExpandAll();
        }

        private void tb_path_KeyUp(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {
                string path = tb_path.Text;
                try {
                    RefreshFiles(path);
                    if(System.IO.File.Exists(path)) {
                        File f = (File) files.GetByIndex(files.IndexOfKey(path));
                        f.SelectFile();
                    }
                } catch(Exception) { }
            }
        }

        private void tb_path_Enter(object sender, EventArgs e) {
            tb_path.BackColor = Color.White;
            tb_path.ForeColor = Color.Black;
        }

        private void tb_path_Leave(object sender, EventArgs e) {
            tb_path.BackColor = Color.Black;
            tb_path.ForeColor = Color.White;
        }

        private void tb_search_Enter(object sender, EventArgs e) {
            tb_search.BackColor = Color.White;
            tb_search.ForeColor = Color.Black;
        }

        private void tb_search_Leave(object sender, EventArgs e) {
            tb_search.BackColor = Color.Black;
            tb_search.ForeColor = Color.White;
        }

        private void pn_flow_Paint(object sender, PaintEventArgs e) {
            if(isDown) {
                g = e.Graphics;
                Rectangle rect = new Rectangle(Math.Min(X, pointXY.X), Math.Min(Y, pointXY.Y), Math.Abs(pointXY.X - X), Math.Abs(pointXY.Y - Y));
                e.Graphics.FillRectangle(new SolidBrush(Color.RoyalBlue), rect);

                for(int i = 0; i < files.Count; i++) {
                    if(rect.IntersectsWith((Rectangle) fileBounds.GetByIndex(i))) {
                        ((File) files.GetByIndex(i)).SelectFile();
                    }
                }

            }
        }

        private void bt_prev_Click(object sender, EventArgs e) {
            try {
                if(seek > 0) {
                    RefreshFiles(history_path.GetByIndex(--seek).ToString());
                    bt_next.Enabled = true;
                }

                if(seek == 0)
                    bt_prev.Enabled = false;

            } catch(Exception) { bt_refresh.PerformClick(); }

        }

        private void bt_next_Click(object sender, EventArgs e) {
            try {
                if(seek < current) {
                    RefreshFiles(history_path.GetByIndex(++seek).ToString());
                    bt_prev.Enabled = true;
                }

                if(seek == current)
                    bt_next.Enabled = false;

            } catch(Exception) { bt_refresh.PerformClick(); }

        }

        private void bt_refresh_Click(object sender, EventArgs e) {
            RefreshFiles(CurrentLocation);
        }

        public void RefreshFiles(string path) {
            try {
                FileOperation.LoadFiles(path);
            } catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void ClearSpace() {
            files.Clear();
            fileBounds.Clear();
            pn_flow.Controls.Clear();
            pn_flow.Controls.Add(lb_info);

        }

        private void sp_container_Panel2_SizeChanged(object sender, EventArgs e) {
            lb_info.Width = sp_container.Panel2.Width;
        }

        private void Base_SizeChanged(object sender, EventArgs e) {
            try {
                if(currentX > this.Width) {
                    int t = sp_container.SplitterDistance - (currentX - this.Width);
                    sp_container.SplitterDistance = t < 0 ? 0 : t;

                } else if(sp_container.SplitterDistance < 151) {
                    int t = sp_container.SplitterDistance + this.Width - currentX;
                    sp_container.SplitterDistance = t < 151 ? t : 150;
                }
            } catch(Exception) { }

            currentX = this.Width;
        }

        private void pn_flow_MouseClicked(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                UnClickAll();
            }
        }

        private void Base_KeyDown(object sender, KeyEventArgs e) { if(e.KeyCode == Keys.ControlKey) ControlKey = true; }

        private void Base_KeyUp(object sender, KeyEventArgs e) { if(e.KeyCode == Keys.ControlKey) ControlKey = false; }

        private void button1_Click(object sender, EventArgs e) {

            // Debugging Msg here ...
        }

        public void AddPathHistory(string path) {
            if(current > -1 && history_path.GetByIndex(current).Equals(path))
                return;
            history_path.Add(++current, path);
            ++seek;
            if(bt_next.Enabled)
                bt_next.Enabled = false;
        }

        public void LoadFiles(string path) {
            try {
                if(!bt_prev.Enabled)
                    bt_prev.Enabled = true;
                RefreshFiles(path);
                seek = current;
                AddPathHistory(path);

            } catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

    }
}

