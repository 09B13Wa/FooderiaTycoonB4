using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;

namespace Launcher
{
    public class Install
    {
        private string _userName;
        private string _firstDirectory;
        private string _backupDirectory;
        private Computer _computer;
        private string _programName;
        private string _downloadUrl;

        public Install(string programName, string downloadUrl)
        {
            _programName = programName;
            _userName = GetOsUserName();
            _computer = new Computer();
            _firstDirectory = _computer.DefaultDirectory;
            _backupDirectory = _computer.BackupDirectory;
            _downloadUrl = downloadUrl;
            CheckDownloadUrl();
        }
        
        public Install(string programName, string downloadUrl, string firstDirectory, string backupDirectory)
        {
            _programName = programName;
            _userName = GetOsUserName();
            _computer = new Computer();
            _firstDirectory = firstDirectory;
            _backupDirectory = backupDirectory;
            _downloadUrl = downloadUrl;
            CheckDownloadUrl();
        }

        public (byte[] hashBulk, string hashStr) GenerateFileHash(string path)
        {
            byte[] hash;
            string hashStr;
            using (MD5 md5 = MD5.Create())
            {
                using (FileStream stream = File.OpenRead(path))
                {
                    hash = md5.ComputeHash(stream);
                    hashStr = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }

            return (hash, hashStr);
        }

        public static string DefaultOsLocation => new Computer().GetDefaultDirectory();
        public string OsPathSeperator => _computer.OsPathSeperator;

        public string UserName => _userName;

        public string RegularDirectory => _firstDirectory;
        public string AppendedRegularDirectory => _firstDirectory + OsPathSeperator + _programName;
        public string AppendedBackupDirectory => _firstDirectory + OsPathSeperator + _programName;

        public Computer Computer => _computer;

        public string ProgramName => _programName;
        public string GetOsUserName()
        {
            return Environment.UserName;
        }

        private bool IsDefaultInstalled()
        {
            return Directory.Exists(AppendedRegularDirectory);
        }

        private static bool AreDirectoriesEqual(string firstDirectoryPath, string secondDirectoryPath)
        {
            DirectoryInfo dir1 = new DirectoryInfo(firstDirectoryPath);  
            DirectoryInfo dir2 = new DirectoryInfo(secondDirectoryPath);  
  
            // Take a snapshot of the file system.  
            IEnumerable<FileInfo> list1 = dir1.GetFiles("*.*", SearchOption.AllDirectories);  
            IEnumerable<FileInfo> list2 = dir2.GetFiles("*.*", SearchOption.AllDirectories);  
  
            //A custom file comparer defined below  
            FileCompare myFileCompare = new FileCompare();  
  
            // This query determines whether the two folders contain  
            // identical file lists, based on the custom file comparer  
            // that is defined in the FileCompare class.  
            // The query executes immediately because it returns a bool.  
            return list1.SequenceEqual(list2, myFileCompare);
        }

        private bool IsDefaultInstallIntact()
        {
            string newDirectory = AppendedRegularDirectory + "Temp";
            InstallTo(newDirectory);
            return AreDirectoriesEqual(AppendedRegularDirectory, newDirectory);
        }
        
        private bool IsSecondaryInstallIntact()
        {
            string newDirectory = AppendedBackupDirectory + "Temp";
            InstallTo(newDirectory);
            return AreDirectoriesEqual(AppendedBackupDirectory, newDirectory);
        }

        private bool IsSecondaryInstalled()
        {
            return Directory.Exists(AppendedBackupDirectory);
        }

        public void CheckInstall()
        {
            if (!IsDefaultInstalled())
                InstallToFirst();
            else if (!IsDefaultInstallIntact())
                ReplaceFirst();
            if (!IsSecondaryInstalled())
                InstallToSecond();
            else if (!IsSecondaryInstallIntact())
                ReplaceSecond();
        }

        private void InstallToFirst()
        {
            InstallTo(_firstDirectory);
        }

        private void InstallToSecond()
        {
            InstallTo(_backupDirectory);
        }

        private void InstallTo(string target)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(_downloadUrl, target + ".zip");
            }

            ZipFile.ExtractToDirectory(target + ".zip", target);
            File.Delete(target + ".zip");
        }

        private void ReplaceFirst()
        {
            Directory.Delete(AppendedRegularDirectory);
            InstallToFirst();
        }

        private void ReplaceSecond()
        {
            Directory.Delete(AppendedBackupDirectory);
            InstallToFirst();
        }

        private void CheckDownloadUrl()
        {
            bool Test  = true;
            Uri urlCheck = new Uri(_downloadUrl);
            WebRequest request = WebRequest.Create(urlCheck);
            request.Timeout = 15000;

            WebResponse response;
            try
            {
                response = request.GetResponse();
            }
            catch (Exception)
            {
                throw new ArgumentException("That is not a valid or known URL, sorry");
            }
        }

        public void RemoveInstall()
        {
            Directory.Delete(AppendedRegularDirectory);
            Directory.Delete(AppendedBackupDirectory);
        }

        public void Launch(string[] arguments)
        {
            Process.Start("notepad", "readme.txt");

            string winpath = Environment.GetEnvironmentVariable("windir");
            string path = AppendedRegularDirectory + OsPathSeperator + _programName + ".exe";

            Process.Start(winpath + @"\Microsoft.NET\Framework\v1.0.3705\Installutil.exe", path);
        }
    }
    
    internal class FileCompare : System.Collections.Generic.IEqualityComparer<System.IO.FileInfo>  
    {  
        public FileCompare() { }  
  
        public bool Equals(System.IO.FileInfo f1, System.IO.FileInfo f2)  
        {  
            return (f1.Name == f2.Name &&  
                    f1.Length == f2.Length);  
        }  
  
        // Return a hash that reflects the comparison criteria. According to the
        // rules for IEqualityComparer<T>, if Equals is true, then the hash codes must  
        // also be equal. Because equality as defined here is a simple value equality, not  
        // reference identity, it is possible that two or more objects will produce the same  
        // hash code.  
        public int GetHashCode(System.IO.FileInfo fi)  
        {  
            string s = $"{fi.Name}{fi.Length}";
            return s.GetHashCode();  
        }  
    }  
}