using DataManagerSystem.Configs;
using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class AdminUI : Form
    {
        string benutzer_Online;
        DatabaseManager databaseManager = new DatabaseManager();
        OleDbConnection UserConnection = new OleDbConnection();
        UserData userData = new UserData();
       

        public AdminUI(string onlineUser)
        {
            InitializeComponent();
            benutzer_Online = onlineUser;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
           
        }

        private void AdminUI_Load(object sender, EventArgs e)
        {
            userData = XmlDataManager.XmlUserDataReader("userdata.xml");
            UsernameLabel.Text = userData.Username;
            Atrributlabel.Text = userData.UserAttribut;
            if(userData.UserAttribut == "SuperAdmin")
            {
                databaseManager.ShowDatabase(UserDataGrid);
            }
            else
            {
                ControlPanel.Enabled = false;
                UserDataGrid.BackgroundColor = System.Drawing.Color.Gray;
                AddUserButton.BackColor = System.Drawing.Color.Gray;
                EditUserButton.BackColor = System.Drawing.Color.Gray;
                RemoveUserButton.BackColor = System.Drawing.Color.Gray;
                UpdateUserDataGridButton.BackColor = System.Drawing.Color.Gray;
            }
        }

        private void EditAccountButton_Click(object sender, EventArgs e)
        {
            bool testConnection = databaseManager.Test_Connection_User(benutzer_Online);
            if (testConnection == true)
            {
                EditAccountUI editAccountUI = new EditAccountUI(benutzer_Online);
                editAccountUI.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("The User " + benutzer_Online + " is offline!");
                this.Close();
            }
           
        }

        private void UserDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UpdateUserDataGridButton_Click(object sender, EventArgs e)
        {
            databaseManager.ShowDatabase(UserDataGrid);
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            AddUserUI addUserUI = new AddUserUI();
            addUserUI.Show();
        }

        private void EditUserButton_Click(object sender, EventArgs e)
        {
            EditUserUI editUserUI = new EditUserUI();
            editUserUI.Show();
        }

        private void RemoveUserButton_Click(object sender, EventArgs e)
        {
            RemoveUserUI removeUserUI = new RemoveUserUI();
            removeUserUI.Show();
        }
    }
}
