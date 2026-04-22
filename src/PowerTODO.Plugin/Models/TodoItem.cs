using Wox.Plugin;

public class TodoItem
{
    public string Title { get; set; } = "";
    public string Path { get; set; } = "";
    public DateTime LastModified { get; set; }

    public Func<ActionContext, bool>? Action { get; set; }
}