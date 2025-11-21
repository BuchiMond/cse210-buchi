using System;
using System.Collections.Generic;

public class Video
{
    // Basic video info
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }

    // List of comments for this video
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

    // Add a comment to the video
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Return the number of comments
    public int GetCommentCount()
    {
        return _comments.Count;
    }

    // Return all comments (read-only)
    public List<Comment> GetComments()
    {
        return _comments;
    }
}
