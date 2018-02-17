using DataManagerSystem.Modules;
using System;
using System.Windows.Forms;

namespace DataManagerSystem
{
    public partial class MainWindow : Form
    {
        SettingsUI settingUI = new SettingsUI();
        AdminUI adminUI = new AdminUI();

        public MainWindow( string status)
        {
            InitializeComponent();
            Disable(status);
            labelStatus.Text = status;

            // to display the time
            timer1.Start();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Close();
        }

        private void SettingButton_Click(object sender, EventArgs e)
        {
            settingUI.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            NewStudentUI newStudentUI = new NewStudentUI();
            newStudentUI.Show();
            
        }

        private void AdminButton_Click(object sender, EventArgs e)
        {
            adminUI.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void ShowDbButton_Click(object sender, EventArgs e)
        {

        }

        private void EditButton_Click(object sender, EventArgs e)
        {

        }

        private void Helpbutton_Click(object sender, EventArgs e)
        {

        }

        private void Disable(string status)
        {
            if (((status == "Professor") || (status == "Assistant") || (status == "Admin")))
            {
                SettingButton.Enabled = false;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.labelTime.Text = dateTime.ToString();
        }

        private void StudiengangButton_Click(object sender, EventArgs e)
        {
            StudiengangUI studiengangUI = new StudiengangUI();
            studiengangUI.Show();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
