using System.Collections.Generic;
using Wox.Plugin;

public interface ITodoDataService
{
    List<Result> List(string? keyword = null);
    Result Creat(string context);
    void Add(string content);
    bool Delete(TodoItem item);
}