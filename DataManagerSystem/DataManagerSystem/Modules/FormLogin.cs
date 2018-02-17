﻿using DataManagerSystem.Configs;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Data.OleDb;
using System.Data;

namespace DataManagerSystem
{
    
    public partial class FormLogin : Form

    {
        DatabaseManager databaseManager = new DatabaseManager();
        String Attribut = string.Empty;
        UserData benutzer = new UserData();
        UserData userData = new UserData();
        ConfigData config = new ConfigData();

        public FormLogin()
        {
            InitializeComponent();
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
        }

        //Window Loader
        private void Form_Login_Load(object sender, EventArgs e)
        {
            if (File.Exists("userData.xml"))
            {
                userData = XmlDataManager.XmlUserDataReader("userData.xml");
                UserNameTextBox.Text = userData.Username;
                AttributComboBox.Text = userData.UserAttribut;
            }
        }

        // Button to Exit the Application
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        // Button to Login
        private void LoginButton_Click(object sender, EventArgs e)
        {
            UserData benutzerOnline = new UserData();
            //Checking the accuracy of user data
            if (UserNameTextBox.Text == string.Empty || PasswordTextBox.Text == string.Empty || AttributComboBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter correct data!");
            }
            else
            {
                benutzerOnline.Username = UserNameTextBox.Text.Trim();
                benutzerOnline.Password = PasswordTextBox.Text.Trim();
                benutzerOnline.UserAttribut = AttributComboBox.Text.Trim();

                

                if (benutzerOnline.UserAttribut != "SuperAdmin")
                {
                    bool Check_benutzer_online = Search_Online_benutzer(benutzerOnline);
                    if (Check_benutzer_online == true)
                    {
                        Set_USer_Online(benutzerOnline);
                    }
                    else
                    {
                        MessageBox.Show("connection failed! " + benutzerOnline.Username + " is already online!");
                    }
                   
                   
               
                }
                else
                {
                    if (File.Exists("XMLSystemAdmin.xml"))
                    {
                        userData.Username = UserNameTextBox.Text.Trim();
                        userData.UserAttribut = AttributComboBox.Text.Trim();
                        XmlDataManager.XmlDataWriter(userData, "userData.xml");

                        userData = XmlDataManager.XmlUserDataReader("XMLSystemAdmin.xml");

                        if (UserNameTextBox.Text.Trim() == userData.Username.Trim() & PasswordTextBox.Text.Trim() == userData.Password.Trim() & AttributComboBox.Text.Trim() == userData.UserAttribut.Trim())
                        {
                            MainWindow objMainWindow = new MainWindow(userData.Username,userData.UserAttribut);
                            objMainWindow.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Check your Username and Password!");
                        }
                    }
                }
            }
        }

        
        // Check ob the User is already online
        public bool Search_Online_benutzer(UserData userdat)
        {
            int count = 0;
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            OleDbConnection LoginConnection = new OleDbConnection();
            LoginConnection.ConnectionString = config.DbConnectionString;
            LoginConnection.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = LoginConnection;
            cmd.CommandText = "SELECT BlnOnline FROM tab_User where Username = '" + userdat.Username + "' and Password = '" + userdat.Password + "' and Attribut = '" + userdat.UserAttribut + "' ";
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                count++;
            }

            LoginConnection.Close();

            // Test if the given username exists in the database
            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // connect a user to the Database
        public void Set_USer_Online(UserData user)
        {
            // check if the username already exist and return his value
            bool response = Search_Online_benutzer(user);
            int userID = databaseManager.checkUserID(user.Username);
      
            
                if (response == true)
                {
                    config = XmlDataManager.XmlConfigDataReader("configs.xml");
                    string query = "Update  tab_User set [BlnOnline] = '" + 1 + "'  where ID = " + userID + "";
                    OleDbConnection UserConnection = new OleDbConnection();
                    UserConnection.ConnectionString = config.DbConnectionString;
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = UserConnection;
                    UserConnection.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                       // MessageBox.Show("Data Edit Successful");
                        UserConnection.Close();
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex);
                    }
                     userData.Username = user.Username;
                     userData.UserAttribut = user.UserAttribut;
                     XmlDataManager.XmlDataWriter(userData, "userData.xml");
                     Attribut = user.UserAttribut;
                     MainWindow objMainWindow = new MainWindow(user.Username,Attribut);
                     objMainWindow.Show();
                     this.Hide();

                }
                else
                {
                    MessageBox.Show("connection failed! Wrong Username or Password Please Check your Data.");
                }
        }
    }


}
