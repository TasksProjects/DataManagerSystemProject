using DataManagerSystem.Configs;
using System;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class EditAccountUI : Form
    {
        string Online_User;
        DatabaseManager databaseManager = new DatabaseManager();
        OleDbConnection UserConnection = new OleDbConnection();
        ConfigData config = new ConfigData();
        UserData userData = new UserData();
        UserData userData1 = new UserData();

        public EditAccountUI(string OnlineUser)
        {
            InitializeComponent();
            Online_User = OnlineUser;
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            AdminUI adminUI = new AdminUI(Online_User);
            this.Close();
            adminUI.Show();
        }

        private void EditAccountUI_Load(object sender, EventArgs e)
        {
            userData = XmlDataManager.XmlUserDataReader("userdata.xml");
            UsernameTextBox.Text = userData.Username;
            OldPasswordTextBox.Text = userData.Password;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!UsernameTextBox.Text.Trim().Equals(string.Empty) && !OldPasswordTextBox.Text.Trim().Equals(string.Empty) && !NewPasswordTextBox.Text.Trim().Equals(string.Empty) && !RepeatPasswordTextBox.Text.Trim().Equals(string.Empty))
            {
                userData = XmlDataManager.XmlUserDataReader("userdata.xml");
                string unchangeUsername = userData.Username; // old Username
                string UserAttribut = userData.UserAttribut;

                userData1 = XmlDataManager.XmlUserDataReader("XMLSystemAdmin.xml");
                string UserAttribut1 = userData1.UserAttribut;

                if (!(UserAttribut.Equals("SuperAdmin")))
                {
                    // return the UserId from the database
                    int UserId = databaseManager.ReturnUserID(unchangeUsername, OldPasswordTextBox.Text);

                    string newUsername = UsernameTextBox.Text; // new Username
                    string oldPassword = OldPasswordTextBox.Text; // old Password
                    string newPassword = NewPasswordTextBox.Text; // new Password
                    string repeatPassword = RepeatPasswordTextBox.Text; // new Password

                    //Edit the UserData as simple user.
                    databaseManager.EditAccountUser(UserId, newUsername, oldPassword, newPassword, repeatPassword);
                    UsernameTextBox.Clear();
                    OldPasswordTextBox.Clear();
                    NewPasswordTextBox.Clear();
                    RepeatPasswordTextBox.Clear();

                    AdminUI adminUI = new AdminUI(Online_User);
                    this.Close();
                    adminUI.Show();
                }
                else
                {
                    string AdminPassword = userData1.Password;
                    if ((OldPasswordTextBox.Text).Equals(AdminPassword))
                    {
                        if (File.Exists("XMLSystemAdmin.xml"))
                        {
                            userData.Username = UsernameTextBox.Text.Trim();
                            userData.Password = NewPasswordTextBox.Text.Trim();
                            userData.UserAttribut = UserAttribut;
                            XmlDataManager.XmlDataWriter(userData, "XMLSystemAdmin.xml");
                            MessageBox.Show("SuperAdmin Data changed successful");

                            AdminUI adminUI = new AdminUI(Online_User);
                            this.Close();
                            adminUI.Show();
                        }
                        else
                        {
                            MessageBox.Show("XMLSystemAdmin.xml File not found!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password. Please give a correct password!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Fill all Fields");
            } 
        }
    }
}
