using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagerSystem.Configs
{
    public class StudiengaangAndNote
    {
        public StudiengaangAndNote()
        {

        }

        private int _fachID;
        public int FachID
        {
            get { return _fachID; }
            set { _fachID = value; }
        }

        private int _studiengangID;
        public int StudiengangID
        {
            get { return _studiengangID; }
            set { _studiengangID = value; }
        }

        private int _intCP;
        public int IntCP
        {
            get { return _intCP; }
            set { _intCP = value; }
        }

        private string _fach;
        public string Fach
        {
            get { return _fach; }
            set { _fach = value; }
        }
    }
}
