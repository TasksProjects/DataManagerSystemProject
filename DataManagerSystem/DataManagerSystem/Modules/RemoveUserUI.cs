using DataManagerSystem.Configs;
using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class RemoveUserUI : Form
    {
        string User_online;
        DatabaseManager databaseManager = new DatabaseManager();
        OleDbConnection UserConnection = new OleDbConnection();
        ConfigData config = new ConfigData();

        public RemoveUserUI(string user_online)
        {
            InitializeComponent();
            this.User_online = user_online;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (!UserIDTextBox.Text.Trim().Equals(string.Empty))
            {
                int id = Convert.ToInt32(UserIDTextBox.Text);
                databaseManager.RemoveUser(id);
                this.Close();

                AdminUI adminUI = new AdminUI(User_online);
                adminUI.Show();
            }
            else
            {
                MessageBox.Show("Please fill all the field!");
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            AdminUI adminUI = new AdminUI(User_online);
            this.Close();
            adminUI.Show();
        }
    }
}
