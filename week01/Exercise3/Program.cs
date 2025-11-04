using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        // Keep playing the game as long as the user wants
        while (playAgain.ToLower() == "yes")
        {
            // Create a random number generator
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101); // 1 to 100

            int guess = -1;
            int guessCount = 0;

            Console.WriteLine("Welcome to the Guess My Number Game!");
            Console.WriteLine("I have picked a number between 1 and 100. Try to guess it!");

            // Keep looping until the guess is correct
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher!");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower!");
                }
                else
                {
                    Console.WriteLine($"You guessed it! The number was {magicNumber}.");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            // Ask if the user wants to play again
            Console.Write("Do you want to play again (yes/no)? ");
            playAgain = Console.ReadLine();
            Console.WriteLine(); // Add a blank line for spacing
        }

        Console.WriteLine("Thanks for playing! Goodbye!");
    }
}
