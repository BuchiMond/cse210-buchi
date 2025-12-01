using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by guiding you through deep breathing.")
    { }

    public override void Run()
    {
        DisplayStartingMessage();
        ShowCountDown(Duration);

        string[] breaths = { "Breathe in...", "Breathe out..." };
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        int breathCount = 0;

        while (DateTime.Now < endTime)
        {
            Console.WriteLine(breaths[breathCount % 2]);
            ShowCountDown(5); // Pause for 5 seconds between breaths
            breathCount++;
        }

        DisplayEndingMessage();
    }
}
