using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagerSystem.Configs
{
    public class SuperUserData
    {
        private string _superusername; // the Username
        public string SuperUsername
        {
            get { return _superusername; }
            set { _superusername = value; }
        }

        private string _superuserpassword; // the password
        public string SuperuserPassword
        {
            get { return _superuserpassword; }
            set { _superuserpassword = value; }
        }

        private string _superuserAttribut; // the user's Attribut
        public string SuperUserAttribut
        {
            get { return _superuserAttribut; }
            set { _superuserAttribut = value; }
        }

        private int _superuserstatut; // the user's statut
        public int SuperUserstatut
        {
            get { return _superuserstatut; }
            set { _superuserstatut = value; }
        }
    }
}
