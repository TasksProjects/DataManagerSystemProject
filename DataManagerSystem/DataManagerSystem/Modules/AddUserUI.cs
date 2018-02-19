using DataManagerSystem.Configs;
using System;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class AddUserUI : Form
    {
        string benutzer_Online;
        DatabaseManager databaseManager = new DatabaseManager();
        OleDbConnection UserConnection = new OleDbConnection();
        ConfigData config = new ConfigData();

        public AddUserUI(string user_online)
        {
            InitializeComponent();
            benutzer_Online = user_online;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!UsernameTextBox.Text.Trim().Equals(string.Empty) && !PasswordTextBox.Text.Trim().Equals(string.Empty) && !AttributComboBox.Text.Trim().Equals(string.Empty))
            {
                UserData user = new UserData();
                SuperUserData superUser = new SuperUserData();

                if (File.Exists("userData.xml"))
                {
                    user = XmlDataManager.XmlUserDataReader("userData.xml");
                }
                if (user.UserAttribut == "SuperAdmin")
                {
                    if (File.Exists("SuperUserStatut.xml"))
                    {
                        superUser = XmlDataManager.XmlSuperUserDataReader("SuperUserStatut.xml");
                    }

                    if (superUser.SuperUserstatut == 1)
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
                    else
                    {
                        MessageBox.Show("The User " + benutzer_Online + " is offline!");
                        this.Close();
                    }

                }
            }
            else
            {
                MessageBox.Show("Please fill all the field!");
            }

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
