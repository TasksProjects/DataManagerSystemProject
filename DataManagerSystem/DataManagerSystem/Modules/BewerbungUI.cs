using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using DataManagerSystem.Configs;

namespace DataManagerSystem.Modules
{
    public partial class BewerbungUI : Form
    {
        int bewerbungsnummer;
        string BewerbungsNationalitaet;
        string BewerbungsBachelor;
        StudentData studentData = new StudentData();
        Bewerbungsdata bewerbungsdata = new Bewerbungsdata();
        private ConfigData config = new ConfigData();

        public BewerbungUI()
        {
            InitializeComponent();
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
        }

        private void BewerbungUI_Load(object sender, EventArgs e)
        {
            Show_Database();
        }

        private void Show_Database()
        {
            try
            {
                OleDbConnection UserConnection = new OleDbConnection();
                UserConnection.ConnectionString = config.DbConnectionString;

                UserConnection.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = UserConnection;


                string query = "SELECT b.ID AS BewerbungsNummer, a.txtVorname AS Vorname, a.txtName AS Name, a.txtGeschlecht AS Geschlecht," +
                    " l.txtNationalität AS Nationalität, s.txtName AS Bachelorstudiengang, m.txtName AS Masterstudiengang, w.txtSemester AS Semester," +
                    " a.dblNote AS Abschlussnote, a.intCP AS Erworbene_CP, b.txtKommentar1 AS Zusatz, b.txtKommentar2 AS Ablehnungsgrung," +
                    " b.txtKommentar3 AS Kommentare, a.blnNoteVorläufig AS Note_Vorläufig, b.blnProf AS An_Prof , b.blnVerwaltung AS Ha_4_1," +
                    " b.blnAngenommen As Angenommen" +
                    " FROM tab_person AS a, tab_bewerbung AS b, tab_land AS l, tab_studiengang AS s, tab_masterstudiengang AS m, tab_semester AS w" +
                    " WHERE a.ID = b.intPerson AND l.ID = a.intNationalität AND s.ID = a.intBachelor AND m.ID = b.intMasterstudiengang AND w.ID = b.intSemester";





                cmd.CommandText = query;



                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView.DataSource = dt;

                UserConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            int id;
            bool result = int.TryParse(BewerbungsnummerTextBox.Text.Trim(), out id);
            if(result == true)
            {
                bewerbungsnummer = id;
                SearchStudentenWithBewerbungID(bewerbungsnummer);
               // EditPerson editPerson(bewerbungsnummer, sewerbungsdata, studentData);
            }
            else
            {
                MessageBox.Show("Bewerbungsnummer doesn't exist!");
            }
            


        }

        public bool SearchBewerbungId(int idBewerbung)
        {
            bool resultat = false;
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            int bewerbungID = idBewerbung;
            
           
                string query = "SELECT ID, intPerson, intMasterstudiengang, intSemester, blnProf, blnVerwltung, blnAngenommen" +
                        "FROM tab_bewerbung" +
                        "WHERE ID = bewerbungID";

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
                    string ID = reader["ID"].ToString();
                    string IntPerson = reader["intPerson"].ToString();
                    string IntMasterstudiengang = reader["intMasterstudiengang"].ToString();
                    string IntSemester = reader["intSemester"].ToString();
                    string BoolAnProf = reader["blnProf"].ToString();
                    string BoolAnHA_4_1 = reader["blnVerwaltung"].ToString();
                    string BoolAngenommen = reader["blnAngenommen"].ToString();
                    UserConnection1.Close();
                    int id = Convert.ToInt32(ID);
                    int idPerson = Convert.ToInt32(IntPerson);
                    int intMasterstudiengang = Convert.ToInt32(IntMasterstudiengang);
                    int intSemester = Convert.ToInt32(IntSemester);
                    bool boolAnprof = Convert.ToBoolean(BoolAnProf);
                    bool boolAnA_4_1 = Convert.ToBoolean(BoolAnHA_4_1);
                    bool boolAngenommen = Convert.ToBoolean(BoolAngenommen);

                    bewerbungsdata.StudentID = idPerson;
                    bewerbungsdata.Master_StudiengangID = intMasterstudiengang;
                    bewerbungsdata.SemesterID = intSemester;
                    if(boolAnprof == false)
                    {
                        bewerbungsdata.Prof = 0;
                    }
                    else
                    {
                        bewerbungsdata.Prof = 1;
                    }
                    if (boolAnA_4_1 == false)
                    {
                        bewerbungsdata.Verwaltung = 0;
                    }
                    else
                    {
                        bewerbungsdata.Verwaltung = 1;
                    }
                    if (boolAngenommen == false)
                    {
                        bewerbungsdata.Angenommen = 0;
                    }
                    else
                    {
                        bewerbungsdata.Angenommen = 1;
                    }

                    resultat = true;
                }
                else
                {
                    UserConnection1.Close();
                }
            
                return resultat ;
        }


        public void SearchStudentenWithBewerbungID(int idNummer)
        {
            if (SearchBewerbungId(idNummer) == true)
            {
                config = XmlDataManager.XmlConfigDataReader("configs.xml");
                int Bewerbungsnummer = bewerbungsdata.StudentID;

                string query = "SELECT a.ID, a.txtVorname, a.txtName, a.txtGeschlecht, a.dblNote, a.blnNoteVorläufig," +
                    " a.intCP, b.txtNationalität, c.txtName" +
                        "FROM tab_person AS a, tab_land As b, tab_studiengang AS c" +
                        "WHERE b.ID = a.intNationalität AND c.ID = a.intBachelor";

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
                    string ID = reader["a.ID"].ToString();
                    string Vorname = reader["a.txtVorname"].ToString();
                    string Name = reader["a.txtName"].ToString();
                    BewerbungsNationalitaet = reader["b.txtNationalität"].ToString();
                    string Geschlecht = reader["a.txtGeschlecht"].ToString();
                    BewerbungsBachelor = reader["c.txtName"].ToString();
                    string DoubleNote = reader["a.dblNote"].ToString();
                    string BoolNoteVorläufig = reader["a.blnNoteVorläufig"].ToString();
                    string IntCP = reader["a.intCP"].ToString();
                   
                    UserConnection1.Close();

                    int id = Convert.ToInt32(ID);
                    double doubleNote = Convert.ToDouble(DoubleNote);
                    bool boolNoteVorläufig = Convert.ToBoolean(BoolNoteVorläufig);
                    int intCP = Convert.ToInt32(IntCP);
                    int IntNationalität = Convert.ToInt32(BewerbungsNationalitaet);
                    int IntBachelor = Convert.ToInt32(BewerbungsBachelor);


                    studentData.Vorname = Vorname;
                    studentData.Name = Name;
                    studentData.Geschlecht = Geschlecht;
                    studentData.Nationalitaet = IntNationalität ;
                    studentData.Bachelor = IntBachelor;
                    studentData.Student_Note = doubleNote;
                    studentData.Creditpunkte = intCP;

                    if (boolNoteVorläufig == false)
                    {
                        studentData.NoteVorlaefig = 0;
                    }
                    else
                    {
                        studentData.NoteVorlaefig = 1;
                    }
                }
                else
                {
                    UserConnection1.Close();
                }



            }
            
            
           
        }

    }
}
