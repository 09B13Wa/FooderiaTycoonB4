using System;
using System.Collections;
using System.Collections.Generic;

namespace FooderiaTycoon.IO
{
    public class Mod: IEnumerable
    {
        private string _name;
        private Account _developer;
        private Settings _modSettings;
        private string _location;
        private List<Mod> _dependencies;
        private FooderiaTycoon _game;
        public Mod(FooderiaTycoon game, string name, Account developer, Settings modSettings)
        {
            _game = game;
            _name = name;
            _developer = developer;
            _modSettings = modSettings;
            _location = _game.Location;
            _dependencies = new List<Mod>();
        }

        public Mod(FooderiaTycoon game, string name, Account developer, string modSettingsPath)
        {
            _game = game;
            _name = name;
            _developer = developer;
            _modSettings = Settings.CreateSettingsFromFile(modSettingsPath);
            _location = _game.Location;
            _dependencies = new List<Mod>();
        }
        
        public Mod(FooderiaTycoon game, string name, Account developer, Settings modSettings, string location)
        {
            _game = game;
            _name = name;
            _developer = developer;
            _modSettings = modSettings;
            _location = location;
            _dependencies = new List<Mod>();
        }

        public Mod(FooderiaTycoon game, string name, Account developer, string modSettingsPath, string location)
        {
            _game = game;
            _name = name;
            _developer = developer;
            _modSettings = Settings.CreateSettingsFromFile(modSettingsPath);
            _location = location;
            _dependencies = new List<Mod>();
        }
        
        public Mod(FooderiaTycoon game, string name, Account developer, Settings modSettings, List<Mod> dependencies)
        {
            _game = game;
            _name = name;
            _developer = developer;
            _modSettings = modSettings;
            _location = _game.Location;
            _dependencies = dependencies;
        }

        public Mod(FooderiaTycoon game, string name, Account developer, string modSettingsPath, List<Mod> dependencies)
        {
            _game = game;
            _name = name;
            _developer = developer;
            _modSettings = Settings.CreateSettingsFromFile(modSettingsPath);
            _location = _game.Location;
            _dependencies = dependencies;
        }
        
        public Mod(FooderiaTycoon game, string name, Account developer, Settings modSettings, string location, List<Mod> dependencies)
        {
            _game = game;
            _name = name;
            _developer = developer;
            _modSettings = modSettings;
            _location = _game.Location;
            _dependencies = new List<Mod>();
        }

        public Mod(FooderiaTycoon game, string name, Account developer, string modSettingsPath, string location, List<Mod> dependencies)
        {
            _game = game;
            _name = name;
            _developer = developer;
            _modSettings = Settings.CreateSettingsFromFile(modSettingsPath);
            _location = location;
            _dependencies = dependencies;
        }

        public string Name => _name;
        public Account Developer => _developer;
        public Settings ModSettings => _modSettings;
        public string Location => _location;
        public List<Mod> Dependencies => _dependencies;
        
        public static List<Mod> ReadModDependencies(string file)
        {
            throw new NotImplementedException();
        }

        public bool IsModRequired(Mod mod)
        {
            throw new NotImplementedException();
        }

        public Mod DownloadMod(string modLink)
        {
            throw new NotImplementedException();
        }

        public static bool IsModActive(Mod mod)
        {
            throw new NotImplementedException();
        }

        public static bool AreDependenciesCompatible(List<Mod> firstModList, List<Mod> secondModList)
        {
            throw new NotImplementedException();
        }

        public void ReloadWithChanges()
        {
            throw new NotImplementedException();
        }

        private void CheckForCircularDependencies()
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public bool UploadMod(string modPath)
        {
            throw new NotImplementedException();
        }
    }
}