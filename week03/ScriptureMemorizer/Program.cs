using System;
using System.Collections.Generic;

// I added a “Progress Bar” showing how much is hidden  This helps users know how far along they are in memorizing.

namespace ScriptureMemorizer
{
    // This class represents the reference (Book, Chapter, Verse or Verse Range)
    class Reference
    {
        private string _book;
        private int _chapter;
        private int _verseStart;
        private int _verseEnd;

        // Constructor for a single verse (e.g., "John 3:16")
        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _verseStart = verse;
            _verseEnd = verse; // same as start for a single verse
        }

        // Constructor for a verse range (e.g., "Proverbs 3:5-6")
        public Reference(string book, int chapter, int verseStart, int verseEnd)
        {
            _book = book;
            _chapter = chapter;
            _verseStart = verseStart;
            _verseEnd = verseEnd;
        }

        // Returns the reference in a nice string format
        public override string ToString()
        {
            if (_verseStart == _verseEnd)
            {
                return $"{_book} {_chapter}:{_verseStart}";
            }
            else
            {
                return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
            }
        }
    }

    // This class represents a single word in the scripture
    class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public bool IsHidden
        {
            get { return _isHidden; }
        }

        // Hide the word by marking it as hidden
        public void Hide()
        {
            _isHidden = true;
        }

        // Return either the word or underscores if it is hidden
        public string GetDisplayText()
        {
            if (_isHidden)
            {
                // Replace each character with an underscore
                return new string('_', _text.Length);
            }
            else
            {
                return _text;
            }
        }
    }

    // This class represents the scripture (reference + list of words)
    class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            _random = new Random();

            // Split the text into words by spaces
            string[] parts = text.Split(' ');

            foreach (string part in parts)
            {
                _words.Add(new Word(part));
            }
        }

        // Returns the full display (reference + text)
        public string GetDisplayText()
        {
            string referenceText = _reference.ToString();

            List<string> wordTexts = new List<string>();
            foreach (Word w in _words)
            {
                wordTexts.Add(w.GetDisplayText());
            }

            string scriptureText = string.Join(" ", wordTexts);

            return $"{referenceText}\n{scriptureText}";
        }

        // ✅ New: Get a simple progress text showing how much is hidden
        public string GetProgressText()
        {
            int hiddenCount = 0;

            foreach (Word w in _words)
            {
                if (w.IsHidden)
                {
                    hiddenCount++;
                }
            }

            double percentHidden = (double)hiddenCount / _words.Count * 100;

            return $"Progress: {hiddenCount}/{_words.Count} words hidden ({percentHidden:0}%)";
        }

        // Check if all words are hidden
        public bool AllWordsHidden()
        {
            foreach (Word w in _words)
            {
                if (!w.IsHidden)
                {
                    return false;
                }
            }
            return true;
        }

        // Hide a few random words that are not already hidden
        public void HideRandomWords(int numberToHide)
        {
            // Get indices of all words that are not hidden yet
            List<int> visibleIndices = new List<int>();
            for (int i = 0; i < _words.Count; i++)
            {
                if (!_words[i].IsHidden)
                {
                    visibleIndices.Add(i);
                }
            }

            // If there are no visible words left, we are done
            if (visibleIndices.Count == 0)
            {
                return;
            }

            // Hide up to numberToHide words (or as many as are left)
            int wordsToHide = Math.Min(numberToHide, visibleIndices.Count);

            for (int i = 0; i < wordsToHide; i++)
            {
                // Pick a random index from the visible list
                int randomPosition = _random.Next(visibleIndices.Count);
                int wordIndex = visibleIndices[randomPosition];

                // Hide that word
                _words[wordIndex].Hide();

                // Remove it from the visible list so we don't hide it again this round
                visibleIndices.RemoveAt(randomPosition);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example: Proverbs 3:5-6
            Reference reference = new Reference("Proverbs", 3, 5, 6);

            string text = "Trust in the Lord with all thine heart; " +
                          "and lean not unto thine own understanding. " +
                          "In all thy ways acknowledge him, and he shall direct thy paths.";

            Scripture scripture = new Scripture(reference, text);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Scripture Memorizer ===\n");
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();

                // Show progress bar text
                Console.WriteLine(scripture.GetProgressText());
                Console.WriteLine();

                // If everything is hidden, end the program
                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("All the words are now hidden. Great job practicing!");
                    break;
                }

                Console.WriteLine("Press ENTER to hide more words, or type 'quit' to finish.");
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) &&
                    input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                // Hide a few random words each time
                scripture.HideRandomWords(3);
            }

            Console.WriteLine("\nPress any key to close...");
            Console.ReadKey();
        }
    }
}
