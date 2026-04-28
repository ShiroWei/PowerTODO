using System.Text.Json;
using Wox.Plugin;

public class TodoDataService : ITodoDataService
{
    // TODO: 添加本地持久化开关
    
    private readonly string _dataFilePath;
    // 读取 todo 列表存储为变量
    private List<TodoItem>? _todos;

    private TodoFactory todoFactory = null!;

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

        if (keyword == null) return new List<Result>();
        var results = new List<Result>();
        foreach (var item in _todos ?? new List<TodoItem>())
        {
            if (item.Title.ToLower().Contains(keyword.ToLower()))
            {
                var result = todoFactory.listResult(item);
                results.Add(result);
            }
        }
        return results;
    }

    public Result Creat(string context)
    {
        var result = todoFactory.creatResult(context);
        return result;
    }

    public void Add(string context)
    {
        var todo = todoFactory.addTodoItem(context, _dataFilePath);
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