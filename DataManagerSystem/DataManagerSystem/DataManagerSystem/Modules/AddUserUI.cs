using DataManagerSystem.Configs;
using System;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class AddUserUI : Form
    {
        string User_Online;
        DatabaseManager databaseManager = new DatabaseManager();
        OleDbConnection UserConnection = new OleDbConnection();
        ConfigData config = new ConfigData();

        public AddUserUI(string user_online)
        {
            InitializeComponent();
            User_Online = user_online;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!UsernameTextBox.Text.Trim().Equals(string.Empty) && !PasswordTextBox.Text.Trim().Equals(string.Empty) && !AttributComboBox.Text.Trim().Equals(string.Empty))
            {
                string username = UsernameTextBox.Text;
                string password = PasswordTextBox.Text;
                string attribut = AttributComboBox.Text;
                databaseManager.AddUser(username, password, attribut);
                UsernameTextBox.Clear();
                PasswordTextBox.Clear();

                AdminUI adminUI = new AdminUI(User_Online);
                this.Close();
                adminUI.Show();
            }
            else
            {
                MessageBox.Show("Please fill all the fields!");
            }

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            AdminUI adminUI = new AdminUI(User_Online);
            this.Close();
            adminUI.Show();
        }
    }
}
