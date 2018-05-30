using DataManagerSystem.Configs;
using System;
using System.IO;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class SettingsUI : Form
    {
        ConfigData config = new ConfigData();

        public SettingsUI()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                config.DatabasePath = openFileDialog.FileName.Trim();
                DbPathTexbox.Text = config.DatabasePath;
            }
        }

        private void SettingsUI_Load(object sender, EventArgs e)
        {
            if (File.Exists("configs.xml"))
            {
                config = XmlDataManager.XmlConfigDataReader("configs.xml");
                DbPathTexbox.Text = config.DatabasePath;
                DocxPathTB.Text = config.SaveDocxPath;
            }
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (DbPathTexbox.Text == string.Empty && DocxPathTB.Text == string.Empty)
            {
                MessageBox.Show("Please Fill All Boxes Before Saving");
            }
            else
            {
                try
                {
                    config.DbConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + config.DatabasePath + ";Persist Security Info = False;";
                    config.SaveDocxPath = @DocxPathTB.Text.Trim();
                    XmlDataManager.XmlDataWriter(config, "configs.xml");
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DocxPathBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                config.SaveDocxPath = folderDialog.SelectedPath;
                DocxPathTB.Text = config.SaveDocxPath;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
