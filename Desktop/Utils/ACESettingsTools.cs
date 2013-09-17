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
        public static void SaveSettings<T>(string path, T toSerialize)
        {
            if (toSerialize == null)
            {
                return;
            }

            if (File.Exists(path) == false)
            {
                //File.Create(path);
                return;
            }

            XmlSerializer serializer = new XmlSerializer(toSerialize.GetType());
            StreamWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, toSerialize);
            writer.Close();
        }

        public static T LoadSettings<T>(string path)
        {
            T result = default(T);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            FileStream fileStream = new FileStream(path, FileMode.Open);
            if (fileStream.Length > 0)
            {
                result = (T)serializer.Deserialize(fileStream);
            }
            
            fileStream.Close();
            return result;
        }
    }
}
