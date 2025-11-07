using System;

namespace DailyJournal
{
    public class Entry
    {
        public string Date { get; }
        public string PromptText { get; }
        public string EntryText { get; }
        public string Mood { get; }

        public Entry(string date, string promptText, string entryText, string mood = "")
        {
            Date = date ?? "";
            PromptText = promptText ?? "";
            EntryText = entryText ?? "";
            Mood = mood ?? "";
        }

        public void Display()
        {
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine($"Prompt: {PromptText}");
            Console.WriteLine("Response:");
            Console.WriteLine(EntryText);
            if (!string.IsNullOrWhiteSpace(Mood))
            {
                Console.WriteLine($"Mood: {Mood}");
            }
        }
    }
}
