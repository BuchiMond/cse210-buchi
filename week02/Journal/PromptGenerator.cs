using System;
using System.Collections.Generic;

namespace DailyJournal
{
    public class PromptGenerator
    {
        private List<string> _prompts;
        private Random _rng;

        public PromptGenerator()
        {
            _rng = new Random();
            _prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?",
                "One small win I had today was...",
                "What surprised me today?",
                "What am I grateful for today?"
            };
        }

        public string GetRandomPrompt()
        {
            if (_prompts.Count == 0) return "";
            int idx = _rng.Next(_prompts.Count);
            return _prompts[idx];
        }
    }
}
