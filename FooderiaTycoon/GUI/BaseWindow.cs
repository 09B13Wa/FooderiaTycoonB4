using System;
using System.Drawing;

namespace FooderiaTycoon.GUI
{
    public class BaseWindow
    {
        protected FooderiaTycoon _game;
        protected string _title;
        protected Resolution _resolution;
        protected (int size, Color color) _border;
        protected (int size, Color color) _padding;
        protected Grid _geometryManager;
        protected (int x, int y) _originCoordinates;

        public BaseWindow(FooderiaTycoon fooderiaTycoon, int x, int y, string title, Resolution resolution)
        {
            _title = title;
            _resolution = resolution;
            _border = (0, Color.Transparent);
            _padding = (0, Color.Transparent);
            _geometryManager = new Grid();
            _originCoordinates.x = x;
            _originCoordinates.y = y;
            _game = fooderiaTycoon;
        }

        public BaseWindow(FooderiaTycoon fooderiaTycoon, int x, int y, string title, Resolution resolution, (int size, Color color) border)
        {
            _title = title;
            _resolution = resolution;
            _border = border;
            _padding = (0, Color.Transparent);
            _geometryManager = new Grid();
            _originCoordinates.x = x;
            _originCoordinates.y = y;
            _game = fooderiaTycoon;
        }
        
        public BaseWindow(FooderiaTycoon fooderiaTycoon, int x, int y, string title, Resolution resolution, (int size, Color color) border, (int size, Color color) padding)
        {
            _title = title;
            _resolution = resolution;
            _border = border;
            _padding = padding;
            _geometryManager = new Grid();
            _originCoordinates.x = x;
            _originCoordinates.y = y;
            _game = fooderiaTycoon;
        }
        
        public BaseWindow(FooderiaTycoon fooderiaTycoon, int x, int y, string title, Resolution resolution, Grid geometryManager)
        {
            _title = title;
            _resolution = resolution;
            _border = (0, Color.Transparent);
            _padding = (0, Color.Transparent);
            _geometryManager = geometryManager;
            _originCoordinates.x = x;
            _originCoordinates.y = y;
            _game = fooderiaTycoon;
        }
        
        public BaseWindow(FooderiaTycoon fooderiaTycoon, int x, int y, string title, Resolution resolution, Grid geometryManager, (int size, Color color) border)
        {
            _title = title;
            _resolution = resolution;
            _border = border;
            _padding = (0, Color.Transparent);
            _geometryManager = geometryManager;
            _originCoordinates.x = x;
            _originCoordinates.y = y;
            _game = fooderiaTycoon;
        }
        
        public BaseWindow(FooderiaTycoon fooderiaTycoon, int x, int y, string title, Resolution resolution, Grid geometryManager, (int size, Color color) border, (int size, Color color) padding)
        {
            _title = title;
            _resolution = resolution;
            _border = border;
            _padding = padding;
            _geometryManager = geometryManager;
            _originCoordinates.x = x;
            _originCoordinates.y = y;
            _game = fooderiaTycoon;
        }

        public Grid GeometryManager => _geometryManager;
        
        public (int size, Color color) Border
        {
            get => _border;
            set => _border = value;
        }

        public (int size, Color color) Padding
        {
            get => _padding;
            set => _padding = value;
        }
        
        public string Title => _title;

        public Resolution Resolution => _resolution;

        public (int x, int y) Origin
        {
            get => _originCoordinates;
            set => SetNewOrigin(value.x, value.y);
        }

        public int XOrigin
        {
            get => _originCoordinates.x;
            set => SetNewXOrigin(value);
        }

        public int YOrigin
        {
            get => _originCoordinates.y;
            set => SetNewYOrigin(value);
        }

        public void SetNewOrigin(int x, int y)
        {
            throw new NotImplementedException();
        }

        private void SetNewXOrigin(int x)
        {
            throw new NotImplementedException();
        }
        
        private void SetNewYOrigin(int y)
        {
            throw new NotImplementedException();
        }
        
        public Bitmap Draw()
        {
            return _geometryManager.DrawGrid();
        }
    }
}