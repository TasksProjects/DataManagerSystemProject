using DataManagerSystem.Configs;
using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class AddUserUI : Form
    {
        DatabaseManager databaseManager = new DatabaseManager();
        OleDbConnection UserConnection = new OleDbConnection();
        ConfigData config = new ConfigData();

        public AddUserUI()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text == string.Empty || PasswordTextBox.Text == string.Empty || AttributComboBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter correct data!");
            }
            else
            {
                string username = UsernameTextBox.Text;
                string password = PasswordTextBox.Text;
                string attribut = AttributComboBox.Text;
                databaseManager.AddUser(username, password, attribut);
                UsernameTextBox.Clear();
                PasswordTextBox.Clear();
            }

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
