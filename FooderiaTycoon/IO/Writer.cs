using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace FooderiaTycoon.IO
{
    public class Writer : IEnumerable
    {
        private string _currentDirectory;
        private Dictionary<string, Func<List<string>, string>> _paths;

        public Writer(string currentDirectory)
        {
            _currentDirectory = currentDirectory;
            _paths = new Dictionary<string, Func<List<string>, string>>();
        }

        public Writer(string currentDirectory, Dictionary<string, Func<List<string>, string>> paths)
        {
            _paths = paths;
        }
        public Writer(Writer writer)
        {
            _currentDirectory = writer.CurrentDirectory;
            _paths = new Dictionary<string, Func<List<string>, string>>();
            foreach (KeyValuePair<string, Func<List<string>, string>> keyValuePair in writer.Paths)
                _paths.Add(keyValuePair.Key, keyValuePair.Value);
        }
        
        public Writer(string currentDirectory, Writer writer)
        {
            _currentDirectory = currentDirectory;
            _paths = new Dictionary<string, Func<List<string>, string>>();
            foreach (KeyValuePair<string, Func<List<string>, string>> keyValuePair in writer.Paths)
                _paths.Add(keyValuePair.Key, keyValuePair.Value);
        }
        
        public Writer(Writer writer, Dictionary<string, Func<List<string>, string>> paths)
        {
            _currentDirectory = writer.CurrentDirectory;
            _paths = paths;
        }
        public string CurrentDirectory => _currentDirectory;
        public Dictionary<string, Func<List<string>, string>> Paths => _paths;
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void AddPath(string path, Func<List<string>, string> writer)
        {
            throw new NotImplementedException();
        }

        public void AddPath((string path, Func<List<string>, string> writer) path)
        {
            AddPath(path.path, path.writer);
        }

        public void AddPath(KeyValuePair<string, Func<List<string>, string>> keyValuePair)
        {
            AddPath(keyValuePair.Key, keyValuePair.Value);
        }

        public void RemovePath(string path)
        {
            
        }
        
        public void IsPathPresent(string path)
        {
            
        }
    }
}