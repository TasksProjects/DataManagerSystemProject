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
    public partial class NewStudentUI : Form
    {
        private ConfigData config = new ConfigData();
        DatabaseManager databaseManager = new DatabaseManager();
        string benutzer_Name;
        string geschlecht;



        public NewStudentUI(string benutzername)
        {
            
            InitializeComponent();
            benutzer_Name = benutzername;
            AutoCompleteText_Nationalitaet();
            Load_Nationalitaet_Database();
            AutoCompleteText_Land();
            Load_Land_Database();
            AutoCompleteText_Hochschule();
            Load_Hochschule_Database();
            AutoCompleteText_Studiengang();
            Load_Studiengang_Database();
            AutoCompleteText_Master_Studiengang();
            Load_Master_Studiengang_Database();
            AutoCompleteText_Vorname();
            AutoCompleteText_Name();
            Load_Semester_Database();
            AutoCompleteText_Semester();
        }

        private void AddStudiengangBtn_Click(object sender, EventArgs e)
        {
            UserData user = new UserData();
            SuperUserData superUser = new SuperUserData();
            if (File.Exists("userData.xml"))
            {
                user = XmlDataManager.XmlUserDataReader("userData.xml");
            }

            if (user.UserAttribut != "SuperAdmin")
            {
                bool test_Connection = databaseManager.Test_Connection_User(benutzer_Name);

                if (test_Connection == true)
                {
                    StudiengangUI studiengangUI = new StudiengangUI(benutzer_Name, StudiengangCB.Text);
                    studiengangUI.Show();
                }
                else
                {
                    MessageBox.Show("The User " + benutzer_Name + " is offline!");
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
                    StudiengangUI studiengangUI = new StudiengangUI(benutzer_Name, StudiengangCB.Text);
                    studiengangUI.Show();
                }
                else
                {
                    MessageBox.Show("The User " + benutzer_Name + " is offline!");
                    this.Close();
                }
            }
        }

        private void AddHochschuleBtn_Click(object sender, EventArgs e)
        {
            UserData user = new UserData();
            SuperUserData superUser = new SuperUserData();
            if (File.Exists("userData.xml"))
            {
                user = XmlDataManager.XmlUserDataReader("userData.xml");
            }

            if (user.UserAttribut != "SuperAdmin")
            {
                bool test_Connection = databaseManager.Test_Connection_User(benutzer_Name);

                if (test_Connection == true)
                {
                    Add_Hochschule add_Hochschule = new Add_Hochschule(benutzer_Name, HochshuleCB.Text);
                    add_Hochschule.Show();
                }
                else
                {
                    MessageBox.Show("The User " + benutzer_Name + " is offline!");
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
                    Add_Hochschule add_Hochschule = new Add_Hochschule(benutzer_Name, HochshuleCB.Text);
                    add_Hochschule.Show();
                }
                else
                {
                    MessageBox.Show("The User " + benutzer_Name + " is offline!");
                    this.Close();
                }
            }
        }

        private void AddNationalitaetBtn_Click(object sender, EventArgs e)
        {
            UserData user = new UserData();
            SuperUserData superUser = new SuperUserData();
            if (File.Exists("userData.xml"))
            {
                user = XmlDataManager.XmlUserDataReader("userData.xml");
            }

            if (user.UserAttribut != "SuperAdmin")
            {
                bool test_Connection = databaseManager.Test_Connection_User(benutzer_Name);

                if (test_Connection == true)
                {
                    Add_Land add_Land = new Add_Land(benutzer_Name, NationalityTB.Text);
                    add_Land.Show();
                }
                else
                {
                    MessageBox.Show("The User " + benutzer_Name + " is offline!");
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
                    Add_Land add_Land = new Add_Land(benutzer_Name, NationalityTB.Text);
                    add_Land.Show();
                }
                else
                {
                    MessageBox.Show("The User " + benutzer_Name + " is offline!");
                    this.Close();
                }
            }
        }

        private void NewStudentUI_Load(object sender, EventArgs e)
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


        //Load Nationalität in NationalitätComboBox
        private void Load_Nationalitaet_Database()
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtNationalität FROM tab_land";

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
                string sName = reader["txtNationalität"].ToString();
                NationalityTB.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        // fill the ComboBox Nationalität with Database
        private void AutoCompleteText_Nationalitaet()
        {
            NationalityTB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            NationalityTB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtNationalität FROM tab_land";

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
                    string Nationalitaet = reader["txtNationalität"].ToString();
                    coll.Add(Nationalitaet);
          
                }
                UserConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            NationalityTB.AutoCompleteCustomSource = coll;
        }

        //Load Land in LandComboBox
        private void Load_Land_Database()
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
                StudienLandCB.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        // fill the ComboBox Land with Database
        private void AutoCompleteText_Land()
        {
            StudienLandCB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            StudienLandCB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtName FROM tab_land";

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
                UserConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            StudienLandCB.AutoCompleteCustomSource = coll;
        }

        //Load Hochschule in HochschuleComboBox
        private void Load_Hochschule_Database()
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtName FROM tab_hochschule";

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
                HochshuleCB.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        // fill the ComboBox Hochschule with Database
        private void AutoCompleteText_Hochschule()
        {
            HochshuleCB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            HochshuleCB.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
                    string HochschuleName = reader["txtName"].ToString();
                    coll.Add(HochschuleName);

                }
                UserConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            HochshuleCB.AutoCompleteCustomSource = coll;
        }

        //Load Hochschule in StudiengangComboBox
        private void Load_Studiengang_Database()
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtName FROM tab_studiengang";

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
                StudiengangCB.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        // fill the ComboBox Studiengang with Database
        private void AutoCompleteText_Studiengang()
        {
            StudiengangCB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            StudiengangCB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtName FROM tab_studiengang";

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
                    string StudiengangName = reader["txtName"].ToString();
                    coll.Add(StudiengangName);

                }
                UserConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            StudiengangCB.AutoCompleteCustomSource = coll;
        }

        //Load Hochschule in MasterStudiengangComboBox
        private void Load_Master_Studiengang_Database()
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtName FROM tab_masterstudiengang";

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
                MasterstudiengangCB.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        // fill the ComboBox Master_Studiengang with Database
        private void AutoCompleteText_Master_Studiengang()
        {
            MasterstudiengangCB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            MasterstudiengangCB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtName FROM tab_masterstudiengang";

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
                    string MasterStudiengangName = reader["txtName"].ToString();
                    coll.Add(MasterStudiengangName);

                }
                UserConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MasterstudiengangCB.AutoCompleteCustomSource = coll;
        }

        // fill the textbox Vorname with Database
        private void AutoCompleteText_Vorname()
        {
            FirstnameTB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            FirstnameTB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtVorname FROM tab_person";

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
                    string Vorname = reader["txtVorname"].ToString();
                    coll.Add(Vorname);

                }
                UserConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            FirstnameTB.AutoCompleteCustomSource = coll;
        }

        // fill the textbox Name with Database
        private void AutoCompleteText_Name()
        {
            NameTB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            NameTB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtName FROM tab_person";

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
                    string Name = reader["txtName"].ToString();
                    coll.Add(Name);

                }
                UserConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            NameTB.AutoCompleteCustomSource = coll;
        }

        //Load Semester in SemesterComboBox
        private void Load_Semester_Database()
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtSemester FROM tab_semester";

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
                string sName = reader["txtSemester"].ToString();
                SemesterCB.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        // fill the ComboBox Semester with Database
        private void AutoCompleteText_Semester()
        {
            SemesterCB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            SemesterCB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtSemester FROM tab_semester";

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
                    string Semester = reader["txtSemester"].ToString();
                    coll.Add(Semester);

                }
                UserConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SemesterCB.AutoCompleteCustomSource = coll;
        }

      

        private void NameTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void SemesterBtn_Click(object sender, EventArgs e)
        {
            Add_Semester add_Semester = new Add_Semester();
            add_Semester.Show();
        }

        // return the nationality ID
        public int Search_NationalitaetID(string nationalitaet)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT ID FROM tab_land where txtNationalität = '" + nationalitaet + "'";

            OleDbConnection UserConnection1 = new OleDbConnection();
            UserConnection1.ConnectionString = config.DbConnectionString;
            UserConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = UserConnection1;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = query;
            OleDbDataReader reader = cmd1.ExecuteReader();


            if (reader.HasRows)

            {
                reader.Read();
                string resultat = reader["ID"].ToString();
                UserConnection1.Close();
                int id = Convert.ToInt32(resultat);
                return id;
            }

            else
            {
                UserConnection1.Close();
                return 0;
            }
        }

        // return the studiengang ID
        public int Search_StudiengangID(string studiengang)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT ID FROM tab_studiengang where txtName = '" + studiengang + "'";

            OleDbConnection UserConnection1 = new OleDbConnection();
            UserConnection1.ConnectionString = config.DbConnectionString;
            UserConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = UserConnection1;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = query;
            OleDbDataReader reader = cmd1.ExecuteReader();


            if (reader.HasRows)

            {
                reader.Read();
                string resultat = reader["ID"].ToString();
                UserConnection1.Close();
                int id = Convert.ToInt32(resultat);
                return id;
            }

            else
            {
                UserConnection1.Close();
                return 0;
            }
        }

        //Function to save Student's information
        public void Add_New_Student()
        {
            int check_NoteVorläufing;
            int check_geschlecht;

            config = XmlDataManager.XmlConfigDataReader("configs.xml");

            if (NoteVorläufingCheckBox.Checked == true)
            {
                check_NoteVorläufing = 1;
            }
            else
            {
                check_NoteVorläufing = 0;
            }

            if ((MannlichRadioButton.Checked == true)||(WeiblichRadioButton.Checked == true))
            {
                check_geschlecht = 1;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Geschelcht bitte auswählen: Ja für Männlich und Nein für Weiblich.", "Geschlecht auswählen", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    MannlichRadioButton.Checked = true;
                }
                else if (dialogResult == DialogResult.No)
                {
                    WeiblichRadioButton.Checked = true;
                }
            }

         


           // int BachelorNummer = 50;
            int Student_nationalitaet = Search_NationalitaetID(NationalityTB.Text.Trim());
            int Student_studiengang = Search_StudiengangID(StudiengangCB.Text.Trim());
            double AbschlussNote;
            int CP;
            bool res = double.TryParse(AbschlussnoteTB.Text.Trim(), out AbschlussNote);
            bool result = int.TryParse(CpTB.Text.Trim(), out CP);

            if ((Student_nationalitaet !=0)&&(Student_studiengang !=0))
            {
                if ((res == true) && (result == true))
                {
                    StudentData studentData = new StudentData
                    {
                        Vorname = FirstnameTB.Text.Trim(),
                        Name = NameTB.Text.Trim(),
                        Nationalitaet = Student_nationalitaet,
                        Bachelor = Student_studiengang,
                        //Student_Note = Convert.ToDouble(AbschlussnoteTB.Text.Trim()),
                        Student_Note = AbschlussNote,
                        NoteVorlaefig = check_NoteVorläufing,
                        // Creditpunkte = Convert.ToInt32(CpTB.Text.Trim())
                        Creditpunkte = CP
                    };

                    string query = "insert into  tab_person([txtVorname],[txtName],[txtGeschlecht],[intNationalität],[intBachelor],[dblNote],[blnNoteVorläufig],[intCP])" +
                           " values ('" + studentData.Vorname + "','" + studentData.Name + "','" + geschlecht + "','" + studentData.Nationalitaet + "'," +
                           "'" + studentData.Bachelor + "','" + studentData.Student_Note + "', '" + studentData.NoteVorlaefig + "', '" + studentData.Creditpunkte + "')";
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
                        // MessageBox.Show("Data Saved Successful");
                        UserConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter correct Abschlussnote or CP! " + CP + " or " + AbschlussNote + " has bad format!");
                }
            }
            else
            {
                MessageBox.Show("Please check the nationality! " + NationalityTB.Text.Trim() + " doesn't exist!" );
            }

           
        }
        
        // function to search a Student_ID in database
        public int Search_ID_Student(string Student_Name)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT ID FROM tab_person where txtName = '" + Student_Name + "'";

            OleDbConnection UserConnection1 = new OleDbConnection();
            UserConnection1.ConnectionString = config.DbConnectionString;
            UserConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = UserConnection1;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = query;
            OleDbDataReader reader = cmd1.ExecuteReader();


            if (reader.HasRows)

            {
                reader.Read();
                string resultat = reader["ID"].ToString();
                UserConnection1.Close();
                int id = Convert.ToInt32(resultat);
                return id;
            }

            else
            {
                UserConnection1.Close();
                return 0;
            }
        }

        // function to search a Masterstudiengang_ID in database
        public int Search_ID_Masterstudiengang(string Masterstudiengang)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT ID FROM tab_masterstudiengang where txtName = '" + Masterstudiengang + "'";

            OleDbConnection UserConnection1 = new OleDbConnection();
            UserConnection1.ConnectionString = config.DbConnectionString;
            UserConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = UserConnection1;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = query;
            OleDbDataReader reader = cmd1.ExecuteReader();


            if (reader.HasRows)

            {
                reader.Read();
                string resultat = reader["ID"].ToString();
                UserConnection1.Close();
                int id = Convert.ToInt32(resultat);
                return id;
            }

            else
            {
                UserConnection1.Close();
                return 0;
            }
        }

        // function to search a Semester_ID in database
        public int Search_ID_Smester(string Semester)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT Id FROM tab_semester where txtSemester = '" + Semester + "'";

            OleDbConnection UserConnection1 = new OleDbConnection();
            UserConnection1.ConnectionString = config.DbConnectionString;
            UserConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = UserConnection1;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = query;
            OleDbDataReader reader = cmd1.ExecuteReader();


            if (reader.HasRows)

            {
                reader.Read();
                string resultat = reader["ID"].ToString();
                UserConnection1.Close();
                int id = Convert.ToInt32(resultat);
                return id;
            }

            else
            {
                UserConnection1.Close();
                return 0;
            }
        }


        // Add a New Bewerbung in Database
        public void Add_New_Bewerbung()
        {
            int check_Prof ;
            int check_Verwaltung ;
            int check_Angenommen ;

            if (AnProfCheckBox.Checked == true)
            {
                check_Prof = 1;
            }
            else
            {
                check_Prof = 0;
            }

            if (AngenommenCheckBox.Checked == true)
            {
                check_Angenommen = 1;
            }
            else
            {
                check_Angenommen = 0;
            }

            if (AnHaCheckBox.Checked == true)
            {
                check_Verwaltung = 1;
            }
            else
            {
                check_Verwaltung = 0;
            }
            config = XmlDataManager.XmlConfigDataReader("configs.xml");

        

            int Student_nationalitaet = Search_NationalitaetID(NationalityTB.Text.Trim());
            int Studenten_ID = Search_ID_Student(NameTB.Text.Trim());
            int MasterstudiengangID = Search_ID_Masterstudiengang(MasterstudiengangCB.Text.Trim());
            int Studenten_SemesterID = Search_ID_Smester(SemesterCB.Text.Trim());

            if ((Student_nationalitaet!=0)&&(Studenten_ID != 0)&&(MasterstudiengangID !=0)&&(Studenten_SemesterID !=0))
            {
                Bewerbungsdata bewerbungsdata = new Bewerbungsdata
                {
                    StudentID = Studenten_ID,
                    Master_StudiengangID = MasterstudiengangID,
                    SemesterID = Studenten_SemesterID,
                    Comment1 = ZusatzTB.Text.Trim(),
                    Comment2 = AblehnungsgrundTB.Text.Trim(),
                    Comment3 = KommentarTB.Text.Trim(),
                    Prof = check_Prof,
                    Verwaltung = check_Verwaltung,
                    Angenommen = check_Angenommen

                };

                string query = "insert into  tab_bewerbung([intPerson],[intMasterstudiengang],[intSemester],[txtKommentar1],[txtKommentar2],[txtKommentar3],[blnProf],[blnVerwaltung],[blnAngenommen])" +
                             " values ('" + bewerbungsdata.StudentID + "','" + bewerbungsdata.Master_StudiengangID + "','" + bewerbungsdata.SemesterID + "'," +
                             "'" + bewerbungsdata.Comment1 + "','" + bewerbungsdata.Comment2 + "', '" + bewerbungsdata.Comment3 + "', '" + check_Prof + "', '" + check_Verwaltung + "', '" + check_Angenommen + "')";
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
                    MessageBox.Show("Data Saved Successful");
                    UserConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else
            {
                MessageBox.Show("Please check the student'daten! " + MasterstudiengangCB.Text.Trim() + " or " + SemesterCB.Text.Trim() + " has bad format!");
                NewStudentUI newStudent = new NewStudentUI(benutzer_Name);
                newStudent.Show();
            }

           
        }

        private void CanceledBtn_Click(object sender, EventArgs e)
        {

            this.Close();
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
                bool test_Connection = databaseManager.Test_Connection_User(benutzer_Name);

                if (test_Connection == true)
                {
                    if (FirstnameTB.Text != string.Empty || NameTB.Text != string.Empty || NationalityTB.Text != string.Empty || StudiengangCB.Text != string.Empty
                       || HochshuleCB.Text != string.Empty || StudiengangCB.Text != string.Empty || AbschlussnoteTB.Text != string.Empty
                       || CpTB.Text != string.Empty || MasterstudiengangCB.Text != string.Empty || SemesterCB.Text != string.Empty)
                    {
                        Add_New_Student();
                        Add_New_Bewerbung();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please fill all the field!");
                    }
                }
                else
                {
                    MessageBox.Show("The User " + benutzer_Name + " is offline!");
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
                    if (FirstnameTB.Text != string.Empty || NameTB.Text != string.Empty || NationalityTB.Text != string.Empty || StudiengangCB.Text != string.Empty
                      || HochshuleCB.Text != string.Empty || StudiengangCB.Text != string.Empty || AbschlussnoteTB.Text != string.Empty
                      || CpTB.Text != string.Empty || MasterstudiengangCB.Text != string.Empty || SemesterCB.Text != string.Empty)
                    {
                        Add_New_Student();
                        Add_New_Bewerbung();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please fill all the field!");
                    }
                }
                else
                {
                    MessageBox.Show("The User " + benutzer_Name + " is offline!");
                    this.Close();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MannlichRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            geschlecht = "Mannlich";
        }

        private void WeiblichRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            geschlecht = "Weiblich";
        }
    }
}
