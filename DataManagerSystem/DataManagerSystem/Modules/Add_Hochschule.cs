using DataManagerSystem.Configs;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class Add_Hochschule : Form
    {
        DatabaseManager databaseManager = new DatabaseManager();
        string benutzerOnline;
        private ConfigData config = new ConfigData();

      

        public Add_Hochschule(string benutzer_online, string hochschuleName)
        {

            InitializeComponent();
            NameTextBox.Text = hochschuleName;
            benutzerOnline = benutzer_online;
            AutoCompleteText_Land();
            Load_Hochschule_Land_Database();
            

        }

        private void Add_Hochschule_Load(object sender, EventArgs e)
        {
            if (File.Exists("configs.xml"))
            {
                config = XmlDataManager.XmlConfigDataReader("configs.xml");

            }
            else
            {
                MessageBox.Show("no config xml file!");
            }
        }

        private void Load_Hochschule_Land_Database()
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtName FROM tab_land";

            OleDbConnection UserConnection1 = new OleDbConnection
            {
                ConnectionString = config.DbConnectionString
            };
            UserConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand
            {
                Connection = UserConnection1,
                CommandType = CommandType.Text,
                CommandText = query
            };
            OleDbDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                string sName = reader["txtName"].ToString();
                LandComboBox.Items.Add(sName);
            }
        }

        // fill the Combo´Box Hochschule with Database
        private void AutoCompleteText_Land()
        {
            LandComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            LandComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtName FROM tab_hochschule";

            OleDbConnection UserConnection1 = new OleDbConnection
            {
                ConnectionString = config.DbConnectionString
            };
            try
            {
                UserConnection1.Open();
                OleDbCommand cmd1 = new OleDbCommand
                {
                    Connection = UserConnection1,
                    CommandType = CommandType.Text,
                    CommandText = query
                };
                OleDbDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    string LandName = reader["txtName"].ToString();
                    coll.Add(LandName);
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LandComboBox.AutoCompleteCustomSource = coll;
        }

       

        public int Search_Land_ID(string LandName)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT ID FROM tab_land where txtName = '" + LandName + "' ";



            OleDbConnection LandConnection1 = new OleDbConnection();
            LandConnection1.ConnectionString = config.DbConnectionString;
            LandConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand
            {
                Connection = LandConnection1,
                CommandType = CommandType.Text,
                CommandText = query
            };
            OleDbDataReader reader = cmd1.ExecuteReader();


            if (reader.HasRows)

            {
                reader.Read();
                string resultat = reader["ID"].ToString();
                int id = Convert.ToInt32(resultat);
                LandConnection1.Close();
                return id;
            }

            else
            {
                LandConnection1.Close();
                return 0;
               
            }
        }

        public void AddHochschule(int Land_ID)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");

            string query = "insert into  tab_hochschule ([txtName],[intLand])" +
                          " values ('" + NameTextBox.Text.Trim() + "','" +  Land_ID + "')";
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
            UserData user = new UserData();
            SuperUserData superUser = new SuperUserData();
            if (File.Exists("userData.xml"))
            {
                user = XmlDataManager.XmlUserDataReader("userData.xml");
            }

            if (user.UserAttribut != "SuperAdmin")
            {
                bool test_Connection = databaseManager.Test_Connection_User(benutzerOnline);

                if (test_Connection == true)
                {
                    int ID_Land = Search_Land_ID(LandComboBox.Text.Trim());
                    if (ID_Land != 0 && ID_Land != -1)
                    {
                        AddHochschule(ID_Land);
                    }
                    else if (ID_Land == 0)
                    {

                        DialogResult dialogResult = MessageBox.Show("Land doesn't exist! Please click Ok to add a new Land!", "confirmation", MessageBoxButtons.OKCancel);
                        if (dialogResult == DialogResult.OK)
                        {
                            Add_Land add_Land = new Add_Land(benutzerOnline, LandComboBox.Text);
                            add_Land.Show();
                            this.Close();
                        }

                    }

                    this.Close();
                    /*StudiengangUI studiengangUI = new StudiengangUI();
                    studiengangUI.Show();*/
                }
                else
                {
                    MessageBox.Show("The User " + benutzerOnline + " is offline!");
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
                    int ID_Land = Search_Land_ID(LandComboBox.Text.Trim());
                    if (ID_Land != 0 && ID_Land != -1)
                    {
                        AddHochschule(ID_Land);
                    }
                    else if (ID_Land == 0)
                    {

                        DialogResult dialogResult = MessageBox.Show("Land doesn't exist! Please click Ok to add a new Land!", "confirmation", MessageBoxButtons.OKCancel);
                        if (dialogResult == DialogResult.OK)
                        {
                            Add_Land add_Land = new Add_Land(benutzerOnline, LandComboBox.Text);
                            add_Land.Show();
                            this.Close();
                        }

                    }

                    this.Close();
                    /*StudiengangUI studiengangUI = new StudiengangUI();
                    studiengangUI.Show();*/
                }
                else
                {
                    MessageBox.Show("The User " + benutzerOnline + " is offline!");
                    this.Close();
                }
            }
        }

      

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            /*StudiengangUI studiengangUI = new StudiengangUI();
            studiengangUI.Show();*/
        }
    }
}
