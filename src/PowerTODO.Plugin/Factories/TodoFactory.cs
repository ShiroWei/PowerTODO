
using Wox.Plugin;

public class TodoFactory
{
    // 插件图标路径
    private string iconPath = "Images/PowerTODO_dark.png";
    public static TodoFactory Instance { get; } = new TodoFactory();
    private TodoFactory() { }

    public TodoItem addTodoItem(string context, string path)
    {
        var todo = new TodoItem
        {
            Id = Guid.NewGuid(),
            Title = context,
            Path = path,
            isDone = false,
            LastModified = DateTime.Now
        };
        return todo;
    }

    public Result listResult(TodoItem item)
    {
        var result = new Result
        {
            Title = item.Title,
            IcoPath = iconPath,
            Action = e =>
            {
                return TodoDataService.Instance.Delete(item); // 返回true表示操作成功，Run会关闭
            }
        };
        return result;
    }

    public Result creatResult(string context)
    {
        var result = new Result
        {
            Title = $"添加待办：{context}",
            // TODO: 添加提示和图标
            // SubTitle = "", 
            IcoPath = iconPath,
            Action = e =>
            {
                TodoDataService.Instance.Add(context);
                return true; // 返回true表示操作成功，Run会关闭
            }
        };
        return result;
    }
}