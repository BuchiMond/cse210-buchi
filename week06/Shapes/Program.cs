using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Test the individual shapes first
        Square sq = new Square("Blue", 4);
        Console.WriteLine($"Square Colour: {sq.GetColor()}");
        Console.WriteLine($"Square Area: {sq.GetArea()}");

        Rectangle rec = new Rectangle("Red", 5, 3);
        Console.WriteLine($"Rectangle Colour: {rec.GetColor()}");
        Console.WriteLine($"Rectangle Area: {rec.GetArea()}");

        Circle cir = new Circle("Green", 2.5);
        Console.WriteLine($"Circle Colour: {cir.GetColor()}");
        Console.WriteLine($"Circle Area: {cir.GetArea()}");

        Console.WriteLine();

        // Now using a List<Shape>
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("Yellow", 6));
        shapes.Add(new Rectangle("Purple", 10, 4));
        shapes.Add(new Circle("Orange", 3));

        Console.WriteLine("Shapes in the list:");
        foreach (Shape s in shapes)
        {
            Console.WriteLine($"Colour: {s.GetColor()}, Area: {s.GetArea()}");
        }
    }
}
