using DataManagerSystem.Configs;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class EditPerson : Form
    {
        int bewerbungsID;
        Bewerbungsdata bewerbungsdata = new Bewerbungsdata();
        StudentData studentData = new StudentData();
        private ConfigData config = new ConfigData();
        DatabaseManager databaseManager = new DatabaseManager();
        string[] studentenInfo = new string[5];
        string Nationalitaet;
        string Bachelor;
        string benutzer_Name;
        string geschlecht;
        public EditPerson(int idStudent, string[] information, Bewerbungsdata bewerbung, StudentData student)

        {
            InitializeComponent();
            bewerbungsID = idStudent;
            bewerbungsdata = bewerbung;
            studentData = student;
            studentenInfo = information;
            Nationalitaet = studentenInfo[2];
            Bachelor = studentenInfo[3];

            VornameTextbox.Text = student.Vorname;
            NameTextbox.Text = student.Name;

            if (student.NoteVorlaefig == 1)
            {
                NoteVorläufigcheckBox.Checked = true;
            }
            else
            {
                NoteVorläufigcheckBox.Checked = false;
            }

            if (bewerbung.Prof == 1)
            {
                AnProfcheckBox.Checked = true;
            }
            else
            {
                AnProfcheckBox.Checked = false;
            }

            if (bewerbung.Verwaltung == 1)
            {
                AnHa41checkBox.Checked = true;
            }
            else
            {
                AnHa41checkBox.Checked = false;
            }

            if (bewerbung.Angenommen == 1)
            {
                AngenommencheckBox.Checked = true;
            }
            else
            {
                AngenommencheckBox.Checked = false;
            }

            if (student.Geschlecht == "Weiblich")
            {
                WeiblichRadioButton.Checked = true;
            }
            else
            {
                MannlichRadioButton.Checked = true;
            }

            NationalitaetcomboBox.Text = Nationalitaet;
            StudiengangcomboBox.Text = Bachelor;
            AbschlussnotetextBox.Text = "" + student.Student_Note;
            ErworbeneCPtextBox.Text = "" + student.Creditpunkte;
            MasterstudiengangcomboBox.Text = studentenInfo[0];
            SemestercomboBox.Text = studentenInfo[1];



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
            Load_Semester_Database();
            AutoCompleteText_Semester();
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
                    Add_Land add_Land = new Add_Land(benutzer_Name, NationalitaetcomboBox.Text);
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
                    Add_Land add_Land = new Add_Land(benutzer_Name, NationalitaetcomboBox.Text);
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
                NationalitaetcomboBox.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        // fill the ComboBox Nationalität with Database
        private void AutoCompleteText_Nationalitaet()
        {
            NationalitaetcomboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            NationalitaetcomboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
            NationalitaetcomboBox.AutoCompleteCustomSource = coll;
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
                studienlandcomboBox.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        // fill the ComboBox Land with Database
        private void AutoCompleteText_Land()
        {
            studienlandcomboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            studienlandcomboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
            studienlandcomboBox.AutoCompleteCustomSource = coll;
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
                HochschulecomboBox.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        // fill the ComboBox Hochschule with Database
        private void AutoCompleteText_Hochschule()
        {
            HochschulecomboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            HochschulecomboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
            HochschulecomboBox.AutoCompleteCustomSource = coll;
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
                StudiengangcomboBox.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        // fill the ComboBox Studiengang with Database
        private void AutoCompleteText_Studiengang()
        {
            StudiengangcomboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            StudiengangcomboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
            StudiengangcomboBox.AutoCompleteCustomSource = coll;
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
                MasterstudiengangcomboBox.Items.Add(sName);
                MasterstudiengangcomboBox2.Items.Add(sName);
                MasterstudiengangcomboBox3.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        // fill the ComboBox Master_Studiengang with Database
        private void AutoCompleteText_Master_Studiengang()
        {
            MasterstudiengangcomboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            MasterstudiengangcomboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            MasterstudiengangcomboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            MasterstudiengangcomboBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            MasterstudiengangcomboBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            MasterstudiengangcomboBox3.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
            MasterstudiengangcomboBox.AutoCompleteCustomSource = coll;
            MasterstudiengangcomboBox2.AutoCompleteCustomSource = coll;
            MasterstudiengangcomboBox3.AutoCompleteCustomSource = coll;
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
                SemestercomboBox.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        // fill the ComboBox Semester with Database
        private void AutoCompleteText_Semester()
        {
            SemestercomboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            SemestercomboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
            SemestercomboBox.AutoCompleteCustomSource = coll;
        }

        private void SemesterBtn_Click(object sender, EventArgs e)
        {
            Add_Semester add_Semester = new Add_Semester();
            add_Semester.Show();
        }

        // return the nationality ID
        public string Search_Nationalitaet(int nationalitaetID)
        {

            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtNationalität FROM tab_land where ID = " + nationalitaetID + "";

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
                string resultat = reader["txtNationalität"].ToString();
                UserConnection1.Close();
                return resultat;


            }

            else
            {
                UserConnection1.Close();
                return null;
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



        private void CanceledBtn_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void DruckenBtn_Click(object sender, EventArgs e)
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



        private void StudiengangHinzufügenBtn_Click(object sender, System.EventArgs e)
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
                    StudiengangUI studiengangUI = new StudiengangUI(benutzer_Name, studienlandcomboBox.Text);
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
                    StudiengangUI studiengangUI = new StudiengangUI(benutzer_Name, studienlandcomboBox.Text);
                    studiengangUI.Show();
                }
                else
                {
                    MessageBox.Show("The User " + benutzer_Name + " is offline!");
                    this.Close();
                }
            }
        }

        private void HochschuleHinzufügenBtn_Click(object sender, System.EventArgs e)
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
                    Add_Hochschule add_Hochschule = new Add_Hochschule(benutzer_Name, HochschulecomboBox.Text);
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
                    Add_Hochschule add_Hochschule = new Add_Hochschule(benutzer_Name, HochschulecomboBox.Text);
                    add_Hochschule.Show();
                }
                else
                {
                    MessageBox.Show("The User " + benutzer_Name + " is offline!");
                    this.Close();
                }
            }
        }

        private void SemesterHinzufügenBtn_Click(object sender, EventArgs e)
        {

        }

        //Funktion zur Verwaltung des Alters (Herr)
        private void MannlichRadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            geschlecht = "Mannlich";
        }

        //Funktion zur Verwaltung des Alters (Herr)
        private void WeiblichRadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            geschlecht = "Weiblich";
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


        //Studenten Informations ändern
        public bool EditInformationStudent(int IdBewerbung)
        {
            bool response = false;
            int IdStudent = IdBewerbung;
            int check_NoteVorläufing;



            config = XmlDataManager.XmlConfigDataReader("configs.xml");

            if (NoteVorläufigcheckBox.Checked == true)
            {
                check_NoteVorläufing = 1;
            }
            else
            {
                check_NoteVorläufing = 0;
            }

            int Student_nationalitaet = Search_NationalitaetID(NationalitaetcomboBox.Text.Trim());
            int Student_studiengang = Search_StudiengangID(StudiengangcomboBox.Text.Trim());
            double AbschlussNote;
            int CP;
            bool res = double.TryParse(AbschlussnotetextBox.Text.Trim(), out AbschlussNote);
            bool result = int.TryParse(ErworbeneCPtextBox.Text.Trim(), out CP);

            if ((Student_nationalitaet != 0) && (Student_studiengang != 0) && ((res == true) && (result == true)))
            {

                StudentData studentData1 = new StudentData
                {
                    Vorname = VornameTextbox.Text.Trim(),
                    Name = NameTextbox.Text.Trim(),
                    Nationalitaet = Student_nationalitaet,
                    Bachelor = Student_studiengang,
                    Geschlecht = geschlecht,
                    Student_Note = AbschlussNote,
                    NoteVorlaefig = check_NoteVorläufing,
                    Creditpunkte = CP
                };

                string query = "Update  tab_person set [txtVorname] = '" + studentData1.Vorname + "'  ,[txtName] = '" + studentData1.Name + "', " +
                    "[txtGeschlecht] = '" + studentData1.Geschlecht + "', [intNationalität] = '" + studentData1.Nationalitaet + "'," +
                    " [intBachelor] = '" + studentData1.Bachelor + "', [dblNote] = '" + studentData1.Student_Note + "'," +
                    " [blnNoteVorläufig] = '" + studentData1.NoteVorlaefig + "', [intCP] = '" + studentData1.Creditpunkte + "'  where ID = " + IdStudent + "";
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
                    response = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);

                }
            }
            return response;
        }

        public bool EditInformationBewerbung()
        {
            bool response1 = false;
            if (EditInformationStudent(bewerbungsdata.StudentID) == true)
            {
                int check_Prof;
                int check_Verwaltung;
                int check_Angenommen;

                if (AnProfcheckBox.Checked == true)
                {
                    check_Prof = 1;
                }
                else
                {
                    check_Prof = 0;
                }

                if (AngenommencheckBox.Checked == true)
                {
                    check_Angenommen = 1;
                }
                else
                {
                    check_Angenommen = 0;
                }

                if (AnHa41checkBox.Checked == true)
                {
                    check_Verwaltung = 1;
                }
                else
                {
                    check_Verwaltung = 0;
                }
                config = XmlDataManager.XmlConfigDataReader("configs.xml");



                int Student_nationalitaet = Search_NationalitaetID(NationalitaetcomboBox.Text.Trim());
                int Studenten_ID = Search_ID_Student(NameTextbox.Text.Trim());
                int MasterstudiengangID = Search_ID_Masterstudiengang(MasterstudiengangcomboBox.Text.Trim());
                int MasterstudiengangID2 = Search_ID_Masterstudiengang(MasterstudiengangcomboBox2.Text.Trim());
                int MasterstudiengangID3 = Search_ID_Masterstudiengang(MasterstudiengangcomboBox3.Text.Trim());
                int Studenten_SemesterID = Search_ID_Smester(SemestercomboBox.Text.Trim());

                if ((Student_nationalitaet != 0) && (Studenten_ID != 0) && (MasterstudiengangID != 0) && (MasterstudiengangID2 != 0) && (MasterstudiengangID3 != 0) && (Studenten_SemesterID != 0))
                {
                    Bewerbungsdata bewerbungsdata1 = new Bewerbungsdata
                    {
                        StudentID = Studenten_ID,
                        Master_StudiengangID = MasterstudiengangID,
                        Master_StudiengangID2 = MasterstudiengangID2,
                        Master_StudiengangID3 = MasterstudiengangID3,
                        SemesterID = Studenten_SemesterID,
                        Comment1 = ZusatztextBox.Text.Trim(),
                        Comment2 = AblehnungsgrungtextBox.Text.Trim(),
                        Comment3 = KommentartextBox.Text.Trim(),
                        Prof = check_Prof,
                        Verwaltung = check_Verwaltung,
                        Angenommen = check_Angenommen

                    };




                    string query = "Update  tab_bewerbung set [intPerson] = '" + bewerbungsdata.StudentID + "'  ,[intMasterstudiengang] = '" + bewerbungsdata1.Master_StudiengangID + "',[intMasterstudiengang2] = '" + bewerbungsdata1.Master_StudiengangID2 + "',[intMasterstudiengang3] = '" + bewerbungsdata1.Master_StudiengangID3 + "', " +
                    "[intSemester] = '" + bewerbungsdata1.SemesterID + "', [txtKommentar1] = '" + bewerbungsdata1.Comment1 + "'," +
                    " [txtKommentar2] = '" + bewerbungsdata1.Comment2 + "', [txtKommentar3] = '" + bewerbungsdata1.Comment3 + "'," +
                    " [blnProf] = '" + bewerbungsdata1.Prof + "', [blnVerwaltung] = '" + bewerbungsdata1.Verwaltung + "' , [blnAngenommen] = '" + bewerbungsdata1.Angenommen + "'  where ID = " + bewerbungsID + "";
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
                        MessageBox.Show("Data mit IdNummer " + bewerbungsID + " was edited Successful!");
                        UserConnection.Close();
                        response1 = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex);
                    }
                }
            }

            return response1;
        }

        private void SpeicherBtn_Click(object sender, EventArgs e)
        {
            UserData user = new UserData();
            SuperUserData superUser = new SuperUserData();
            if (File.Exists("userData.xml"))
            {
                user = XmlDataManager.XmlUserDataReader("userData.xml");
            }

            if ((user.UserAttribut != "SuperAdmin") && databaseManager.Test_Connection_User(benutzer_Name))
            {


                if (VornameTextbox.Text.Trim() != string.Empty && NameTextbox.Text.Trim() != string.Empty && NationalitaetcomboBox.Text.Trim() != string.Empty && studienlandcomboBox.Text.Trim() != string.Empty
                  && HochschulecomboBox.Text.Trim() != string.Empty && StudiengangcomboBox.Text.Trim() != string.Empty && AbschlussnotetextBox.Text.Trim() != string.Empty
                  && ErworbeneCPtextBox.Text.Trim() != string.Empty && MasterstudiengangcomboBox.Text.Trim() != string.Empty && SemestercomboBox.Text.Trim() != string.Empty && (MannlichRadioButton.Checked != false && WeiblichRadioButton.Checked == false)
                  || (MannlichRadioButton.Checked == false && WeiblichRadioButton.Checked != false))
                {


                    if (EditInformationBewerbung() == true)
                    {

                        this.Close();
                        BewerbungUI bewerbungUI = new BewerbungUI();
                        bewerbungUI.Show();
                    }
                    else
                    {
                        MessageBox.Show(" Data can not be edit, Please check the student'daten!");
                    }

                }
                else
                {
                    MessageBox.Show("Please fill all the field!");
                }

            }
            else if (File.Exists("SuperUserStatut.xml"))
            {
                superUser = XmlDataManager.XmlSuperUserDataReader("SuperUserStatut.xml");
            }

            if (superUser.SuperUserstatut == 1)
            {
                if (VornameTextbox.Text.Trim() != string.Empty && NameTextbox.Text.Trim() != string.Empty && NationalitaetcomboBox.Text.Trim() != string.Empty && studienlandcomboBox.Text.Trim() != string.Empty
                  && HochschulecomboBox.Text.Trim() != string.Empty && StudiengangcomboBox.Text.Trim() != string.Empty && AbschlussnotetextBox.Text.Trim() != string.Empty
                  && ErworbeneCPtextBox.Text.Trim() != string.Empty && MasterstudiengangcomboBox.Text.Trim() != string.Empty && SemestercomboBox.Text.Trim() != string.Empty && (MannlichRadioButton.Checked != false && WeiblichRadioButton.Checked == false)
                  || (MannlichRadioButton.Checked == false && WeiblichRadioButton.Checked != false))
                {
                    if (EditInformationBewerbung() == true)
                    {

                        this.Close();
                        BewerbungUI bewerbungUI = new BewerbungUI();
                        bewerbungUI.Show();
                    }
                    else
                    {
                        MessageBox.Show(" Data can not be edit, Please check the student'daten!");
                    }
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

        private void AbbrechenBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            BewerbungUI bewerbungUI = new BewerbungUI();
            bewerbungUI.Show();

        }
    }

}
