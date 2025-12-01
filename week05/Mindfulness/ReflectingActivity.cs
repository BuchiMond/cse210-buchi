using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _questions;

    public ReflectingActivity() : base("Reflection Activity", "This activity helps you reflect on experiences when you showed strength and resilience.")
    {
        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public override void Run()
    {
        DisplayStartingMessage();
        ShowCountDown(Duration);

        string prompt = "Think of a time when you stood up for someone else."; // Randomly selected or pre-defined
        Console.WriteLine(prompt);
        ShowCountDown(5); // Give the user time to reflect

        Random rand = new Random();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine(question);
            ShowSpinner(3); // Show spinner during pauses
        }

        DisplayEndingMessage();
    }
}
