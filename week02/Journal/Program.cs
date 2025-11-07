using System;
// To show creativity, I added "Mood" in the journal entry.
namespace DailyJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            var journal = new Journal();
            var promptGen = new PromptGenerator();

            Console.WriteLine("Welcome to the Journal Program!");
            bool running = true;
            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("Please select one of the following choices:");
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Load");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Quit");
                Console.Write("What would you like to do? ");

                string choice = Console.ReadLine()?.Trim();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                    case "Write":
                    case "write":
                        WriteEntry(journal, promptGen);
                        break;

                    case "2":
                    case "Display":
                    case "display":
                        journal.DisplayAll();
                        break;

                    case "3":
                    case "Load":
                    case "load":
                        Console.Write("Enter filename to load from: ");
                        string loadFile = Console.ReadLine();
                        try
                        {
                            journal.LoadFromFile(loadFile);
                            Console.WriteLine($"Loaded journal from '{loadFile}'.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Failed to load file: {ex.Message}");
                        }
                        break;

                    case "4":
                    case "Save":
                    case "save":
                        Console.Write("Enter filename to save to: ");
                        string saveFile = Console.ReadLine();
                        try
                        {
                            journal.SaveToFile(saveFile);
                            Console.WriteLine($"Saved journal to '{saveFile}'.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Failed to save file: {ex.Message}");
                        }
                        break;

                    case "5":
                    case "Quit":
                    case "quit":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter 1–5.");
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
        }

        static void WriteEntry(Journal journal, PromptGenerator promptGen)
        {
            string prompt = promptGen.GetRandomPrompt();
            Console.WriteLine(prompt);
            Console.WriteLine();
            Console.Write("Your response: ");
            string response = Console.ReadLine();

            Console.Write("Mood (optional, e.g. happy, tired): ");
            string mood = Console.ReadLine();

            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var entry = new Entry(date, prompt, response, mood);
            journal.AddEntry(entry);

            Console.WriteLine("Entry recorded.");
        }
    }
}
