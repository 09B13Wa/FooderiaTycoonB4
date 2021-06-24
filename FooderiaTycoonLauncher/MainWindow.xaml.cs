using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private MainView _mainView;
        public MainWindow()
        {
            _mainView = new MainView();
            _mainView.AddImageBrush(new ImageBrush(new BitmapImage(new Uri("ImageSource = \"FooderiaTycoonLogo.png\""))));
            _mainView.AddImageBrush(new ImageBrush(new BitmapImage(new Uri("ImageSource = \"vv.png\""))));
            _mainView.AddImageBrush(new ImageBrush(new BitmapImage(new Uri("ImageSource = \"FooderiaTycoonLogo.png\""))));
            _mainView.AddImageBrush(new ImageBrush(new BitmapImage(new Uri("ImageSource = \"vv.png\""))));
            InitializeComponent();
        }
    }
}