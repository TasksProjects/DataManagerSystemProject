using DataManagerSystem.Configs;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DataManagerSystem.Verwaltungsbetreuer
{
    public class VerwaltungVonBetreuer
    {
        public ConfigData config = new ConfigData();

        // Anzeige der nformationen des Betreuer
        public void ShowBetreuerInfo(DataGridView grid)
        {
            try
            {
                /*t.txtTitel AS Titel, tab_titel AS t, WHERE t.ID = b.intTitel */
                config = XmlDataManager.XmlConfigDataReader("configs.xml");
                string query = "SELECT b.ID AS BetreuerID, t.txtTitel AS Titel, b.txtVorname AS Vorname, b.txtName AS Name, b.txtMail AS AdresseMail, b.txtTelefon AS Telefonnumer " +
                                "FROM tab_titel AS t, tab_betreuer AS b WHERE t.ID = b.intTitel";
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



        // Function to add UserData in the database
        public void AddBetreuer(string Vorname, string Name, string Email, int Titel, string Telefonnummer)
        {
                config = XmlDataManager.XmlConfigDataReader("configs.xml");

                string query = "insert into  tab_betreuer ([txtVorname],[txtName],[txtMail],[intTitel],[txtTelefon]) " +
                               "values ('" + Vorname + "','" + Name + "','" + Email + "','" + Titel + "','" + Telefonnummer + "')";
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

        // Return the Titel ID from tab_titel 
        public int ReturnTitelID(string titel)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT ID FROM tab_titel where txtTitel = '" + titel + "' ";

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

        // Function to remove Betreuer from the tab_betreuer
        public void RemoveUser(int id)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");

            string query = "delete from  tab_betreuer  where ID = " + id + "";
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
                MessageBox.Show("Data Removed Successful");
                UserConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

    }
}
