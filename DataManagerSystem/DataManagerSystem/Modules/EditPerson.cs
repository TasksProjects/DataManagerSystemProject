using DataManagerSystem.Configs;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class EditPerson : Form
    {
        Bewerbungsdata bewerbungsdata = new Bewerbungsdata();
        StudentData studentData = new StudentData();
        //public EditPerson(int id, Bewerbungsdata bewerbung, StudentData student)
        public EditPerson()
        {
            InitializeComponent();
          //  bewerbungsdata = bewerbung;
           // studentData = student;

        }

        private void textBox21_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}
