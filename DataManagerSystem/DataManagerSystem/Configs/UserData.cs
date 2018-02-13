namespace DataManagerSystem.Configs
{
    public class UserData
    {
        private string _username; // the Username
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password; // the password
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _userAttribut; // the user's Attribut
        public string UserAttribut
        {
            get { return _userAttribut; }
            set { _userAttribut = value; }
        }
    }
}
