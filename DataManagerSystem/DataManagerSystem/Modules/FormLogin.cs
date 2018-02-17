using DataManagerSystem.Configs;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Data.OleDb;

namespace DataManagerSystem
{
    public partial class FormLogin : Form
    {
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
            //Checking the accuracy of user data
            if (UserNameTextBox.Text == string.Empty || PasswordTextBox.Text == string.Empty || AttributComboBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter correct data!");
            }
            else
            {
                if (AttributComboBox.Text.Trim() != "SuperAdmin")
                {
                    String Attribut = string.Empty;
                    int count = 0;

                    OleDbConnection LoginConnection = new OleDbConnection();
                    LoginConnection.ConnectionString = config.DbConnectionString;
                    LoginConnection.Open();                    

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = LoginConnection;
                    cmd.CommandText = "SELECT * FROM tab_User where Username = '" + UserNameTextBox.Text.Trim() + "' and Password = '" + PasswordTextBox.Text.Trim() + "' and Attribut = '" + AttributComboBox.Text.Trim() + "' ";
                    OleDbDataReader reader = cmd.ExecuteReader();
                        
                    while (reader.Read())
                    {
                        count++;
                    }

                    LoginConnection.Close();

                    // Test if the given username exists in the database
                    if (count==1)
                    {
                        //Save user data into an xml File for futher connection
                        try
                        {
                            userData.Username = UserNameTextBox.Text.Trim();
                            userData.UserAttribut = AttributComboBox.Text.Trim();
                            XmlDataManager.XmlDataWriter(userData, "userData.xml");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        Attribut = userData.UserAttribut;

                        MainWindow objMainWindow = new MainWindow(Attribut);
                        objMainWindow.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show(" Wrong Username or Password Please Check your Data!");
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
                            MainWindow objMainWindow = new MainWindow(userData.UserAttribut);
                            objMainWindow.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Check your Username and Password");
                        }
                    }
                }
            }
        }
    }

}
