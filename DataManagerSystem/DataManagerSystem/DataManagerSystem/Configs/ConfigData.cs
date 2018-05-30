using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagerSystem.Configs
{
    public class ConfigData
    {
        private string _databasePath; //Database Path
        public string DatabasePath
        {
            get { return _databasePath; }
            set { _databasePath = value; }
        }

        private string _dbConnectionString; //Database Default Path
        public string DbConnectionString
        {
            get { return _dbConnectionString;}
            set { _dbConnectionString = value;}
        }

        private string _saveDocxPath;
        public string SaveDocxPath
        {
            get { return _saveDocxPath; }
            set { _saveDocxPath = value; }
        }
    }
}
