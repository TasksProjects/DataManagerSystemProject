using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagerSystem.Configs
{
    public class StudentData
    {
        private string _vorname; // the Username
        public string Vorname
        {
            get { return _vorname; }
            set { _vorname = value; }
        }

        private string _name; // the password
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _nationalitaet; // the user's Attribut
        public int Nationalitaet
        {
            get { return _nationalitaet; } // the Student's nationality
            set { _nationalitaet = value; }
        }

        private int _bachelor; // grade of the student
        public int Bachelor
        {
            get { return _bachelor; } 
            set { _bachelor = value; }
        }

        private double _studentNote; // notes of the student
        public double Student_Note
        {
            get { return _studentNote; }
            set { _studentNote = value; }
        }

        private int _creditpunkte; // point of the student
        public int Creditpunkte
        {
            get { return _creditpunkte; }
            set { _creditpunkte = value; }
        }

        private int _noteVorlaefig; 
        public int NoteVorlaefig
        {
            get { return _noteVorlaefig; }
            set { _noteVorlaefig = value; }
        }

        private string _geschlecht;
        public string Geschlecht
        {
            get { return _geschlecht; }
            set {_geschlecht = value; }
        }
       
    }
}
