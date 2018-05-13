using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using DataManagerSystem.Configs;

namespace DataManagerSystem.Modules
{
    public partial class BewerbungUI : Form
    {
        int bewerbungID;
        Bewerbungsdata bewerbungsdata;
        private ConfigData config = new ConfigData();

        public BewerbungUI()
        {
            InitializeComponent();
            bewerbungsdata = new Bewerbungsdata();
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

                 string query = "SELECT b.ID AS BewerbungID, a.txtVorname AS Vorname, a.txtName AS Name, a.txtGeschlecht AS Geschlecht," +
                     " l.txtNationalität AS Nationalität, s.txtName AS Bachelorstudiengang, m.txtName AS Masterstudiengang1, p.txtName AS Masterstudiengang2, q.txtName AS Masterstudiengang3, w.txtSemester AS Semester," +
                     " a.dblNote AS Abschlussnote, a.intCP AS Erworbene_CP, b.txtKommentar1 AS Zusatz, b.txtKommentar2 AS Ablehnungsgrund," +
                     " b.txtKommentar3 AS Kommentare, a.blnNoteVorläufig AS Note_Vorläufig, b.blnProf AS An_Prof , b.blnVerwaltung AS Ha_4_1," +
                     " b.blnAngenommen As Angenommen" +
                     " FROM tab_person AS a, tab_bewerbung AS b, tab_land AS l, tab_studiengang AS s, tab_masterstudiengang AS m, tab_masterstudiengang AS p, tab_masterstudiengang AS q, tab_semester AS w" +
                     " WHERE a.ID = b.intPerson AND l.ID = a.intNationalität AND s.ID = a.intBachelor AND m.ID = b.intMasterstudiengang AND w.ID = b.intSemester AND p.ID = b.intMasterstudiengang2 AND q.ID = b.intMasterstudiengang3";
                               
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

        public void GetBewerbungDataFromDataView(DataGridViewRow row)
        {
            bewerbungsdata.Vorname = row.Cells["Vorname"].Value.ToString();
            bewerbungsdata.Name = row.Cells["Name"].Value.ToString();
            bewerbungsdata.Geschlecht = row.Cells["Geschlecht"].Value.ToString();
            bewerbungsdata.Nationalitaet = row.Cells["Nationalität"].Value.ToString();
            bewerbungsdata.Bachelor = row.Cells["Bachelorstudiengang"].Value.ToString();
            bewerbungsdata.Masterstudiengang = row.Cells["Masterstudiengang1"].Value.ToString();
            bewerbungsdata.Masterstudiengang_2 = row.Cells["Masterstudiengang2"].Value.ToString();
            bewerbungsdata.Masterstudiengang_3 = row.Cells["Masterstudiengang3"].Value.ToString();
            bewerbungsdata.Semester = row.Cells["Semester"].Value.ToString();
            bewerbungsdata.Student_Note = row.Cells["Abschlussnote"].Value.ToString();
            bewerbungsdata.Creditpunkte = row.Cells["Erworbene_CP"].Value.ToString();
            bewerbungsdata.Zusatz = row.Cells["Zusatz"].Value.ToString();
            bewerbungsdata.Ablehnungsgrund = row.Cells["Ablehnungsgrund"].Value.ToString();
            bewerbungsdata.Comment = row.Cells["Kommentare"].Value.ToString();
            bewerbungsdata.NoteVorlaeufig = (bool)row.Cells["Note_Vorläufig"].Value;
            bewerbungsdata.Prof = (bool)row.Cells["An_Prof"].Value;
            bewerbungsdata.Verwaltung = (bool)row.Cells["Ha_4_1"].Value;
            bewerbungsdata.Angenommen = (bool)row.Cells["Angenommen"].Value;
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (BewerbungIDTextBox.Text.Trim() != string.Empty)
            {
                EditPerson editPerson = new EditPerson(bewerbungID, bewerbungsdata);
                editPerson.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No Cell Selected!");
            }
        }
        
        /*public bool SearchBewerbungId(int idBewerbung)
        {
            bool resultat = false;
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            int bewerbungID = idBewerbung;

            string query = "SELECT a.ID AS IDs, a.intPerson AS intPerson, b.txtName As Masterstudiengang, c.txtSemester AS Semester, a.blnProf AS blnProf, a.blnVerwaltung As blnVerwaltung, a.blnAngenommen AS blnAngenommen FROM tab_bewerbung AS a, tab_masterstudiengang AS b, tab_semester AS c WHERE b.ID = a.intMasterstudiengang AND c.ID = a.intSemester AND a.ID = " +bewerbungID+ ""; 

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
                    string ID = reader["IDs"].ToString();

                    string IntPerson = reader["intPerson"].ToString();
                    string Masterstudiengang = reader["Masterstudiengang"].ToString();
                    string Semester = reader["Semester"].ToString();
                    string BoolAnProf = reader["blnProf"].ToString();
                    string BoolAnHA_4_1 = reader["blnVerwaltung"].ToString();
                    string BoolAngenommen = reader["blnAngenommen"].ToString();
                UserConnection1.Close(); 
                int id = Convert.ToInt32(ID);
                Console.WriteLine(ID);


                int idPerson = Convert.ToInt32(IntPerson);
                StudentInfo[0] = Masterstudiengang;
                StudentInfo[1] = Semester;

                int intMasterstudiengang; ;
                bool result = int.TryParse(Masterstudiengang, out intMasterstudiengang);
                int intSemester;
                bool result1= int.TryParse(Semester, out intSemester);
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

                string query = "SELECT a.ID AS ID, a.txtVorname AS Vorname, a.txtName, a.txtGeschlecht AS Geschlecht, a.dblNote AS AbschlussNote, a.blnNoteVorläufig AS NoteVorläufig, a.intCP AS CreditPunkt, b.txtNationalität AS Nationalitaet, c.txtName FROM tab_person AS a, tab_land As b, tab_studiengang AS c WHERE a.ID = " + Bewerbungsnummer + " AND b.ID = a.intNationalität AND c.ID = a.intBachelor";

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
                    string Vorname = reader["Vorname"].ToString();
                    string Name = reader["a.txtName"].ToString();
                    BewerbungsNationalitaet = reader["Nationalitaet"].ToString();
                    string Geschlecht = reader["Geschlecht"].ToString();
                    BewerbungsBachelor = reader["c.txtName"].ToString();
                    string DoubleNote = reader["AbschlussNote"].ToString();
                    string BoolNoteVorläufig = reader["NoteVorläufig"].ToString();
                    string IntCP = reader["CreditPunkt"].ToString();
                    StudentInfo[2] = BewerbungsNationalitaet;
                    StudentInfo[3] = BewerbungsBachelor;

                    UserConnection1.Close();

                    // int id = Convert.ToInt32(ID);
                    double doubleNote = Convert.ToDouble(DoubleNote);
                    bool boolNoteVorläufig = Convert.ToBoolean(BoolNoteVorläufig);

                    int intCP = Convert.ToInt32 (IntCP);
                    bool result1 = int.TryParse(IntCP, out intCP);
                    int IntNationalität;
                    bool result = int.TryParse(BewerbungsNationalitaet, out IntNationalität);
                    int IntBachelor;
                    bool resulte = int.TryParse(BewerbungsBachelor, out IntBachelor);

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

                    EditPerson editPerson = new EditPerson(bewerbungID, StudentInfo, bewerbungsdata, studentData);
                    editPerson.Show();
                    this.Close();
                }
                else
                {
                    UserConnection1.Close();
                }
            }
            else
            {
                MessageBox.Show("Bewerbungsnummer doesn't exist!");
            }     
        }
      */

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (BewerbungIDTextBox.Text.Trim() != string.Empty)
            {
                DialogResult dialogResult = MessageBox.Show("Do you really want to remove Registration with nummer " + bewerbungID + " ", "Confirm Remove Registration", MessageBoxButtons.YesNo);
                if ((dialogResult == DialogResult.Yes) && RemoveBewerbung(bewerbungID) && RemoveStudent(bewerbungsdata.StudentID))
                {
                    MessageBox.Show("Bewerbung  Removed Successful!");
                    BewerbungIDTextBox.Text = "";
                    Show_Database();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Show_Database();
                }
            }
            else
            {
                MessageBox.Show("No Cell Selected!");
            }               
        }

        public bool RemoveBewerbung(int bewerbungsnummer)
        {
            bool resp = false;
            config = XmlDataManager.XmlConfigDataReader("configs.xml");

            string query = "delete from  tab_bewerbung  where ID = " + bewerbungsnummer + "";
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
                resp = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            return resp;
        }

        public bool RemoveStudent(int IDStudent)
        {
            bool resp = false;
            config = XmlDataManager.XmlConfigDataReader("configs.xml");

            string query = "delete from  tab_person  where ID = " + IDStudent + "";
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
                resp = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            return resp;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView.Rows[e.RowIndex];
                bewerbungID = (int)row.Cells["BewerbungID"].Value;
                BewerbungIDTextBox.Text = bewerbungID.ToString();
                GetBewerbungDataFromDataView(row);
                //BewerbungIDTextBox.Text = bewerbungsdata.Angenommen.ToString();
            }
        }
    }
}
