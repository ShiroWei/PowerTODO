using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Wox.Plugin;

public class TodoDataService : ITodoDataService
{
    // TODO: 添加本地持久化开关
    // 类的私有只读成员变量 依赖注入
    private readonly string _dataFilePath;
    // 读取 todo 列表存储为变量
    private List<TodoItem>? _todos;
    // 插件图标路径
    private string iconPath = "Images/PowerTODO_dark.png";

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

    public List<Result> List(string? keyword = null)
    {
        var results = new List<Result>();
        if (keyword != null)
        {
            foreach (var item in _todos ?? new List<TodoItem>())
            {
                if (item.Title.ToLower().Contains(keyword.ToLower()))
                {
                    var result = new Result
                    {
                        Title = item.Title,
                        IcoPath = iconPath,
                        Action = e =>
                        {
                            return Delete(item); // 返回true表示操作成功，Run会关闭
                        }
                    };
                    results.Add(result);
                }
            }
        }
        return results;
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

    public bool Delete(TodoItem item)
    {
        _todos?.Remove(item);
        return true;
    }
}