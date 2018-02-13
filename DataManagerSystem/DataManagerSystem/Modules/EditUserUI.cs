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
    public partial class EditUserUI : Form
    {
        DatabaseManager databaseManager = new DatabaseManager();
        OleDbConnection UserConnection = new OleDbConnection();
        ConfigData config = new ConfigData();
        public EditUserUI()
        {
            InitializeComponent();
        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            this.Close();
            //Boolean resp = databaseManager.SearchUser(UsernameTextBox.Text);
            //MessageBox.Show("le resultat est : " +resp);
           
            
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            

            if (UserIdTextBox.Text == string.Empty || UsernameTextBox.Text == string.Empty || PasswordTextBox.Text == string.Empty || AttributComboBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter correct data!");
            }
            else
            {   
                int id = Convert.ToInt32(UserIdTextBox.Text);
                string username = UsernameTextBox.Text;
                string password = PasswordTextBox.Text;
                string attribut = AttributComboBox.Text;
                databaseManager.EditUser(id, username, password, attribut);
                UserIdTextBox.Clear();
                UsernameTextBox.Clear();
                PasswordTextBox.Clear();
            }
         
            
        }
    }
}
