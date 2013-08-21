using Desktop.UserSettings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Desktop.Utils
{
    public class ACESettingsTools
    {
        public static void SaveSettings(string path, ACESettings settings)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ACESettings));
            StreamWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, settings);
            writer.Close();
        }

        public static ACESettings LoadSettings(string path)
        {
            ACESettings result = new ACESettings();
            XmlSerializer serializer = new XmlSerializer(typeof(ACESettings));
            FileStream fileStream = new FileStream(path, FileMode.Open);

            result = (ACESettings)serializer.Deserialize(fileStream);
            fileStream.Close();

            return result;
        }
    }
}
