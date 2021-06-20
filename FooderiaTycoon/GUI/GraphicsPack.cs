using System;
using System.Collections.Generic;
using System.Drawing;

namespace FooderiaTycoon.GUI
{
    public class GraphicsPack
    {
        private Dictionary<string, Bitmap> _relation;
        private List<string> _model = new List<string>();
        private FooderiaTycoon _game;

        public GraphicsPack(FooderiaTycoon game, List<string> model, Dictionary<string, Bitmap> relation)
        {
            _relation = relation;
            _model = model;
            _game = game;
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

        private static bool BuildModel()
        {
            throw new NotImplementedException();
        }
    }
}