using System;

namespace FractionApp
{
    public class Fraction
    {
        // Private attributes
        private int _top;
        private int _bottom;

        // Constructor with no parameters (1/1)
        public Fraction()
        {
            _top = 1;
            _bottom = 1;
        }

        // Constructor with one parameter (top / 1)
        public Fraction(int top)
        {
            _top = top;
            _bottom = 1;
        }

        // Constructor with two parameters (top / bottom)
        public Fraction(int top, int bottom)
        {
            _top = top;
            _bottom = bottom;
        }

        // Getter and Setter for Top
        public int GetTop()
        {
            return _top;
        }

        public void SetTop(int top)
        {
            _top = top;
        }

        // Getter and Setter for Bottom
        public int GetBottom()
        {
            return _bottom;
        }

        public void SetBottom(int bottom)
        {
            _bottom = bottom;
        }

        // Method to get fraction as string (e.g., 3/4)
        public string GetFractionString()
        {
            return $"{_top}/{_bottom}";
        }

        // Method to get decimal value (e.g., 0.75)
        public double GetDecimalValue()
        {
            return (double)_top / _bottom;
        }
    }
}
