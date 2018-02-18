using DataManagerSystem.Configs;
using System;
using System.Data.OleDb;
using System.IO;
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
            UserData user = new UserData();
            SuperUserData superUser = new SuperUserData();
            if (File.Exists("userData.xml"))
            {
                user = XmlDataManager.XmlUserDataReader("userData.xml");
            }
            if (user.UserAttribut != "SuperAdmin")
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
            else
            {
                if (File.Exists("SuperUserStatut.xml"))
                {
                    superUser = XmlDataManager.XmlSuperUserDataReader("SuperUserStatut.xml");
                }

                if (superUser.SuperUserstatut == 1)
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
        }

        private void UserDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UpdateUserDataGridButton_Click(object sender, EventArgs e)
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
                    databaseManager.ShowDatabase(UserDataGrid);
                }
                else
                {
                    MessageBox.Show("The User " + benutzer_Online + " is offline!");
                    this.Close();
                }

            }
        }

        private void AddUserButton_Click(object sender, EventArgs e)
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
                    AddUserUI addUserUI = new AddUserUI(benutzer_Online);
                    addUserUI.Show();
                }
                else
                {
                    MessageBox.Show("The User " + benutzer_Online + " is offline!");
                    this.Close();
                }

            }
        }

        private void EditUserButton_Click(object sender, EventArgs e)
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
                    EditUserUI editUserUI = new EditUserUI(benutzer_Online);
                    editUserUI.Show();
                }
                else
                {
                    MessageBox.Show("The User " + benutzer_Online + " is offline!");
                    this.Close();
                }

            }
           
        }

        private void RemoveUserButton_Click(object sender, EventArgs e)
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
                    RemoveUserUI removeUserUI = new RemoveUserUI(benutzer_Online);
                    removeUserUI.Show();
                }
                else
                {
                    MessageBox.Show("The User " + benutzer_Online + " is offline!");
                    this.Close();
                }

            }
        }
    }
}
