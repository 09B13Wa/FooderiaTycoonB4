using System;
using System.Collections.Generic;
using System.Drawing;

namespace FooderiaTycoon.GUI
{
    public class GraphicsPack
    {
        private Dictionary<string, Bitmap> _relation;

        public GraphicsPack(Dictionary<string, Bitmap> relation)
        {
            _relation = relation;
        }

        public GraphicsPack(string path)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, Bitmap> Relation => _relation;

        public static bool IsCompatible(GraphicsPack graphicsPack)
        {
            throw new NotImplementedException();
        }

        public static bool IsCompatible(string path)
        {
            return IsCompatible(new GraphicsPack(path));
        }
    }
}