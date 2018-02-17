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
       

        public NewStudentUI()
        {
            
            InitializeComponent();
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
            StudiengangUI studiengangUI = new StudiengangUI(StudiengangCB.Text);
            studiengangUI.Show();
        }

        private void AddHochschuleBtn_Click(object sender, EventArgs e)
        {
            Add_Hochschule add_Hochschule = new Add_Hochschule(HochshuleCB.Text);
            add_Hochschule.Show();

        }

        private void AddNationalitaetBtn_Click(object sender, EventArgs e)
        {
            Add_Land add_Land = new Add_Land(NationalityTB.Text);
            add_Land.Show();
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

       //Function to save Student's information
        public void Add_New_Student()
        {
            int check_NoteVorläufing;
            config = XmlDataManager.XmlConfigDataReader("configs.xml");

            if (NoteVorläufingCheckBox.Checked == true)
            {
                check_NoteVorläufing = 1;
            }
            else
            {
                check_NoteVorläufing = 0;
            }
           
            int BachelorNummer = 50;
            int Student_nationalitaet = Search_NationalitaetID(NationalityTB.Text.Trim());
            StudentData studentData = new StudentData
            {
                Vorname = FirstnameTB.Text,
                Name = NameTB.Text,
                Nationalitaet = Student_nationalitaet,
                Bachelor = BachelorNummer,
                Student_Note = Convert.ToDouble(AbschlussnoteTB.Text),
                NoteVorlaefig = check_NoteVorläufing,
                Creditpunkte = Convert.ToInt32(CpTB.Text)
            };

            string query = "insert into  tab_person([txtVorname],[txtName],[intNationalität],[intBachelor],[dblNote],[blnNoteVorläufig],[intCP])" +
                         " values ('" + studentData.Vorname + "','" + studentData.Name + "','" + studentData.Nationalitaet + "'," +
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
            int STudenten_SemesterID = Search_ID_Smester(SemesterCB.Text.Trim());

            Bewerbungsdata bewerbungsdata = new Bewerbungsdata
            {
                StudentID = Studenten_ID,
                Master_StudiengangID = MasterstudiengangID,
                SemesterID = STudenten_SemesterID,
                Comment1 = ZusatzTB.Text,
                Comment2 = AblehnungsgrundTB.Text,
                Comment3 = KommentarTB.Text,
                Prof = check_Prof,
                Verwaltung = check_Verwaltung,
                Angenommen = check_Angenommen
                
            };

            string query = "insert into  tab_bewerbung([intPerson],[intMasterstudiengang],[intSemester],[txtKommentar1],[txtKommentar2],[txtKommentar3],[blnProf],[blnVerwaltung],[blnAngenommen])" +
                         " values ('" + bewerbungsdata.StudentID + "','" + bewerbungsdata.Master_StudiengangID + "','" + bewerbungsdata.SemesterID + "'," +
                         "'" +  bewerbungsdata.Comment1 + "','" + bewerbungsdata.Comment2 + "', '" + bewerbungsdata.Comment3 + "', '" +check_Prof  + "', '" + check_Verwaltung + "', '" + check_Angenommen + "')";
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

        private void CanceledBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Add_New_Student();
            Add_New_Bewerbung();
            this.Close();

        }

       

        
    }
}
