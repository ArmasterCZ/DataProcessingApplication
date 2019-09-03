using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataProcessingApplication
{
    /// <summary>
    /// allow serialize and save json or xml file
    /// </summary>
    class FileSaver
    {
        public static void serialToXmlFile<T>(string FilePath, T studentToSave)
        {
            using (FileStream fs = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer formatter = new XmlSerializer(studentToSave.GetType());
                formatter.Serialize(fs, studentToSave);
            }
        }

        public static void serialToJsonFile<T>(string FilePath, T studentToSave)
        {
            using (FileStream fs = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
            {
                string jsonString = JsonConvert.SerializeObject(studentToSave, Formatting.Indented);
                byte[] bytes = Encoding.ASCII.GetBytes(jsonString);
                fs.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
