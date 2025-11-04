using System;

class Program
{
    static void Main(string[] args)
    {
        // Step 1: Display welcome message
        DisplayWelcome();

        // Step 2: Ask for user's name and store it
        string userName = PromptUserName();

        // Step 3: Ask for user's favourite number and store it
        int userNumber = PromptUserNumber();

        // Step 4: Calculate the square of that number
        int squaredNumber = SquareNumber(userNumber);

        // Step 5: Display the result using user's name and squared number
        DisplayResult(userName, squaredNumber);
    }

    // Function 1: Display welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Function 2: Ask for and return user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Function 3: Ask for and return user's favourite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // Function 4: Return the square of the given number
    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    // Function 5: Display user's name and squared number
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}
