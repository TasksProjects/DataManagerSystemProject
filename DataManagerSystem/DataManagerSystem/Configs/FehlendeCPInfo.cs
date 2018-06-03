using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagerSystem.Configs
{
    public class FehlendeCPInfo
    {
        public FehlendeCPInfo()
        {

        }

        private int _intCPdelta;
        public int IntCPdelta
        {
            get { return _intCPdelta; }
            set { _intCPdelta = value; }
        }

        private int _fehlCP;
        public int FehlCP
        {
            get { return _fehlCP; }
            set { _fehlCP = value; }
        }

        private int _intBewerbungID;
        public int IntBewerbungID
        {
            get { return _intBewerbungID; }
            set { _intBewerbungID = value; }
        }

        private bool _erfuelle;
        public bool Erfuelle
        {
            get { return _erfuelle; }
            set { _erfuelle = value; }
        }

    }
}
