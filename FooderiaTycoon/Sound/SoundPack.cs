using System;
using System.Collections.Generic;
using System.Drawing;
using FooderiaTycoon.GUI;

namespace FooderiaTycoon.Sound
{
    public class SoundPack
    {
        private Dictionary<string, Music> _relation;

        public SoundPack(Dictionary<string, Music> relation)
        {
            _relation = relation;
        }

        public SoundPack(string path)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, Music> Relation => _relation;

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