using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DataManagerSystem.Configs
{
    public class DatabaseManager
    {
        private ConfigData config = new ConfigData();
       

        public void ShowDatabase(DataGridView grid)
        {
            try
            {
                config = XmlDataManager.XmlConfigDataReader("configs.xml");

                OleDbConnection UserConnection = new OleDbConnection();
                UserConnection.ConnectionString = config.DbConnectionString;

                UserConnection.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = UserConnection;
                cmd.CommandText = "SELECT * FROM tab_User";

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid.DataSource = dt;

                UserConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        public Boolean SearchUser(string username)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT * FROM tab_User where Username = '" +username+ "' ";
           
            OleDbConnection UserConnection1 = new OleDbConnection();
            UserConnection1.ConnectionString = config.DbConnectionString;
            UserConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = UserConnection1;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = query;
            OleDbDataReader reader = cmd1.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count++;
            }
            UserConnection1.Close();

            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

         }

        // Function to edit UserData as SuperAdmin in the database
        public void EditUser(int id, string username, string password, string attribut)
        {
            // check if the username already exist and return his value
            Boolean response = SearchUser(username);
            int userID = checkUserID(username);
            if (response == false)
            {
                config = XmlDataManager.XmlConfigDataReader("configs.xml");
                string query = "Update  tab_User set [Username] = '" + username + "'  ,[Password] = '" + password + "' ,[Attribut] = '" + attribut + "' where ID = " + id + "";
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
                    MessageBox.Show("Data Edit Successful");
                    UserConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else
            {
                if (id == userID )
                {
                    config = XmlDataManager.XmlConfigDataReader("configs.xml");
                    string query = "Update  tab_User set [Username] = '" + username + "'  ,[Password] = '" + password + "' ,[Attribut] = '" + attribut + "' where ID = " + id + "";
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
                        MessageBox.Show("Data Edit Successful");
                        UserConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Username already Used");
                }
               
            }
           

        }

        // Function to add UserData in the database
        public void AddUser(string username, string password, string attribut)
        {
            // check if the username already exist and return his value
            Boolean response = SearchUser(username);
            if (response == false)
            {

                config = XmlDataManager.XmlConfigDataReader("configs.xml");


                string query = "insert into  tab_User ([Username],[Password],[Attribut]) values ('" + username + "','" + password + "','" + attribut + "')";
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
                    MessageBox.Show("Data Saved Successful");
                    UserConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else
            {
                MessageBox.Show("Username already Used");
            }

        }
        // Function to remove UserData from the database
        public void RemoveUser(int id)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");

            string query = "delete from  tab_User  where ID = " + id + "";
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
                MessageBox.Show("Data Removed Successful");
                UserConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        // Function to edit UserData as simple user in the database
        public void EditAccountUser(int id, string username, string password, string newPassword, string repeatPassword)
        {
            int userID = id;
            // check if the given password are equal
            if (newPassword.Equals(repeatPassword))
            {
                // check if the username exist in the database
                if (userID != 0)
                {
                    int UseID = checkUserID(username);
                    if ((userID == UseID)||(UseID == 0))
                    {
                        config = XmlDataManager.XmlConfigDataReader("configs.xml");
                        string query = "Update  tab_User set [Username] = '" + username + "'  ,[Password] = '" + newPassword + "' where ID = " + userID + "";
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
                            MessageBox.Show("Data Edit Successful");
                            UserConnection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error " + ex);
                        }
                    }
                    else
                    {

                        MessageBox.Show("Username already Used");
                    }

                   
                }
                else
                {
                    MessageBox.Show("Wrong Password please enter the correct Password!");
                }
            }
            else
            {
                MessageBox.Show("Please enter the same Password");
            }
            

        }

        // Return the UserID when the user exists in the database
        public int ReturnUserID(string username,string password)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT ID FROM tab_User where Username = '" + username + "'and Password = '" + password + "' ";

            OleDbConnection UserConnection1 = new OleDbConnection();
            UserConnection1.ConnectionString = config.DbConnectionString;
            UserConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = UserConnection1;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = query;
            OleDbDataReader reader = cmd1.ExecuteReader();
           

            if (reader.HasRows)

            {
                reader.Read();
                string resultat = reader["ID"].ToString();
                UserConnection1.Close();
                int id = Convert.ToInt32(resultat);
                return id;
            }

            else
            {
                return 0;
            }

        }


        //Check if the given username already in the database exists.   
        public int checkUserID(string username)
        {
         
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT ID FROM tab_User where Username = '" + username + "'";

            OleDbConnection UserConnection1 = new OleDbConnection();
            UserConnection1.ConnectionString = config.DbConnectionString;
            UserConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = UserConnection1;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = query;
            OleDbDataReader reader = cmd1.ExecuteReader();


            if (reader.HasRows)

            {
                reader.Read();
                string userId = reader["ID"].ToString();
       
                UserConnection1.Close();
                int id = Convert.ToInt32(userId);

                return id;
            }

            else
            {
                return 0;
            }

        }

        // Search the connected user
        public bool Search_User_Online(UserData userdat)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            int count = 0;

            OleDbConnection LoginConnection = new OleDbConnection();
            LoginConnection.ConnectionString = config.DbConnectionString;
            LoginConnection.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = LoginConnection;
            cmd.CommandText = "SELECT * FROM tab_User where Username = '" + userdat.Username + "' and Password = '" + userdat.Password + "' and Attribut = '" + userdat.UserAttribut + "' ";
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                count++;
            }

            LoginConnection.Close();

            // Test if the given username exists in the database
            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Test_Connection_User(string benutzername)
        {
            
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            OleDbConnection LoginConnection = new OleDbConnection();
            LoginConnection.ConnectionString = config.DbConnectionString;
            LoginConnection.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = LoginConnection;
            cmd.CommandText = "SELECT BlnOnline FROM tab_User where Username = '" + benutzername + "' ";
            OleDbDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)

            {
                reader.Read();
                string userOnline = reader["BlnOnline"].ToString();

                LoginConnection.Close();
                bool UserIsOnline = Convert.ToBoolean(userOnline);

                return UserIsOnline;
            }

            else
            {
                return false;
            }
        }

    }
}
