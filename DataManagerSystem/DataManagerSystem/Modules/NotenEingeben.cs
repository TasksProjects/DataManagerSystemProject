using DataManagerSystem.Configs;
using DataManagerSystem.VerwaltungStudentenInfo;
using System;
using System.Collections;
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
    public partial class NotenEingeben : Form
    {
        StudiengaangAndNote[] listeFaecher = new StudiengaangAndNote[10];
        //FehlendeCPInfo[] listeFehlendeCP = new FehlendeCPInfo[10];
        // List<StudiengaangAndNote> listeFaecher = new List<StudiengaangAndNote>();
        List<FehlendeCPInfo> listeFehlendeCP = new List<FehlendeCPInfo>();
        StudentenVerwaltung studentenVerwaltung = new StudentenVerwaltung();
        Bewerbungsdata bewerbungsdata = new Bewerbungsdata();
        public NotenEingeben(Bewerbungsdata bewerbung )
        {
            InitializeComponent();
            bewerbungsdata = bewerbung;
            InitField(bewerbung);
            listeFaecher = studentenVerwaltung.ShowStudiengangNoten(bewerbung.Masterstudiengang);


        }

        private void BtnSchließen_Click(object sender, EventArgs e)
        {
            BewerbungUI bewerbungUI = new BewerbungUI();
            bewerbungUI.Show();
            this.Close();
        }

        private void InitField(Bewerbungsdata data)
        {
            LabelBewerbungsID.Text = (data.ID).ToString();
            LabelMasterstudiengang1.Text = data.Masterstudiengang;
            LabelMasterstudiengang2.Text = data.Masterstudiengang_2;
            LabelMasterstudiengang3.Text = data.Masterstudiengang_3;
            LabelName.Text = data.Name;
            LabelVorname.Text = data.Vorname;
            LabelGeschlecht.Text = data.Geschlecht;
        }

        private void BtnNotenEingeben1_Click(object sender, EventArgs e)
        {
            StudiengangNotenEingeben studiengangNotenEingeben = new StudiengangNotenEingeben(listeFaecher, bewerbungsdata);
            studiengangNotenEingeben.Show();
        }
    }
}
