using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagerSystem.Configs
{
    public class Bewerbungsdata
    {

        private int _studentID; // the Username
        public int StudentID
        {
            get { return _studentID; }
            set { _studentID = value; }
        }

        private int _masterStudiengangID; // the password
        public int Master_StudiengangID
        {
            get { return _masterStudiengangID; }
            set { _masterStudiengangID = value; }
        }

        private int _masterStudiengangID2; // the password
        public int Master_StudiengangID2
        {
            get { return _masterStudiengangID2; }
            set { _masterStudiengangID2 = value; }
        }

        private int _masterStudiengangID3; // the password
        public int Master_StudiengangID3
        {
            get { return _masterStudiengangID3; }
            set { _masterStudiengangID3 = value; }
        }

        private int _semesterID; // the user's Attribut
        public int SemesterID
        {
            get { return _semesterID; }
            set { _semesterID = value; }
        }

        private string _comment1;
        public string Comment1
        {
            get { return _comment1; }
            set { _comment1 = value; }
        }

        private string _comment2;
        public string Comment2
        {
            get { return _comment2; }
            set { _comment2 = value; }
        }

        private string _comment3;
        public string Comment3
        {
            get { return _comment3; }
            set { _comment3 = value; }
        }

        private int _prof;
        public int Prof
        {
            get { return _prof; }
            set { _prof = value; }
        }

        private int _verwaltung;
        public int Verwaltung
        {
            get { return _verwaltung; }
            set { _verwaltung = value; }
        }

        private int _angenommen;
        public int Angenommen
        {
            get { return _angenommen; }
            set { _angenommen = value; }
        }
    }
}
