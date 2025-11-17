using System;

namespace FractionApp // Now Program is inside the same namespace as Fraction
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using no-parameter constructor
            Fraction fraction1 = new Fraction();
            Console.WriteLine(fraction1.GetFractionString());
            Console.WriteLine(fraction1.GetDecimalValue());

            // Using one-parameter constructor
            Fraction fraction2 = new Fraction(5);
            Console.WriteLine(fraction2.GetFractionString());
            Console.WriteLine(fraction2.GetDecimalValue());

            // Using two-parameter constructor
            Fraction fraction3 = new Fraction(3, 4);
            Console.WriteLine(fraction3.GetFractionString());
            Console.WriteLine(fraction3.GetDecimalValue());

            // Another example
            Fraction fraction4 = new Fraction(1, 3);
            Console.WriteLine(fraction4.GetFractionString());
            Console.WriteLine(fraction4.GetDecimalValue());

            // Testing getters and setters
            fraction1.SetTop(7);
            fraction1.SetBottom(2);
            Console.WriteLine(fraction1.GetFractionString());
            Console.WriteLine(fraction1.GetDecimalValue());
        }
    }
}