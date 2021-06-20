using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using FooderiaTycoon.Sound;

namespace FooderiaTycoon.IO
{
    public class Reader
    {
        private string _gameDirectory;
        private List<string> _textFiles;
        private List<string> _bitmapFiles;
        private List<string> _audioFiles;
        private List<string> _videoFiles;
        private Dictionary<string, Func<string, List<string>>> _readers;
        public Reader(string path)
        {
            _gameDirectory = path;
            _textFiles = new List<string>();
            _bitmapFiles = new List<string>();
            _audioFiles = new List<string>();
            _videoFiles = new List<string>();
        }
        public string GameDirectory
        {
            get => _gameDirectory;
            set => _gameDirectory = value;
        }
        public List<string> TextFiles => _textFiles;
        public List<string> BitmapFiles => _bitmapFiles;
        public List<string> MusicFiles => _audioFiles;
        public List<string> VideoFiles => _videoFiles;
        public int NumberOfTextFiles => _textFiles.Count;
        public int NumberOfBitmapFiles => _bitmapFiles.Count;
        public int NumberOfMusicFiles => _audioFiles.Count;
        public int NumberOfVideoFiles => _videoFiles.Count;
        public int NumberOfFiles => NumberOfTextFiles + NumberOfBitmapFiles + NumberOfMusicFiles + NumberOfVideoFiles;
        public List<string> AudioFiles => _audioFiles;
        public Dictionary<string, Func<string, List<string>>> Readers => _readers;

        public void AddTextFile(string path)
        {
            throw new NotImplementedException();
        }

        public void AddTextFile(List<string> paths)
        {
            foreach (string path in paths)
                AddTextFile(path);
        }
        public void RemoveTextFile(string path)
        {
            throw new NotImplementedException();
        }

        public bool IsTextFilePresent(string path)
        {
            throw new NotImplementedException();
        }
        
        public void AddBitmapFile(string path)
        {
            throw new NotImplementedException();
        }

        public void AddBitmapFile(List<string> paths)
        {
            foreach (string path in paths)
                AddTextFile(path);
        }
        public void RemoveBitmapFile(string path)
        {
            throw new NotImplementedException();
        }

        public bool IsBitmapFilePresent(string path)
        {
            throw new NotImplementedException();
        }
        
        public void AddMusicFile(string path)
        {
            throw new NotImplementedException();
        }

        public void AddMusicFile(List<string> paths)
        {
            foreach (string path in paths)
                AddTextFile(path);
        }
        public void RemoveMusicFile(string path)
        {
            throw new NotImplementedException();
        }

        public bool IsMusicFilePresent(string path)
        {
            throw new NotImplementedException();
        }
        
        public void AddVideoFile(string path)
        {
            throw new NotImplementedException();
        }

        public void AddVideoFile(List<string> paths)
        {
            foreach (string path in paths)
                AddTextFile(path);
        }
        public void RemoveVideoFile(string path)
        {
            throw new NotImplementedException();
        }

        public bool IsVideoFilePresent(string path)
        {
            throw new NotImplementedException();
        }

        public void AddReader(string extension, Func<string, List<string>> readerFunction)
        {
            throw new NotImplementedException();
        }

        public void RemoveReader(string extension, Func<string, List<string>> readerFunction)
        {
            throw new NotImplementedException();
        }

        public bool IsReaderPresent(string extension, Func<string, List<string>> readerFunction)
        {
            throw new NotImplementedException();
        }

        public List<string> ReadFile(string fileName)
        {
            throw new NotImplementedException();
        }

        public List<string> ReadFileFromPath(string path)
        {
            throw new NotImplementedException();
        }
        
        public Bitmap ReadBitmap(string musicName)
        {
            throw new NotImplementedException();
        }

        public Bitmap ReadBitmapFromPath(string path)
        {
            throw new NotImplementedException();
        }

        public Music ReadMusic(string musicName)
        {
            throw new NotImplementedException();
        }

        public Music ReadMusicFromPath(string path)
        {
            throw new NotImplementedException();
        }
        
        public List<Bitmap> ReadVideo(string musicName)
        {
            throw new NotImplementedException();
        }

        public List<Bitmap> ReadVideoFromPath(string path)
        {
            throw new NotImplementedException();
        }
    }
}