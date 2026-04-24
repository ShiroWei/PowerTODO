using System.Collections.Generic;
using Wox.Plugin;

public interface ITodoDataService
{
    List<Result> List(string? keyword = null);
    void Add(string todoContent);
    bool Delete(Guid id);
}