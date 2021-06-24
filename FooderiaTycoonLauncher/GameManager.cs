using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Launcher
{
    public class GameManager
    {
        private Install _launcherInstall;
        private List<(Version version, Install install)> _gameInstalls;
        private string _fooderiaDownloadUrl;

        public GameManager(Install mainInstall, string fooderiaDownloadUrl)
        {
            _fooderiaDownloadUrl = fooderiaDownloadUrl;
            _launcherInstall = mainInstall;
            _gameInstalls = new List<(Version version, Install install)>();
            ScanForInstalls();
            CheckInstalls();
        }

        public string FooderiaDownloadUrl => _fooderiaDownloadUrl;

        private void ScanForInstalls()
        {
            List<string> directories = Directory.EnumerateDirectories(_launcherInstall.AppendedRegularDirectory).ToList();
            List<string> fooderiaTycoonDirectories = new List<string>();
            foreach (string directory in directories)
                if (IsFooderiaTycoonInstall(directory))
                    fooderiaTycoonDirectories.Add(directory);
            foreach (string fooderiaTycoonDirectory in fooderiaTycoonDirectories)
                _gameInstalls.Add(ParseFooderiaTycoonInstall(fooderiaTycoonDirectory));
        }

        private void CheckInstalls()
        {
            foreach ((Version version, Install install) in _gameInstalls)
                install.CheckInstall();
        }

        public bool IsVersionAvailable(Version version)
        {
            bool isAlreadyInstalled = _gameInstalls.Exists(tuple => tuple.version == version);
            bool isAvailable;
            try
            {
                string name = "FooderiaTycoon" + "_v_" + version.Major + "_" + version.Minor + "_" + version.Build;
                Install install = new Install(name, FooderiaDownloadUrl + "_v_" + version.Major + "_" + version.Minor + "_" + version.Build);
                isAvailable = true;
            }
            catch (ArgumentException e)
            {
                isAvailable = false;
            }

            return !isAlreadyInstalled && isAvailable;
        }

        public void AddVersion(Version version)
        {
            string name = "FooderiaTycoon" + "_v_" + version.Major + "_" + version.Minor + "_" + version.Build;
            string downloadUrl = FooderiaDownloadUrl + "_v_" + version.Major + "_" + version.Minor + "_" + version.Build;
            if (IsVersionAvailable(version))
                _gameInstalls.Add((version, new Install(name, downloadUrl)));
        }

        public void RemoveVersion(Version version)
        {
            (Version version, Install install) tuple = _gameInstalls.Find(tuple => version == tuple.version);
            _gameInstalls.Remove(tuple);
            tuple.install.RemoveInstall();
        }

        private bool IsFooderiaTycoonInstall(string fooderiaTycoonSupposedInstall)
        {
            Match match = Regex.Match(fooderiaTycoonSupposedInstall, "FooderiaTycoon_v_\\d_\\d\\d_\\d\\d");
            return match.Success;
        }

        public int CharToDigit(char c)
        {
            int digit;
            switch (c)
            {
                case '0':
                    digit = 0;
                    break;
                case '1':
                    digit = 1;
                    break;
                case '2':
                    digit = 2;
                    break;
                case '3':
                    digit = 3;
                    break;
                case '4':
                    digit = 4;
                    break;
                case '5':
                    digit = 5;
                    break;
                case '6':
                    digit = 6;
                    break;
                case '7':
                    digit = 7;
                    break;
                case '8':
                    digit = 8;
                    break;
                case '9':
                    digit = 9;
                    break;
                default:
                    throw new ArgumentException($"Error: expected a digit but got {c}");
            }

            return digit;
        }

        private (Version, Install) ParseFooderiaTycoonInstall(string fooderiaTycoonInstall)
        {
            int major = CharToDigit(fooderiaTycoonInstall[17]);
            int minor = CharToDigit(fooderiaTycoonInstall[19]) * 10 + CharToDigit(fooderiaTycoonInstall[20]);
            int build = CharToDigit(fooderiaTycoonInstall[22]) * 10 + CharToDigit(fooderiaTycoonInstall[23]);
            Version version = new Version(major, minor, build);
            Install install = new Install(fooderiaTycoonInstall,
                FooderiaDownloadUrl + "_v_" + major + "_" + minor + "_" + build);
            return (version, install);
        }

        private void LaunchVersion(Version version)
        {
            CheckInstalls();
            if (_gameInstalls.Exists(tuple => tuple.version == version))
            {
               int location = _gameInstalls.FindIndex(tuple => tuple.version == version);
               _gameInstalls[location].install.Launch(new string[0]);
            }
        }
    }
}