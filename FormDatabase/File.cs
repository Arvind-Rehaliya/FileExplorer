using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormDatabase
{
    public partial class File : Form
    {
        private string name;
        private Enum type;
        private bool isClicked = false;
        private Base b;

        public File(string name, Enum type, Base b)
        {
            InitializeComponent();
            this.name = name;
            this.type = type;
            this.b = b;

            CreateFile();
            
        }

        private void CreateFile()
        {
            lb_name.Text = name;
            if(type.ToString().Equals("Directory"))
                pb_file.Image = Properties.Resources.folder;
            else
                pb_file.Image = Properties.Resources.document_160;
        }

        private void File_MouseHover(object sender, EventArgs e) {}

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!isClicked)
            {
                SelectFile();
                b.UnClickLastFile();
                isClicked = true;
                b.ClickFile();
            }
            else
            {
                UnSelectFile();
                isClicked = false;
            }
        }

        public string GetName()
        {
            return name;
        }

        public void SelectFile()
        {
            fl_file.BackColor = Color.SteelBlue;
        }

        public void UnSelectFile()
        {
            fl_file.BackColor = Color.Empty;
        }

        public bool IsClicked()
        {
            return isClicked;
        }

        public void SetClicked(bool b)
        {
            isClicked = b;
        }

        private void File_DoubleCLicked(object sender, EventArgs e)
        {
            b.ClickFile();
            if(type.ToString().Equals("Directory"))
            FileOperation.Fill(b.tb_path.Text + @"\" + name);
        }
    }
}
