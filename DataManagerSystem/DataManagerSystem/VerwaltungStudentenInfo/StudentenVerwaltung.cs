using DataManagerSystem.Configs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataManagerSystem.VerwaltungStudentenInfo
{
    public class StudentenVerwaltung
    {
        public ConfigData config = new ConfigData();
        //List<StudiengaangAndNote> listeFach = new List<StudiengaangAndNote>();
       List<FehlendeCPInfo> listeFehlCP = new List<FehlendeCPInfo>();
        StudiengaangAndNote[] listeFach = new StudiengaangAndNote[10];
        //FehlendeCPInfo[] listeFehlCP = new FehlendeCPInfo[10];
        // return the nationality 
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

        // function to search a Semester in database
        public string Search_ID_Smester(int SemesterID)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtSemester FROM tab_semester where Id = " + SemesterID + "";

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
                string resultat = reader["txtSemester"].ToString();
                UserConnection1.Close();
                return resultat;


            }

            else
            {
                UserConnection1.Close();
                return null;
            }
        }



        // Anzeige der Informationen des Studenten
        public void ShowStudentenInfo(DataGridView grid, int BewerbungsID)
        {
            try
            {
                /*t.txtTitel AS Titel, tab_titel AS t, WHERE t.ID = b.intTitel */
                config = XmlDataManager.XmlConfigDataReader("configs.xml");
                string query1 = "SELECT t.intBewerbung AS BewerbungsID, t.Masterstudiengang_1 AS Masterstudiengang_1, t.Masterstudiengang_2 AS Masterstudiengang_2, t.Masterstudiengang_3 AS Masterstudiengang_3, t.datDatum AS Datum, t.txtBenutzer AS txtBenutzer" +
                                "FROM tab_status AS t WHERE t.intBewerbung = " + BewerbungsID + "";

                string query = "SELECT intBewerbung AS BewerbungID, Masterstudiengang_1 AS Masterstudiengang1, Masterstudiengang_2 AS Masterstudiengang2, Masterstudiengang_3 AS Masterstudiengang3, datDatum AS Datum, txtBenutzer AS Benutzer " +
                                "FROM tab_status AS t WHERE t.intBewerbung = " + BewerbungsID + "";

                

                OleDbConnection UserConnection = new OleDbConnection();
                UserConnection.ConnectionString = config.DbConnectionString;

                UserConnection.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = UserConnection;
                cmd.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid.DataSource = dt;

                UserConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        // Noten Suchen
        public StudiengaangAndNote[] ShowStudiengangNoten(string MastStudiengang)
        {
              
                
                 config = XmlDataManager.XmlConfigDataReader("configs.xml");
                 int ID = ShowMasterstudiengangID(MastStudiengang);

                string query = "SELECT t.ID, t.intStudiengang, t.intCP, t.txtFach FROM tab_cpdelta AS t WHERE t.intStudiengang = " + ID + "";

                OleDbConnection UserConnection1 = new OleDbConnection();
                UserConnection1.ConnectionString = config.DbConnectionString;
                UserConnection1.Open();
                OleDbCommand cmd1 = new OleDbCommand();
                cmd1.Connection = UserConnection1;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = query;
                OleDbDataReader reader = cmd1.ExecuteReader();
            int z = 0;
            while (reader.Read() && z < 10)
            {
                StudiengaangAndNote studiengaangAndNote = new StudiengaangAndNote();
                string Fach = reader["txtFach"].ToString();
                studiengaangAndNote.Fach = Fach;
                string studiengangID = reader["intStudiengang"].ToString();
                int StudiengangID = Convert.ToInt32(studiengangID);
                studiengaangAndNote.StudiengangID = StudiengangID;
                string Fachid = reader["ID"].ToString();
                int FachID = Convert.ToInt32(Fachid);
                studiengaangAndNote.FachID = FachID;
                string intCP = reader["intCP"].ToString();
                int IntCP = Convert.ToInt32(intCP);
                studiengaangAndNote.IntCP = IntCP;
                //listeFach.Add(studiengaangAndNote);
                listeFach[z] = studiengaangAndNote;
                z++;
            }
            UserConnection1.Close();

            return listeFach;
        }

        //  MasterstudiengangID anzeigen
        public int ShowMasterstudiengangID(string Studiengang)
        {
            
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT ID FROM tab_masterstudiengang where txtName = '" + Studiengang + "'";

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
                return 0;
            }
        }

        // Check if  the BewerbungIDin tab_fehltcp exist
        public bool Search_BewerbungID_in_tab_FehlCP(int bewerbungsID)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            int count = 0;

            OleDbConnection LoginConnection = new OleDbConnection();
            LoginConnection.ConnectionString = config.DbConnectionString;
            LoginConnection.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = LoginConnection;
            cmd.CommandText = "SELECT intBewerbung FROM tab_fehlcp where intBewerbung = " + bewerbungsID + " ";
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                count++;
            }

            LoginConnection.Close();

            // Test if the given username exists in the database
            if (count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Noten Suchen
        public FehlendeCPInfo ShowFehlendeCI(string MastStudiengang, int Deltacp)
        {
            int bewerbungsID = ShowMasterstudiengangID(MastStudiengang);
            FehlendeCPInfo fehlendeCPInfo = new FehlendeCPInfo();
            fehlendeCPInfo.IntCPdelta = 1;
            config = XmlDataManager.XmlConfigDataReader("configs.xml");

            string query = "SELECT t.intCPdelta, t.intWert, t.intBewerbung, t.blnErfüllt  FROM tab_fehlcp AS t WHERE t.intBewerbung = " + bewerbungsID + " AND t.intCPdelta = " + Deltacp + "";

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

                string intCPDelta = reader["intCPdelta"].ToString();
                string fehlCP = reader["intWert"].ToString();
                string intBewerbung = reader["intBewerbung"].ToString();
                string erfuelle = reader["blnErfüllt"].ToString();
                UserConnection1.Close();

                int IntCPDelta = Convert.ToInt32(intCPDelta);
                int FehlCP = Convert.ToInt32(fehlCP);
                int IntBewerbung = Convert.ToInt32(intBewerbung);
                bool Erfuelle = Convert.ToBoolean(erfuelle);


                fehlendeCPInfo.IntCPdelta = IntCPDelta;
                fehlendeCPInfo.FehlCP = FehlCP;
                fehlendeCPInfo.IntBewerbungID = IntBewerbung;
                fehlendeCPInfo.Erfuelle = Erfuelle;

                return fehlendeCPInfo;
            }
            else
            {
                return fehlendeCPInfo;
            }


        }

        // Function to Add fehlendeCP when bewerbungsID doesn't exist and to update it when this exist  
        public void AddNotenInTab_fehCP(int bewerbungid, int i, FehlendeCPInfo[] listeFehlCP)
        {
            // check if the BewerbungsID already exist and return true
            bool response = Search_BewerbungID_in_tab_FehlCP(bewerbungid);
            if (response == true)
            {
                if (listeFehlCP[i].FehlCP != 0)
                {
                  
                    config = XmlDataManager.XmlConfigDataReader("configs.xml");
                    string query = "Update  tab_fehlcp set [intWert] = '" + listeFehlCP[i].FehlCP + "' where intCPdelta = " + listeFehlCP[i].IntCPdelta + " and intBewerbung = " + listeFehlCP[i].IntBewerbungID + " ";
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
                        MessageBox.Show("Data Edit Successful");
                        UserConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex);
                    }
                }
                else
                {
                    config = XmlDataManager.XmlConfigDataReader("configs.xml");
                    string query = "Update  tab_fehlcp set [intWert] = '" + listeFehlCP[i].FehlCP + "', [blnErfüllt] = '" + 1 + "'   where intCPdelta = " + listeFehlCP[i].IntCPdelta + " and intBewerbung = " + listeFehlCP[i].IntBewerbungID + " ";
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
                        MessageBox.Show("Data Edit Successful");
                        UserConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex);
                    }
                }
               
            }
            else
            {
                int valueOfErfuellt = 0;
                config = XmlDataManager.XmlConfigDataReader("configs.xml");
                if (listeFehlCP[i].FehlCP == 0)
                {
                    valueOfErfuellt = 1;
                }
                string query = "insert into  tab_fehlcp ([intCPdelta],[intWert],[intBewerbung],[blnErfüllt]) values ('" + listeFehlCP[i].IntCPdelta + "','" + listeFehlCP[i].FehlCP + "','" + listeFehlCP[i].IntBewerbungID + "','" + valueOfErfuellt + "')";
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


        }

    }
}
