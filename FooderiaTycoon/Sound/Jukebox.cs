using System;
using System.Collections.Generic;
using FooderiaTycoon.GUI;
using FooderiaTycoon.Tools;

namespace FooderiaTycoon.Sound
{
    public class Jukebox
    {
        private List<Music> _queue;
        private string _name;
        private int _currentIndex;
        private Percentage _musicVolume;
        private Percentage _effectsVolume;
        private List<(List<Music> style, string name)> _styles;
        private int _queueSize;
        private bool _playing = true;
        private OverlayedWindow _jukeboxGui;
        private OverlayedWindow _programGui;

        public Jukebox(string name, bool playing = false)
        {
            InitializeComponents(name, new List<Music>(), new Percentage(50), new Percentage(50), 
                new List<(List<Music> style, string name)>(), playing);
        }

        public Jukebox(string name, List<Music> queue, bool playing = false)
        {
            InitializeComponents(name, queue, new Percentage(50), new Percentage(50), 
                new List<(List<Music> style, string name)>(), playing);
        }
        
        public Jukebox(string name, List<Music> queue, Percentage musicVolume, bool playing = false)
        {
            InitializeComponents(name, queue, musicVolume, new Percentage(50), 
                new List<(List<Music> style, string name)>(), playing);
        }
        
        public Jukebox(string name, List<Music> queue, Percentage musicVolume, Percentage effectsVolume, bool playing = false)
        {
            InitializeComponents(name, queue, musicVolume, effectsVolume, 
                new List<(List<Music> style, string name)>(), playing);
        }
        
        public Jukebox(string name, List<Music> queue, Percentage musicVolume, Percentage effectsVolume, 
            List<(List<Music> style, string name)> styles, bool playing = false)
        {
            InitializeComponents(name, queue, musicVolume, effectsVolume, styles, playing);
        }

        public string Name => _name;
        public List<Music> Queue => _queue;
        public int NumberOfTracksInQueue => _queueSize;
        public Music CurrentMusic => _queueSize == 0 ? null : _queue[_currentIndex];
        public int CurrentIndex => _currentIndex;
        public int CurrentTrack => CurrentIndex;
        public string CurrentTrackStr => TrackNumberToStr();
        public Percentage MusicVolume
        {
            get => GetMusicVolume();
            set => SetNewMusicVolume(value);
        }
        public Percentage EffectsVolume
        {
            get => GetMusicVolume();
            set => SetNewMusicVolume(value);
        }
        public int MusicVolumeValue
        {
            get => GetMusicVolume().Percent;
            set => SetNewMusicVolume(value);
        }
        public int EffectsVolumeValue
        {
            get => GetMusicVolume().Percent;
            set => SetNewMusicVolume(value);
        }
        public List<(List<Music> style, string name)> Styles => _styles;
        public OverlayedWindow MainGuiWindow => _jukeboxGui;
        public OverlayedWindow ProgramGuiWindow => _programGui;
        public bool IsPlying => _playing;

        private void InitializeComponents(string name, List<Music> queue, Percentage musicVolume,
            Percentage effectsVolume, List<(List<Music> style, string name)> styles, bool playing)
        {
            CheckPercentage(musicVolume);
            CheckPercentage(effectsVolume);
            _name = name;
            _queue = queue;
            _currentIndex = 0;
            _musicVolume = musicVolume;
            _effectsVolume = effectsVolume;
            _styles = styles;
            _queueSize = queue.Count;
            _playing = playing;
            _jukeboxGui = GenerateMusicGuiWindow();
            _programGui = GenerateMusicProgramSelectionWindow();
        }

        private string TrackNumberToStr()
        {
            return CurrentTrackStr;
        }

        private void CheckPercentage(int value)
        {
            if (value < 0 || value > 100)
                throw new ArgumentException($"Error: expected a volume between 0 and 100 but got {value}");
        }
        
        private void CheckPercentage(Percentage value)
        {
            if (value.Percent < 0 || value.Percent > 100)
                throw new ArgumentException($"Error: expected a volume between 0 and 100 but got {value.Percent}");
        }

        public Percentage GetMusicVolume()
        {
            return _musicVolume;
        }
        
        public int GetMusicVolumeValue()
        {
            return _musicVolume.Percent;
        }

        public void SetNewMusicVolume(int percentage)
        {
            CheckPercentage(percentage);
            _musicVolume.SetNewPercentage(percentage);
        }
        
        public void SetNewMusicVolume(Percentage percentage)
        {
            CheckPercentage(percentage);
            _musicVolume.SetNewPercentage(percentage);
        }
        
        public Percentage GetEffectsVolume()
        {
            return _effectsVolume;
        }
        
        public int GetEffectsVolumeValue()
        {
            return _effectsVolume.Percent;
        }

