using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace Launcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private GameManager _gameManager;
        private MainView _mainView;
        private App()
        {
            _gameManager = new GameManager(new Install("Fooderia Tycoon", "http://localhost/downloads/game"),
                "https://localhost/downloads/game");
            _mainView = new MainView();
            ImageBrush firstImage = new ImageBrush(new BitmapImage());
            
            _mainView.AddImageBrush(new ImageBrush(new BitmapImage()));
            MainDisplay();
        }

        public void MainDisplay()
        {
            
        }
    }
}