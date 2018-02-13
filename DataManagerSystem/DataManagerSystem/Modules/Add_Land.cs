using DataManagerSystem.Configs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class Add_Land : Form
    {
        private ConfigData config = new ConfigData();

        public Add_Land(String NameLand)
        {
            InitializeComponent();
            LandTextBox.Text = NameLand;
        }

        public Add_Land()
        {
        }

        public void AddLand()
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "insert into  tab_land ([txtName],[txtNationalität])" +
                          " values ('" + LandTextBox.Text.Trim() + "','" + NationalitättextBox.Text + "')";
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
            AddLand();
            this.Close();
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
