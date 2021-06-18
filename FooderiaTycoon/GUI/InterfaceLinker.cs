using System;
using System.Collections.Generic;

namespace FooderiaTycoon.GUI
{
    public class InterfaceLinker
    {
        private Func<OverlayedWindow, FooderiaTycoon, Dictionary<Exception, string>> _action;
        private bool _isActive;

        public InterfaceLinker()
        {
            _action = new Func<OverlayedWindow, FooderiaTycoon, Dictionary<Exception, string>>((OverlayedWindow ow, FooderiaTycoon game) => new Dictionary<Exception, string>());
            _isActive = false;
        }

        public InterfaceLinker(Func<OverlayedWindow, FooderiaTycoon, Dictionary<Exception, string>> action, bool isActive = true)
        {
            _action = action;
            _isActive = isActive;
        }

        public Func<OverlayedWindow, FooderiaTycoon, Dictionary<Exception, string>> Action => _action;

        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

        public void ChangeFunction(Func<OverlayedWindow, FooderiaTycoon, Dictionary<Exception, string>> action,
            bool isActive = true)
        {
            _action = action;
            _isActive = isActive;
        }

        public void Activate(OverlayedWindow overlayedWindow, FooderiaTycoon game)
        {
            _action.Invoke(overlayedWindow, game);
            throw new NotImplementedException();
        }
    }
}