using System;
using System.Collections;

namespace FooderiaTycoon
{
    public enum ResolutionStandard
    {
        P480,
        P600,
        P720,
        P768,
        P960,
        P1050,
        P1080,
        P1200,
        P1152,
        P1440,
        P2160,
        NHD,
        SVGA,
        XGA,
        WXGA_16_9,
        WXGA_16_10,
        HD_PLUS,
        WSXGA_PLUS,
        FHD,
        WUXGA,
        QWXGA,
        QHD,
        UHD_4K,
        OTHER
}
    public class Resolution: IComparable, IEnumerable
    {
        private int _x;
        private int _y;
        private int _frameRate;
        private double _xScaling;
        private double _yScaling;
        public int Width
        {
            get => _x;
            private set
            {
                if (value < 0)
                    throw new ArgumentException($"Error: expected positive value for X but got {value}");
                _x = value;
            }
        }
        public int Height 
        { 
            get => _y;
            private set
            {
                if (value < 0)
                    throw new ArgumentException($"Error: expected positive value for Y but got {value}");
                _y = value;
            }
        }

        public int FrameRate
        {
            get => _frameRate; 
            private set
            {
                if (value < 0)
                    throw new ArgumentException($"Error: expected positive value for FrameRate but got {value}");
                _frameRate = value;
            }
        }

        public int X
        {
            get => Width;
            private set => Width = value;
        }

        public int Y
        {
            get => Height;
            private set => Height = value;
        }

        public static Resolution DefaultResolution => new Resolution();

        public static double DefaultXScaling => DefaultResolution.ScalingX;

        public static double DefaultYScaling => DefaultResolution.ScalingY;

        public static int DefaultFrameRate => 60;
        
        
        
        public double ScalingX { get => _xScaling; private set => _xScaling = value;}
        
        public double ScalingY { get => _yScaling; private set => _yScaling = value;}

        public Resolution(int width, int height, int frameRate = 60)
        {
            Width = width;
            Height = height;
            FrameRate = frameRate;
            (ScalingX, ScalingY) = DetermineScalling(width, height);
        }

        public Resolution(ResolutionStandard standard)
        {
            throw new NotImplementedException();
        }

        public Resolution(string resolutionString)
        {
            throw new NotImplementedException();
        }

        public Resolution(Resolution resolution)
        {
            Width = resolution.Width;
            Height = resolution.Height;
            FrameRate = resolution.FrameRate;
            (ScalingX, ScalingY) = (resolution.ScalingX, resolution.ScalingY);
        }

        public Resolution()
        {
            throw new NotImplementedException();
        }

        private (double, double) DetermineScalling(int width, int height)
        {
            throw new NotImplementedException();
        }

        public static (double, double) DetermineGameScalling(FooderiaTycoon game, int width, int height)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return X + " x " + Y + "@" + FrameRate;
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Resolution firstResolution, Resolution secondResolution)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(Resolution firstResolution, Resolution secondResolution)
        {
            return !(firstResolution == secondResolution);
        }
        
        public static bool operator <(Resolution firstResolution, Resolution secondResolution)
        {
            throw new NotImplementedException();
        }

        public static bool operator >(Resolution firstResolution, Resolution secondResolution)
        {
            throw new NotImplementedException();
        }

        public static bool operator <=(Resolution firstResolution, Resolution secondResolution)
        {
            throw new NotImplementedException();
        }

        public static bool operator >=(Resolution firstResolution, Resolution secondResolution)
        {
            throw new NotImplementedException();
        }
        
        public static Resolution operator +(Resolution firstResolution, Resolution secondResolution)
        {
            throw new NotImplementedException();
        }

        public static Resolution operator -(Resolution firstResolution, Resolution secondResolution)
        {
            throw new NotImplementedException();
        }

        public static Resolution operator *(Resolution firstResolution, Resolution secondResolution)
        {
            throw new NotImplementedException();
        }

        public static Resolution operator /(Resolution firstResolution, Resolution secondResolution)
        {
            throw new NotImplementedException();
        }

        public static Resolution operator +(Resolution resolution)
        {
            return resolution;
        }

        public static ResolutionStandard DetermineResolutionStandardFromString(string standard)
        {
            throw new NotImplementedException();
        }
    }
}