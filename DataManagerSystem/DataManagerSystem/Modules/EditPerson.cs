﻿using DataManagerSystem.Configs;
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
        private ConfigData config = new ConfigData();
        DatabaseManager databaseManager = new DatabaseManager();
        string[] studentenInfo = new string[5];
        string Nationalitaet;
        string Bachelor;
        string benutzer_Name;
        string geschlecht;

        public EditPerson(int ID, Bewerbungsdata bewerbung)
        {
            /* InitializeComponent();
             bewerbungsID = ID;
             bewerbungsdata = bewerbung;
             //studentData = student;
             //studentenInfo = information;
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
             AutoCompleteText_Semester();*/
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
             
         }

         private void HochschuleHinzufügenBtn_Click(object sender, System.EventArgs e)
         {
             
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

         private void AbbrechenBtn_Click(object sender, EventArgs e)
         {
             this.Close();
             BewerbungUI bewerbungUI = new BewerbungUI();
             bewerbungUI.Show();

         }

        private void NationalitaetHinzufügenBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
