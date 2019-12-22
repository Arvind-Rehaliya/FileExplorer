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
            this.lb_name = new System.Windows.Forms.Label();
            this.fl_file.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_file)).BeginInit();
            this.SuspendLayout();
            // 
            // fl_file
            // 
            this.fl_file.AutoSize = true;
            this.fl_file.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fl_file.Controls.Add(this.pb_file);
            this.fl_file.Controls.Add(this.lb_name);
            this.fl_file.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fl_file.Location = new System.Drawing.Point(1, 3);
            this.fl_file.Name = "fl_file";
            this.fl_file.Size = new System.Drawing.Size(79, 110);
            this.fl_file.TabIndex = 0;
            // 
            // pb_file
            // 
            this.pb_file.Image = global::FileExplorer.Properties.Resources.document_160;
            this.pb_file.Location = new System.Drawing.Point(3, 3);
            this.pb_file.Name = "pb_file";
            this.pb_file.Padding = new System.Windows.Forms.Padding(5);
            this.pb_file.Size = new System.Drawing.Size(73, 77);
            this.pb_file.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_file.TabIndex = 0;
            this.pb_file.TabStop = false;
            this.pb_file.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pb_file.DoubleClick += new System.EventHandler(this.File_DoubleCLicked);
            this.pb_file.MouseHover += new System.EventHandler(this.File_MouseHover);
            // 
            // lb_name
            // 
            this.lb_name.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_name.ForeColor = System.Drawing.Color.White;
            this.lb_name.Location = new System.Drawing.Point(3, 83);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(73, 18);
            this.lb_name.TabIndex = 1;
            this.lb_name.Text = "file_1";
            this.lb_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_name.UseCompatibleTextRendering = true;
            // 
            // File
            // 
            this.ClientSize = new System.Drawing.Size(104, 117);
            this.Controls.Add(this.fl_file);
            this.Name = "File";
            this.fl_file.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_file)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pb_file;
        private System.Windows.Forms.Label lb_name;
        public System.Windows.Forms.FlowLayoutPanel fl_file;
    }
}
