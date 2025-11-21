using System;

public class Comment
{
    // Person who made the comment
    public string CommenterName { get; set; }

    // Text of the comment
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}
