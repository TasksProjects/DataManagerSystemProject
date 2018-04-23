using DataManagerSystem.Configs;
using System;
using System.IO;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class EditPerson : Form
    {
        Bewerbungsdata bewerbungsdata = new Bewerbungsdata();
        StudentData studentData = new StudentData();
        private ConfigData config = new ConfigData();

        public EditPerson()
        {
            InitializeComponent();
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            ExportDocument();
        }

        private void ExportDocument()
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            WordDocCreator Docx = new WordDocCreator(@Path.GetDirectoryName(Application.ExecutablePath).Trim() + "\\template\\BCI.docx");

            Docx.FindAndReplace("<name>", NameTB.Text.Trim());
            Docx.FindAndReplace("<vorname>", FirstnameTB.Text.Trim());
            Docx.FindAndReplace("<nationalitaet>", NationalitaetCB.Text.Trim());
            Docx.FindAndReplace("<studiengang>", StudienCB.Text.Trim());
            Docx.FindAndReplace("<hochschule>", HochshuleCB.Text.Trim());
            Docx.FindAndReplace("<note>", AbschlussnoteTB.Text.Trim());
            Docx.FindAndReplace("<erworbenecp>", CpTB.Text.Trim());
            Docx.FindAndReplace("<masterstudiengang>", MasterstudiengangCB.Text.Trim());

            Docx.FindAndReplace("<ablehnungsgrund>", AblehnungsgrundTB.Text.Trim());
            Docx.FindAndReplace("<kommentar>", KommentarTB.Text.Trim());
            Docx.FindAndReplace("<date>", DateTime.Now.ToShortDateString());

            string filename = "\\" + NameTB.Text.Trim() + DateTime.Now.ToShortDateString().Trim() + ".docx";

            Docx.CreateDocx(config.SaveDocxPath.Trim() + filename.Trim());
        }
    }
}
