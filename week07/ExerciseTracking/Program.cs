using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create activities
        var running1 = new Running(new DateTime(2022, 11, 3), 30, 4.8);       // 4.8 km
        var cycling1 = new Cycling(new DateTime(2022, 11, 3), 45, 20);        // 20 km/h
        var swimming1 = new Swimming(new DateTime(2022, 11, 3), 60, 40);      // 40 laps

        // Put them in a list
        List<Activity> activities = new List<Activity> { running1, cycling1, swimming1 };

        // Display summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
