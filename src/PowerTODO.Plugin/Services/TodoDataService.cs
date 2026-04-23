using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class TodoDataService : ITodoDataService
{
    // 类的私有只读成员变量 依赖注入
    private readonly string _dataFilePath;
    // 读取后的 todo 列表存在变量
    private List<TodoItem> _todos;

    public TodoDataService(string dataDirectory)
    {
        _dataFilePath = Path.Combine(dataDirectory, "todo.json");
    }

    private void LoadTodos(){}
    private void SaveTodos(){}

    public List<TodoItem> List(string? keyword = null)
    {
        return new List<TodoItem>();
    }

    public void Add(string path)
    {
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }
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