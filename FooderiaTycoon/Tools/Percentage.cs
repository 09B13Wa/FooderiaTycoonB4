using System;

namespace FooderiaTycoon
{
    public struct Percentage
    {
        private int _percentageValue;
        
        public int Percent
        {
            get => _percentageValue;
            set
            {
                CheckPercentage(value);
                _percentageValue = value;
            }
        }

        public Percentage(int percentageValue)
        {
            _percentageValue = percentageValue;
            CheckPercentage(_percentageValue);
        }

        private void CheckPercentage(int percentageValue)
        {
            if (percentageValue < 0)
                throw new ArgumentException($"Error: expected positive value for percentage but got {percentageValue}");
        }

        public override string ToString()
        {
            return Percent + "%";
        }
    }
}