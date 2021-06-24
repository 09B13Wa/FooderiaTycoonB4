using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;
using System.Xml.Linq;

namespace FooderiaTycoon.IO
{
    public class Settings
    {
        private List<(string name, XDocument xDocument)> _xmlDocuments;
        private Dictionary<int, List<(HashSet<XmlAttribute> attributes, string kind, List<object> returnTypes)>> _parser;
        private string _homeDirectory;

        public Settings(string homeDirectory)
        {
            _homeDirectory = homeDirectory;
            _xmlDocuments = new List<(string name, XDocument xDocument)>();
            _parser = new Dictionary<int, List<(HashSet<XmlAttribute> attributes, string kind, List<object> returnTypes)>>();
            AddXmlDocuments(homeDirectory);
        }
        
        public Settings(string homeDirectory, Dictionary<int, List<(HashSet<XmlAttribute> attributes, string kind, List<object> returnTypes)>> parser)
        {
            _homeDirectory = homeDirectory;
            _xmlDocuments = new List<(string name, XDocument xDocument)>();
            _parser = parser;
            AddXmlDocuments(homeDirectory);
        }
        public List<(string name, XDocument xDocument)> XmlDocuments => _xmlDocuments;
        public Dictionary<int, List<(HashSet<XmlAttribute> attributes, string kind, List<object> returnTypes)>> Parser => _parser;
        public string HomeDirectory => _homeDirectory;
        
        public void AddXmlDocuments(string path)
        {
            IEnumerable<string> files = Directory.EnumerateFiles(_homeDirectory, "*.xml");
            foreach (string file in files)
            {
                StreamReader reader = new StreamReader(file);
                string fileContents = reader.ReadToEnd();
                XDocument xDocument = XDocument.Parse(fileContents);
                reader.Close();
                _xmlDocuments.Add((file, xDocument));
            }
        }
        public void AddXmlDocuments(List<(string, XDocument)> xDocuments)
        {
            _xmlDocuments.AddRange(xDocuments);
        }

        public void RemoveXmlDocument(string path)
        {
            throw new NotImplementedException();
        }

        public void RemoveXmlDocument(XDocument xmlDocument)
        {
            throw new NotImplementedException();
        }

        public bool IsXmlDocumentPresent(XDocument xDocument)
        {
            throw new NotImplementedException();
        }

        public bool IsXmlDocumentPresent(string xDocument)
        {
            throw new NotImplementedException();
        }

        public (HashSet<XmlAttribute>, string kind, List<object> returnTypes) GetParser(string kind)
        {
            throw new NotImplementedException();
        }

        public bool DoesParserExist(string kind)
        {
            throw new NotImplementedException();
        }

        public static Settings CreateSettingsFromFile(string path)
        {
            throw new NotImplementedException();
        }
    }
}