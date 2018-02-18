using System.IO;
using System.Xml.Serialization;

namespace DataManagerSystem.Configs
{
    public class XmlDataManager
    {
        //xml data writer
        public static void XmlDataWriter(object obj, string filename)
        {
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(filename);
            sr.Serialize(writer, obj);
            writer.Close();
        }

        //Userdata xml reader
        public static UserData XmlUserDataReader(string filename)
        {
            UserData obj = new UserData();
            XmlSerializer xs = new XmlSerializer(typeof(UserData));
            FileStream reader = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            obj = (UserData)xs.Deserialize(reader);
            reader.Close();
            return obj;
        }

        //Userdata xml reader
        public static SuperUserData XmlSuperUserDataReader(string filename)
        {
            SuperUserData obj = new SuperUserData();
            XmlSerializer xs = new XmlSerializer(typeof(SuperUserData));
            FileStream reader = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            obj = (SuperUserData)xs.Deserialize(reader);
            reader.Close();
            return obj;
        }

        //Configs xml reader
        public static ConfigData XmlConfigDataReader(string filename)
        {
            ConfigData obj = new ConfigData();
            XmlSerializer xs = new XmlSerializer(typeof(ConfigData));
            FileStream reader = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            obj = (ConfigData)xs.Deserialize(reader);
            reader.Close();
            return obj;
        }
    }
}
