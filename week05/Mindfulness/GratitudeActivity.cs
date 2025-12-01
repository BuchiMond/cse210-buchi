using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    private List<string> _prompts;

    public GratitudeActivity() : base("Gratitude Activity", "This activity helps you focus on things you're grateful for in your life.")
    {
        _prompts = new List<string>
        {
            "What are you grateful for today?",
            "Who in your life are you most grateful for?",
            "What accomplishments are you most proud of?",
            "What moments in your life are you grateful for?",
            "What is something that brought you happiness recently?"
        };
    }

    public override void Run()
    {
        DisplayStartingMessage();
        ShowCountDown(Duration);

        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        ShowCountDown(5); // Give the user time to think

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Enter something you're grateful for (or type 'done' to finish): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "done") break;
            items.Add(input);
        }

        Console.WriteLine($"You listed {items.Count} things you are grateful for.");
        DisplayEndingMessage();
    }
}
