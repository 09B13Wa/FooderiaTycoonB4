using System;

namespace FooderiaTycoon.Tools
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

        public int GetPercentage()
        {
            return _percentageValue;
        }

        public void SetNewPercentage(int value)
        {
            _percentageValue = value;
        }
        
        public void SetNewPercentage(Percentage value)
        {
            _percentageValue = value.Percent;
        }

        public override string ToString()
        {
            return Percent + "%";
        }

        public static float ValueWithPercentageFloat(int value, int percentage)
        {
            return ValueWithPercentageFloat(value, new Percentage(percentage));
        }

        public static float ValueWithPercentageFloat(int value, Percentage percentage)
        {
            return value * percentage.ToFloat();
        }
        
        public static double ValueWithPercentageDouble(int value, int percentage)
        {
            return ValueWithPercentageDouble(value, new Percentage(percentage));
        }

        public static double ValueWithPercentageDouble(int value, Percentage percentage)
        {
            return value * percentage.ToDouble();
        }
        
        public static decimal ValueWithPercentageDecimal(int value, int percentage)
        {
            return ValueWithPercentageDecimal(value, new Percentage(percentage));
        }

        public static decimal ValueWithPercentageDecimal(int value, Percentage percentage)
        {
            return value * percentage.ToDecimal();
        }

        public float ToFloat()
        {
            return (float) (_percentageValue * 0.01);
        }

        public double ToDouble()
        {
            return _percentageValue * 0.01;
        }

        public decimal ToDecimal()
        {
            return (decimal) (_percentageValue * 0.01);
        }
    }
}