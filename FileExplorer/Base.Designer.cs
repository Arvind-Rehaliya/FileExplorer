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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Desktop");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Downloads");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Recent places");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Favorites", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Documents");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Music");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Pictures");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Videos");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Libraries", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            this.pn_flow = new System.Windows.Forms.FlowLayoutPanel();
            this.lb_info = new System.Windows.Forms.Label();
            this.sp_container = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tv_favorites = new System.Windows.Forms.TreeView();
            this.tv_libraries = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.bt_refresh = new System.Windows.Forms.Button();
            this.bt_prev = new System.Windows.Forms.Button();
            this.bt_next = new System.Windows.Forms.Button();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.pn_flow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sp_container)).BeginInit();
            this.sp_container.Panel1.SuspendLayout();
            this.sp_container.Panel2.SuspendLayout();
            this.sp_container.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_flow
            // 
            this.pn_flow.AutoScroll = true;
            this.pn_flow.BackColor = System.Drawing.Color.Black;
            this.pn_flow.Controls.Add(this.lb_info);
            this.pn_flow.Cursor = System.Windows.Forms.Cursors.Default;
            this.pn_flow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_flow.Location = new System.Drawing.Point(0, 0);
            this.pn_flow.Margin = new System.Windows.Forms.Padding(10);
            this.pn_flow.Name = "pn_flow";
            this.pn_flow.Size = new System.Drawing.Size(713, 461);
            this.pn_flow.TabIndex = 0;
            this.pn_flow.Click += new System.EventHandler(this.pn_flow_Clicked);
            this.pn_flow.Paint += new System.Windows.Forms.PaintEventHandler(this.pn_flow_Paint);
            this.pn_flow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pn_flow_Clicked);
            this.pn_flow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pn_flow_MouseDown);
            this.pn_flow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pn_flow_MouseMove);
            this.pn_flow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pn_flow_MouseUp);
            // 
            // lb_info
            // 
            this.lb_info.BackColor = System.Drawing.Color.Black;
            this.lb_info.ForeColor = System.Drawing.Color.White;
            this.lb_info.Location = new System.Drawing.Point(0, 0);
            this.lb_info.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lb_info.Name = "lb_info";
            this.lb_info.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lb_info.Size = new System.Drawing.Size(696, 28);
            this.lb_info.TabIndex = 0;
            this.lb_info.Text = "This folder is empty";
            this.lb_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_info.Visible = false;
            // 
            // sp_container
            // 
            this.sp_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp_container.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sp_container.Location = new System.Drawing.Point(0, 0);
            this.sp_container.Name = "sp_container";
            // 
            // sp_container.Panel1
            // 
            this.sp_container.Panel1.Controls.Add(this.flowLayoutPanel1);
            this.sp_container.Panel1MinSize = 65;
            // 
            // sp_container.Panel2
            // 
            this.sp_container.Panel2.Controls.Add(this.pn_flow);
            this.sp_container.Panel2.SizeChanged += new System.EventHandler(this.sp_container_Panel2_SizeChanged);
            this.sp_container.Panel2MinSize = 110;
            this.sp_container.Size = new System.Drawing.Size(865, 461);
            this.sp_container.SplitterDistance = 150;
            this.sp_container.SplitterWidth = 2;
            this.sp_container.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Controls.Add(this.tv_favorites);
            this.flowLayoutPanel1.Controls.Add(this.tv_libraries);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(150, 461);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // tv_favorites
            // 
            this.tv_favorites.BackColor = System.Drawing.Color.Black;
            this.tv_favorites.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tv_favorites.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tv_favorites.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_favorites.ForeColor = System.Drawing.SystemColors.Info;
            this.tv_favorites.FullRowSelect = true;
            this.tv_favorites.LineColor = System.Drawing.Color.White;
            this.tv_favorites.Location = new System.Drawing.Point(3, 3);
            this.tv_favorites.Name = "tv_favorites";
            treeNode1.BackColor = System.Drawing.Color.Black;
            treeNode1.ForeColor = System.Drawing.Color.White;
            treeNode1.Name = "Desktop";
            treeNode1.Text = "Desktop";
            treeNode2.BackColor = System.Drawing.Color.Black;
            treeNode2.ForeColor = System.Drawing.Color.White;
            treeNode2.Name = "Downloads";
            treeNode2.Text = "Downloads";
            treeNode3.BackColor = System.Drawing.Color.Black;
            treeNode3.ForeColor = System.Drawing.Color.White;
            treeNode3.Name = "Recent Places";
            treeNode3.Text = "Recent places";
            treeNode4.BackColor = System.Drawing.Color.Gray;
            treeNode4.ForeColor = System.Drawing.Color.White;
            treeNode4.Name = "Favorites";
            treeNode4.Text = "Favorites";
            this.tv_favorites.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.tv_favorites.Scrollable = false;
            this.tv_favorites.Size = new System.Drawing.Size(138, 112);
            this.tv_favorites.TabIndex = 7;
            this.tv_favorites.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_favorites_AfterSelect);
            // 
            // tv_libraries
            // 
            this.tv_libraries.BackColor = System.Drawing.Color.Black;
            this.tv_libraries.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tv_libraries.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tv_libraries.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_libraries.ForeColor = System.Drawing.SystemColors.Info;
            this.tv_libraries.FullRowSelect = true;
            this.tv_libraries.LineColor = System.Drawing.Color.White;
            this.tv_libraries.Location = new System.Drawing.Point(3, 121);
            this.tv_libraries.Name = "tv_libraries";
            treeNode5.BackColor = System.Drawing.Color.Black;
            treeNode5.ForeColor = System.Drawing.Color.White;
            treeNode5.Name = "Documents";
            treeNode5.Text = "Documents";
            treeNode6.BackColor = System.Drawing.Color.Black;
            treeNode6.ForeColor = System.Drawing.Color.White;
            treeNode6.Name = "Music";
            treeNode6.Text = "Music";
            treeNode7.BackColor = System.Drawing.Color.Black;
            treeNode7.ForeColor = System.Drawing.Color.White;
            treeNode7.Name = "Pictures";
            treeNode7.Text = "Pictures";
            treeNode8.BackColor = System.Drawing.Color.Black;
            treeNode8.ForeColor = System.Drawing.Color.White;
            treeNode8.Name = "Videos";
            treeNode8.Text = "Videos";
            treeNode9.BackColor = System.Drawing.Color.Gray;
            treeNode9.ForeColor = System.Drawing.Color.White;
            treeNode9.Name = "Libraries";
            treeNode9.Text = "Libraries";
            this.tv_libraries.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.tv_libraries.Scrollable = false;
            this.tv_libraries.Size = new System.Drawing.Size(138, 129);
            this.tv_libraries.TabIndex = 6;
            this.tv_libraries.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_libraries_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.sp_container);
            this.panel1.Location = new System.Drawing.Point(0, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 461);
            this.panel1.TabIndex = 0;
            // 
            // tb_path
            // 
            this.tb_path.AcceptsReturn = true;
            this.tb_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_path.BackColor = System.Drawing.Color.DimGray;
            this.tb_path.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_path.ForeColor = System.Drawing.Color.White;
            this.tb_path.Location = new System.Drawing.Point(97, 10);
            this.tb_path.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(507, 21);
            this.tb_path.TabIndex = 8;
            this.tb_path.WordWrap = false;
            this.tb_path.Enter += new System.EventHandler(this.tb_path_Enter);
            this.tb_path.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_path_KeyUp);
            this.tb_path.Leave += new System.EventHandler(this.tb_path_Leave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.bt_refresh);
            this.panel2.Controls.Add(this.bt_prev);
            this.panel2.Controls.Add(this.bt_next);
            this.panel2.Controls.Add(this.tb_search);
            this.panel2.Controls.Add(this.tb_path);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(865, 39);
            this.panel2.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::FileExplorer.Properties.Resources.search_204;
            this.button2.Location = new System.Drawing.Point(826, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 28);
            this.button2.TabIndex = 12;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // bt_refresh
            // 
            this.bt_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_refresh.BackColor = System.Drawing.Color.Transparent;
            this.bt_refresh.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bt_refresh.FlatAppearance.BorderSize = 0;
            this.bt_refresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.bt_refresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.bt_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_refresh.Image = global::FileExplorer.Properties.Resources.refresh_25;
            this.bt_refresh.Location = new System.Drawing.Point(610, 7);
            this.bt_refresh.Name = "bt_refresh";
            this.bt_refresh.Size = new System.Drawing.Size(27, 28);
            this.bt_refresh.TabIndex = 11;
            this.bt_refresh.UseVisualStyleBackColor = false;
            this.bt_refresh.Click += new System.EventHandler(this.bt_refresh_Click);
            // 
            // bt_prev
            // 
            this.bt_prev.BackColor = System.Drawing.Color.Transparent;
            this.bt_prev.Enabled = false;
            this.bt_prev.Image = global::FileExplorer.Properties.Resources.back_401;
            this.bt_prev.Location = new System.Drawing.Point(3, 6);
            this.bt_prev.Name = "bt_prev";
            this.bt_prev.Size = new System.Drawing.Size(47, 30);
            this.bt_prev.TabIndex = 10;
            this.bt_prev.UseVisualStyleBackColor = false;
            this.bt_prev.Click += new System.EventHandler(this.bt_prev_Click);
            // 
            // bt_next
            // 
            this.bt_next.BackColor = System.Drawing.Color.Transparent;
            this.bt_next.Enabled = false;
            this.bt_next.Image = global::FileExplorer.Properties.Resources.back_30;
            this.bt_next.Location = new System.Drawing.Point(47, 8);
            this.bt_next.Name = "bt_next";
            this.bt_next.Size = new System.Drawing.Size(31, 26);
            this.bt_next.TabIndex = 9;
            this.bt_next.UseVisualStyleBackColor = false;
            this.bt_next.Click += new System.EventHandler(this.bt_next_Click);
            // 
            // tb_search
            // 
            this.tb_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_search.BackColor = System.Drawing.Color.DimGray;
            this.tb_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search.ForeColor = System.Drawing.Color.White;
            this.tb_search.Location = new System.Drawing.Point(682, 10);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(141, 21);
            this.tb_search.TabIndex = 1;
            this.tb_search.WordWrap = false;
            this.tb_search.Enter += new System.EventHandler(this.tb_search_Enter);
            this.tb_search.Leave += new System.EventHandler(this.tb_search_Leave);
            // 
            // Base
            // 
            this.ClientSize = new System.Drawing.Size(865, 503);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(450, 0);
            this.Name = "Base";
            this.Load += new System.EventHandler(this.Base_Load);
            this.SizeChanged += new System.EventHandler(this.Base_SizeChanged);
            this.pn_flow.ResumeLayout(false);
            this.sp_container.Panel1.ResumeLayout(false);
            this.sp_container.Panel1.PerformLayout();
            this.sp_container.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_container)).EndInit();
            this.sp_container.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel pn_flow;
        private System.Windows.Forms.SplitContainer sp_container;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.TreeView tv_libraries;
        private System.Windows.Forms.TreeView tv_favorites;
        public System.Windows.Forms.TextBox tb_path;
        public System.Windows.Forms.Label lb_info;
        private System.Windows.Forms.Button bt_prev;
        private System.Windows.Forms.Button bt_next;
        private System.Windows.Forms.Button bt_refresh;
        private System.Windows.Forms.Button button2;
    }
}

