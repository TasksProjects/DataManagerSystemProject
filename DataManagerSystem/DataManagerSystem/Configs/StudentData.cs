using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagerSystem.Configs
{
    public class StudentData
    {
        private string _vorname;
        public string Vorname
        {
            get { return _vorname; }
            set { _vorname = value; }
        }

        private string _name; 
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _nationalitaet;
        public int Nationalitaet
        {
            get { return _nationalitaet; }
            set { _nationalitaet = value; }
        }

        private int _bachelor;
        public int Bachelor
        {
            get { return _bachelor; } 
            set { _bachelor = value; }
        }

        private double _studentNote;
        public double Student_Note
        {
            get { return _studentNote; }
            set { _studentNote = value; }
        }

        private int _creditpunkte;
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
