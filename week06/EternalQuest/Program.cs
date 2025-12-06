// EXTRA FEATURES ADDED: ProgressGoal (large goals with gradual progress)
// and NegativeGoal (bad-habit goals that subtract points when recorded).

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();

        Console.WriteLine("Thanks for playing Eternal Quest! Press Enter to exit.");
        Console.ReadLine();
    }
}
