using System;
using System.Collections.Generic;
using System.IO;

namespace DailyJournal
{
    public class Journal
    {
        private List<Entry> _entries = new List<Entry>();

        public void AddEntry(Entry newEntry)
        {
            if (newEntry == null) return;
            _entries.Add(newEntry);
        }

        public void DisplayAll()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("No entries in the journal.");
                return;
            }

            Console.WriteLine("Journal entries:");
            Console.WriteLine();
            foreach (var e in _entries)
            {
                e.Display();
                Console.WriteLine();
            }
        }

        public void SaveToFile(string file)
        {
            if (string.IsNullOrWhiteSpace(file))
                throw new ArgumentException("Filename cannot be empty.");

            using (var writer = new StreamWriter(file))
            {
                foreach (var e in _entries)
                {
                    string line = $"{Escape(e.Date)}~|~{Escape(e.PromptText)}~|~{Escape(e.EntryText)}~|~{Escape(e.Mood)}";
                    writer.WriteLine(line);
                }
            }
        }

        public void LoadFromFile(string file)
        {
            if (string.IsNullOrWhiteSpace(file))
                throw new ArgumentException("Filename cannot be empty.");
            if (!File.Exists(file))
                throw new FileNotFoundException("File not found.", file);

            var newList = new List<Entry>();
            var lines = File.ReadAllLines(file);
            foreach (var line in lines)
            {
                var parts = line.Split(new string[] { "~|~" }, StringSplitOptions.None);
                if (parts.Length < 3) continue;

                string date = Unescape(parts[0]);
                string prompt = parts.Length > 1 ? Unescape(parts[1]) : "";
                string entryText = parts.Length > 2 ? Unescape(parts[2]) : "";
                string mood = parts.Length > 3 ? Unescape(parts[3]) : "";

                newList.Add(new Entry(date, prompt, entryText, mood));
            }

            _entries = newList;
        }

        private string Escape(string input)
        {
            if (input == null) return "";
            return input.Replace("\r", "\\r").Replace("\n", "\\n").Replace("~|~", "\\s");
        }

        private string Unescape(string input)
        {
            if (input == null) return "";
            return input.Replace("\\r", "\r").Replace("\\n", "\n").Replace("\\s", "~|~");
        }
    }
}
