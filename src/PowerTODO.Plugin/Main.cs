using System.Collections.Generic;
using System.ComponentModel;
using Wox.Plugin;

public class Main : IPlugin
{
    // PowerToy 必须属性 PluginID, Name, Description
    // TODO: PluginID更新为 GUID
    public static string PluginID => "TodoPlugin";
    public string Name => "PowerTODO";
    public string Description => "A TODO manager for Powertoy Run";

    private ITodoDataService _todoService = null!;

    // Init 方法
    public void Init(PluginInitContext context)
    {
        // 改为在软件目录下新建目录
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string todoDataPath = Path.Combine(appDataPath, "PowerTODO");
        Directory.CreateDirectory(todoDataPath); // 确保目录存在防止空值
        _todoService = new TodoDataService(todoDataPath);
    }
    // Query 方法
    public List<Result> Query(Query query)
    {
        var todoContent = query.Search;
        // 构建结果列表
        var results = new List<Result>();

        // 触发词没有内容
        if (todoContent.Length == 0) { }
        // 创建代办事项（常驻）
        else
        {
            var result = new Result
            {
                Title = $"添加待办：{todoContent}",
                // IcoPath = "",
                Action = e =>
                {
                    _todoService.Add(todoContent);
                    return true; // 返回true表示操作成功，Run会关闭
                }
            };
            results.Add(result);
        }
        // TODO: 获取现有列表

        return results;

    }
}