using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections;

namespace FileExplorer
{
    public partial class Base : Form
    {
        private SortedList files = new SortedList();
        private Graphics g;
        private bool isDown = false;
        private int X = 0, Y = 0;
        private Point pointXY;
        private SortedList fileBounds = new SortedList();
        private int lastClickedFile = 0;
        private TreeNode[] lib_nodes = new TreeNode[5];
        private TreeNode[] fav_nodes = new TreeNode[4];

        public Base()
        {
            InitializeComponent();
            CreateContextMenu();
            InitNodes();
        }

        public void FillFiles(string fileName, Enum type)
        {
            File file = CreateNewFolder(fileName, type);
            files.Add(fileName, file);
            pn_flow.Controls.Add(file.fl_file);
            fileBounds.Add(fileName, file.fl_file.Bounds);
        }

        private void pn_flow_Clicked(object sender, System.EventArgs e)
        {
            UnSelectAll();
        }

        private File CreateNewFolder(String name, Enum type)
        {
            return new File(name, type.ToString().Equals("Directory") ? Type.Directory : Type.File, this);
        }

        private void pn_flow_MouseMove(object sender, MouseEventArgs me)
        {
            if (isDown)
            {
                pointXY = me.Location;
                Refresh();

            }
        }

        private void pn_flow_MouseUp(object sender, MouseEventArgs me)
        {
            if (isDown)
            {
                pointXY = me.Location;
                isDown = false;
                Refresh();
            }

        }

        private void CreateContextMenu()
        {
            MenuItem m_new = new MenuItem("New");
          //  MenuItem m_folder = new MenuItem("Folder");
          //  MenuItem m_doc = new MenuItem("Document");
           
            
            MenuItem m_cut = new MenuItem("Cut");

            m_cut.Click += (o, e) =>
            {
                MessageBox.Show("cut");
            };
            MenuItem m_copy = new MenuItem("Copy");
            MenuItem m_paste = new MenuItem("Paste");
            MenuItem m_refresh = new MenuItem("Refresh");
            MenuItem m_prop = new MenuItem("Properties");

            MenuItem[] menuItems = { m_new,
                m_cut,
                m_copy,
                m_paste,
                m_refresh,
                m_prop
            };
            ContextMenu menu = new ContextMenu(menuItems);
            pn_flow.ContextMenu = menu;
        }

        private void pn_flow_Paing(object sender, PaintEventArgs e)
        {
            if (isDown)
            {
                g = e.Graphics;
                Rectangle rect = new Rectangle(Math.Min(X, pointXY.X), Math.Min(Y, pointXY.Y), Math.Abs(pointXY.X - X), Math.Abs(pointXY.Y - Y));
                e.Graphics.FillRectangle(new SolidBrush(Color.RoyalBlue), rect);

                for (int i = 0; i < files.Count; i++)
                {
                    if (rect.IntersectsWith((Rectangle)fileBounds.GetByIndex(i)))
                    {
                        ((File)files.GetByIndex(i)).SelectFile();
                    }
                }

            }
        }

        private void pn_flow_MouseDown(object sender, MouseEventArgs me)
        {
            Refresh();
            isDown = true;
            X = me.X;
            Y = me.Y;
            UnSelectAll();
        }

        public void ClickFile()
        {
            UnSelectAll();
            for (int i = 0; i < files.Count; i++)
            {
                if (((File)files.GetByIndex(i)).IsClicked())
                {
                    ((File)files.GetByIndex(i)).SelectFile();
                    lastClickedFile = i;
                    break;
                }
            }
        }

        public void UnSelectAll()
        {
            for (int i = 0; i < files.Count; i++)
            {
                ((File)files.GetByIndex(i)).UnSelectFile();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                FileOperation.Fill(tb_path.Text);
            }
            catch(Exception ex) { MessageBox.Show("Specified Path not Found !\n" + ex.Message); }
        }

        private void NodeDocuments_Clicked()
        {
            
        }

        private void NodeMusic_Clicked()
        {
            
        }

        private void NodePictures_Clicked()
        {
            
        }

        private void NodeVideos_Clicked()
        {
            
        }

        private void NodeDesktop_Clicked()
        {
            
        }

        private void NodeDownloads_Clicked()
        {
            
        }

        private void NodeRecentPlaces_Clicked()
        {
            
        }

        private void tv_favorites_AfterSelect(object sender, TreeViewEventArgs e)
        {
            String name = e.Node.Name;
            try { tv_favorites.TopNode.Nodes[tv_favorites.TopNode.Nodes.IndexOfKey(name)].BackColor = Color.Red; }
            catch (Exception) { tv_favorites.TopNode.BackColor = Color.Red; }

            switch (name)
            {
                case "Desktop": NodeDesktop_Clicked(); break;
                case "Downloads": NodeDownloads_Clicked(); break;
                case "Recent Places": NodeRecentPlaces_Clicked(); break;
            }
        }

        private void tv_favorites_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            UnSelectLastSelectedNode();
        }

        private void tv_libraries_AfterSelect(object sender, TreeViewEventArgs e)
        {
            String name = e.Node.Name;
            try { tv_libraries.TopNode.Nodes[tv_libraries.TopNode.Nodes.IndexOfKey(name)].BackColor = Color.Red; }
            catch(Exception) { tv_libraries.TopNode.BackColor = Color.Red; }

            switch (name)
            {
                case "Documents": NodeDocuments_Clicked(); break;
                case "Music": NodeMusic_Clicked(); break;
                case "Pictures": NodePictures_Clicked(); break;
                case "Videos": NodeVideos_Clicked(); break;
            }
        }

        private void InitNodes()
        {
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

        private void tv_libraries_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            UnSelectLastSelectedNode();
        }

        private void UnSelectLastSelectedNode()
        {
            for (int i = 0; i < lib_nodes.Length; i++)
                if (lib_nodes[i].IsSelected) { lib_nodes[i].BackColor = Color.Black; break; }
            for (int i = 0; i < fav_nodes.Length; i++)
                if (fav_nodes[i].IsSelected) { fav_nodes[i].BackColor = Color.Black; break; }
        }

        public void UnClickLastFile()
        {
            if (files.Count > 0)
                ((File)files.GetByIndex(lastClickedFile)).SetClicked(false);
            ((File)files.GetByIndex(lastClickedFile)).UnSelectFile();
        }

        public void ClearSpace()
        {
            files.Clear();
            fileBounds.Clear();
            pn_flow.Controls.Clear();
        }

    }
}
