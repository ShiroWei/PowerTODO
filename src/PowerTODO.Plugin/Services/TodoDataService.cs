using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

public class TodoDataService : ITodoDataService
{
    // 类的私有只读成员变量 依赖注入
    private readonly string _dataFilePath;
    // 读取 todo 列表存储为变量
    private List<TodoItem>? _todos;

    public TodoDataService(string dataDirectory)
    {
        // Path.Combine 实现跨平台兼容性
        _dataFilePath = Path.Combine(dataDirectory, "todo.json");
        LoadTodos();
    }

    private void LoadTodos()
    {
        if (File.Exists(_dataFilePath))
        {
            var json = File.ReadAllText(_dataFilePath);
            // 序列化后结果可能为 null 使用空合并运算符（??）保证后续操作合法
            _todos = JsonSerializer.Deserialize<List<TodoItem>>(json) ?? new List<TodoItem>();
        }
        else
        {
            _todos = new List<TodoItem>();
        }
    }
    private void SaveTodos()
    {
        var json = JsonSerializer.Serialize(_todos);
        File.WriteAllText(_dataFilePath, json);
    }

    public List<TodoItem> List(string? keyword = null)
    {
        return new List<TodoItem>();
    }

    public void Add(string context)
    {
        var todo = new TodoItem
        {
            Id = Guid.NewGuid(),
            Title = context,
            Path = _dataFilePath,
            LastModified = DateTime.Now
        };
        // 空条件运算符防止 _todos 为 null 报 warning
        _todos?.Add(todo);
        SaveTodos();
    }

    public bool Delete(Guid id)
    {
        bool isTodo = false;
        if (isTodo)
        {
            return true;
        }
        return false;
    }
}