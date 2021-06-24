using System;
using System.Collections.Generic;

namespace FooderiaTycoon.Core
{
    public class Region
    {
        private List<(Square square, int subX, int subY)> _squares;
        private List<Region> _connectedRegions;
        private Map _map;
        private List<Entity> _entities;
        private (int x, int y) _regionalCordinates;
        private int _regionSize;
        private int _numberOfSquares;
        private int _numberOfEntities;

        public Region(int regionalX, int regionalY, List<(Square square, int subX, int subY)> squares)
        {
            _regionalCordinates.x = regionalX;
            _regionalCordinates.y = regionalY;
            _squares = squares;
            _numberOfSquares = squares.Count;
            _connectedRegions = new List<Region>();
            _map = new Map();
            _entities = new List<Entity>();
            _numberOfEntities = 0;
        }
        public Map Map => _map;
        
        public List<(Square square, int subX, int subY)> Squares => _squares;

        public int NumberOfEntities => _numberOfEntities;
            
        public Square this[int i] => GetSquareAt(i);
        
        public Square this[int i, int j] => GetSquareAt(i, j);
        
        public int XPos => _regionalCordinates.x;
        
        public int YPos => _regionalCordinates.y;
        
        public Square GetSquareAt(int index)
        {
            if (index >= 0 && index < _numberOfSquares)
                return _squares[index].square;
            throw new ArgumentException(
                    $"Error: expected index to be between 0 (included) and the number of squares ({_numberOfSquares}) (excluded) but got {index}");
        }

        public Square GetSquareAt(int i, int j)
        {
            Square requestedSquare = null;
            foreach ((Square square, int xPos, int yPos) square in _squares)
            {
                if (square.square.InRegionPosition.x == i && square.square.InRegionPosition.y == j)
                {
                    requestedSquare = square.square;
                    break;
                }
            }

            return requestedSquare;
        }

        public Square GetMaxHeightSquare()
        {
            
        }

        public (int, int) GetLocalCoordinatesOfSquare(Square square)
        {
            (Square square, int xPos, int yPos) foundSquare = _squares.Find((tuple => square == tuple.square));
            return (foundSquare.xPos, foundSquare.yPos);
        }
        public void Extend(Square square, int subX, int subY)
        {
            _squares.Add((square, subX, subY));
        }
        
        public void Extend(Flooring flooring, int subX, int subY)
        {
            Square squareToAdd = new Square(this, subX, subY, flooring);
            _squares.Add((squareToAdd, subX, subY));
        }
        public bool HasSomething<T>() where T : Entity
        {
            bool isPresent = false;
            for (int i = 0; !isPresent && i < NumberOfEntities; i++)
                isPresent = _entities[i] is T;
            return isPresent;
        }
    }
}