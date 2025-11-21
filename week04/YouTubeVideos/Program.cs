using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold all videos
        List<Video> videos = new List<Video>();

        // ---------- Video 1 ----------
        Video video1 = new Video("Learning C# Basics", "CodeWithSara", 600);
        video1.AddComment(new Comment("Alice", "This really helped me understand classes!"));
        video1.AddComment(new Comment("John", "Very clear explanation, thanks."));
        video1.AddComment(new Comment("Musa", "Please make a video on inheritance next."));
        videos.Add(video1);

        // ---------- Video 2 ----------
        Video video2 = new Video("Top 10 Travel Destinations", "WanderWorld", 900);
        video2.AddComment(new Comment("Esther", "Now I want to travel to all of these places 😍"));
        video2.AddComment(new Comment("David", "Great editing and visuals!"));
        video2.AddComment(new Comment("Liam", "Can you do a budget travel version?"));
        video2.AddComment(new Comment("Chidi", "Love the way you explained each city."));
        videos.Add(video2);

        // ---------- Video 3 ----------
        Video video3 = new Video("Healthy Meal Prep Ideas", "FitLifeKitchen", 750);
        video3.AddComment(new Comment("Grace", "I tried the first recipe and it’s amazing."));
        video3.AddComment(new Comment("Noah", "Please share a vegetarian version too."));
        video3.AddComment(new Comment("Amina", "This makes meal prep look so easy!"));
        videos.Add(video3);

        // ---------- Video 4 (optional extra) ----------
        Video video4 = new Video("Productivity Tips for Students", "StudySmart", 820);
        video4.AddComment(new Comment("Kelvin", "The time-blocking tip changed everything for me."));
        video4.AddComment(new Comment("Ruth", "Watching this right before exams 😅"));
        video4.AddComment(new Comment("Bella", "Can you share a printable planner?"));
        videos.Add(video4);

        // Now iterate through each video and display the details
        foreach (Video video in videos)
        {
            Console.WriteLine("=======================================");
            Console.WriteLine($"Title:   {video.Title}");
            Console.WriteLine($"Author:  {video.Author}");
            Console.WriteLine($"Length:  {video.LengthInSeconds} seconds");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");
            Console.WriteLine();

            // Display each comment
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine("=======================================\n");
        }

        // Keep console open (optional, depending on environment)
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
