namespace FileExplorer
{
    partial class Base
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Desktop");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Downloads");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Recent places");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Favorites", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Documents");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Music");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Pictures");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Videos");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Libraries", new System.Windows.Forms.TreeNode[] {
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26});
            this.pn_flow = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tv_favorites = new System.Windows.Forms.TreeView();
            this.tv_libraries = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pb_enter = new System.Windows.Forms.PictureBox();
            this.tb_search = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_enter)).BeginInit();
            this.SuspendLayout();
            // 
            // pn_flow
            // 
            this.pn_flow.AutoScroll = true;
            this.pn_flow.AutoSize = true;
            this.pn_flow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pn_flow.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pn_flow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_flow.Location = new System.Drawing.Point(0, 0);
            this.pn_flow.Margin = new System.Windows.Forms.Padding(0);
            this.pn_flow.Name = "pn_flow";
            this.pn_flow.Padding = new System.Windows.Forms.Padding(5);
            this.pn_flow.Size = new System.Drawing.Size(672, 417);
            this.pn_flow.TabIndex = 0;
            this.pn_flow.Click += new System.EventHandler(this.pn_flow_Clicked);
            this.pn_flow.Paint += new System.Windows.Forms.PaintEventHandler(this.pn_flow_Paing);
            this.pn_flow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pn_flow_Clicked);
            this.pn_flow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pn_flow_MouseDown);
            this.pn_flow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pn_flow_MouseMove);
            this.pn_flow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pn_flow_MouseUp);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel1MinSize = 65;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pn_flow);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(824, 417);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlText;
            this.flowLayoutPanel1.Controls.Add(this.tv_favorites);
            this.flowLayoutPanel1.Controls.Add(this.tv_libraries);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(150, 417);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // tv_favorites
            // 
            this.tv_favorites.BackColor = System.Drawing.SystemColors.InfoText;
            this.tv_favorites.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tv_favorites.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tv_favorites.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_favorites.ForeColor = System.Drawing.SystemColors.Info;
            this.tv_favorites.FullRowSelect = true;
            this.tv_favorites.LineColor = System.Drawing.Color.White;
            this.tv_favorites.Location = new System.Drawing.Point(3, 3);
            this.tv_favorites.Name = "tv_favorites";
            treeNode19.BackColor = System.Drawing.Color.Black;
            treeNode19.ForeColor = System.Drawing.Color.White;
            treeNode19.Name = "Desktop";
            treeNode19.Text = "Desktop";
            treeNode20.BackColor = System.Drawing.Color.Black;
            treeNode20.ForeColor = System.Drawing.Color.White;
            treeNode20.Name = "Downloads";
            treeNode20.Text = "Downloads";
            treeNode21.BackColor = System.Drawing.Color.Black;
            treeNode21.ForeColor = System.Drawing.Color.White;
            treeNode21.Name = "Recent Places";
            treeNode21.Text = "Recent places";
            treeNode22.BackColor = System.Drawing.Color.Gray;
            treeNode22.ForeColor = System.Drawing.Color.White;
            treeNode22.Name = "Favorites";
            treeNode22.Text = "Favorites";
            this.tv_favorites.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode22});
            this.tv_favorites.Scrollable = false;
            this.tv_favorites.Size = new System.Drawing.Size(138, 112);
            this.tv_favorites.TabIndex = 7;
            this.tv_favorites.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tv_favorites_BeforeSelect);
            this.tv_favorites.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_favorites_AfterSelect);
            // 
            // tv_libraries
            // 
            this.tv_libraries.BackColor = System.Drawing.SystemColors.InfoText;
            this.tv_libraries.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tv_libraries.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tv_libraries.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_libraries.ForeColor = System.Drawing.SystemColors.Info;
            this.tv_libraries.FullRowSelect = true;
            this.tv_libraries.LineColor = System.Drawing.Color.White;
            this.tv_libraries.Location = new System.Drawing.Point(3, 121);
            this.tv_libraries.Name = "tv_libraries";
            treeNode23.BackColor = System.Drawing.Color.Black;
            treeNode23.ForeColor = System.Drawing.Color.White;
            treeNode23.Name = "Documents";
            treeNode23.Text = "Documents";
            treeNode24.BackColor = System.Drawing.Color.Black;
            treeNode24.ForeColor = System.Drawing.Color.White;
            treeNode24.Name = "Music";
            treeNode24.Text = "Music";
            treeNode25.BackColor = System.Drawing.Color.Black;
            treeNode25.ForeColor = System.Drawing.Color.White;
            treeNode25.Name = "Pictures";
            treeNode25.Text = "Pictures";
            treeNode26.BackColor = System.Drawing.Color.Black;
            treeNode26.ForeColor = System.Drawing.Color.White;
            treeNode26.Name = "Videos";
            treeNode26.Text = "Videos";
            treeNode27.BackColor = System.Drawing.Color.Gray;
            treeNode27.ForeColor = System.Drawing.Color.White;
            treeNode27.Name = "Libraries";
            treeNode27.Text = "Libraries";
            this.tv_libraries.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode27});
            this.tv_libraries.Scrollable = false;
            this.tv_libraries.Size = new System.Drawing.Size(138, 129);
            this.tv_libraries.TabIndex = 6;
            this.tv_libraries.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tv_libraries_BeforeSelect);
            this.tv_libraries.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_libraries_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Location = new System.Drawing.Point(0, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(824, 417);
            this.panel1.TabIndex = 0;
            // 
            // tb_path
            // 
            this.tb_path.AcceptsReturn = true;
            this.tb_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_path.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tb_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_path.ForeColor = System.Drawing.SystemColors.Info;
            this.tb_path.HideSelection = false;
            this.tb_path.Location = new System.Drawing.Point(93, 11);
            this.tb_path.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(510, 20);
            this.tb_path.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.pb_enter);
            this.panel2.Controls.Add(this.tb_search);
            this.panel2.Controls.Add(this.tb_path);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(824, 39);
            this.panel2.TabIndex = 0;
            // 
            // pb_enter
            // 
            this.pb_enter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_enter.Image = global::FileExplorer.Properties.Resources.back_30;
            this.pb_enter.Location = new System.Drawing.Point(614, 7);
            this.pb_enter.Name = "pb_enter";
            this.pb_enter.Size = new System.Drawing.Size(40, 32);
            this.pb_enter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_enter.TabIndex = 0;
            this.pb_enter.TabStop = false;
            this.pb_enter.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // tb_search
            // 
            this.tb_search.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tb_search.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tb_search.ForeColor = System.Drawing.SystemColors.Info;
            this.tb_search.Location = new System.Drawing.Point(671, 11);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(141, 20);
            this.tb_search.TabIndex = 1;
            // 
            // Base
            // 
            this.ClientSize = new System.Drawing.Size(824, 459);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Base";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_enter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel pn_flow;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.PictureBox pb_enter;
        private System.Windows.Forms.TreeView tv_libraries;
        private System.Windows.Forms.TreeView tv_favorites;
        public System.Windows.Forms.TextBox tb_path;
    }
}

