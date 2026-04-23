using System.Collections.Generic;

public interface ITodoDataService
{
    List<TodoItem> List(string? keyword = null);
    void Add(string todoContent);
    bool Delete(Guid id);
}