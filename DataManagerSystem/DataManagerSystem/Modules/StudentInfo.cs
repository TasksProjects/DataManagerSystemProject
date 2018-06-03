using DataManagerSystem.Configs;
using DataManagerSystem.VerwaltungStudentenInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class StudentInfo : Form
    {
        StudentenVerwaltung studentenVerwaltung = new StudentenVerwaltung();
        Bewerbungsdata bewerbungsdata = new Bewerbungsdata();

        public StudentInfo(Bewerbungsdata bewerbung)
        {
            InitializeComponent();
            bewerbungsdata = bewerbung;
            InitField(bewerbung);
        }


        private void InitField(Bewerbungsdata data)
        {

            LabelName.Text = data.Name.Trim();
            LabelVorname.Text = data.Vorname.Trim();
            Labelgeschlecht.Text = data.Geschlecht.Trim();
            LabelNationalitaet.Text = data.Nationalitaet.Trim();
            LabelSemester.Text = data.Semester.Trim();
            LabelBewerbungsID.Text = (data.ID).ToString();
        }

        private void StudentInfo_Load(object sender, EventArgs e)
        {
            studentenVerwaltung.ShowStudentenInfo(dataGridView, bewerbungsdata.ID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            BewerbungUI bewerbungUI = new BewerbungUI();
            bewerbungUI.Show();
        }
    }
}
