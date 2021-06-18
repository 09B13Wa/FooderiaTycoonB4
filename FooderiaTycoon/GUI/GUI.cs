using System;
using System.Collections.Generic;

namespace FooderiaTycoon.GUI
{
    public class GUI
    {
        private OverlayedWindow _window;
        private OverlayedWindow _exitWindow;
        private List<Caster> _casters;
        private FooderiaTycoon _game;
        private List<Widget> _widgets;
        private List<OverlayedWindow> _overlayedWindows;
        private Resolution _mainResolution;
        private GraphicsPack _graphicsPack;

        public GUI()
        {
            throw new NotImplementedException();
        }

        public GUI(GraphicsPack graphicsPack)
        {
            throw new NotImplementedException();
        }

        public BaseWindow MainWindow => _window;
        public BaseWindow ExitWindow => _exitWindow;
        public List<Caster> Casters => _casters;
        public FooderiaTycoon Game => _game;
        public List<Widget> Widgets => _widgets;
        public List<OverlayedWindow> OverlayedWindows => _overlayedWindows;
        public Resolution Resolution => _mainResolution;
        public GraphicsPack GraphicsPack => _graphicsPack;

        public void ChangeGraphicsPack()
        {
            throw new NotImplementedException();
        }

        public void ChangeGraphicsPack(GraphicsPack graphicsPack)
        {
            throw new NotImplementedException();
        }

        public void ExitAttempt()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }
    }
}