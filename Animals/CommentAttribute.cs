namespace Animals;

public class CommentAttribute : Attribute
{
    public string Comment;

    public CommentAttribute(string comment)
    {
        Comment = comment;
    }
}