using System.Collections.Generic;
using System.Drawing;

namespace FooderiaTycoon.GUI
{
    public class OverlayedWindow : BaseWindow
    {
        private Dictionary<(int, int), InterfaceLinker> _hitRegions;
        private bool _isMainWindow;
        private bool _isPinned;
        private bool _isInFocus;

        public OverlayedWindow(FooderiaTycoon fooderiaTycoon, int x, int y, string title, Resolution resolution, bool isMainWindow = false) : 
            base(fooderiaTycoon, x, y, title, resolution)
        {
            InitializeComponents(isMainWindow);
        }

        public OverlayedWindow(FooderiaTycoon fooderiaTycoon, int x, int y, string title, Resolution resolution, (int size, Color color) border, bool isMainWindow = false) : 
            base(fooderiaTycoon, x, y, title, resolution, border)
        {
            InitializeComponents(isMainWindow);
        }

        public OverlayedWindow(FooderiaTycoon fooderiaTycoon, int x, int y, string title, Resolution resolution, (int size, Color color) border, (int size, Color color) padding, bool isMainWindow = false) : 
            base(fooderiaTycoon, x, y, title, resolution, border, padding)
        {
            InitializeComponents(isMainWindow);
        }

        public OverlayedWindow(FooderiaTycoon fooderiaTycoon, int x, int y, string title, Resolution resolution, Grid geometryManager, bool isMainWindow = false) : 
            base(fooderiaTycoon, x, y, title, resolution, geometryManager)
        {
            InitializeComponents(isMainWindow);
        }

        public OverlayedWindow(FooderiaTycoon fooderiaTycoon, int x, int y, string title, Resolution resolution, Grid geometryManager, (int size, Color color) border, bool isMainWindow = false) : 
            base(fooderiaTycoon, x, y, title, resolution, geometryManager, border)
        {
            InitializeComponents(isMainWindow);
        }

        public OverlayedWindow(FooderiaTycoon fooderiaTycoon, int x, int y, string title, Resolution resolution, Grid geometryManager, 
            (int size, Color color) border, (int size, Color color) padding, bool isMainWindow = false) : 
            base(fooderiaTycoon, x, y, title, resolution, geometryManager, border, padding)
        {
            InitializeComponents(isMainWindow);
        }

        private void InitializeComponents(bool isMainWindow)
        {
            _isMainWindow = isMainWindow;
            _hitRegions = new Dictionary<(int, int), InterfaceLinker>();
            _isInFocus = false;
            _isPinned = false;
        }
    }
}