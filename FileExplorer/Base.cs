using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace FileExplorer {
    public partial class Base : Form {
        private SortedList files = new SortedList();
        private Graphics g;
        private bool isDown = false;
        private int X = 0, Y = 0;
        private Point pointXY;
        private SortedList fileBounds = new SortedList();
        private int lastClickedFile = 0;
        private TreeNode[] lib_nodes = new TreeNode[5];
        private TreeNode[] fav_nodes = new TreeNode[4];
        private SortedList history_path = new SortedList();
        private int seek = -1, current = -1, currentX = 0;

        public Base() {
            InitializeComponent();
            SetProperties();
            CreateContextMenu();
            InitNodes();

        }

        private void SetProperties() {
            currentX = this.Width;
        }

        public void FillFiles(string fileName, Enum type) {
            File file = CreateNewFolder(fileName, type);
            files.Add(fileName, file);
            pn_flow.Controls.Add(file.fl_file);
            fileBounds.Add(fileName, file.fl_file.Bounds);
        }

        private void pn_flow_Clicked(object sender, System.EventArgs e) {
            UnSelectAll();
        }

        private File CreateNewFolder(String name, Enum type) {
            return new File(name, type.ToString().Equals("Directory") ? Type.Directory : Type.File, this);
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
            MenuItem m_new = new MenuItem("New");
            MenuItem m_folder = new MenuItem("Folder");
            MenuItem m_doc = new MenuItem("Document");
            m_new.MergeMenu(new ContextMenu(new MenuItem[] { m_folder, m_doc }));

            MenuItem m_refresh = new MenuItem("Refresh");
            m_refresh.Click += (o, e) => {
                bt_refresh.PerformClick();
            };

            m_folder.Click += (o, e) => {
                MessageBox.Show("Folder Created ");
            };

            m_doc.Click += (o, e) => {
                MessageBox.Show("Document Created ");
            };

            ContextMenu menu = new ContextMenu(new MenuItem[] { m_new, m_refresh });
            pn_flow.ContextMenu = menu;
        }

        private void pn_flow_MouseDown(object sender, MouseEventArgs me) {
            Refresh();
            isDown = true;
            X = me.X;
            Y = me.Y;
            UnSelectAll();
        }

        public void ClickFile() {
            UnSelectAll();
            for(int i = 0; i < files.Count; i++) {
                if(((File) files.GetByIndex(i)).IsClicked()) {
                    ((File) files.GetByIndex(i)).SelectFile();
                    lastClickedFile = i;
                    break;
                }
            }
        }

        public void UnSelectAll() {
            for(int i = 0; i < files.Count; i++) {
                ((File) files.GetByIndex(i)).UnSelectFile();
            }
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

        public void UnClickLastFile() {
            if(files.Count > 0) {
                try {
                    ((File) files.GetByIndex(lastClickedFile)).SetClicked(false);
                    ((File) files.GetByIndex(lastClickedFile)).UnSelectFile();
                } catch(Exception e) { MessageBox.Show(e.Message + "\n" + lastClickedFile + "/" + files.Count); }

            }
        }

        private void tb_path_KeyUp(object sender, KeyEventArgs e) {
            if(e.KeyCode.ToString().Equals("Return")) {
                try {
                    LoadFiles(tb_path.Text);
                } catch(Exception ex) { MessageBox.Show("Specified Path not Found !\n" + ex.Message); }
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
                    FileOperation.Fill(history_path.GetByIndex(--seek).ToString());
                    bt_next.Enabled = true;
                }

                if(seek == 0)
                    bt_prev.Enabled = false;

            } catch(Exception) { bt_refresh.PerformClick(); }

        }

        private void bt_next_Click(object sender, EventArgs e) {
            try {
                if(seek < current) {
                    FileOperation.Fill(history_path.GetByIndex(++seek).ToString());
                    bt_prev.Enabled = true;
                }

                if(seek == current)
                    bt_next.Enabled = false;

            } catch(Exception) { bt_refresh.PerformClick(); }

        }

        private void bt_refresh_Click(object sender, EventArgs e) {
            FileOperation.Fill(history_path.GetByIndex(seek).ToString());
        }

        public void ClearSpace() {
            lastClickedFile = 0;
            files.Clear();
            fileBounds.Clear();
            pn_flow.Controls.Clear();
            pn_flow.Controls.Add(lb_info);
        }
        
        private void sp_container_Panel2_SizeChanged(object sender, EventArgs e) {
            lb_info.Width = sp_container.Panel2.Width - 5;
        }

        private void Base_SizeChanged(object sender, EventArgs e) {
            if(currentX > this.Width) {
                int t = sp_container.SplitterDistance - (currentX - this.Width);
                sp_container.SplitterDistance = t < 0 ? 0 : t;

            } else if(sp_container.SplitterDistance < 151) {
                int t = sp_container.SplitterDistance + this.Width - currentX;
                sp_container.SplitterDistance = t < 151 ? t : 150;
            }
            
            currentX = this.Width;
        }

        private void Base_Load(object sender, EventArgs e) {
            this.ActiveControl = null;
        }

        public void AddPathHistory(string path) {
            history_path.Add(++current, path);
            ++seek;
            if(bt_next.Enabled)
                bt_next.Enabled = false;
        }

        public void LoadFiles(string path) {
            try {
                if(!bt_prev.Enabled)
                    bt_prev.Enabled = true;
                FileOperation.Fill(path);
                seek = current;
                AddPathHistory(path);

            } catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void Reload() {
            try {
                FileOperation.Fill(tb_path.Text);
            } catch(Exception e) { MessageBox.Show("Expn at Base: Reload() \n " + e); }
        }

    }
}

