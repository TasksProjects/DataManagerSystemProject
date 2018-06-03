using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using DataManagerSystem.Configs;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace DataManagerSystem.Modules
{
    public partial class BewerbungUI : Form
    {
        Bewerbungsdata bewerbungsdata = new Bewerbungsdata();
        private ConfigData config = new ConfigData();
        int bewerbungID;

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


                string query = "SELECT b.ID, b.Vorname, b.Name, b.Geschlecht, c.txtNationalität AS Nationalitaet,d.txtName AS Studiengang, e.txtName AS Hochschule, " +
                    "b.Creditpunkt, b.NoteVorlaeufig, b.Note,f.txtName AS Masterstudiengang, h.txtName AS Masterstudiengang2, j.txtName AS Masterstudiengang3, s.txtSemester AS Semester, " +
                    "b.Kommentar, b.Zusatz, b.Ablehnungsgrund, b.AnProf, b.Verwaltung, b.Angenommen " +
                    "FROM tab_bewerbung AS b, tab_land AS c, tab_hochschule AS e, tab_studiengang AS d, tab_masterstudiengang AS f, tab_masterstudiengang AS h, " +
                    "tab_semester AS s, tab_masterstudiengang AS j " +
                    "Where c.ID = b.Nationalitaet AND e.ID = b.Hochschule AND d.ID = b.Studiengang AND f.ID = b.Masterstudiengang " +
                    "AND s.ID = b.Semester AND h.ID = b.Masterstudiengang2 AND j.ID = b.Masterstudiengang3";

                cmd.CommandText = query;

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

        public void GetBewerbungDataFromDataView(DataGridViewRow row)
        {
            bewerbungsdata.ID = bewerbungID;
            bewerbungsdata.Vorname = row.Cells["Vorname"].Value.ToString();
            bewerbungsdata.Name = row.Cells["Name"].Value.ToString();
            bewerbungsdata.Geschlecht = row.Cells["Geschlecht"].Value.ToString();
            bewerbungsdata.Nationalitaet = row.Cells["Nationalitaet"].Value.ToString();

            bewerbungsdata.Studiengang = row.Cells["Studiengang"].Value.ToString();
            bewerbungsdata.Hochschule = row.Cells["Hochschule"].Value.ToString();
            bewerbungsdata.Creditpunkte = row.Cells["Creditpunkt"].Value.ToString();
            bewerbungsdata.NoteVorlaeufig = (bool)row.Cells["NoteVorlaeufig"].Value;
            bewerbungsdata.Note = row.Cells["Note"].Value.ToString();

            bewerbungsdata.Masterstudiengang = row.Cells["Masterstudiengang"].Value.ToString();
            bewerbungsdata.Masterstudiengang_2 = row.Cells["Masterstudiengang2"].Value.ToString();
            bewerbungsdata.Masterstudiengang_3 = row.Cells["Masterstudiengang3"].Value.ToString();
            bewerbungsdata.Semester = row.Cells["Semester"].Value.ToString();

            
            bewerbungsdata.Zusatz = row.Cells["Zusatz"].Value.ToString();
            bewerbungsdata.Comment = row.Cells["Kommentar"].Value.ToString();
            bewerbungsdata.Prof = (bool)row.Cells["AnProf"].Value;
            bewerbungsdata.Ablehnungsgrund = row.Cells["Ablehnungsgrund"].Value.ToString();
            bewerbungsdata.Verwaltung = (bool)row.Cells["Verwaltung"].Value;
            bewerbungsdata.Angenommen = (bool)row.Cells["Angenommen"].Value;
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (BewerbungIdTB.Text.Trim() != string.Empty)
            {
                EditPerson editPerson = new EditPerson(bewerbungsdata);
                editPerson.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No Cell Selected!");
            }
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (BewerbungIdTB.Text.Trim() != string.Empty)
            {
                DialogResult dialogResult = MessageBox.Show("Do you really want to remove Registration with nummer " + bewerbungID + " ", "Confirm Remove Registration", MessageBoxButtons.YesNo);
                if ((dialogResult == DialogResult.Yes) && RemoveBewerbung(bewerbungID))
                {
                    MessageBox.Show("Bewerbung  Removed Successful!");
                    BewerbungIdTB.Text = "";
                    Show_Database();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Show_Database();
                }
            }
            else
            {
                MessageBox.Show("No Cell Selected!");
            }               
        }

        public bool RemoveBewerbung(int id)
        {
            bool resp = false;
            config = XmlDataManager.XmlConfigDataReader("configs.xml");

            string query = "delete from  tab_bewerbung  where ID = " + id + "";
            OleDbConnection UserConnection = new OleDbConnection();
            UserConnection.ConnectionString = config.DbConnectionString;
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Connection = UserConnection;
            UserConnection.Open();
            try
            {
                cmd.ExecuteNonQuery();
                UserConnection.Close();
                resp = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            return resp;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView.Rows[e.RowIndex];
                bewerbungID = (int)row.Cells["ID"].Value;
                BewerbungIdTB.Text = bewerbungID.ToString();
                GetBewerbungDataFromDataView(row);
            }
        }      

        public void CreateMail(string subject, string body, string attachment = "")
        {
            try
            {
                Outlook.Application oApp = new Outlook.Application();
                Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);

                oMsg.Subject = subject;
                oMsg.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
                oMsg.HTMLBody = body;
                if(attachment != string.Empty)
                {
                    oMsg.Attachments.Add(attachment, Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                }
                oMsg.Display(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Close();
            }
        }

        private void SetupMail()
        {
            if (BewerbungIdTB.Text.Trim() != string.Empty)
            {

                string docx = ExportDocx(bewerbungsdata.Masterstudiengang.Trim(),1);

                if (bewerbungsdata.Masterstudiengang_2 != 0.ToString())
                {
                    ExportDocx(bewerbungsdata.Masterstudiengang_2.Trim(),2);
                }

                if (bewerbungsdata.Masterstudiengang_3 != 0.ToString())
                {
                    ExportDocx(bewerbungsdata.Masterstudiengang_3.Trim(),3);
                }

                CreateMail("subject", "body", @docx);
            }
            else
            {
                MessageBox.Show("No Cell Selected!");
            }
        }

        private void AnProfBtn_Click(object sender, EventArgs e)
        {
            SetupMail();
        }

        private void HA4_1Btn_Click(object sender, EventArgs e)
        {
            SetupMail();
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            if (BewerbungIdTB.Text.Trim() != string.Empty)
            {

                ExportDocx(bewerbungsdata.Masterstudiengang.Trim(), 1);

                if (bewerbungsdata.Masterstudiengang_2 != 0.ToString())
                {
                    ExportDocx(bewerbungsdata.Masterstudiengang_2.Trim(), 2);
                }

                if (bewerbungsdata.Masterstudiengang_3 != 0.ToString())
                {
                    ExportDocx(bewerbungsdata.Masterstudiengang_3.Trim(), 3);
                }

                MessageBox.Show("All File Created successfully!");
            }
            else
            {
                MessageBox.Show("No Cell Selected!");
            }
           
        }

        private String ExportDocx(string masterStudiengang, int fileIndex)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            WordDocCreator Docx = new WordDocCreator(@Path.GetDirectoryName(Application.ExecutablePath).Trim() + "\\bci.docx");

            Docx.FindAndReplace("<name>", bewerbungsdata.Name.Trim());
            Docx.FindAndReplace("<vorname>", bewerbungsdata.Vorname.Trim());
            Docx.FindAndReplace("<nationalitaet>", bewerbungsdata.Nationalitaet.Trim());
            Docx.FindAndReplace("<studiengang>", bewerbungsdata.Studiengang.Trim());
            Docx.FindAndReplace("<hochschule>", bewerbungsdata.Hochschule.Trim());
            Docx.FindAndReplace("<note>", bewerbungsdata.Note.Trim());
            Docx.FindAndReplace("<erworbenecp>", bewerbungsdata.Creditpunkte.Trim());
            Docx.FindAndReplace("<masterstudiengang>", masterStudiengang.Trim());

            Docx.FindAndReplace("<ablehnungsgrund>", bewerbungsdata.Ablehnungsgrund.Trim());
            Docx.FindAndReplace("<kommentar>", bewerbungsdata.Comment.Trim());
            Docx.FindAndReplace("<date>", DateTime.Now.ToShortDateString());

            string filename = "\\" + bewerbungsdata.Name.Trim() + bewerbungsdata.Vorname.Trim() + fileIndex.ToString().Trim() +".docx";
            string filepath = config.SaveDocxPath.Trim() + filename.Trim();

            Docx.CreateDocx(filepath);

            return filepath;
        }

        private void StatusBtn_Click(object sender, EventArgs e)
        {
            if (BewerbungIdTB.Text.Trim() != string.Empty)
            {
                StudentInfo studentInfo = new StudentInfo(bewerbungsdata);
                studentInfo.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No Cell Selected!");
            }        
        }

        private void EinstufBtn_Click(object sender, EventArgs e)
        {

            if (BewerbungIdTB.Text.Trim() != string.Empty)
            {
                EinstufenUI einstufenUI = new EinstufenUI(bewerbungsdata);
                einstufenUI.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No Cell Selected!");
            }
        }

        private void BtnNotenEingeben_Click(object sender, EventArgs e)
        {
            if (BewerbungIdTB.Text.Trim() != string.Empty)
            {
                NotenEingeben notenEingeben = new NotenEingeben (bewerbungsdata);
                notenEingeben.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No Cell Selected!");
            }
        }
    }
}
