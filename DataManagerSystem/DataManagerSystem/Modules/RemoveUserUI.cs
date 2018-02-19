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
    public partial class RemoveUserUI : Form
    {
        string Benutzer_online;
        DatabaseManager databaseManager = new DatabaseManager();
        OleDbConnection UserConnection = new OleDbConnection();
        ConfigData config = new ConfigData();
        public RemoveUserUI(string user_online)
        {
            InitializeComponent();
            Benutzer_online = user_online;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (!UserIDTextBox.Text.Trim().Equals(string.Empty) && !UsernameTextBox.Text.Trim().Equals(string.Empty))
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
                    else
                    {
                        MessageBox.Show("The User " + Benutzer_online + " is offline!");
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
