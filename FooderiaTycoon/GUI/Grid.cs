using System;
using System.Collections.Generic;
using System.Drawing;

namespace FooderiaTycoon.GUI
{
    public class Grid
    {
        private List<int> _lines;
        private List<int> _columns;
        private List<(int x, int y, WindowObject bitmap)> _objects;
        private int _maxX;
        private int _maxY;
        private bool _isDynamic;

        public Grid(int maxX, int maxY, bool isDynamic = true)
        {
            _lines = new List<int>();
            _columns = new List<int>();
            _isDynamic = isDynamic;
            _objects = new List<(int x, int y, WindowObject bitmap)>();
            _maxX = maxX;
            _maxY = maxY;
        }
        
        public Grid(bool isDynamic = true)
        {
            _lines = new List<int>();
            _columns = new List<int>();
            _isDynamic = isDynamic;
            _objects = new List<(int x, int y, WindowObject bitmap)>();
            _maxX = -1;
            _maxY = -1;
        }

        public Grid(Grid gridToDeepCopy)
        {
            throw new NotImplementedException();
        }

        public Grid(List<int> lines, List<int> columns, List<(int x, int y, WindowObject bitmap)> objects = null)
        {
            _lines = lines;
            _columns = columns;
            _objects = objects ?? new List<(int x, int y, WindowObject bitmap)>();
        }

        public int Width => MaxX;
        public int X => MaxX;
        public int MaxX => _isDynamic ? _maxX : -1;
        
        public int Height => MaxY;
        public int Y => MaxY;
        public int MaxY => _isDynamic ? _maxY : -1;
        public (int, int) Max => _isDynamic ? (_maxX, _maxY) : (-1, -1);

        public (int, int) Dimension => Max;

        public bool IsDynamic => _isDynamic;

        public int NumberOfLines => _lines.Count;

        public int NumberOfColumns => _columns.Count;
        
        public WindowObject this[int x, int y] 
        {
            get => GetObjectAt(x, y);
            set => AddElement(x, y, value);
        }
        
        
        public void AddElement(int x, int y, WindowObject bitmap)
        {
            throw new NotImplementedException();
        }

        public void AddElement(WindowObject windowObject)
        {
            AddElement(0, 0, windowObject);
        }

        public bool IsGridSpaceOccupied(int x, int y)
        {
            throw new NotImplementedException();
        }

        public bool IsGridSpaceOccupied()
        {
            return IsGridSpaceOccupied(0, 0);
        }

        public void AddColumns(int number)
        {
            throw new NotImplementedException();
        }

        public void AddLines(int number)
        {
            throw new NotImplementedException();
        }

        public void AddSpace(int lines, int columns)
        {
            AddLines(lines);
            AddColumns(columns);
        }
        
        public void SetNumberOfColumns(int number)
        {
            throw new NotImplementedException();
        }

        public void SetNumberOfLines(int number)
        {
            throw new NotImplementedException();
        }

        public void SetSpace(int lines, int columns)
        {
            AddLines(lines);
            AddColumns(columns);
        }

        public (int x, int y) FindObject(WindowObject windowObject)
        {
            throw new NotImplementedException();
        }

        public bool IsObjectThere(WindowObject windowObject)
        {
            (int x, int y) = FindObject(windowObject);
            return x != -1 || y != -1;
        }

        public bool DoesColumnExist(int column)
        {
            throw new NotImplementedException();
        }

        public bool DoesLineExist(int line)
        {
            throw new NotImplementedException();
        }

        public bool DoesSquareExist(int line, int column)
        {
            return DoesLineExist(line) && DoesColumnExist(column);
        }

        public WindowObject GetObjectAt(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Bitmap DrawGrid()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public List<(int x, int y, WindowObject windowObject)> GetAllObjectsInGridWithCoordinates()
        {
            return _objects;
        }

        public List<WindowObject> GetAllObjects()
        {
            List<WindowObject> windowObjects = new List<WindowObject>();
            foreach ((int x, int y, WindowObject windowObject) in _objects)
                windowObjects.Add(windowObject);
            return windowObjects;
        }

        public List<int> GetLinesDimensions()
        {
            return _lines;
        }

        public List<int> GetColumnDimensions()
        {
            return _columns;
        }

        public List<WindowObject> GetAllObjectsOnLine(int line)
        {
            throw new NotImplementedException();
        }
        
        public List<WindowObject> GetAllObjectsOnColumn(int column)
        {
            throw new NotImplementedException();
        }

        public WindowObject[,] ToMatrix()
        {
            throw new NotImplementedException();
        }
    }
}