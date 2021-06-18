using System;
using System.Drawing;

namespace FooderiaTycoon.GUI
{
    public class WindowObject
    {
        private string _name;
        private int _id;
        private Widget _widget;

        public WindowObject(string name, int id, Widget widget)
        {
            _name = name;
            _id = id;
            _widget = widget;
        }

        public string Name => _name;

        public int Id => _id;

        public Widget Widget => _widget;

        public static WindowObject CreateButton(int x, int y, bool isActive)
        {
            throw new NotImplementedException();
        }
        
        public static WindowObject CreateButton(int x, int y, bool isActive, Bitmap bitmap)
        {
            throw new NotImplementedException();
        }
        
        public static WindowObject CreateCheckMark(int x, int y, bool isActive)
        {
            throw new NotImplementedException();
        }
        
        public static WindowObject CreateLabel(int x, int y, bool isActive)
        {
            throw new NotImplementedException();
        }
        
        public static WindowObject CreateSlideOver(int x, int y, bool isActive)
        {
            throw new NotImplementedException();
        }
        
        public static Widget CreateButtonSimple(int x, int y, bool isActive)
        {
            throw new NotImplementedException();
        }
    }
}