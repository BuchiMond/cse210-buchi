using System;

public class MathAssignment : Assignment
{
    // Extra member variables for Math
    private string _textbookSection;
    private string _problems;

    // Constructor
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic) // Call base class constructor
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    // Method that shows the homework list
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}
