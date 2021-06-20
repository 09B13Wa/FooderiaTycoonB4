using System;
using System.Drawing;

namespace FooderiaTycoon.GUI
{
    public class WindowObject
    {
        private string _name;
        private int _id;
        private Widget _widget;
        private FooderiaTycoon _game;

        public WindowObject(string name, int id, Widget widget)
        {
            _name = name;
            _id = id;
            _widget = widget;
        }

        public string Name => _name;
        public int Id => _id;
        public Widget Widget => _widget;

        public static WindowObject CreateButton(FooderiaTycoon game, string name, int x, int y, bool isActive, InterfaceLinker interfaceLinker)
        {
            // I added "FooderiaTycoon game", to create a widget
            //TODO : id 
            Widget widget = new Widget(game, x, y, interfaceLinker, isActive);
            WindowObject windowObject = new WindowObject(name, id, widget);
            return windowObject;
        }
        
        public static WindowObject CreateButton(string name, int x, int y, bool isActive, InterfaceLinker interfaceLinker, Bitmap bitmap)
        {
            throw new NotImplementedException();
        }
        
        public static WindowObject CreateCheckMark(string name, int x, int y, bool isActive)
        {
            throw new NotImplementedException();
        }
        
        public static WindowObject CreateLabel(string name, int x, int y, bool isActive)
        {
            throw new NotImplementedException();
        }
        
        public static WindowObject CreateSlideOver(string name, int x, int y, bool isActive)
        {
            throw new NotImplementedException();
        }
        
        public static Widget CreateButtonSimple(string name, int x, int y, bool isActive)
        {
            throw new NotImplementedException();
        }
    }
}