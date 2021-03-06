﻿using DataManagerSystem.Configs;
using DataManagerSystem.Modules;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace DataManagerSystem
{
    public partial class MainWindow : Form
    {
        string User_online;
        DatabaseManager databaseManager = new DatabaseManager();
        ConfigData config = new ConfigData();
        SettingsUI settingUI = new SettingsUI();
       
        public MainWindow( string benutzerName, string status)
        {
            InitializeComponent();
            Disable(status);
            labelStatus.Text = status;
            User_online = benutzerName;

            //display the time
            timer1.Start();
        }

        // Disconect the user
        private void LogoutButton_Click(object sender, EventArgs e)
        {
            UserData user = new UserData();
            SuperUserData superUser = new SuperUserData();
            if (File.Exists("userData.xml"))
            {
                user = XmlDataManager.XmlUserDataReader("userData.xml");
                if (user.UserAttribut != "SuperAdmin")
                {
                    Disconnect_USer(User_online);
                    //Application.ExitThread();
                    Application.Exit();
                }
                else
                {
                    if (File.Exists("SuperUserStatut.xml"))
                    {
                        superUser = XmlDataManager.XmlSuperUserDataReader("SuperUserStatut.xml");

                        superUser.SuperUserstatut = 0;
                        XmlDataManager.XmlDataWriter(superUser, "SuperUserStatut.xml");
                        Application.Exit();
                    }
                }
            }
           
        }

        private void SettingButton_Click(object sender, EventArgs e)
        {
            settingUI.Show();
        }

        //Exit Program
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
     
        private void AddButton_Click(object sender, EventArgs e)
        {
           NewStudentUI newStudentUI = new NewStudentUI();
          newStudentUI.Show();
        }

        private void AdminButton_Click(object sender, EventArgs e)
        {
            AdminUI adminUI = new AdminUI(User_online);
            adminUI.Show();
        }

        private void ShowDbButton_Click(object sender, EventArgs e)
        {
           BewerbungUI bewerbungUI = new BewerbungUI();
           bewerbungUI.Show();
        }

        private void Disable(string status)
        {
            if (((status == "Professor") || (status == "Assistant") || (status == "Admin")))
            {
                SettingButton.Enabled = false;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.labelTime.Text = dateTime.ToString();
        }

        private void StudiengangButton_Click(object sender, EventArgs e)
        {
            string studuengang = "";
            StudiengangUI studiengangUI = new StudiengangUI(studuengang );
            studiengangUI.Show();
        }

        // Disconnect the User
        public void Disconnect_USer(string user)
        {
            UserData onlineuser = new UserData();
            onlineuser.Username = user;
            
            // check if the username already exist and return his value
            Boolean response = Search_User_Online_To_Disconect(onlineuser);
            int userID = databaseManager.checkUserID(onlineuser.Username);

            if (response == true)
            {
                config = XmlDataManager.XmlConfigDataReader("configs.xml");
                string query = "Update  tab_User set [BlnOnline] = '" + 0 + "'  where ID = " + userID + "";
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
                    UserConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else
            {
                MessageBox.Show("Logout failed! " + user + " is already offline!");
            }
        }

        // Search the connected user
        public bool Search_User_Online_To_Disconect(UserData userdat)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            int count = 0;

            OleDbConnection LoginConnection = new OleDbConnection();
            LoginConnection.ConnectionString = config.DbConnectionString;
            LoginConnection.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = LoginConnection;
            cmd.CommandText = "SELECT * FROM tab_User where Username = '" + userdat.Username + "' ";
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

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void EditButton_Click(object sender, EventArgs e)
        {
            UebersichtBetreuer uebersichtBetreuer = new UebersichtBetreuer();
            uebersichtBetreuer.Show();
        }

        private void Helpbutton_Click(object sender, EventArgs e)
        {

        }

    }
}
