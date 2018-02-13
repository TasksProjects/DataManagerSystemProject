using DataManagerSystem.Configs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class RemoveUserUI : Form
    {
        DatabaseManager databaseManager = new DatabaseManager();
        OleDbConnection UserConnection = new OleDbConnection();
        ConfigData config = new ConfigData();
        public RemoveUserUI()
        {
            InitializeComponent();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (UserIDTextBox.Text == string.Empty || UsernameTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter correct data!");
            }
            else
            {
                int id = Convert.ToInt32(UserIDTextBox.Text);
                string username = UsernameTextBox.Text;
                 databaseManager.RemoveUser(id, username);
                UserIDTextBox.Clear();
                UsernameTextBox.Clear();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
