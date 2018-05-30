using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using DataManagerSystem.Verwaltungsbetreuer;
using System.Windows.Forms;
using DataManagerSystem.Configs;
using System.Data.OleDb;

namespace DataManagerSystem.Modules
{
    public partial class AddBetreuer : Form
    {
        VerwaltungVonBetreuer verwaltungVonBetreuer = new VerwaltungVonBetreuer();
        public ConfigData config = new ConfigData();
        public AddBetreuer()
        {
            InitializeComponent();
            Load_Titel_Database();
        }

        private void Schlißen_Click(object sender, EventArgs e)
        {
            UebersichtBetreuer uebersichtBetreuer = new UebersichtBetreuer();
            uebersichtBetreuer.Show();
            this.Close();
        }

 

        // fill the ComboBox Titel with Database
        private void Load_Titel_Database()
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtTitel FROM tab_titel";

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
                string Titel = reader["txtTitel"].ToString();
                TitelComboBox.Items.Add(Titel);
            }
            UserConnection1.Close();
        }

        private void BetreuerHinzufuegen_Click(object sender, EventArgs e)
        {
            int BetreuerID = verwaltungVonBetreuer.ReturnTitelID(TitelComboBox.Text.Trim());
            verwaltungVonBetreuer.AddBetreuer(VornameTextBox.Text.Trim(),NameTextBox.Text.Trim(),MailTextbox.Text.Trim(),BetreuerID,TelefonnummerTextbox.Text.Trim());
            UebersichtBetreuer uebersichtBetreuer = new UebersichtBetreuer();
            uebersichtBetreuer.Show();
            this.Close();
        }

    }
}
