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
    public partial class Add_Land : Form
    {
        DatabaseManager databaseManager = new DatabaseManager();
        string benutzer_Online;
        private ConfigData config = new ConfigData();

        public Add_Land(string benutzer, String NameNationalitaet)
        {
            InitializeComponent();
            NationalitättextBox.Text = NameNationalitaet;
            benutzer_Online = benutzer;
        }

        public Add_Land()
        {
        }

        public void AddLand()
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "insert into  tab_land ([txtName],[txtNationalität])" +
                          " values ('" + LandTextBox.Text.Trim() + "','" + NationalitättextBox.Text + "')";
            OleDbConnection UserConnection = new OleDbConnection();

            UserConnection.ConnectionString = config.DbConnectionString;


            OleDbCommand cmd = new OleDbCommand
            {
                CommandType = CommandType.Text,
                CommandText = query,
                Connection = UserConnection
            };
            UserConnection.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Saved Successful");
                UserConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!LandTextBox.Text.Trim().Equals(string.Empty) && !NationalitättextBox.Text.Trim().Equals(string.Empty))
            {
                UserData user = new UserData();
                SuperUserData superUser = new SuperUserData();
                if (File.Exists("userData.xml"))
                {
                    user = XmlDataManager.XmlUserDataReader("userData.xml");
                }

                if (user.UserAttribut != "SuperAdmin")
                {
                    bool test_Connection = databaseManager.Test_Connection_User(benutzer_Online);

                    if (test_Connection == true)
                    {
                        AddLand();
                        this.Close();
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
                        AddLand();
                        this.Close();
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

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
