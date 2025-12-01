using System;

class Program
{
    static void Main(string[] args)
    {
        // I added a new Gratitude Activiyt to prompt users to reflect on things they are grateful for. 
        // It allowing users to list their responses witin a set duration. 


        while (true)
        {
            Console.Clear();
            Console.WriteLine("Select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflection Activity");
            Console.WriteLine("4. Gratitude Activity"); // Added new option for Gratitude Activity
            Console.WriteLine("5. Exit");

            int choice = int.Parse(Console.ReadLine());

            Activity activity = choice switch
            {
                1 => new BreathingActivity(),
                2 => new ListingActivity(),
                3 => new ReflectingActivity(),
                4 => new GratitudeActivity(), // Added new activity for Gratitude
                5 => null,
                _ => null
            };

            if (activity == null) break;

            activity.Run();
        }
    }
}
