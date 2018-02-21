using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using DataManagerSystem.Configs;

namespace DataManagerSystem.Modules
{
    public partial class BewerbungUI : Form
    {
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
                cmd.CommandText = "SELECT * FROM tab_bewerbung";



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
    }
}
