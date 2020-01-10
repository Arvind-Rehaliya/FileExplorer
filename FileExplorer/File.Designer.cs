namespace FileExplorer
{
    partial class File
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
            this.fl_file = new System.Windows.Forms.FlowLayoutPanel();
            this.pb_file = new System.Windows.Forms.PictureBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.fl_file.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_file)).BeginInit();
            this.SuspendLayout();
            // 
            // fl_file
            // 
            this.fl_file.BackColor = System.Drawing.Color.Black;
            this.fl_file.CausesValidation = false;
            this.fl_file.Controls.Add(this.pb_file);
            this.fl_file.Controls.Add(this.tb_name);
            this.fl_file.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fl_file.Location = new System.Drawing.Point(1, 3);
            this.fl_file.Name = "fl_file";
            this.fl_file.Size = new System.Drawing.Size(79, 109);
            this.fl_file.TabIndex = 0;
            // 
            // pb_file
            // 
            this.pb_file.Location = new System.Drawing.Point(3, 3);
            this.pb_file.Name = "pb_file";
            this.pb_file.Padding = new System.Windows.Forms.Padding(5);
            this.pb_file.Size = new System.Drawing.Size(73, 78);
            this.pb_file.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_file.TabIndex = 0;
            this.pb_file.TabStop = false;
            this.pb_file.MouseClick += new System.Windows.Forms.MouseEventHandler(this.File_MouseClicked);
            this.pb_file.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.File_MouseDoubleClicked);
            this.pb_file.MouseHover += new System.EventHandler(this.File_MouseHover);
            // 
            // tb_name
            // 
            this.tb_name.AcceptsReturn = true;
            this.tb_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_name.BackColor = System.Drawing.Color.Black;
            this.tb_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_name.CausesValidation = false;
            this.tb_name.Cursor = System.Windows.Forms.Cursors.Default;
            this.tb_name.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_name.ForeColor = System.Drawing.Color.White;
            this.tb_name.Location = new System.Drawing.Point(3, 87);
            this.tb_name.Name = "tb_name";
            this.tb_name.ReadOnly = true;
            this.tb_name.Size = new System.Drawing.Size(73, 16);
            this.tb_name.TabIndex = 1;
            this.tb_name.Text = "File Name File Name";
            this.tb_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_name.WordWrap = false;
            this.tb_name.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Name_KeyUp);
            this.tb_name.Leave += new System.EventHandler(this.tb_name_Leave);
            this.tb_name.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Name_MouseDown);
            this.tb_name.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Name_MouseUp);
            // 
            // File
            // 
            this.ClientSize = new System.Drawing.Size(104, 132);
            this.Controls.Add(this.fl_file);
            this.Name = "File";
            this.fl_file.ResumeLayout(false);
            this.fl_file.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_file)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pb_file;
        public System.Windows.Forms.FlowLayoutPanel fl_file;
        private System.Windows.Forms.TextBox tb_name;
    }
}
