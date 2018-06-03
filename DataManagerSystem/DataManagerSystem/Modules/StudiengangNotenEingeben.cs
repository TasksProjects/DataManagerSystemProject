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
    public partial class StudiengangNotenEingeben : Form
    {
      
        StudentenVerwaltung studentenVerwaltung = new StudentenVerwaltung();
        StudiengaangAndNote[] listeFaecher = new StudiengaangAndNote[10];
        //FehlendeCPInfo[] listeFehlendeCP = new FehlendeCPInfo[10];
        List<FehlendeCPInfo> listeFehlendeCP = new List<FehlendeCPInfo>();
        //List<StudiengaangAndNote>listeFaecher = new List<StudiengaangAndNote>();
        Bewerbungsdata bewerbungsdata = new Bewerbungsdata();
        public StudiengangNotenEingeben(StudiengaangAndNote[] masterStudiengang, Bewerbungsdata bewerbung)
        {
            InitializeComponent();
            bewerbungsdata = bewerbung;
            listeFaecher = masterStudiengang;
            InitField(bewerbung, listeFaecher);
            ShowFehlCP(bewerbung.ID, listeFaecher);
            BtnEinstufen1.Visible = false;
          
        }

        private void InitField(Bewerbungsdata data, StudiengaangAndNote[] master)
        {
            LabelBewerbungsID.Text = (data.ID).ToString();
            LabelMasterstudiengang1.Text = data.Masterstudiengang;
            LabelName.Text = data.Name;
            LabelVorname.Text = data.Vorname;
            LabelGeschlecht.Text = data.Geschlecht;

            LabelFach1.Text = listeFaecher[0].Fach;
            LabelFach2.Text = listeFaecher[1].Fach;
            LabelFach3.Text = listeFaecher[2].Fach;
            LabelFach4.Text = listeFaecher[3].Fach;
            LabelFach5.Text = listeFaecher[4].Fach;
            LabelFach6.Text = listeFaecher[5].Fach;
            LabelFach7.Text = listeFaecher[6].Fach;
            LabelFach8.Text = listeFaecher[7].Fach;
            LabelFach9.Text = listeFaecher[8].Fach;
            LabelFach10.Text = listeFaecher[9].Fach;

            LabelIntCP1.Text = (listeFaecher[0].IntCP).ToString();
            LabelIntCP2.Text = (listeFaecher[1].IntCP).ToString();
            LabelIntCP3.Text = (listeFaecher[2].IntCP).ToString();
            LabelIntCP4.Text = (listeFaecher[3].IntCP).ToString();
            LabelIntCP5.Text = (listeFaecher[4].IntCP).ToString();
            LabelIntCP6.Text = (listeFaecher[5].IntCP).ToString();
            LabelIntCP7.Text = (listeFaecher[6].IntCP).ToString();
            LabelIntCP8.Text = (listeFaecher[7].IntCP).ToString();
            LabelIntCP9.Text = (listeFaecher[8].IntCP).ToString();
            LabelIntCP10.Text = (listeFaecher[9].IntCP).ToString();
        }

        private void FehlendeCPRechnen()
        {   /*
            
            int i = 0;
            if ((textBoxIstCP1.Text.Trim() != string.Empty && textBoxIstCP2.Text.Trim() != string.Empty && textBoxIstCP3.Text.Trim() != string.Empty &&
                textBoxIstCP4.Text.Trim() != string.Empty && textBoxIstCP5.Text.Trim() != string.Empty && textBoxIstCP6.Text.Trim() != string.Empty &&
                textBoxIstCP7.Text.Trim() != string.Empty && textBoxIstCP8.Text.Trim() != string.Empty && textBoxIstCP9.Text.Trim() != string.Empty &&
                textBoxIstCP10.Text.Trim() != string.Empty) && (CheckValueOftheDigit(textBoxIstCP1.Text.Trim()) != true && CheckValueOftheDigit(textBoxIstCP2.Text.Trim()) != true)
                && CheckValueOftheDigit(textBoxIstCP3.Text.Trim()) != true && CheckValueOftheDigit(textBoxIstCP4.Text.Trim()) != true && CheckValueOftheDigit(textBoxIstCP5.Text.Trim()) != true
                && CheckValueOftheDigit(textBoxIstCP5.Text.Trim()) != true && CheckValueOftheDigit(textBoxIstCP6.Text.Trim()) != true && CheckValueOftheDigit(textBoxIstCP7.Text.Trim()) != true
                && CheckValueOftheDigit(textBoxIstCP8.Text.Trim()) != true && CheckValueOftheDigit(textBoxIstCP9.Text.Trim()) != true && CheckValueOftheDigit(textBoxIstCP10.Text.Trim()) != true)
                {

                if (EingabeWertTest(listeFehlendeCP[0].FehlCP, textBoxIstCP1.Text.Trim()) <0)
                {
                    LabelFehltCP1.Text = EingabeWertTest(listeFehlendeCP[0].FehlCP, textBoxIstCP1.Text.Trim()).ToString() + " Incorrect!";
                    LabelFehltCP1.ForeColor = Color.Red;
                    i = 1;
                }
                else
                {
                    LabelFehltCP1.Text = EingabeWertTest(listeFehlendeCP[0].FehlCP, textBoxIstCP1.Text.Trim()).ToString();
                    LabelFehltCP1.ForeColor = Color.Black;
                   
                }

                if (EingabeWertTest(listeFehlendeCP[1].FehlCP, textBoxIstCP2.Text.Trim()) < 0)
                {
                    LabelFehltCP2.Text = EingabeWertTest(listeFehlendeCP[1].FehlCP, textBoxIstCP2.Text.Trim()).ToString() + " Incorrect!";
                    LabelFehltCP2.ForeColor = Color.Red;
                    i = 1;
                }
                else
                {
                    LabelFehltCP2.Text = EingabeWertTest(listeFehlendeCP[1].FehlCP, textBoxIstCP2.Text.Trim()).ToString();
                    LabelFehltCP2.ForeColor = Color.Black;
                }
                if (EingabeWertTest(listeFehlendeCP[2].FehlCP, textBoxIstCP3.Text.Trim()) < 0)
                {
                    LabelFehltCP3.Text = EingabeWertTest(listeFehlendeCP[2].FehlCP, textBoxIstCP3.Text.Trim()).ToString() + " Incorrect!";
                    LabelFehltCP3.ForeColor = Color.Red;
                    i = 1;
                }
                else
                {
                    LabelFehltCP3.Text = EingabeWertTest(listeFehlendeCP[2].FehlCP, textBoxIstCP3.Text.Trim()).ToString();
                    LabelFehltCP3.ForeColor = Color.Black;
                }
                if (EingabeWertTest(listeFehlendeCP[3].FehlCP, textBoxIstCP4.Text.Trim()) < 0)
                {
                    LabelFehltCP4.Text = EingabeWertTest(listeFehlendeCP[3].FehlCP, textBoxIstCP4.Text.Trim()).ToString() + " Incorrect!";
                    LabelFehltCP4.ForeColor = Color.Red;
                    i = 1;
                }
                else
                {
                    LabelFehltCP4.Text = EingabeWertTest(listeFehlendeCP[3].FehlCP, textBoxIstCP4.Text.Trim()).ToString();
                    LabelFehltCP4.ForeColor = Color.Black;
                }
                if (EingabeWertTest(listeFehlendeCP[4].FehlCP, textBoxIstCP5.Text.Trim()) <0)
                {
                    LabelFehltCP5.Text = EingabeWertTest(listeFehlendeCP[4].FehlCP, textBoxIstCP5.Text.Trim()).ToString() + " Incorrect!";
                    LabelFehltCP5.ForeColor = Color.Red;
                    i = 1;
                }
                else
                {
                    LabelFehltCP5.Text = EingabeWertTest(listeFehlendeCP[4].FehlCP, textBoxIstCP5.Text.Trim()).ToString();
                    LabelFehltCP5.ForeColor = Color.Black;
                }
                if (EingabeWertTest(listeFehlendeCP[5].FehlCP, textBoxIstCP6.Text.Trim())<0)
                {
                    LabelFehltCP6.Text = EingabeWertTest(listeFehlendeCP[5].FehlCP, textBoxIstCP6.Text.Trim()).ToString() + " Incorrect!";
                    LabelFehltCP6.ForeColor = Color.Red;
                    i = 1;
                }
                else
                {
                    LabelFehltCP6.Text = EingabeWertTest(listeFehlendeCP[5].FehlCP, textBoxIstCP6.Text.Trim()).ToString();
                    LabelFehltCP6.ForeColor = Color.Black;
                }
                if (EingabeWertTest(listeFehlendeCP[6].FehlCP, textBoxIstCP7.Text.Trim()) < 0)
                {
                    LabelFehltCP7.Text = EingabeWertTest(listeFehlendeCP[6].FehlCP, textBoxIstCP7.Text.Trim()).ToString() + " Incorrect!";
                    LabelFehltCP7.ForeColor = Color.Red;
                    i = 1;
                }
                else
                {
                    LabelFehltCP7.Text = EingabeWertTest(listeFehlendeCP[6].FehlCP, textBoxIstCP7.Text.Trim()).ToString();
                    LabelFehltCP7.ForeColor = Color.Black;
                }

                if (EingabeWertTest(listeFehlendeCP[7].FehlCP, textBoxIstCP8.Text.Trim()) < 0)
                {
                    LabelFehltCP8.Text = EingabeWertTest(listeFehlendeCP[7].FehlCP, textBoxIstCP8.Text.Trim()).ToString() + " Incorrect!";
                    LabelFehltCP8.ForeColor = Color.Red;
                    i = 1;
                }
                else
                {
                    LabelFehltCP8.Text = EingabeWertTest(listeFehlendeCP[7].FehlCP, textBoxIstCP8.Text.Trim()).ToString();
                    LabelFehltCP8.ForeColor = Color.Black;
                }

                if (EingabeWertTest(listeFehlendeCP[8].FehlCP, textBoxIstCP9.Text.Trim()) < 0)
                {
                    LabelFehltCP9.Text = EingabeWertTest(listeFehlendeCP[8].FehlCP, textBoxIstCP9.Text.Trim()).ToString() + " Incorrect!";
                    LabelFehltCP9.ForeColor = Color.Red;
                    i = 1;
                }
                else
                {
                    LabelFehltCP9.Text = EingabeWertTest(listeFehlendeCP[8].FehlCP, textBoxIstCP9.Text.Trim()).ToString();
                    LabelFehltCP9.ForeColor = Color.Black;
                }

                if (EingabeWertTest(listeFehlendeCP[9].FehlCP, textBoxIstCP10.Text.Trim()) < 0)
                {
                    LabelFehltCP10.Text = EingabeWertTest(listeFehlendeCP[9].FehlCP, textBoxIstCP10.Text.Trim()).ToString() + " Incorrect!";
                    LabelFehltCP10.ForeColor = Color.Red;
                    i = 1;
                }
                else
                {
                    LabelFehltCP10.Text = EingabeWertTest(listeFehlendeCP[9].FehlCP, textBoxIstCP10.Text.Trim()).ToString();
                    LabelFehltCP10.ForeColor = Color.Black;
                }

                
                if (i == 1)
                {
                    MessageBox.Show("Please correct the wrong values!");
                }
                else
                {
                    NeueFehlendeValueBerechnen();
                    BtnEinstufen1.Visible = true;
                   
                }
                
            }
            else
            {
                MessageBox.Show("Please fill all the field or check your daten. The Daten muss not content letter!");
            }
          */  
        }


        private int EingabeWertTest(int intcp, string wert)
        {
            int FehltCP;
            int FehlendeCP = -1;
            int note;
            bool result = CheckValueOftheDigit(wert);
            bool res = int.TryParse(wert, out note);
            if (result != true)
            {
                if(res == true)
                {
                    FehltCP = intcp - note;
                    return FehltCP;
                    
                    
                }
            }
            else
            {
                return FehlendeCP;
            }

   
        }


        //Check if the value hat letter
        private bool CheckValueOftheDigit( string wert)
        {
            bool result = false;

            for (int i = 0; i < wert.Length; i++)
            {
                if (char.IsLetter(wert, i))
                {
                    result = true;
                }
            }
            return result;
        }

        private void ShowFehlCP(int bewerbungsID, StudiengaangAndNote[] listeFach)
        {
           
           
            bool resut = studentenVerwaltung.Search_BewerbungID_in_tab_FehlCP(bewerbungsdata.ID);
            if (resut == false)
            {
                for (int z = 0; z < 10; z++)
                {
                    listeFach[z] = listeFaecher[z];
                }

                    LabelFehltCP1.Text = (listeFach[0].IntCP).ToString();
                    LabelFehltCP2.Text = (listeFach[1].IntCP).ToString();
                    LabelFehltCP3.Text = (listeFach[2].IntCP).ToString();
                    LabelFehltCP4.Text = (listeFach[3].IntCP).ToString();
                    LabelFehltCP5.Text = (listeFach[4].IntCP).ToString();
                    LabelFehltCP6.Text = (listeFach[5].IntCP).ToString();
                    LabelFehltCP7.Text = (listeFach[6].IntCP).ToString();
                    LabelFehltCP8.Text = (listeFach[7].IntCP).ToString();
                    LabelFehltCP9.Text = (listeFach[8].IntCP).ToString();
                    LabelFehltCP10.Text = (listeFach[9].IntCP).ToString();
                /*
                for (int z = 0; z < 10; z++)
                {
                    FehlendeCPInfo fehlendeCPInfo = new FehlendeCPInfo();
                    fehlendeCPInfo.IntCPdelta = listeFach[z].IntCP;
                    fehlendeCPInfo.IntBewerbungID = listeFach[z].StudiengangID;
                    fehlendeCPInfo.Erfuelle = false;
                    fehlendeCPInfo.FehlCP = listeFach[z].IntCP;
                    listeFehlendeCP.Add (fehlendeCPInfo);
                }*/
            }
            else
            {
                /*
                for (int z = 0; z < 10; z++)
                {
                    FehlendeCPInfo fehlendeCPInfo1 = new FehlendeCPInfo();
                    fehlendeCPInfo1 = studentenVerwaltung.ShowFehlendeCI(bewerbungsdata.Masterstudiengang, listeFaecher[z].FachID);
                    listeFehlendeCP.Add(fehlendeCPInfo1);
                }*/
                FehlendeCPInfo fehlendeCPInfo1 = new FehlendeCPInfo();
                fehlendeCPInfo1 = studentenVerwaltung.ShowFehlendeCI(bewerbungsdata.Masterstudiengang, listeFaecher[0].FachID);
                listeFehlendeCP.Add(fehlendeCPInfo1);
                MessageBox.Show("voici ca"+ studentenVerwaltung.ShowFehlendeCI(bewerbungsdata.Masterstudiengang, listeFaecher[0].FachID).IntCPdelta);



               // LabelFehltCP1.Text = (listeFehlendeCP[0].FehlCP).ToString();
                /*
                LabelFehltCP2.Text = (listeFehlendeCP[1].FehlCP).ToString();
                LabelFehltCP3.Text = (listeFehlendeCP[2].FehlCP).ToString();
                LabelFehltCP4.Text = (listeFehlendeCP[3].FehlCP).ToString();
                LabelFehltCP5.Text = (listeFehlendeCP[4].FehlCP).ToString();
                LabelFehltCP6.Text = (listeFehlendeCP[5].FehlCP).ToString();
                LabelFehltCP7.Text = (listeFehlendeCP[6].FehlCP).ToString();
                LabelFehltCP8.Text = (listeFehlendeCP[7].FehlCP).ToString();
                LabelFehltCP9.Text = (listeFehlendeCP[8].FehlCP).ToString();
                LabelFehltCP10.Text =(listeFehlendeCP[9].FehlCP).ToString();*/

            }
        }

        private void ChangeNoteAfterCompute(string not, int j)
        {
            int note;
            bool res = int.TryParse(not, out note);
            if (res == true)
            {
                listeFehlendeCP[j].FehlCP = note;
            }
        }

        private void NeueFehlendeValueBerechnen()
        {
         
            ChangeNoteAfterCompute(LabelFehltCP1.Text.Trim(), 0);
            ChangeNoteAfterCompute(LabelFehltCP2.Text.Trim(), 1);
            ChangeNoteAfterCompute(LabelFehltCP3.Text.Trim(), 2);
            ChangeNoteAfterCompute(LabelFehltCP4.Text.Trim(), 3);
            ChangeNoteAfterCompute(LabelFehltCP5.Text.Trim(), 4);
            ChangeNoteAfterCompute(LabelFehltCP6.Text.Trim(), 5);
            ChangeNoteAfterCompute(LabelFehltCP7.Text.Trim(), 6);
            ChangeNoteAfterCompute(LabelFehltCP8.Text.Trim(), 7);
            ChangeNoteAfterCompute(LabelFehltCP9.Text.Trim(), 8);
            ChangeNoteAfterCompute(LabelFehltCP10.Text.Trim(), 9);
        }

        private void BtnSchließen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnFehlendeCpRechnen_Click(object sender, EventArgs e)
        {
            FehlendeCPRechnen();
        }
    }
}
