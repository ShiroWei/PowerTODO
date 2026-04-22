using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class TodoDataService : ITodoDataService
{
    // 类的私有只读成员变量 依赖注入
    private readonly string _todoPath;

    public TodoDataService(string todoPath)
    {
        // 依赖（即存储位置）从外部“注入”进来
        _todoPath = todoPath;
    }

    public List<TodoItem> List(string? keyword = null)
    {
        if (!Directory.Exists(_todoPath))
            return new List<TodoItem>();

        var files = Directory.GetFiles(_todoPath);

        var result = files.Select(f => new TodoItem
        {
            Title = Path.GetFileName(f),
            Path = f,
            LastModified = File.GetLastWriteTime(f)
        });

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            result = result.Where(x =>
                x.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        return result
            .OrderByDescending(x => x.LastModified)
            .Take(20)
            .ToList();
    }

    public void Add(string path)
    {
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }
    }
}