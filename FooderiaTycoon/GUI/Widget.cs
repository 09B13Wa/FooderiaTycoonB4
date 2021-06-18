using System;
using System.Drawing;

namespace FooderiaTycoon.GUI
{
    public class Widget
    {
        private Bitmap _image;
        private InterfaceLinker _interfaceLinker;
        private (int x, int y) _position;
        private FooderiaTycoon _game;
        private bool _isActive;

        public Widget(FooderiaTycoon game, int x, int y, InterfaceLinker interfaceLinker, bool isActive = true, Bitmap bitmap = null)
        {
            _game = game;
            _position.x = x;
            _position.y = y;
            _interfaceLinker = interfaceLinker;
            _image = bitmap;
            _isActive = isActive;
        }

        public bool HasImage => !(_image is null);

        public Bitmap Image => _image;

        public InterfaceLinker InterfaceLinker => _interfaceLinker;

        public FooderiaTycoon Game => _game;

        public bool IsActive => _isActive;

        public (int x, int y) Position
        {
            get => _position;
            set => SetNewPosition(value);
        }

        public int XPosition
        {
            get => _position.x;
            set => SetNewXPosition(value);
        }
        
        public int YPosition
        {
            get => _position.y;
            set => SetNewYPosition(value);
        }

        public void SetNewXPosition(int x)
        {
            throw new NotImplementedException();
        }

        public void SetNewYPosition(int y)
        {
            throw new NotImplementedException();
        }

        public void SetNewPosition(int x, int y)
        {
            SetNewXPosition(x);
            SetNewYPosition(y);
        }

        public void SetNewPosition((int x, int y) position)
        {
            SetNewPosition(position.x, position.y);
        }

        public void Hide()
        {
            _isActive = false;
        }

        public void Show()
        {
            _isActive = true;
        }
    }
}