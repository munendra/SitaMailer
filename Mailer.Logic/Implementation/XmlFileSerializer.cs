using Mailer.Logic.Interface;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Mailer.Logic.Implementation
{
    public class XmlFileSerializer : IFileSerializer
    {
        public string Type => "Xml";

        public  T DeserializeFile<T>(string path)
        {
            path = Path.GetFullPath(path);
            if (!File.Exists(path))
            {
                throw new Exception("File not found");
            }

            var xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            var textReader = new StringReader(xmlDocument.OuterXml);
            var reader = new XmlTextReader(textReader);
            reader.Namespaces = false;
            var fileSerializer = new XmlSerializer(typeof(T));
            return (T) fileSerializer.Deserialize(reader);
        }
    }
}