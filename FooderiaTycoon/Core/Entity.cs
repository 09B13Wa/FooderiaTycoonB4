using System.Diagnostics.SymbolStore;
using System.Runtime.Remoting.Messaging;
using FooderiaTycoon.Core;

namespace FooderiaTycoon.Core
{
    public abstract class Entity
    {
        protected Region _currentRegion;
        protected Square _currentSquare;
        protected Map _currentMap;

        public Entity()
        {
            _currentSquare = null;
            _currentRegion = null;
            _currentMap = null;
        }

        public Entity(Square currentSquare)
        {
            _currentSquare = currentSquare;
            _currentRegion = _currentSquare.Region;
            _currentMap = _currentRegion.Map;
        }

        public Map Map
        {
            get => _currentMap;
            protected set => _currentMap = value;
        }

        public Region Region
        {
            get => _currentRegion;
            protected set => _currentRegion = value;
        }

        public Square Square
        {
            get => _currentSquare;
            protected set => _currentSquare = value;
        }

        public bool HasNoSquare => _currentSquare is null;

        public bool HasNoRegion => _currentRegion is null;

        public bool HasNoMap => _currentMap is null;

        public bool HasASquare => !HasNoSquare;

        public bool HasARegion => !HasNoRegion;

        public bool HasAMap => !HasNoMap;

        public (int x, int y) GlobalPosition => HasASquare ? Square.GlobalPosition : (-1, -1);

        public Region GetRegion()
        {
            return _currentRegion;
        }

        public Map GetMap()
        {
            return _currentMap;
        }

        public Square GetSquare()
        {
            return _currentSquare;
        }

        protected void SetRegion(Region newRegion)
        {
            _currentRegion = newRegion;
        }

        protected void SetSquare(Square newSquare)
        {
            _currentSquare = newSquare;
        }

        protected void SetMap(Map newMap)
        {
            _currentMap = newMap;
        }
    }
}