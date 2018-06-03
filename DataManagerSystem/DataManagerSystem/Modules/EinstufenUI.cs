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
    public partial class EinstufenUI : Form
    {
        Bewerbungsdata bewerbungsdata = new Bewerbungsdata();
        public EinstufenUI(Bewerbungsdata bewerbung)
        {
           
            InitializeComponent();
            bewerbungsdata = bewerbung;
            InitField(bewerbung);
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            BewerbungUI bewerbungUI = new BewerbungUI();
            bewerbungUI.Show();
        }

    }
}