        public void SetNewEffectsVolume(int percentage)
        {
            CheckPercentage(percentage);
            _effectsVolume.SetNewPercentage(percentage);
        }
        
        public void SetNewEffectsVolume(Percentage percentage)
        {
            CheckPercentage(percentage);
            _effectsVolume.SetNewPercentage(percentage);
        }
        public void Rename(string newName)
        {
            _name = newName;
        }

        public void AddMusic(Music music)
        {
            _queue.Add(music);
        }

        public void AddMusic(Music music, int index)
        {
            if (index >= 0 && index <= _queueSize)
                _queue.Insert(index, music);
            else
                throw new IndexOutOfRangeException(
                    $"Error: expected index between 0 (included) and the queue size (included)({_queueSize} but got {index}");
        }

        public void RemoveMusic(Music music)
        {
            _queue.Remove(music);
        }

        public void ChangeSpotsMusic(Music music, int newIndex)
        {
            RemoveMusic(music);
            for (int i = 0; i < _queueSize; i += 1)
            {
                if (i == newIndex)
                {
                    _queue[i] = music;
                }
            }
        }

        public void ChangeSpotsMusic(int oldIndex, int newIndex)
        {
            Music music = _queue[oldIndex];
            ChangeSpotsMusic(music, newIndex);
        }

        public List<int> FindMusicLocation(Music music)
        {
            List<int> list = new List<int>();
            int i = 0;
            foreach (Music musics in _queue)
            {
                if (music == musics)
                {
                    list.Add(i);
                    return list;
                }
                else
                {
                    i += 1;
                }
            }

            return list;
        }

        public int FindFirstOcurrance(Music music)
        {
            for (int i = 0; i < _queueSize; i += 1)
            {
                if (music == _queue[i])
                {
                    return i;
                }
            }

            return -1;
        }

        public int FindLastOccurance(Music music)
        {
            for (int i = _queueSize; i > -1; i -= 1)
            {
                if (music == _queue[i])
                {
                    return i;
                }
            }

            return -1;
        }

        public bool IsMusicInQueue(Music music)
        {
            foreach (Music musics in _queue)
            {
                if (music == musics)
                {
                    return true;
                }
            }

            return false;
        }

        public void NewStyle(string name, List<Music> newStyle)
        {
            
        }
        
        public void NewStyle(List<Music> newStyle, string name)
        {
            NewStyle(name, newStyle);
        }

        public void RemoveStyle(List<Music> style)
        {
            
            for (int i = 0; i < _styles.Count; i += 1)
            {
                if (_styles[i].style == style)
                {
                    _styles.Remove(_styles[i]);
                }
            }
            
        }
        
        public void RemoveStyle(string name)
        {
            for (int i = 0; i < _styles.Count; i += 1)
            {
                if (_styles[i].name == name)
                {
                    _styles.Remove(_styles[i]);
                }
            }
        }
        
        public void RemoveStyle(List<Music> style, string name)
        {
            RemoveStyle(name);
            
        }
        
        public void RemoveStyle(string name, List<Music> style)
        {
            RemoveStyle(name);
            
        }

        public int FindStyle(List<Music> style)
        {
            for (int i = 0; i < _styles.Count; i += 1)
            {
                if (_styles[i].style == style)
                {
                    return i;
                }
            }

            return -1;

        }
        
        public int FindStyle(string name)
        {
            for (int i = 0; i < _styles.Count; i += 1)
            {
                if (_styles[i].name == name)
                {
                    return i;
                }
            }

            return -1;
        }
        
        public int FindStyle(List<Music> style, string name)
        {
            return FindStyle(name);
        }
        
        public int FindStyle(string name, List<Music> musics)
        {
            return FindStyle(name);
        }

        public bool IsStyleAlreadyIn(string name)
        {
            return FindStyle(name) != -1;
        }
        
        public bool IsStyleAlreadyIn(List<Music> style)
        {
            return FindStyle(style) != -1;
        }
        
        public bool IsStyleAlreadyIn(string name, List<Music> style)
        {
            return IsStyleAlreadyIn(name);
        }

        public bool IsStyleAlreadyIn(List<Music> style, string name)
        {
            return IsStyleAlreadyIn(name);
        }

        public void StartButton()
        {
            _playing = true;
        }
        
        public void StopButton()
        {
            _playing = false;
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Next()
        {
            throw new NotImplementedException();
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        public void Program()
        {
            throw new NotImplementedException();
        }

        private OverlayedWindow GenerateMusicProgramSelectionWindow()
        {
            throw new NotImplementedException();
        }

        private OverlayedWindow GenerateMusicGuiWindow()
        {
            throw new NotImplementedException();
        }
        
        public void Previous()
        {
            throw new NotImplementedException();
        }

        public void Play()
        {
            throw new NotImplementedException();
        }
    }
}