using System.Collections.Generic;
using System.Runtime.InteropServices;
using FooderiaTycoon.Tools;

namespace FooderiaTycoon.Core
{
    public class Pawn : Entity
    {
        protected int _mood;
        protected List<int> _moodModifiers;
        protected string _name;

        public Pawn(string name): base()
        {
            _name = name;
            _mood = 0;
            _moodModifiers = new List<int>();
        }

        public Pawn(Square square, string name) : base(square)
        {
            _name = name;
            _mood = 0;
            _moodModifiers = new List<int>();
        }

        public Pawn(string name, List<int> moodModifiers) : base()
        {
            _name = name;
            _moodModifiers = moodModifiers;
            _mood = ComputeMood(moodModifiers);
        }

        public Pawn(Square square, string name, List<int> moodModifiers) : base(square)
        {
            _name = name;
            _moodModifiers = moodModifiers;
            _mood = ComputeMood(moodModifiers);
        }

        protected void ComputeMood()
        {
            _mood = ComputeMood(_moodModifiers);
        }

        protected static int ComputeMood(List<int> modifiers)
        {
            int mood;
            if (modifiers is null)
                mood = -1;
            else
            {
                mood = 0;
                foreach (int modifier in modifiers)
                    mood += modifier;
            }

            return mood;
        }
    }
}