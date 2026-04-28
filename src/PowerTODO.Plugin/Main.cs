using System.Collections.Generic;
using System.ComponentModel;
using Wox.Plugin;

public class Main : IPlugin
{
    // PowerToys 提供的公共 API
    public IPublicAPI? publicAPI;
    
    // PowerToy 必须属性 PluginID, Name, Description
    // TODO: PluginID更新为 GUID
    public static string PluginID => "TodoPlugin";
    public string Name => "PowerTODO";
    public string Description => "A TODO manager for Powertoy Run";


    private ITodoDataService _todoService = null!;

    // Init 方法
    public void Init(PluginInitContext context)
    {
        publicAPI = context.API;

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
            var result = _todoService.Creat(todoContent);
            results.Add(result);
        }
        // 获取现有列表
        var resultList = _todoService.List(todoContent);
        results.AddRange(resultList);

        return results;
    }
    
    // TODO: 切换主题和图标

}