using DataManagerSystem.Configs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class EditUserUI : Form
    {
        string benutzer_online;
        DatabaseManager databaseManager = new DatabaseManager();
        OleDbConnection UserConnection = new OleDbConnection();
        ConfigData config = new ConfigData();
        public EditUserUI(string userOnline)
        {
            InitializeComponent();
            benutzer_online = userOnline;
        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            this.Close();
            //Boolean resp = databaseManager.SearchUser(UsernameTextBox.Text);
            //MessageBox.Show("le resultat est : " +resp);  
        }

        private void EditButton_Click(object sender, EventArgs e)
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
                    if (UserIdTextBox.Text == string.Empty || UsernameTextBox.Text == string.Empty || PasswordTextBox.Text == string.Empty || AttributComboBox.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter correct data!");
                    }
                    else
                    {
                        int id = Convert.ToInt32(UserIdTextBox.Text);
                        string username = UsernameTextBox.Text;
                        string password = PasswordTextBox.Text;
                        string attribut = AttributComboBox.Text;
                        databaseManager.EditUser(id, username, password, attribut);
                        UserIdTextBox.Clear();
                        UsernameTextBox.Clear();
                        PasswordTextBox.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("The User " + benutzer_online + " is offline!");
                    this.Close();
                }

            }   
        }
    }
}
