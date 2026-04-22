using System.Collections.Generic;

public interface ITodoDataService
{
    List<TodoItem> List(string? keyword = null);
    void Add(string path);
}