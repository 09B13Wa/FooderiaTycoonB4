using System;

namespace FooderiaTycoon.Core
{
    public enum Flooring
    {
        Pavement,
        Asphalt,
        Grass,
        Floor
    }
    
    public class Square
    {
        private Region _region;
        private (int x, int y) _globalPosition;
        private (int x, int y) _inRegionPosition;
        private Entity _entity;
        private Flooring _flooring;
        public Square(Region region, int inRegionX, int inRegionY, Flooring flooring = Flooring.Floor)
        {
            _region = region;
            _inRegionPosition.x = inRegionX;
            _inRegionPosition.y = inRegionY;
            _globalPosition.x = _inRegionPosition.x + region.XPos;
            _globalPosition.y = _inRegionPosition.y + region.YPos;
            _flooring = flooring;
        }
        
        public Square(Region region, (int x, int y) inRegionPosition, Flooring flooring = Flooring.Floor)
        {
            _region = region;
            _inRegionPosition.x = inRegionPosition.x;
            _inRegionPosition.y = inRegionPosition.y;
            _globalPosition.x = _inRegionPosition.x + region.XPos;
            _globalPosition.y = _inRegionPosition.y + region.YPos;
            _flooring = flooring;
        }
        
        public Square(Region region, int inRegionX, int inRegionY, Entity entity, Flooring flooring = Flooring.Floor)
        {
            _region = region;
            _inRegionPosition.x = inRegionX;
            _inRegionPosition.y = inRegionY;
            _globalPosition.x = _inRegionPosition.x + region.XPos;
            _globalPosition.y = _inRegionPosition.y + region.YPos;
            _flooring = flooring;
            _entity = entity;
        }
        
        public Square(Region region, (int x, int y) inRegionPosition, Entity entity, Flooring flooring = Flooring.Floor)
        {
            _region = region;
            _inRegionPosition.x = inRegionPosition.x;
            _inRegionPosition.y = inRegionPosition.y;
            _globalPosition.x = _inRegionPosition.x + region.XPos;
            _globalPosition.y = _inRegionPosition.y + region.YPos;
            _flooring = flooring;
            _entity = entity;
        }

        public Region Region
        {
            get => _region;
            set => _region = value;
        }

        public (int x, int y) InRegionPosition
        {
            get => _inRegionPosition;
            set => _inRegionPosition = value;
        }

        public Entity Entity
        {
            get => _entity;
            set => _entity = value;
        }

        public Flooring Flooring
        {
            get => _flooring;
            set => _flooring = value;
        }

        public (int x, int y) GlobalPosition => _globalPosition;

        private void ChangeRegion(Region newRegion)
        {
            _region = newRegion;
            _inRegionPosition = newRegion.GetLocalCoordinatesOfSquare(this);
        }

        public static bool AreSquaresContentEqual(Square firstSquare, Square secondSquare)
        {
            return firstSquare.Entity.Equals(secondSquare.Entity);
        }

        public static bool ArePositionsEqual((int x, int y) firstPosition, (int x, int y) secondPosition)
        {
            return firstPosition.x == secondPosition.x && firstPosition.y == secondPosition.y;
        }
        public static bool AreTheSameGlobalCoordinates(Square firstSquare, Square secondSquare)
        {
            return ArePositionsEqual(firstSquare.GlobalPosition, secondSquare.GlobalPosition);
        }
        
        public static bool AreTheSameInRegionCoordinates(Square firstSquare, Square secondSquare)
        {
            return ArePositionsEqual(firstSquare.InRegionPosition, secondSquare.InRegionPosition);
        }

        public static bool operator ==(Square firstSquare, Square secondSquare)
        {
            bool areEqual;
            if (firstSquare is null && secondSquare is null)
                areEqual = true;
            else if (firstSquare is null || secondSquare is null)
                areEqual = false;
            else
                areEqual = firstSquare.Region.Equals(secondSquare.Region) && AreTheSameGlobalCoordinates(firstSquare, secondSquare);
            return areEqual;
        }

        public static bool operator !=(Square firstSquare, Square secondSquare)
        {
            return !(firstSquare == secondSquare);
        }
    }
}